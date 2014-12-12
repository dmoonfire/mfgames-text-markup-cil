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
        /// Internal state flag to determine if we are currently in a heading.
        /// </summary>
        private bool inHeading;

        /// <summary>
        /// </summary>
        private bool inItalic;

        /// <summary>
        /// Internal state flag to determine if we are inside a paragraph.
        /// </summary>
        private bool inParagraph;

        /// <summary>
        /// </summary>
        private string originaLine;

        /// <summary>
        /// </summary>
        private bool inContent;

        /// <summary>
        /// </summary>
        private List<BlockReaderBase> availableBlockReaders;

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
                    new HorizontalRuleReaderBase(), 
                    new BlockquoteBlockReader(), 
                    new ParagraphBlockReader(), 
                };
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
                if (!this.inContent)
                {
                    this.inContent = true;
                    this.elementType = MarkupElementType.BeginContent;
                    return true;
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
        /// <returns>
        /// </returns>
        private BlockReaderBase GetNextBlockReader()
        {
            // Go through the list of block readers until we find one that
            // can be used.
            string line = this.Input.CurrentLine;

            foreach (BlockReaderBase blockReader in this.availableBlockReaders)
            {
                if (blockReader.CanRead(line))
                {
                    blockReader.Reset();
                    return blockReader;
                }
            }

            // If we go this far and we can't find out, there is a problem.
            return null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool isDisposing)
        {
        }

#if REMOVED
    
    
    
    // <summary>
    // Checks for metadata in the input stream.
    // </summary>
    /// <returns>Returns true if there is metadata, otherwise false.</returns>
        private bool CheckMetadata()
        {
            // Make sure we allow metadata in the first place.
            if (this.Options.AllowMetadata)
            {
                // Check the first line for a YAML header.
                if (this.currentLine == "---")
                {
                    // We are in a YAML header.
                    return true;
                }
            }

            // Otherwise, go directly to content.
            return false;
        }

        /// <summary>
        /// Retrieves the heading level for the ATX header.
        /// </summary>
        /// <returns>
        /// </returns>
        private int GetAtxHeadingLevel()
        {
            // Parse the current line.
            string line = this.currentLine.Trim();

            for (int index = 0; index < line.Length; index++)
            {
                if (line[index] != '#')
                {
                    return index;
                }
            }

            // If we got this far, then there are non-ATX-header elements, so it is simply
            // the length of the line.
            return line.Length;
        }

        /// <summary>
        /// Identifies the current type of content of the line.
        /// </summary>
        /// <returns>
        /// The content type of the current line.
        /// </returns>
        private MarkdownBlockType GetBlockType()
        {
            bool isBeginningOfLine = this.originaLine == this.currentLine;
            return this.GetBlockType(this.currentLine, isBeginningOfLine);
        }

        /// <summary>
        /// Identifies the current type of content of the line.
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <param name="isBeginningOfLine">
        /// </param>
        /// <returns>
        /// The content type of the current line.
        /// </returns>
        private MarkdownBlockType GetBlockType(
            string line, 
            bool isBeginningOfLine)
        {
            // If we have a blank line left, then this is just whitespace.
            int trimmedLength = line.Trim().Length;

            if (trimmedLength == 0)
            {
                // Return that we are nothing but whitespace.
                return MarkdownBlockType.Whitespace;
            }

            // Check for a horizontal rule.
            if (this.IsHorizontalRule(this.currentLine))
            {
                return MarkdownBlockType.HorizontalRule;
            }

            if (this.IsAtxHeader(this.currentLine))
            {
                return MarkdownBlockType.AtxHeading;
            }

            // Check to see if this is a setext header.
            string nextLine = this.Reader.PeekLine(0);

            if (nextLine != null
                && CommonMarkSpecification.SetextHeaderRegex.IsMatch(nextLine))
            {
                // The next line appears to be a header, so check this line.
                if (line.Trim().Length > 0)
                {
                    // We have at least one line.
                    return MarkdownBlockType.SetextHeading;
                }
            }

            // If we are in the beginning of the line, then we have some additional checks.
            if (isBeginningOfLine)
            {
                // Check for blockquotes.
                if (line.StartsWith(">"))
                {
                    return MarkdownBlockType.Blockquote;
                }

                // Check to see if this is an indented region.
                if (line.StartsWith("    ") ||
                    line.StartsWith("\t"))
                {
                    return MarkdownBlockType.IndentedCodeBlock;
                }
            }

            // Everything else is a paragraph.
            return MarkdownBlockType.Paragraph;
        }

        /// <summary>
        /// Retrieves the prefix for the code block, either tabs or spaces.
        /// </summary>
        /// <returns>
        /// </returns>
        private string GetIndentedCodeBlockPrefix()
        {
            if (this.currentLine.StartsWith("    "))
            {
                return "    ";
            }

            if (this.currentLine.StartsWith("\t"))
            {
                return "\t";
            }

            throw new Exception(
                "Cannot identify indent code block prefix: " + this.currentLine
                    + ".");
        }

        /// <summary>
        /// Retrieves the heading level for the Setext header.
        /// </summary>
        /// <returns>
        /// </returns>
        private int GetSetextHeadingLevel()
        {
            // Parse the current line.
            string line = this.Reader.PeekLine(0).Trim();

            switch (line[0])
            {
                case '=':
                    return 1;

                case '-':
                    return 2;

                default:
                    throw new Exception(
                        "Could not identify setext header level from: "
                            + line);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="controlType">
        /// </param>
        /// <param name="controlText">
        /// </param>
        /// <param name="remainingText">
        /// </param>
        /// <returns>
        /// </returns>
        private bool GetTextControlType(
            out MarkdownControlType controlType, 
            out string controlText, 
            out string remainingText)
        {
            if (this.currentLine.StartsWith("**"))
            {
                controlType = MarkdownControlType.Bold;
                controlText = "**";
                remainingText = this.currentLine.Substring(2);
                return true;
            }

            if (this.currentLine.StartsWith("*")
                || this.currentLine.StartsWith("_"))
            {
                controlType = MarkdownControlType.Italic;
                controlText = this.currentLine[0].ToString();
                remainingText = this.currentLine.Substring(1);
                return true;
            }

            if (this.currentLine.StartsWith("`"))
            {
                controlType = MarkdownControlType.CodeSpan;
                controlText = "`";
                remainingText = this.currentLine.Substring(1);
                return true;
            }

            // If we got this far, we can't handle it.
            controlType = MarkdownControlType.Unknown;
            controlText = null;
            remainingText = null;
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <returns>
        /// </returns>
        private bool IsAtxHeader(string line)
        {
            // If we have a null, then it isn't.
            if (string.IsNullOrEmpty(line))
            {
                return false;
            }

            // Check to see if this is an ATX header.
            bool isAtxHeader = CommonMarkSpecification.AtxHeaderRegex
                .IsMatch(line);

            return isAtxHeader;
        }

        /// <summary>
        /// </summary>
        /// <param name="input">
        /// </param>
        /// <returns>
        /// </returns>
        private bool IsHorizontalRule(string input)
        {
            // If we are blank, then it is never a rule.
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Use the regular expression to determine if we have a rule.
            bool isRule =
                CommonMarkSpecification.HorizontalRuleRegex.IsMatch(input);
            return isRule;
        }

        /// <summary>
        /// Attempts to process an anchor .
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessAnchor()
        {
            // Check to see if we start with an end anchor.
            if (this.currentLine.StartsWith("</a>"))
            {
                this.elementType = MarkupElementType.EndAnchor;
                this.currentLine = this.currentLine.Substring(4);
                return true;
            }

            // If we don't have a match, then we don't do anything.
            Match match =
                CommonMarkSpecification.AnchorRegex.Match(this.currentLine);

            if (!match.Success)
            {
                return false;
            }

            // We need to trim off the current line and then process the anchor.
            string value = match.Groups[0].Value;
            this.currentLine = this.currentLine.Substring(value.Length);

            // We have a match, so indicate that so we can recurse.
            this.elementType = MarkupElementType.BeginAnchor;
            return true;
        }

        /// <summary>
        /// Processes the buffer after the BeginBlockquote event.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBeginBlockquote()
        {
            this.inBlockquote = true;
            return this.ProcessBlock();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessBeginBold()
        {
            this.inBold = true;
            return this.ProcessText();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessBeginCodeBlock()
        {
            // Set that we are in a codeblock.
            this.inCodeBlock = true;

            // We have no clue at this point.
            return this.ProcessText();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessBeginCodeSpan()
        {
            this.inCodeSpan = true;
            return this.ProcessText();
        }

        /// <summary>
        /// Processes the buffer after the BeginHeader event.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBeginHeader()
        {
            // Save that we are in the heading.
            this.inHeading = true;

            // Figure out the content type.
            MarkdownBlockType blockType = this.GetBlockType();

            switch (blockType)
            {
                case MarkdownBlockType.AtxHeading:

                    // Remove the leading and trail space and hash marks. But only in a
                    // specific order to prevent removing too much.
                    var removeLeader = new Regex(@"^\s*\#+\s*");
                    var removeTrailing = new Regex(@"(?:\s+\#+)\s*$");
                    var removeEntire = new Regex(@"^\s*\#+\s*$");

                    this.currentLine = removeLeader.Replace(
                        this.currentLine, string.Empty);
                    this.currentLine = removeEntire.Replace(
                        this.currentLine, string.Empty);
                    this.currentLine = removeTrailing.Replace(
                        this.currentLine, string.Empty);
                    return this.ProcessContent();

                case MarkdownBlockType.SetextHeading:

                    // Pop off the next line, which is the underline.
                    this.Reader.ReadLine();

                    // We don't have to change the line since that is the header text.
                    // So just move into the content processing.
                    return this.ProcessContent();

                default:
                    throw new InvalidOperationException(
                        "Cannot process BeginHeader with content type of "
                            + blockType + ".");
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessBeginItalic()
        {
            this.inItalic = true;
            return this.ProcessText();
        }

        /// <summary>
        /// Processes the state after the BeginMetadata.
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessBeginMetadata()
        {
            // Right now, we only support YAML headers. Grab the first "---" and then
            // loop through until we find the last one.
            var buffer = new StringBuilder();

            buffer.AppendLine(this.currentLine);

            do
            {
                // Grab the next line.
                this.currentLine = this.Reader.ReadLine();
                buffer.AppendLine(this.currentLine);
            }
            while (this.currentLine != "---");

            // Gather up the elements and set it.
            this.currentLine = null;
            this.elementType = MarkupElementType.YamlMetadata;
            this.Text = buffer.ToString();
            return true;
        }

        /// <summary>
        /// Processes the buffer after the BeginParagraph event.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBeginParagraph()
        {
            this.inParagraph = true;
            return this.ProcessContent();
        }

        /// <summary>
        /// Processes the content and returns the resulting Markup type.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBlock()
        {
            // Ignore blank lines at this point.
            while (this.currentLine != null && this.currentLine.Trim()
                .Length == 0)
            {
                this.originaLine = this.Reader.ReadLine();
                this.currentLine = this.originaLine;
            }

            // If the line is a null, then we can't do anything.
            if (this.currentLine == null)
            {
                this.elementType = MarkupElementType.EndContent;
                return true;
            }

            // Figure out what the next line is.
            MarkdownBlockType type = this.GetBlockType();

            switch (type)
            {
                case MarkdownBlockType.Whitespace:

                    // Set up the state for the whitespace.
                    this.elementType = MarkupElementType.NewLine;
                    this.Text = this.currentLine;

                    // Clear out the line so we read the next.
                    this.currentLine = null;

                    // Return true because we're done.
                    return true;

                case MarkdownBlockType.Blockquote:

                    // Update our state at the moment.
                    this.elementType = MarkupElementType.BeginBlockquote;
                    this.currentLine = this.currentLine.Substring(1)
                        .TrimStart();

                    // If we are already in a blockquote, then skip it.
                    if (this.inBlockquote)
                    {
                        return this.ProcessBlock();
                    }

                    return true;

                case MarkdownBlockType.Paragraph:
                    this.elementType = MarkupElementType.BeginParagraph;
                    return true;

                case MarkdownBlockType.AtxHeading:
                    this.elementType = MarkupElementType.BeginHeader;
                    this.Level = this.GetAtxHeadingLevel();
                    this.currentHeadingLevel = this.Level;
                    return true;

                case MarkdownBlockType.SetextHeading:
                    this.elementType = MarkupElementType.BeginHeader;
                    this.Level = this.GetSetextHeadingLevel();
                    this.currentHeadingLevel = this.Level;
                    return true;

                case MarkdownBlockType.HorizontalRule:
                    this.elementType = MarkupElementType.HorizontalRule;
                    this.currentLine = null;
                    return true;

                case MarkdownBlockType.IndentedCodeBlock:
                    this.elementType = MarkupElementType.BeginCodeBlock;
                    this.codeBlockPrefix = this.GetIndentedCodeBlockPrefix();
                    this.currentLine =
                        this.currentLine.Substring(this.codeBlockPrefix.Length);
                    return true;

                case MarkdownBlockType.FencedCodeBlock:
                    throw new Exception("Cannto handle fenced code blocks.");

                default:
                    return false;
            }
        }

        /// <summary>
        /// Processes textual content inside a paragraph or heading.
        /// </summary>
        /// <returns>True if we've processed the paragraph properly.</returns>
        private bool ProcessContent()
        {
            return this.ProcessText();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessEndBlockquote()
        {
            // Remove the blockquote indicator.
            this.inBlockquote = false;

            // If we have a blank line, then we're done.
            if (this.currentLine == null)
            {
                this.elementType = MarkupElementType.EndContent;
                return true;
            }

            // Otherwise, process it as a block.
            return this.ProcessBlock();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessEndBold()
        {
            this.inBold = false;
            return this.ProcessText();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessEndCodeBlock()
        {
            this.inCodeBlock = false;
            return this.ProcessBlock();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessEndCodeSpan()
        {
            this.inCodeSpan = false;
            return this.ProcessText();
        }

        /// <summary>
        /// Processes the input after a EndHeader element.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessEndHeader()
        {
            // Clear the paragraph flag.
            this.inHeading = false;

            // If we don't have a current line.
            if (this.currentLine == null)
            {
                if (this.inBlockquote)
                {
                    this.elementType = MarkupElementType.EndBlockquote;
                }
                else
                {
                    this.elementType = MarkupElementType.EndContent;
                }

                return true;
            }

            // Pass it into the begin content.
            return this.ProcessBlock();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessEndItalic()
        {
            this.inItalic = false;
            return this.ProcessText();
        }

        /// <summary>
        /// Processes the input after a EndParagraph element.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessEndParagraph()
        {
            // Clear the paragraph flag.
            this.inParagraph = false;

            // Advance to the next non-blank line.
            while (this.currentLine != null && (this.currentLine.Trim()
                .Length == 0 || this.currentLine.Trim() == ">"))
            {
                this.originaLine = this.Reader.ReadLine();
                this.currentLine = this.originaLine;
            }

            // If we don't have a current line.
            if (this.currentLine == null)
            {
                if (this.inBlockquote)
                {
                    this.elementType = MarkupElementType.EndBlockquote;
                }
                else
                {
                    this.elementType = MarkupElementType.EndContent;
                }

                return true;
            }

            // Pass it into the begin content.
            return this.ProcessBlock();
        }

        /// <summary>
        /// Checks for non-significant characters. If they exist, sets the element
        /// type and text and returns true.
        /// </summary>
        /// <returns>True if there are non-significant, otherwise false.</returns>
        private bool ProcessNonSignificant()
        {
            // Grab the next non-significant characters from the line.
            string nonSignificant = this.GetNonSignificant();

            // If we haven't found anything, then the entire line counts.
            if (nonSignificant != null)
            {
                // Set up the state elements.
                this.elementType = MarkupElementType.Text;
                this.Text = this.UnescapeString(
                    nonSignificant, 
                    this.currentLine == this.originaLine);

                // Remove the text we just added, but keep a blank line so we can
                // process the next element.
                this.currentLine =
                    this.currentLine.Substring(nonSignificant.Length);

                // If the current line is blank, then we trim the end of our output.
                if (this.currentLine.Length == 0 && !this.inCodeBlock)
                {
                    this.Text = this.Text.TrimEnd();
                }

                // Indicate we have successful processed it.
                return true;
            }

            return false;
        }

        /// <summary>
        /// Processes the input after a Text element.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessText()
        {
            // Check to see if we have remaining text in the current line.
            if (this.currentLine.Length == 0)
            {
                // We are at the end of the line. This is a paragraph break if we don't have
                // a line after this one or we have the Options.TreatNewlinesAsBreaks. Otherwise,
                // we are just going to continue the paragraph.
                bool isEndOfBuffer = this.Reader.PeekLine(0) == null;
                bool isBlankLine = !isEndOfBuffer && this.Reader.PeekLine(0)
                    .Trim()
                    .Length == 0;
                bool isBlankBlockquote = !isEndOfBuffer
                    && this.Reader.PeekLine(0)
                        .Trim() == ">";
                bool isNextHeader = this.IsAtxHeader(this.Reader.PeekLine(0));
                bool isNextBreak = this.IsHorizontalRule(
                    this.Reader.PeekLine(0));

                if (isEndOfBuffer || isBlankLine || isBlankBlockquote
                    || isNextHeader || isNextBreak
                    || this.Options.TreatNewLinesAsBreaks
                    || this.inCodeBlock)
                {
                    // End the paragraph or heading to get into our endgame.
                    this.currentLine = null;

                    if (this.inParagraph)
                    {
                        this.elementType = MarkupElementType.EndParagraph;
                    }
                    else if (this.inHeading)
                    {
                        this.elementType = MarkupElementType.EndHeader;
                        this.Level = this.currentHeadingLevel;
                    }
                    else if (this.inCodeBlock)
                    {
                        // Record it as whitespace and move on since code blocks always
                        // end with a newline.
                        this.Text = Environment.NewLine;
                        this.currentLine = null;
                        this.elementType = MarkupElementType.NewLine;
                    }
                    else if (isEndOfBuffer)
                    {
                        this.elementType = MarkupElementType.EndContent;
                    }
                    else
                    {
                        throw new Exception(
                            "We are at the end of the text but in neither a heading or a paragraph.");
                    }

                    // Finish processing.
                    return true;
                }

                // If we have a blank line and we are in a heading, then
                // stop the header.
                if (this.inHeading)
                {
                    this.elementType = MarkupElementType.EndHeader;
                    this.Level = this.currentHeadingLevel;
                    return true;
                }

                // Record it as whitespace and move on.
                this.Text = Environment.NewLine;
                this.currentLine = null;
                this.elementType = MarkupElementType.NewLine;

                // We are done processing this one.
                return true;
            }

            // If we have non-significant characters, then process that.
            if (this.ProcessNonSignificant())
            {
                return true;
            }

            // Anything left is significant control elements, so pull them out.
            MarkdownControlType controlType;
            string controlText;
            string remainingText;
            bool isControlText = this.GetTextControlType(
                out controlType, 
                out controlText, 
                out remainingText);

            if (isControlText)
            {
                this.currentLine = remainingText;

                switch (controlType)
                {
                    case MarkdownControlType.Bold:
                        this.elementType = this.inBold
                            ? MarkupElementType.EndBold
                            : MarkupElementType.BeginBold;
                        break;
                    case MarkdownControlType.Italic:
                        this.elementType = this.inItalic
                            ? MarkupElementType.EndItalic
                            : MarkupElementType.BeginItalic;
                        break;
                    case MarkdownControlType.CodeSpan:
                        this.elementType = this.inCodeSpan
                            ? MarkupElementType.EndCodeSpan
                            : MarkupElementType.BeginCodeSpan;
                        break;
                    default:
                        throw new Exception(
                            "Unknown control type: " + controlType);
                }

                // We are done processing this one.
                return true;
            }

            // See if we have an anchor.
            bool anchorMatches = this.ProcessAnchor();

            if (anchorMatches)
            {
                return true;
            }

            // No clue, throw an exception.
            throw new Exception("Panic some more.");
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ProcessWhitespace()
        {
            // If we are in a code block, we have some special rules.
            if (this.inCodeBlock)
            {
                // If we have a null line, we have to end the code block.
                if (this.currentLine == null)
                {
                    this.elementType = MarkupElementType.EndCodeBlock;
                    return true;
                }

                // Otherwise, determine if we are still in a code block.
                if (this.currentLine.StartsWith(this.codeBlockPrefix))
                {
                    this.currentLine =
                        this.currentLine.Substring(this.codeBlockPrefix.Length);
                }
            }

            // If we have a null, then we are done processing.
            if (this.currentLine == null)
            {
                this.elementType = MarkupElementType.EndContent;
                return true;
            }

            // Process the rest of the text.
            return this.ProcessText();
        }

        /// <summary>
        /// </summary>
        /// <param name="input">
        /// </param>
        /// <param name="isLineBeginning">
        /// </param>
        /// <returns>
        /// </returns>
        private string UnescapeString(
            string input, 
            bool isLineBeginning)
        {
            // See if we need to trim the beginning.
            if (!this.inCodeBlock && isLineBeginning)
            {
                input = input.TrimStart();
            }

            // Pull out the escaped characters.
            var buffer = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c != '\\')
                {
                    buffer.Append(c);
                }
            }

            // Return the resulting string.
            return buffer.ToString();
        }

#endif

        #endregion
    }
}