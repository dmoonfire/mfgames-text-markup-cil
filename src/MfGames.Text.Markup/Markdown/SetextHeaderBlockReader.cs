// <copyright file="SetextHeaderBlockReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    /// <summary>
    /// </summary>
    public class SetextHeaderBlockReader : BlockReaderBase
    {
        #region Properties

        /// <summary>
        /// </summary>
        protected int Level { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="input">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool CanRead(InputBuffer input)
        {
            string currentLine = input.CurrentLine ?? string.Empty;

            if (string.IsNullOrEmpty(currentLine.Trim()))
            {
                return false;
            }

            string nextLine = input.NextLine ?? string.Empty;
            bool results =
                CommonMarkSpecification.SetextHeaderRegex.IsMatch(nextLine);
            return results;
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
                this.Level = this.GetLevel(input.NextLine);
                reader.SetState(MarkupElementType.BeginHeader, this.Level);
                return BlockReadStatus.Continue;
            }

            // If we have a blank string, we're done.
            if (input.CurrentIsBlank)
            {
                // If we already sent the end header, then finish up.
                if (reader.ElementType == MarkupElementType.EndHeader)
                {
                    input.ReadNext();
                    input.ReadNext();
                    return BlockReadStatus.Finished;
                }

                // Finish up the header.
                reader.SetState(MarkupElementType.EndHeader, this.Level);
                return BlockReadStatus.Continue;
            }

            // Grab the entire line.
            string currentLine = input.CurrentLine;
            input.RemoveFromCurrent(currentLine);
            reader.SetState(MarkupElementType.Text, currentLine);
            return BlockReadStatus.Continue;
        }

        /// <summary>
        /// </summary>
        public override void Reset()
        {
            this.Level = 0;
            base.Reset();
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <returns>
        /// </returns>
        private int GetLevel(string line)
        {
            char c = line.Trim()[0];

            return c == '=' ? 1 : 2;
        }

        #endregion
    }
}