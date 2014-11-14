// <copyright file="CommonMarkSpecification.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains various elements used to implement the CommonMark specification.
    /// </summary>
    public static class CommonMarkSpecification
    {
        #region Static Fields

        /// <summary>
        /// <para>
        /// Contains the regular expression for identifying an ATX-style header. The first
        /// matched group is the series of # characters. The second is the header contents
        /// itself.
        /// </para><para>
        /// CommonMark 0.12 § 4.2: An ATX header consists of a string of characters, parsed as
        /// inline content, between an opening sequence of 1–6 unescaped # characters and an
        /// optional closing sequence of any number of # characters. The opening sequence of #
        /// characters cannot be followed directly by a nonspace character. The optional
        /// closing sequence of #s must be preceded by a space and may be followed by spaces
        /// only. The opening # character may be indented 0-3 spaces. The raw contents of the
        /// header are stripped of leading and trailing spaces before being parsed as inline
        /// content. The header level is equal to the number of # characters in the opening
        /// sequence.
        /// </para>
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", 
            "SA1650:ElementDocumentationMustBeSpelledCorrectly", 
            Justification = "From CommonMark specification.")]
        public static readonly Regex AtxHeaderRegex =
            new Regex(@"^ {0,3}(#{1,6})(?:\s+\#+|\s+(.+?)(?:\s+\#+)?)?\s*$");

        /// <summary>
        /// <para>
        /// Contains the regular expression for identifying an setext style header. The first
        /// matched group is either '=' or '-' based on the header.
        /// </para><para>
        /// CommonMark 0.12 § 4.3: A setext header consists of a line of text, containing at
        /// least one nonspace character, with no more than 3 spaces indentation, followed by
        /// a setext header underline. The line of text must be one that, were it not followed
        /// by the setext header underline, would be interpreted as part of a paragraph: it
        /// cannot be a code block, header, blockquote, horizontal rule, or list. A setext
        /// header underline is a sequence of = characters or a sequence of - characters, with
        /// no more than 3 spaces indentation and any number of trailing spaces. The header is
        /// a level 1 header if = characters are used, and a level 2 header if - characters
        /// are used. The contents of the header are the result of parsing the first line as
        /// Markdown inline content.
        /// </para>
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", 
            "SA1650:ElementDocumentationMustBeSpelledCorrectly", 
            Justification = "From CommonMark specification.")]
        public static readonly Regex SetextHeaderRegex =
            new Regex(@"^ {0,3}([=-])[=-]*\s*$");

        #endregion
    }
}