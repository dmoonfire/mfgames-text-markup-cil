// <copyright file="MarkupElementType.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup
{
    /// <summary>
    /// Identifies the various semantic element types within a marked-up file.
    /// </summary>
    public enum MarkupElementType
    {
        /// <summary>
        /// An unknown element type not supported by the core framework.
        /// </summary>
        Unknown, 

        /// <summary>
        /// Indicates the beginning of a document. This is called before all other element
        /// types are parsed.
        /// </summary>
        BeginDocument, 

        /// <summary>
        /// Indicates the end of the document or the end of processing.
        /// </summary>
        EndDocument, 

        /// <summary>
        /// Indicates the beginning of metadata elements, if present.
        /// </summary>
        BeginMetadata, 

        /// <summary>
        /// Indicates the end of metadata processing.
        /// </summary>
        EndMetadata, 

        /// <summary>
        /// Indicates the beginning of the content (or body) processing.
        /// </summary>
        BeginContent, 

        /// <summary>
        /// Indicates the end of the content processing. This is typically followed by
        /// the EndDocument element.
        /// </summary>
        EndContent, 

        /// <summary>
        /// Indicates the beginning of a paragraph.
        /// </summary>
        BeginParagraph, 

        /// <summary>
        /// Indicates the end of a paragraph.
        /// </summary>
        EndParagraph, 

        /// <summary>
        /// Indicates a block of significant text.
        /// </summary>
        Text, 

        /// <summary>
        /// Indicates a newline was found in the input.
        /// </summary>
        NewLine, 

        /// <summary>
        /// Indicates the beginning of a blockquote.
        /// </summary>
        BeginBlockquote, 

        /// <summary>
        /// Indicates the end of a blockquote.
        /// </summary>
        EndBlockquote, 

        /// <summary>
        /// Indicates the beginning of an italic.
        /// </summary>
        BeginItalic, 

        /// <summary>
        /// Indicates the end of an italic.
        /// </summary>
        EndItalic, 

        /// <summary>
        /// Indicates the beginning of a bold.
        /// </summary>
        BeginBold, 

        /// <summary>
        /// Indicates the end of a bold.
        /// </summary>
        EndBold, 

        /// <summary>
        /// Indicates the beginning of a code span.
        /// </summary>
        BeginCodeSpan, 

        /// <summary>
        /// Indicates the end of a code span.
        /// </summary>
        EndCodeSpan, 

        /// <summary>
        /// Indicates the beginning of a code block (or fence).
        /// </summary>
        BeginCodeBlock, 

        /// <summary>
        /// Indicates the end of a code block.
        /// </summary>
        EndCodeBlock, 

        /// <summary>
        /// Indicates a non-processed YAML configuration block.
        /// </summary>
        YamlMetadata, 

        /// <summary>
        /// Indicates a break or horizontal rule.
        /// </summary>
        HorizontalRule, 

        /// <summary>
        /// Indicates the beginning of a heading section.
        /// </summary>
        BeginHeader, 

        /// <summary>
        /// Indicates the end of a heading section.
        /// </summary>
        EndHeader, 

        /// <summary>
        /// Indicates the beginning of an anchor link.
        /// </summary>
        BeginAnchor, 

        /// <summary>
        /// Indicates the end of an anchor link.
        /// </summary>
        EndAnchor, 

        /// <summary>
        /// Indicates the beginning of an HTML section.
        /// </summary>
        BeginHtml, 

        /// <summary>
        /// Indicates the end of an HTML section.
        /// </summary>
        EndHtml, 

        /// <summary>
        /// </summary>
        BeginOrderedList, 

        /// <summary>
        /// </summary>
        EndOrderedList, 

        /// <summary>
        /// </summary>
        BeginUnorderedList, 

        /// <summary>
        /// </summary>
        EndUnorderedList, 

        /// <summary>
        /// </summary>
        BeginListItem, 

        /// <summary>
        /// </summary>
        EndListItem, 
    }
}