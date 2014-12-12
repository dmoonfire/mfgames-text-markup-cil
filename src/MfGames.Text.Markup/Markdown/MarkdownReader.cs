// <copyright file="MarkdownReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Implements a Markdown reader that parses various flavors of Markdown based
    /// on configuration settings.
    /// </summary>
    public class MarkdownReader : MarkupReader, 
        IDisposable
    {
        #region Fields

        /// <summary>
        /// </summary>
        private readonly List<BlockReaderBase> blockReaders;

        /// <summary>
        /// </summary>
        private List<BlockReaderBase> availableBlockReaders;

        /// <summary>
        /// </summary>
        private string codeBlockPrefix;

        /// <summary>
        /// Contains the current heading level being processed. Since headings cannot be
        /// nested, this is used to report the end of the heading.
        /// </summary>
        private int currentHeadingLevel;

        /// <summary>
        /// </summary>
        private string currentLine;

        /// <summary>
        /// Contains the internal state.
        /// </summary>
        private MarkupElementType elementType;

        /// <summary>
        /// </summary>
        private bool inBlockquote;

        /// <summary>
        /// </summary>
        private bool inBold;

        /// <summary>
        /// </summary>
        private bool inCodeBlock;

        /// <summary>
        /// </summary>
        private bool inCodeSpan;

        /// <summary>
        /// </summary>
        private bool inContent;

        /// <summary>
        /// Internal state flag to determine if we are currently in a heading.
        /// </summary>
        private bool inHeading;

        /// <summary>
        /// </summary>
        private bool inItalic;

        /// <summary>
        /// </summary>
        private bool inMetadata;

        /// <summary>
        /// Internal state flag to determine if we are inside a paragraph.
        /// </summary>
        private bool inParagraph;

        /// <summary>
        /// </summary>
        private string originaLine;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownReader"/> class.
        /// </summary>
        /// <param name="lines">
        /// The lines.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        public MarkdownReader(
            string[] lines, 
            MarkdownOptions options = null)
            : base(lines)
        {
            this.Options = options ?? MarkdownOptions.DefaultOptions;
            this.blockReaders = new List<BlockReaderBase>();
            this.CreateAvailableBlockReaders();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownReader"/> class.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        public MarkdownReader(
            TextReader reader, 
            MarkdownOptions options = null)
            : base(reader)
        {
            this.Options = options ?? MarkdownOptions.DefaultOptions;
            this.blockReaders = new List<BlockReaderBase>();
            this.CreateAvailableBlockReaders();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        /// <value>
        /// The type of the element.
        /// </value>
        public override MarkupElementType ElementType
        {
            get
            {
                return this.elementType;
            }
        }

        /// <summary>
        /// Gets the options associated with the reader.
        /// </summary>
        public MarkdownOptions Options { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// </summary>
        protected BlockReaderBase CurrentBlockReader
        {
            get
            {
                return this.blockReaders[0];
            }
        }

        /// <summary>
        /// </summary>
        protected bool HasCurrentBlockReader
        {
            get
            {
                return this.blockReaders.Count > 0;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Retrieves the leading non-signficant characters characters from the beginning
        /// of the current line.
        /// </summary>
        /// <returns>The significant characters or null if there are none.</returns>
        public string GetNonSignificant()
        {
            return this.GetNonSignificant(this.currentLine);
        }

        /// <summary>
        /// Retrieves the leading non-signficant characters characters from the beginning
        /// of the lines.
        /// </summary>
        /// <param name="line">
        /// The line to process.
        /// </param>
        /// <returns>
        /// The significant characters or null if there are none.
        /// </returns>
        public string GetNonSignificant(string line)
        {
            // Go through the current line until we get to the end or we find a significant
            // element to process.
            bool found = false;
            int index;

            for (index = 0; index < line.Length; index++)
            {
                // Escape characters always advance to the next one.
                if (line[index] == '\\')
                {
                    index++;
                    continue;
                }

                // Look for characters that indicate special processing.
                switch (line[index])
                {
                    case '*':
                    case '`':
                    case '_':
                    case '<':
                        found = true;
                        break;
                }

                if (found)
                {
                    break;
                }
            }

            // If not found, return the whole line.
            if (!found)
            {
                return line;
            }

            // If the index is 0, then the significant characters are immediate. Return null
            // to indicate we have none.
            if (index == 0)
            {
                return null;
            }

            // Break out the string until that point.
            string fragment = this.currentLine.Substring(
                0, 
                index);

            return fragment;
        }

        /// <summary>
        /// Reads the next significant element from the marked-up file.
        /// </summary>
        /// <returns>
        /// True if there is another element available.
        /// </returns>
        public override bool Read()
        {
            // Reset the state.
            this.ResetState();

            // If we have an unknown state, we have to start with the document.
            if (this.ElementType == MarkupElementType.Unknown)
            {
                this.elementType = MarkupElementType.BeginDocument;
                return true;
            }

            // Figure out if we already have a block reader current parsing the line.
            // If we do, then just pass it into that block reader.
            while (this.HasCurrentBlockReader)
            {
                // Pull out the current block reader and read it.
                BlockReaderBase currentBlockReader = this.CurrentBlockReader;
                BlockReadStatus status = currentBlockReader.Read(
                    this, this.Input);

                if (status == BlockReadStatus.Continue)
                {
                    // The reader is still processing the line, so return
                    // true to say the reader has been updated and we'll go
                    // back into this reader with the next loop.
                    return true;
                }

                // If we got this far, then the block reader is done. We
                // remove it from the stack and try again.
                this.blockReaders.RemoveAt(0);
            }

            // If we got this far and we are at the end of the buffer,
            // we go into our end file pattern.
            if (this.Input.IsEndOfBuffer)
            {
                switch (this.elementType)
                {
                    case MarkupElementType.EndContent:
                        this.elementType = MarkupElementType.EndDocument;
                        return true;

                    case MarkupElementType.EndDocument:
                        return false;

                    default:
                        this.elementType = MarkupElementType.EndContent;
                        return true;
                }
            }

            // We ran out of block readers, so we need to find a new one.
            // To process the text.
            BlockReaderBase blockReader = this.GetNextBlockReader();

            if (blockReader != null)
            {
                // Add it to the current list.
                this.blockReaders.Insert(0, blockReader);

                // Check to see if we need the begin content element.
                if (blockReader.BlockType == MarkdownBlockType.Metadata)
                {
                    if (!this.inMetadata)
                    {
                        this.inMetadata = true;
                        this.elementType = MarkupElementType.BeginMetadata;
                        return true;
                    }
                }

                if (blockReader.BlockType == MarkdownBlockType.Content)
                {
                    if (!this.inContent)
                    {
                        this.inContent = true;
                        this.elementType = MarkupElementType.BeginContent;
                        return true;
                    }
                }

                // Parse the results.
                BlockReadStatus status = blockReader.Read(this, this.Input);

                if (status == BlockReadStatus.Continue)
                {
                    return true;
                }

                // If we go here, something is seriously wrong with the
                // system. We just identified the block that needs to be
                // read and it won't read anything.
                throw new Exception("Block reader cannot read initial block.");
            }

            // If all else fails, advance the line until we find something.
            this.Input.ReadNext();
            return this.Read();
        }

        /// <summary>
        /// </summary>
        /// <param name="newElementType">
        /// </param>
        /// <param name="newLevel">
        /// </param>
        public void SetState(
            MarkupElementType newElementType, 
            int newLevel)
        {
            this.SetState(newElementType);
            this.Level = newLevel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="newElementType">
        /// </param>
        internal void SetState(MarkupElementType newElementType)
        {
            this.elementType = newElementType;
        }

        /// <summary>
        /// </summary>
        /// <param name="newElementType">
        /// </param>
        /// <param name="newText">
        /// </param>
        internal void SetState(
            MarkupElementType newElementType, 
            string newText)
        {
            this.SetState(newElementType);
            this.Text = newText;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool isDisposing)
        {
        }

        /// <summary>
        /// Constructs the internal list of block readers we use. This is done
        /// to avoid memory pressure of processing a large number of paragraphs
        /// since most of the data can be reused from call to call.
        /// </summary>
        private void CreateAvailableBlockReaders()
        {
            // The order this is created is important for precedence. The 
            // first item that applies to a given block type will be used.
            this.availableBlockReaders = new List<BlockReaderBase>
                {
                    new YamlConfigurationBlockReader(), 
                    new HorizontalRuleReaderBase(), 
                    new AtxHeaderBlockReader(), 
                    new SetextHeaderBlockReader(), 
                    new BlockquoteBlockReader(), 
                    new ParagraphBlockReader(), 
                };
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private BlockReaderBase GetNextBlockReader()
        {
            // Go through the list of block readers until we find one that
            // can be used.
            foreach (BlockReaderBase blockReader in this.availableBlockReaders)
            {
                if (blockReader.CanRead(this, this.Input))
                {
                    blockReader.Reset();
                    return blockReader;
                }
            }

            // If we go this far and we can't find out, there is a problem.
            return null;
        }

        #endregion
    }
}