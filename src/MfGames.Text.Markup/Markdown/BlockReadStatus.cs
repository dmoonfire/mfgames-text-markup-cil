// <copyright file="BlockReadStatus.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    /// <summary>
    /// </summary>
    public enum BlockReadStatus : byte
    {
        /// <summary>
        /// Indicates that the block reader is still processing data
        /// and should get the next input.
        /// </summary>
        Continue, 

        /// <summary>
        /// Indicates that the block reader is finished processing
        /// and has made no changes to the MarkdownReader. Remove the
        /// block from the processing stack and either move to the next
        /// block or find a new one.
        /// </summary>
        Finished, 
    }
}