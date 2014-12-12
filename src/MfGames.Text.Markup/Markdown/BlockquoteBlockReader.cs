// <copyright file="BlockquoteBlockReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    /// <summary>
    /// </summary>
    public class BlockquoteBlockReader : BlockReaderBase
    {
        #region Fields

        /// <summary>
        /// </summary>
        private readonly ParagraphBlockReader paragraphBlockReader;

        /// <summary>
        /// </summary>
        private bool inParagraph;

        /// <summary>
        /// </summary>
        private int lastLineIndex;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// </summary>
        public BlockquoteBlockReader()
        {
            this.paragraphBlockReader = new ParagraphBlockReader();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="markdownReader">
        /// </param>
        /// <param name="input">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool CanRead(
            MarkdownReader markdownReader, 
            InputBuffer input)
        {
            return input.CurrentLine.TrimStart().StartsWith(">");
        }

        /// <summary>
        /// </summary>
        /// <param name="reader">
        /// </param>
        /// <param name="input">
        /// </param>
        /// <returns>
        /// </returns>
        public override BlockReadStatus Read(
            MarkdownReader reader, 
            InputBuffer input)
        {
            // Check to see if we need to be initialized.
            if (!this.Initialized)
            {
                this.Initialized = true;
                reader.SetState(MarkupElementType.BeginBlockquote);
                return BlockReadStatus.Continue;
            }

            // If we are at the end of the buffer, just finish up our block.
            if (reader.ElementType == MarkupElementType.EndBlockquote)
            {
                input.ReadNext();
                return BlockReadStatus.Finished;
            }

            if (input.IsEndOfBuffer)
            {
                reader.SetState(MarkupElementType.EndBlockquote);
                return BlockReadStatus.Continue;
            }

            // If we are starting a new line (line count changes), then we
            // need to pull out our blockquote elements.
            if (this.lastLineIndex != input.LineIndex)
            {
                string nonPrefix = input.CurrentLine.TrimStart(' ', '\t', '>');
                input.CurrentLine = nonPrefix;
                this.lastLineIndex = input.LineIndex;
            }

            // If we aren't in a paragraph reader and we have a blank, skip it.
            if (!this.inParagraph && string.IsNullOrEmpty(input.CurrentLine))
            {
                input.ReadNext();
                return this.Read(reader, input);
            }

            // Pass the results into the paragraph reader.
            BlockReadStatus status = this.paragraphBlockReader.Read(
                reader, input);

            if (status == BlockReadStatus.Continue)
            {
                this.inParagraph = true;
                return BlockReadStatus.Continue;
            }

            // Check the next line and see if it is blank.
            string nextLine = input.NextLine ?? string.Empty;

            this.inParagraph = false;

            if (string.IsNullOrEmpty(nextLine))
            {
                // If the paragraph reader thinks we're done, then we need to
                // finish up ourselves too.
                reader.SetState(MarkupElementType.EndBlockquote);
                return BlockReadStatus.Continue;
            }

            // Just advanced the line and try again.
            this.paragraphBlockReader.Reset();
            input.ReadNext();

            return this.Read(reader, input);
        }

        /// <summary>
        /// </summary>
        public override void Reset()
        {
            this.paragraphBlockReader.Reset();
            base.Reset();
        }

        #endregion
    }
}