// <copyright file="HorizontalRuleReaderBase.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    /// <summary>
    /// Implements a block reader that handles horizontal breaks.
    /// </summary>
    public class HorizontalRuleReaderBase : BlockReaderBase
    {
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
            string line = input.CurrentLine;
            bool isMatch =
                CommonMarkSpecification.HorizontalRuleRegex.IsMatch(line);
            return isMatch;
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
            if (this.Initialized)
            {
                return BlockReadStatus.Finished;
            }

            this.Initialized = true;
            reader.SetState(MarkupElementType.HorizontalRule);
            input.ReadNext();
            return BlockReadStatus.Continue;
        }

        #endregion
    }
}