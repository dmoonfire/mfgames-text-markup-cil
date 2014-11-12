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
        /// Indicates a block of insignificant whitespace.
        /// </summary>
        Whitespace, 
    }
}