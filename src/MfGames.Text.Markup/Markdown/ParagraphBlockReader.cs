﻿// <copyright file="ParagraphBlockReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    /// <summary>
    /// A contextual reader for paragraph blocks. This supports the full
    /// formatting of data along with optionally returning events for the
    /// newlines.
    /// </summary>
    public class ParagraphBlockReader : BlockReaderBase
    {
        #region Public Methods and Operators

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
                reader.SetState(MarkupElementType.BeginParagraph);
                return BlockReadStatus.Continue;
            }

            // If we are at the end of the buffer, just finish up our block.
            if (reader.ElementType == MarkupElementType.EndParagraph)
            {
                input.ReadNext();
                return BlockReadStatus.Finished;
            }

            if (input.IsEndOfBuffer)
            {
                reader.SetState(MarkupElementType.EndParagraph);
                return BlockReadStatus.Continue;
            }

            // If we are processing a blank line, figure out if we have something.
            if (input.CurrentIsBlank)
            {
                // Check to see if the next line is at the end of the buffer or blank.
                // Either case will terminate a string.
                string nextLine = input.NextLine;

                if (string.IsNullOrEmpty(nextLine))
                {
                    reader.SetState(MarkupElementType.EndParagraph);
                    return BlockReadStatus.Continue;
                }
            }

            // Grab the entire line.
            string currentLine = input.CurrentLine;
            input.RemoveFromCurrent(currentLine);
            reader.SetState(MarkupElementType.Text, currentLine);
            return BlockReadStatus.Continue;
        }

        #endregion
    }
}