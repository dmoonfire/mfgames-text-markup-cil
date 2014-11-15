// <copyright file="MarkdownBlockType.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Identifies the various types of content according to the parser.
    /// </summary>
    internal enum MarkdownBlockType
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

        /// <summary>
        /// Indicates that the content type is a setext heading line.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", 
            "SA1650:ElementDocumentationMustBeSpelledCorrectly", 
            Justification = "Name comes from the CommonMark specfication.")]
        SetextHeading, 

        /// <summary>
        /// Indicates that the content type is a horizontal rule.
        /// </summary>
        HorizontalRule, 

        /// <summary>
        /// Indicates the content type is a blockquote.
        /// </summary>
        Blockquote
    }
}