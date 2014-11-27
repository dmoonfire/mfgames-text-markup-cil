﻿// <copyright file="CommonMarkSpec04LeafBlocks08ParagraphsTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using NUnit.Framework;

    #region Designer generated code

    /// <summary>
    /// Tests various examples from the CommonMark specifiction.
    /// </summary>
    [TestFixture]
    public class CommonMarkSpec04LeafBlocks08ParagraphsTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 129 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample129()
        {
            /* Specification Example:
                .
                aaa
                
                bbb
                .
                <p>aaa</p>
                <p>bbb</p>
                .
            */

            this.Setup(
                "aaa",
                string.Empty,
                "bbb");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 130 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample130()
        {
            /* Specification Example:
                .
                aaa
                bbb
                
                ccc
                ddd
                .
                <p>aaa
                bbb</p>
                <p>ccc
                ddd</p>
                .
            */

            this.Setup(
                "aaa",
                "bbb",
                string.Empty,
                "ccc",
                "ddd");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "ccc" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "ddd" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 131 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample131()
        {
            /* Specification Example:
                .
                aaa
                
                
                bbb
                .
                <p>aaa</p>
                <p>bbb</p>
                .
            */

            this.Setup(
                "aaa",
                string.Empty,
                string.Empty,
                "bbb");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 132 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample132()
        {
            /* Specification Example:
                .
                  aaa
                 bbb
                .
                <p>aaa
                bbb</p>
                .
            */

            this.Setup(
                "  aaa",
                " bbb");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 133 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample133()
        {
            /* Specification Example:
                .
                aaa
                             bbb
                                                       ccc
                .
                <p>aaa
                bbb
                ccc</p>
                .
            */

            this.Setup(
                "aaa",
                "             bbb",
                "                                       ccc");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "ccc" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 134 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample134()
        {
            /* Specification Example:
                .
                   aaa
                bbb
                .
                <p>aaa
                bbb</p>
                .
            */

            this.Setup(
                "   aaa",
                "bbb");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 135 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample135()
        {
            /* Specification Example:
                .
                    aaa
                bbb
                .
                <pre><code>aaa
                </code></pre>
                <p>bbb</p>
                .
            */

            this.Setup(
                "    aaa",
                "bbb");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 136 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks08ParagraphsExample136()
        {
            /* Specification Example:
                .
                aaa     
                bbb     
                .
                <p>aaa<br />
                bbb</p>
                .
            */

            this.Setup(
                "aaa     ",
                "bbb     ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<br />" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
