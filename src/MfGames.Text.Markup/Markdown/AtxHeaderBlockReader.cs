// <copyright file="AtxHeaderBlockReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// </summary>
    public class AtxHeaderBlockReader : BlockReaderBase
    {
        #region Properties

        /// <summary>
        /// </summary>
        protected int Level { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool CanRead(string line)
        {
            bool results = CommonMarkSpecification.AtxHeaderRegex.IsMatch(line);
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
                // Parse the ATX header and put the title back.
                Match matches =
                    CommonMarkSpecification.AtxHeaderRegex.Match(
                        input.CurrentLine);
                string level = matches.Groups[1].Value;
                string title = matches.Groups[2].Value;

                input.CurrentLine = title;

                // Clean up the header.
                this.Initialized = true;
                this.Level = level.Length;
                reader.SetState(MarkupElementType.BeginHeader, this.Level);
                return BlockReadStatus.Continue;
            }

            // If we have a blank string, we're done.
            if (input.CurrentIsBlank)
            {
                // If we already sent the end header, then finish up.
                if (reader.ElementType == MarkupElementType.EndHeader)
                {
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
    }
}