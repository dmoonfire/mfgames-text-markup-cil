// <copyright file="MarkdownReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System;
    using System.IO;
    using System.Text;

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
        private string currentLine;

        /// <summary>
        /// Contains the internal state.
        /// </summary>
        private MarkupElementType elementType;

        /// <summary>
        /// </summary>
        private bool inBold;

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
                    continue;
                }

                // Look for characters that indicate special processing.
                switch (line[index])
                {
                    case '*':
                    case '`':
                    case '_':
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

                case MarkupElementType.BeginMetadata:
                    return this.ProcessBeginMetadata();

                case MarkupElementType.YamlMetadata:
                    this.elementType = MarkupElementType.EndMetadata;
                    return true;

                case MarkupElementType.EndMetadata:
                    this.elementType = MarkupElementType.BeginContent;
                    return true;

                case MarkupElementType.BeginDocument:
                    this.elementType = this.CheckMetadata()
                        ? MarkupElementType.BeginMetadata
                        : MarkupElementType.BeginContent;
                    return true;

                case MarkupElementType.BeginContent:
                case MarkupElementType.HorizontalRule:
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

                case MarkupElementType.EndHeading:
                    return this.ProcessEndHeading();

                case MarkupElementType.EndContent:
                    this.elementType = MarkupElementType.EndDocument;
                    return true;

                case MarkupElementType.EndDocument:
                    return false;

                case MarkupElementType.BeginBold:
                    return this.ProcessBeginBold();
                case MarkupElementType.EndBold:
                    return this.ProcessEndBold();
                case MarkupElementType.BeginItalic:
                    return this.ProcessBeginItalic();
                case MarkupElementType.EndItalic:
                    return this.ProcessEndItalic();
                case MarkupElementType.BeginCodeSpan:
                    return this.ProcessBeginCodeSpan();
                case MarkupElementType.EndCodeSpan:
                    return this.ProcessEndCodeSpan();
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
            // Check the first line for a YAML header.
            if (this.currentLine == "---")
            {
                // We are in a YAML header.
                return true;
            }

            // Otherwise, go directly to content.
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

            // Check for a horizontal rule.
            bool isRule =
                CommonMarkSpecification.HorizontalRuleRegex.IsMatch(
                    this.currentLine);

            if (isRule)
            {
                return MarkdownContentType.HorizontalRule;
            }

            // Check to see if this is an ATX header.
            bool isAtxHeader =
                CommonMarkSpecification.AtxHeaderRegex.IsMatch(this.currentLine);

            if (isAtxHeader)
            {
                return MarkdownContentType.AtxHeading;
            }

            // Check to see if this is a setext header.
            string nextLine = this.Reader.PeekLine(0);

            if (nextLine != null
                && CommonMarkSpecification.SetextHeaderRegex.IsMatch(nextLine))
            {
                // The next line appears to be a header, so check this line.
                if (this.currentLine.Trim()
                    .Length > 0)
                {
                    // We have at least one line.
                    return MarkdownContentType.SetextHeading;
                }
            }

            // Everything else is a paragraph.
            return MarkdownContentType.Paragraph;
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
        private bool ProcessBeginCodeSpan()
        {
            this.inCodeSpan = true;
            return this.ProcessText();
        }

        /// <summary>
        /// Processes the content and returns the resulting Markup type.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessBeginContent()
        {
            // Ignore blank lines at this point.
            while (this.currentLine != null && this.currentLine.Trim()
                .Length == 0)
            {
                this.originaLine = this.Reader.ReadLine();
                this.currentLine = this.originaLine;
            }

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
                    this.inParagraph = true;
                    return true;

                case MarkdownContentType.AtxHeading:
                case MarkdownContentType.SetextHeading:
                    this.elementType = MarkupElementType.BeginHeading;
                    this.inHeading = true;
                    return true;

                case MarkdownContentType.HorizontalRule:
                    this.elementType = MarkupElementType.HorizontalRule;
                    this.currentLine = null;
                    return true;

                default:
                    return false;
            }
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

                    // Remove the leading and trail space and hash marks. But only in a
                    // specific order to prevent removing too much.
                    this.currentLine = this.currentLine.TrimStart(' ')
                        .TrimStart('#')
                        .TrimStart(' ')
                        .TrimEnd(' ')
                        .TrimEnd('#')
                        .TrimEnd(' ');
                    return this.ProcessContent();

                case MarkdownContentType.SetextHeading:

                    // Pop off the next line, which is the underline.
                    this.Reader.ReadLine();

                    // We don't have to change the line since that is the header text.
                    // So just move into the content processing.
                    return this.ProcessContent();

                default:
                    throw new InvalidOperationException(
                        "Cannot process BeginHeading with content type of "
                            + contentType + ".");
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
            return this.ProcessContent();
        }

        /// <summary>
        /// Processes textual content inside a paragraph or heading.
        /// </summary>
        /// <returns>True if we've processed the paragraph properly.</returns>
        private bool ProcessContent()
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
        private bool ProcessEndCodeSpan()
        {
            this.inCodeSpan = false;
            return this.ProcessText();
        }

        /// <summary>
        /// Processes the input after a EndHeading element.
        /// </summary>
        /// <returns>
        /// True if this is successfully processed.
        /// </returns>
        private bool ProcessEndHeading()
        {
            // Clear the paragraph flag.
            this.inHeading = false;

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
            while (this.currentLine != null && this.currentLine.Trim()
                .Length == 0)
            {
                this.originaLine = this.Reader.ReadLine();
                this.currentLine = this.originaLine;
            }

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
                bool isBlankLine = !isEndOfBuffer && this.Reader.PeekLine(0)
                    .Trim()
                    .Length == 0;

                if (isEndOfBuffer || isBlankLine
                    || this.Options.TreatNewLinesAsBreaks)
                {
                    // End the paragraph or heading to get into our endgame.
                    this.currentLine = null;

                    if (this.inParagraph)
                    {
                        this.elementType = MarkupElementType.EndParagraph;
                    }
                    else if (this.inHeading)
                    {
                        this.elementType = MarkupElementType.EndHeading;
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

            // No clue, throw an exception.
            throw new Exception("Panic some more.");
        }

        #endregion
    }
}