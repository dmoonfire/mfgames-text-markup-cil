// <copyright file="CommonMarkSpec04LeafBlocks01HorizontalRulesTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using Xunit;

    #region Designer generated code

    /// <summary>
    /// Tests various examples from the CommonMark specifiction.
    /// </summary>
    public class CommonMarkSpec04LeafBlocks01HorizontalRulesTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 4 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample004()
        {
            /* Specification Example:
                .
                ***
                ---
                ___
                .
                <hr />
                <hr />
                <hr />
                .
            */

            this.Setup(
                "***",
                "---",
                "___");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 5 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample005()
        {
            /* Specification Example:
                .
                +++
                .
                <p>+++</p>
                .
            */

            this.Setup(
                "+++");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "+++" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 6 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample006()
        {
            /* Specification Example:
                .
                ===
                .
                <p>===</p>
                .
            */

            this.Setup(
                "===");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "===" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 7 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample007()
        {
            /* Specification Example:
                .
                --
                **
                __
                .
                <p>--
                **
                __</p>
                .
            */

            this.Setup(
                "--",
                "**",
                "__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "--" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "**" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "__" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 8 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample008()
        {
            /* Specification Example:
                .
                 ***
                  ***
                   ***
                .
                <hr />
                <hr />
                <hr />
                .
            */

            this.Setup(
                " ***",
                "  ***",
                "   ***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 9 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample009()
        {
            /* Specification Example:
                .
                    ***
                .
                <pre><code>***
                </code></pre>
                .
            */

            this.Setup(
                "    ***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "***" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 10 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample010()
        {
            /* Specification Example:
                .
                Foo
                    ***
                .
                <p>Foo
                ***</p>
                .
            */

            this.Setup(
                "Foo",
                "    ***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "***" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 11 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample011()
        {
            /* Specification Example:
                .
                _____________________________________
                .
                <hr />
                .
            */

            this.Setup(
                "_____________________________________");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 12 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample012()
        {
            /* Specification Example:
                .
                 - - -
                .
                <hr />
                .
            */

            this.Setup(
                " - - -");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 13 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample013()
        {
            /* Specification Example:
                .
                 **  * ** * ** * **
                .
                <hr />
                .
            */

            this.Setup(
                " **  * ** * ** * **");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 14 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample014()
        {
            /* Specification Example:
                .
                -     -      -      -
                .
                <hr />
                .
            */

            this.Setup(
                "-     -      -      -");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 15 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample015()
        {
            /* Specification Example:
                .
                - - - -    
                .
                <hr />
                .
            */

            this.Setup(
                "- - - -    ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 16 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample016()
        {
            /* Specification Example:
                .
                _ _ _ _ a
                
                a------
                
                ---a---
                .
                <p>_ _ _ _ a</p>
                <p>a------</p>
                <p>---a---</p>
                .
            */

            this.Setup(
                "_ _ _ _ a",
                string.Empty,
                "a------",
                string.Empty,
                "---a---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_ _ _ _ a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a------" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "---a---" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 17 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample017()
        {
            /* Specification Example:
                .
                 *-*
                .
                <p><em>-</em></p>
                .
            */

            this.Setup(
                " *-*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "-" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 18 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample018()
        {
            /* Specification Example:
                .
                - foo
                ***
                - bar
                .
                <ul>
                <li>foo</li>
                </ul>
                <hr />
                <ul>
                <li>bar</li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "***",
                "- bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 19 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample019()
        {
            /* Specification Example:
                .
                Foo
                ***
                bar
                .
                <p>Foo</p>
                <hr />
                <p>bar</p>
                .
            */

            this.Setup(
                "Foo",
                "***",
                "bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 20 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample020()
        {
            /* Specification Example:
                .
                Foo
                ---
                bar
                .
                <h2>Foo</h2>
                <p>bar</p>
                .
            */

            this.Setup(
                "Foo",
                "---",
                "bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndHeader) { Level = 2 },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 21 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample021()
        {
            /* Specification Example:
                .
                * Foo
                * * *
                * Bar
                .
                <ul>
                <li>Foo</li>
                </ul>
                <hr />
                <ul>
                <li>Bar</li>
                </ul>
                .
            */

            this.Setup(
                "* Foo",
                "* * *",
                "* Bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "Bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 22 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks01HorizontalRulesExample022()
        {
            /* Specification Example:
                .
                - Foo
                - * * *
                .
                <ul>
                <li>Foo</li>
                <li><hr />
                </li>
                </ul>
                .
            */

            this.Setup(
                "- Foo",
                "- * * *");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
