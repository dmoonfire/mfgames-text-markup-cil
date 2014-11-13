// <copyright file="MarkdownContentType.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    /// <summary>
    /// Identifies the various types of content according to the parser.
    /// </summary>
    internal enum MarkdownContentType
    {
        /// <summary>
        /// Indicates that the content type is a paragraph.
        /// </summary>
        Paragraph, 

        /// <summary>
        /// Indicates that the content type is whitespace.
        /// </summary>
        Whitespace,

        /// <summary>
        /// Indicates that the content type is a ATX-style heading line.
        /// </summary>
        AtxHeading,
    }
}