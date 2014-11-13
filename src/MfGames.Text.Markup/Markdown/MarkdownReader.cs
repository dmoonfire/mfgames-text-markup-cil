﻿// <copyright file="MarkdownReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Implements a Markdown reader that parses various flavors of Markdown based
    /// on configuration settings.
    /// </summary>
    public class MarkdownReader : MarkupReader, 
        IDisposable
    {
        #region Static Fields

        /// <summary>
        /// <para>
        /// Contains the regular expression for identifying an ATX-style header. The first
        /// matched group is the series of # characters. The second is the header contents
        /// itself.
        /// </para><para>
        /// CommonMark 0.12 § 4.2: An ATX header consists of a string of characters, parsed as
        /// inline content, between an opening sequence of 1–6 unescaped # characters and an
        /// optional closing sequence of any number of # characters. The opening sequence of #
        /// characters cannot be followed directly by a non-space character. The optional
        /// closing sequence of #s must be preceded by a space and may be followed by spaces
        /// only. The opening # character may be indented 0-3 spaces. The raw contents of the
        /// header are stripped of leading and trailing spaces before being parsed as inline
        /// content. The header level is equal to the number of # characters in the opening
        /// sequence.
        /// </para>
        /// </summary>
        public static readonly Regex AtxHeaderRegex =
            new Regex(@"^ {0,3}(#{1,6})(?:\s+\#+|\s+(.+?)(?:\s+\#+)?)?\s*$");

        #endregion

        #region Fields

        /// <summary>
        /// </summary>
        private string currentLine;

        /// <summary>
        /// Contains the internal state.
        /// </summary>
        private MarkupElementType elementType;

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
                }
            }

            // If not found, return the whole line.
            if (!found)
            {
                return line;
            }

            // Otherwise, blow up.
            throw new Exception("I can't handle change.");
        }

        /// <summary>
        /// Reads the next significant element from the marked-up file.
        /// </summary>
        /// <returns>
        /// True if there is another element available.
        /// </returns>
        public override bool Read()
        {
            // If the current line is null, then load the next one.
            if (this.currentLine == null)
            {
                this.originaLine = this.Reader.ReadLine();
                this.currentLine = this.originaLine;
            }

            // Our processing is based on our current state.
            switch (this.ElementType)
            {
                case MarkupElementType.Unknown:
                    this.elementType = MarkupElementType.BeginDocument;
                    return true;

                case MarkupElementType.BeginDocument:
                    this.elementType = this.CheckMetadata()
                        ? MarkupElementType.BeginMetadata
                        : MarkupElementType.BeginContent;
                    return true;

                case MarkupElementType.BeginContent:
                    return this.ProcessBeginContent();

                   case MarkupElementType.BeginHeading:
                    return this.ProcessBeginHeading();

                case MarkupElementType.BeginParagraph:
                    return this.ProcessBeginParagraph();

                case MarkupElementType.Text:
                case MarkupElementType.Whitespace:
                    return this.ProcessText();

                case MarkupElementType.EndParagraph:
                    return this.ProcessEndParagraph();

                case MarkupElementType.EndContent:
                    this.elementType = MarkupElementType.EndDocument;
                    return true;

                case MarkupElementType.EndDocument:
                    return false;
            }

            // If we drop out, we are done processing.
            return false;
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

        /// <summary>
        /// Checks for metadata in the input stream.
        /// </summary>
        /// <returns>Returns true if there is metadata, otherwise false.</returns>
        private bool CheckMetadata()
        {
            return false;
        }

        /// <summary>
        /// Identifies the current type of content of the line.
        /// </summary>
        /// <returns>
        /// The content type of the current line.
        /// </returns>
        private MarkdownContentType GetContentType()
        {
            // If we have a blank line left, then this is just whitespace.
            int trimmedLength = this.currentLine.Trim()
                .Length;

            if (trimmedLength == 0)
            {
                // Return that we are nothing but whitespace.
                return MarkdownContentType.Whitespace;
            }

            // Check to see if this is an ATX header.
            bool isAtxHeader = AtxHeaderRegex.IsMatch(this.currentLine);

            if (isAtxHeader)
            {
                return MarkdownContentType.AtxHeading;
            }

            // Check to see if this is a Setext header.

            // Everything else is a paragraph.
            return MarkdownContentType.Paragraph;
        }

        /// <summary>
        /// Processes the content and returns the resulting Markup type.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBeginContent()
        {
            // Figure out what the next line is.
            MarkdownContentType type = this.GetContentType();

            switch (type)
            {
                case MarkdownContentType.Whitespace:

                    // Set up the state for the whitespace.
                    this.elementType = MarkupElementType.Whitespace;
                    this.Text = this.currentLine;

                    // Clear out the line so we read the next.
                    this.currentLine = null;

                    // Return true because we're done.
                    return true;

                case MarkdownContentType.Paragraph:
                    this.elementType = MarkupElementType.BeginParagraph;
                    return true;

                case MarkdownContentType.AtxHeading:
                    this.elementType = MarkupElementType.BeginHeading;
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Processes the buffer after the BeginParagraph event.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBeginParagraph()
        {
            // If we have non-significant characters, then process that.
            if (this.ProcessNonSignificant())
            {
                return true;
            }

            // No clue, throw an exception.
            throw new Exception("Panic");
        }

        /// <summary>
        /// Processes the buffer after the BeginHeading event.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBeginHeading()
        {
            // Figure out the content type.
            MarkdownContentType contentType = this.GetContentType();

            switch (contentType)
            {
                case MarkdownContentType.AtxHeading:
                    // Remove the leading space and hash marks. We do this in three parts
                    // because the second hash in " # #" should not be removed.
                    this.currentLine = this.currentLine.TrimStart(' ')
                        .TrimStart('#')
                        .TrimStart(' ');
                    return this.ProcessBeginParagraph();

                default:
                    throw new InvalidOperationException(
                        "Cannot process BeginHeading with content type of "
                            + contentType + ".");
            }
        }

        /// <summary>
        /// Processes the input after a EndParagraph element.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessEndParagraph()
        {
            // If we don't have a current line.
            if (this.currentLine == null)
            {
                this.elementType = MarkupElementType.EndContent;
                return true;
            }

            // Pass it into the begin content.
            return this.ProcessBeginContent();
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
                this.Text = nonSignificant;

                // Remove the text we just added, but keep a blank line so we can
                // process the next element.
                this.currentLine =
                    this.currentLine.Substring(nonSignificant.Length);

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

                if (isEndOfBuffer || this.Options.TreatNewLinesAsBreaks)
                {
                    // End the paragraph to get into our endgame.
                    this.currentLine = null;
                    this.elementType = MarkupElementType.EndParagraph;
                }
                else
                {
                    // Record it as whitespace and move on.
                    this.Text = Environment.NewLine;
                    this.currentLine = null;
                    this.elementType = MarkupElementType.Whitespace;
                }

                // We are done processing this one.
                return true;
            }

            // If we have non-significant characters, then process that.
            if (this.ProcessNonSignificant())
            {
                return true;
            }

            // No clue, throw an exception.
            throw new Exception("Panic some more.");
        }

        #endregion
    }
}