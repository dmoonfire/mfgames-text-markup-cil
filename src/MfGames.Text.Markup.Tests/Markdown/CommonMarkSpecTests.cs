// <copyright file="CommonMarkSpecTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using NUnit.Framework;

    /// <summary>
    /// Tests various examples from the CommonMark specifiction.
    /// </summary>
    [TestFixture]
    public class CommonMarkSpecTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 1 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark02Preprocessing00AboutThisDocumentExample001()
        {
            /* Specification Example:
                .
                →foo→baz→→bim
                .
                <pre><code>foo baz     bim
                </code></pre>
                .
            */

            this.Setup(
                "\tfoo\tbaz\t\tbim");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo baz     bim" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 2 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark02Preprocessing00AboutThisDocumentExample002()
        {
            /* Specification Example:
                .
                    a→a
                    ὐ→a
                .
                <pre><code>a   a
                ὐ   a
                </code></pre>
                .
            */

            this.Setup(
                "    a\ta",
                "    ὐ\ta");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "a   a" },
                new Event(MarkupElementType.Text) { Text = "ὐ   a" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 3 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark03BlocksAndInlines01PrecedenceExample003()
        {
            /* Specification Example:
                .
                - `one
                - two`
                .
                <ul>
                <li>`one</li>
                <li>two`</li>
                </ul>
                .
            */

            this.Setup(
                "- `one",
                "- two`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 4 of the CommonMark specification.
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
                new Event(MarkupElementType.Text) { Text = "**" },
                new Event(MarkupElementType.Text) { Text = "__" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 8 of the CommonMark specification.
        /// </summary>
        [Test]
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
        [Test]
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
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 10 of the CommonMark specification.
        /// </summary>
        [Test]
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
                new Event(MarkupElementType.Text) { Text = "***" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 11 of the CommonMark specification.
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
                "",
                "a------",
                "",
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
        [Test]
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
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 18 of the CommonMark specification.
        /// </summary>
        [Test]
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
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 19 of the CommonMark specification.
        /// </summary>
        [Test]
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
        [Test]
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
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 21 of the CommonMark specification.
        /// </summary>
        [Test]
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
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 22 of the CommonMark specification.
        /// </summary>
        [Test]
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
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 23 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample023()
        {
            /* Specification Example:
                .
                # foo
                ## foo
                ### foo
                #### foo
                ##### foo
                ###### foo
                .
                <h1>foo</h1>
                <h2>foo</h2>
                <h3>foo</h3>
                <h4>foo</h4>
                <h5>foo</h5>
                <h6>foo</h6>
                .
            */

            this.Setup(
                "# foo",
                "## foo",
                "### foo",
                "#### foo",
                "##### foo",
                "###### foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 24 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample024()
        {
            /* Specification Example:
                .
                ####### foo
                .
                <p>####### foo</p>
                .
            */

            this.Setup(
                "####### foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "####### foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 25 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample025()
        {
            /* Specification Example:
                .
                #5 bolt
                .
                <p>#5 bolt</p>
                .
            */

            this.Setup(
                "#5 bolt");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "#5 bolt" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 26 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample026()
        {
            /* Specification Example:
                .
                \## foo
                .
                <p>## foo</p>
                .
            */

            this.Setup(
                "\\## foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "## foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 27 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample027()
        {
            /* Specification Example:
                .
                # foo *bar* \*baz\*
                .
                <h1>foo <em>bar</em> *baz*</h1>
                .
            */

            this.Setup(
                "# foo *bar* \\*baz\\*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 28 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample028()
        {
            /* Specification Example:
                .
                #                  foo                     
                .
                <h1>foo</h1>
                .
            */

            this.Setup(
                "#                  foo                     ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 29 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample029()
        {
            /* Specification Example:
                .
                 ### foo
                  ## foo
                   # foo
                .
                <h3>foo</h3>
                <h2>foo</h2>
                <h1>foo</h1>
                .
            */

            this.Setup(
                " ### foo",
                "  ## foo",
                "   # foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 30 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample030()
        {
            /* Specification Example:
                .
                    # foo
                .
                <pre><code># foo
                </code></pre>
                .
            */

            this.Setup(
                "    # foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "# foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 31 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample031()
        {
            /* Specification Example:
                .
                foo
                    # bar
                .
                <p>foo
                # bar</p>
                .
            */

            this.Setup(
                "foo",
                "    # bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "# bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 32 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample032()
        {
            /* Specification Example:
                .
                ## foo ##
                  ###   bar    ###
                .
                <h2>foo</h2>
                <h3>bar</h3>
                .
            */

            this.Setup(
                "## foo ##",
                "  ###   bar    ###");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 33 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample033()
        {
            /* Specification Example:
                .
                # foo ##################################
                ##### foo ##
                .
                <h1>foo</h1>
                <h5>foo</h5>
                .
            */

            this.Setup(
                "# foo ##################################",
                "##### foo ##");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 34 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample034()
        {
            /* Specification Example:
                .
                ### foo ###     
                .
                <h3>foo</h3>
                .
            */

            this.Setup(
                "### foo ###     ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 35 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample035()
        {
            /* Specification Example:
                .
                ### foo ### b
                .
                <h3>foo ### b</h3>
                .
            */

            this.Setup(
                "### foo ### b");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 36 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample036()
        {
            /* Specification Example:
                .
                # foo#
                .
                <h1>foo#</h1>
                .
            */

            this.Setup(
                "# foo#");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 37 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample037()
        {
            /* Specification Example:
                .
                ### foo \###
                ## foo #\##
                # foo \#
                .
                <h3>foo ###</h3>
                <h2>foo ###</h2>
                <h1>foo #</h1>
                .
            */

            this.Setup(
                "### foo \\###",
                "## foo #\\##",
                "# foo \\#");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 38 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample038()
        {
            /* Specification Example:
                .
                ****
                ## foo
                ****
                .
                <hr />
                <h2>foo</h2>
                <hr />
                .
            */

            this.Setup(
                "****",
                "## foo",
                "****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 39 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample039()
        {
            /* Specification Example:
                .
                Foo bar
                # baz
                Bar foo
                .
                <p>Foo bar</p>
                <h1>baz</h1>
                <p>Bar foo</p>
                .
            */

            this.Setup(
                "Foo bar",
                "# baz",
                "Bar foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Bar foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 40 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample040()
        {
            /* Specification Example:
                .
                ## 
                #
                ### ###
                .
                <h2></h2>
                <h1></h1>
                <h3></h3>
                .
            */

            this.Setup(
                "## ",
                "#",
                "### ###");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 41 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample041()
        {
            /* Specification Example:
                .
                Foo *bar*
                =========
                
                Foo *bar*
                ---------
                .
                <h1>Foo <em>bar</em></h1>
                <h2>Foo <em>bar</em></h2>
                .
            */

            this.Setup(
                "Foo *bar*",
                "=========",
                "",
                "Foo *bar*",
                "---------");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 42 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample042()
        {
            /* Specification Example:
                .
                Foo
                -------------------------
                
                Foo
                =
                .
                <h2>Foo</h2>
                <h1>Foo</h1>
                .
            */

            this.Setup(
                "Foo",
                "-------------------------",
                "",
                "Foo",
                "=");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 43 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample043()
        {
            /* Specification Example:
                .
                   Foo
                ---
                
                  Foo
                -----
                
                  Foo
                  ===
                .
                <h2>Foo</h2>
                <h2>Foo</h2>
                <h1>Foo</h1>
                .
            */

            this.Setup(
                "   Foo",
                "---",
                "",
                "  Foo",
                "-----",
                "",
                "  Foo",
                "  ===");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 44 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample044()
        {
            /* Specification Example:
                .
                    Foo
                    ---
                
                    Foo
                ---
                .
                <pre><code>Foo
                ---
                
                Foo
                </code></pre>
                <hr />
                .
            */

            this.Setup(
                "    Foo",
                "    ---",
                "",
                "    Foo",
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Text) { Text = "---" },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 45 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample045()
        {
            /* Specification Example:
                .
                Foo
                   ----      
                .
                <h2>Foo</h2>
                .
            */

            this.Setup(
                "Foo",
                "   ----      ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 46 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample046()
        {
            /* Specification Example:
                .
                Foo
                     ---
                .
                <p>Foo
                ---</p>
                .
            */

            this.Setup(
                "Foo",
                "     ---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Text) { Text = "---" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 47 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample047()
        {
            /* Specification Example:
                .
                Foo
                = =
                
                Foo
                --- -
                .
                <p>Foo
                = =</p>
                <p>Foo</p>
                <hr />
                .
            */

            this.Setup(
                "Foo",
                "= =",
                "",
                "Foo",
                "--- -");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Text) { Text = "= =" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 48 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample048()
        {
            /* Specification Example:
                .
                Foo  
                -----
                .
                <h2>Foo</h2>
                .
            */

            this.Setup(
                "Foo  ",
                "-----");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 49 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample049()
        {
            /* Specification Example:
                .
                Foo\
                ----
                .
                <h2>Foo\</h2>
                .
            */

            this.Setup(
                "Foo\\",
                "----");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 50 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample050()
        {
            /* Specification Example:
                .
                `Foo
                ----
                `
                
                <a title="a lot
                ---
                of dashes"/>
                .
                <h2>`Foo</h2>
                <p>`</p>
                <h2>&lt;a title=&quot;a lot</h2>
                <p>of dashes&quot;/&gt;</p>
                .
            */

            this.Setup(
                "`Foo",
                "----",
                "`",
                "",
                "<a title=\"a lot",
                "---",
                "of dashes\"/>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "`" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "of dashes&quot;/&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 51 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample051()
        {
            /* Specification Example:
                .
                > Foo
                ---
                .
                <blockquote>
                <p>Foo</p>
                </blockquote>
                <hr />
                .
            */

            this.Setup(
                "> Foo",
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 52 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample052()
        {
            /* Specification Example:
                .
                - Foo
                ---
                .
                <ul>
                <li>Foo</li>
                </ul>
                <hr />
                .
            */

            this.Setup(
                "- Foo",
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 53 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample053()
        {
            /* Specification Example:
                .
                Foo
                Bar
                ---
                
                Foo
                Bar
                ===
                .
                <p>Foo
                Bar</p>
                <hr />
                <p>Foo
                Bar
                ===</p>
                .
            */

            this.Setup(
                "Foo",
                "Bar",
                "---",
                "",
                "Foo",
                "Bar",
                "===");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Text) { Text = "Bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Text) { Text = "Bar" },
                new Event(MarkupElementType.Text) { Text = "===" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 54 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample054()
        {
            /* Specification Example:
                .
                ---
                Foo
                ---
                Bar
                ---
                Baz
                .
                <hr />
                <h2>Foo</h2>
                <h2>Bar</h2>
                <p>Baz</p>
                .
            */

            this.Setup(
                "---",
                "Foo",
                "---",
                "Bar",
                "---",
                "Baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 55 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample055()
        {
            /* Specification Example:
                .
                
                ====
                .
                <p>====</p>
                .
            */

            this.Setup(
                "",
                "====");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "====" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 56 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample056()
        {
            /* Specification Example:
                .
                ---
                ---
                .
                <hr />
                <hr />
                .
            */

            this.Setup(
                "---",
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 57 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample057()
        {
            /* Specification Example:
                .
                - foo
                -----
                .
                <ul>
                <li>foo</li>
                </ul>
                <hr />
                .
            */

            this.Setup(
                "- foo",
                "-----");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 58 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample058()
        {
            /* Specification Example:
                .
                    foo
                ---
                .
                <pre><code>foo
                </code></pre>
                <hr />
                .
            */

            this.Setup(
                "    foo",
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 59 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample059()
        {
            /* Specification Example:
                .
                > foo
                -----
                .
                <blockquote>
                <p>foo</p>
                </blockquote>
                <hr />
                .
            */

            this.Setup(
                "> foo",
                "-----");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 60 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks03SetextHeadersExample060()
        {
            /* Specification Example:
                .
                \> foo
                ------
                .
                <h2>&gt; foo</h2>
                .
            */

            this.Setup(
                "\\> foo",
                "------");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 61 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample061()
        {
            /* Specification Example:
                .
                    a simple
                      indented code block
                .
                <pre><code>a simple
                  indented code block
                </code></pre>
                .
            */

            this.Setup(
                "    a simple",
                "      indented code block");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "a simple" },
                new Event(MarkupElementType.Text) { Text = "  indented code block" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 62 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample062()
        {
            /* Specification Example:
                .
                    <a/>
                    *hi*
                
                    - one
                .
                <pre><code>&lt;a/&gt;
                *hi*
                
                - one
                </code></pre>
                .
            */

            this.Setup(
                "    <a/>",
                "    *hi*",
                "",
                "    - one");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "&lt;a/&gt;" },
                new Event(MarkupElementType.Text) { Text = "*hi*" },
                new Event(MarkupElementType.Text) { Text = "- one" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 63 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample063()
        {
            /* Specification Example:
                .
                    chunk1
                
                    chunk2
                  
                 
                 
                    chunk3
                .
                <pre><code>chunk1
                
                chunk2
                
                
                
                chunk3
                </code></pre>
                .
            */

            this.Setup(
                "    chunk1",
                "",
                "    chunk2",
                "  ",
                " ",
                " ",
                "    chunk3");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "chunk1" },
                new Event(MarkupElementType.Text) { Text = "chunk2" },
                new Event(MarkupElementType.Text) { Text = "chunk3" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 64 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample064()
        {
            /* Specification Example:
                .
                    chunk1
                      
                      chunk2
                .
                <pre><code>chunk1
                  
                  chunk2
                </code></pre>
                .
            */

            this.Setup(
                "    chunk1",
                "      ",
                "      chunk2");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "chunk1" },
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.Text) { Text = "  chunk2" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 65 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample065()
        {
            /* Specification Example:
                .
                Foo
                    bar
                
                .
                <p>Foo
                bar</p>
                .
            */

            this.Setup(
                "Foo",
                "    bar",
                "");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 66 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample066()
        {
            /* Specification Example:
                .
                    foo
                bar
                .
                <pre><code>foo
                </code></pre>
                <p>bar</p>
                .
            */

            this.Setup(
                "    foo",
                "bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 67 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample067()
        {
            /* Specification Example:
                .
                # Header
                    foo
                Header
                ------
                    foo
                ----
                .
                <h1>Header</h1>
                <pre><code>foo
                </code></pre>
                <h2>Header</h2>
                <pre><code>foo
                </code></pre>
                <hr />
                .
            */

            this.Setup(
                "# Header",
                "    foo",
                "Header",
                "------",
                "    foo",
                "----");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 68 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample068()
        {
            /* Specification Example:
                .
                        foo
                    bar
                .
                <pre><code>    foo
                bar
                </code></pre>
                .
            */

            this.Setup(
                "        foo",
                "    bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "    foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 69 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample069()
        {
            /* Specification Example:
                .
                
                    
                    foo
                    
                
                .
                <pre><code>foo
                </code></pre>
                .
            */

            this.Setup(
                "",
                "    ",
                "    foo",
                "    ",
                "");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 70 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks04IndentedCodeBlocksExample070()
        {
            /* Specification Example:
                .
                    foo  
                .
                <pre><code>foo  
                </code></pre>
                .
            */

            this.Setup(
                "    foo  ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo  " },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 71 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample071()
        {
            /* Specification Example:
                .
                ```
                <
                 >
                ```
                .
                <pre><code>&lt;
                 &gt;
                </code></pre>
                .
            */

            this.Setup(
                "```",
                "<",
                " >",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "&lt;" },
                new Event(MarkupElementType.Text) { Text = " &gt;" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 72 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample072()
        {
            /* Specification Example:
                .
                ~~~
                <
                 >
                ~~~
                .
                <pre><code>&lt;
                 &gt;
                </code></pre>
                .
            */

            this.Setup(
                "~~~",
                "<",
                " >",
                "~~~");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "&lt;" },
                new Event(MarkupElementType.Text) { Text = " &gt;" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 73 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample073()
        {
            /* Specification Example:
                .
                ```
                aaa
                ~~~
                ```
                .
                <pre><code>aaa
                ~~~
                </code></pre>
                .
            */

            this.Setup(
                "```",
                "aaa",
                "~~~",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "~~~" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 74 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample074()
        {
            /* Specification Example:
                .
                ~~~
                aaa
                ```
                ~~~
                .
                <pre><code>aaa
                ```
                </code></pre>
                .
            */

            this.Setup(
                "~~~",
                "aaa",
                "```",
                "~~~");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "```" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 75 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample075()
        {
            /* Specification Example:
                .
                ````
                aaa
                ```
                ``````
                .
                <pre><code>aaa
                ```
                </code></pre>
                .
            */

            this.Setup(
                "````",
                "aaa",
                "```",
                "``````");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "```" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 76 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample076()
        {
            /* Specification Example:
                .
                ~~~~
                aaa
                ~~~
                ~~~~
                .
                <pre><code>aaa
                ~~~
                </code></pre>
                .
            */

            this.Setup(
                "~~~~",
                "aaa",
                "~~~",
                "~~~~");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "~~~" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 77 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample077()
        {
            /* Specification Example:
                .
                ```
                .
                <pre><code></code></pre>
                .
            */

            this.Setup(
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 78 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample078()
        {
            /* Specification Example:
                .
                `````
                
                ```
                aaa
                .
                <pre><code>
                ```
                aaa
                </code></pre>
                .
            */

            this.Setup(
                "`````",
                "",
                "```",
                "aaa");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "```" },
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 79 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample079()
        {
            /* Specification Example:
                .
                ```
                
                  
                ```
                .
                <pre><code>
                  
                </code></pre>
                .
            */

            this.Setup(
                "```",
                "",
                "  ",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 80 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample080()
        {
            /* Specification Example:
                .
                ```
                ```
                .
                <pre><code></code></pre>
                .
            */

            this.Setup(
                "```",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 81 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample081()
        {
            /* Specification Example:
                .
                 ```
                 aaa
                aaa
                ```
                .
                <pre><code>aaa
                aaa
                </code></pre>
                .
            */

            this.Setup(
                " ```",
                " aaa",
                "aaa",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 82 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample082()
        {
            /* Specification Example:
                .
                  ```
                aaa
                  aaa
                aaa
                  ```
                .
                <pre><code>aaa
                aaa
                aaa
                </code></pre>
                .
            */

            this.Setup(
                "  ```",
                "aaa",
                "  aaa",
                "aaa",
                "  ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 83 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample083()
        {
            /* Specification Example:
                .
                   ```
                   aaa
                    aaa
                  aaa
                   ```
                .
                <pre><code>aaa
                 aaa
                aaa
                </code></pre>
                .
            */

            this.Setup(
                "   ```",
                "   aaa",
                "    aaa",
                "  aaa",
                "   ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = " aaa" },
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 84 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample084()
        {
            /* Specification Example:
                .
                    ```
                    aaa
                    ```
                .
                <pre><code>```
                aaa
                ```
                </code></pre>
                .
            */

            this.Setup(
                "    ```",
                "    aaa",
                "    ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "```" },
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "```" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 85 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample085()
        {
            /* Specification Example:
                .
                ```
                aaa
                  ```
                .
                <pre><code>aaa
                </code></pre>
                .
            */

            this.Setup(
                "```",
                "aaa",
                "  ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 86 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample086()
        {
            /* Specification Example:
                .
                   ```
                aaa
                  ```
                .
                <pre><code>aaa
                </code></pre>
                .
            */

            this.Setup(
                "   ```",
                "aaa",
                "  ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 87 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample087()
        {
            /* Specification Example:
                .
                ```
                aaa
                    ```
                .
                <pre><code>aaa
                    ```
                </code></pre>
                .
            */

            this.Setup(
                "```",
                "aaa",
                "    ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "    ```" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 88 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample088()
        {
            /* Specification Example:
                .
                ``` ```
                aaa
                .
                <p><code></code>
                aaa</p>
                .
            */

            this.Setup(
                "``` ```",
                "aaa");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 89 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample089()
        {
            /* Specification Example:
                .
                ~~~~~~
                aaa
                ~~~ ~~
                .
                <pre><code>aaa
                ~~~ ~~
                </code></pre>
                .
            */

            this.Setup(
                "~~~~~~",
                "aaa",
                "~~~ ~~");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "~~~ ~~" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 90 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample090()
        {
            /* Specification Example:
                .
                foo
                ```
                bar
                ```
                baz
                .
                <p>foo</p>
                <pre><code>bar
                </code></pre>
                <p>baz</p>
                .
            */

            this.Setup(
                "foo",
                "```",
                "bar",
                "```",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 91 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample091()
        {
            /* Specification Example:
                .
                foo
                ---
                ~~~
                bar
                ~~~
                # baz
                .
                <h2>foo</h2>
                <pre><code>bar
                </code></pre>
                <h1>baz</h1>
                .
            */

            this.Setup(
                "foo",
                "---",
                "~~~",
                "bar",
                "~~~",
                "# baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 92 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample092()
        {
            /* Specification Example:
                .
                ```ruby
                def foo(x)
                  return 3
                end
                ```
                .
                <pre><code class="language-ruby">def foo(x)
                  return 3
                end
                </code></pre>
                .
            */

            this.Setup(
                "```ruby",
                "def foo(x)",
                "  return 3",
                "end",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "  return 3" },
                new Event(MarkupElementType.Text) { Text = "end" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 93 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample093()
        {
            /* Specification Example:
                .
                ~~~~    ruby startline=3 $%@#$
                def foo(x)
                  return 3
                end
                ~~~~~~~
                .
                <pre><code class="language-ruby">def foo(x)
                  return 3
                end
                </code></pre>
                .
            */

            this.Setup(
                "~~~~    ruby startline=3 $%@#$",
                "def foo(x)",
                "  return 3",
                "end",
                "~~~~~~~");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "  return 3" },
                new Event(MarkupElementType.Text) { Text = "end" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 94 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample094()
        {
            /* Specification Example:
                .
                ````;
                ````
                .
                <pre><code class="language-;"></code></pre>
                .
            */

            this.Setup(
                "````;",
                "````");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 95 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample095()
        {
            /* Specification Example:
                .
                ``` aa ```
                foo
                .
                <p><code>aa</code>
                foo</p>
                .
            */

            this.Setup(
                "``` aa ```",
                "foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 96 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks05FencedCodeBlocksExample096()
        {
            /* Specification Example:
                .
                ```
                ``` aaa
                ```
                .
                <pre><code>``` aaa
                </code></pre>
                .
            */

            this.Setup(
                "```",
                "``` aaa",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "``` aaa" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 97 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample097()
        {
            /* Specification Example:
                .
                <table>
                  <tr>
                    <td>
                           hi
                    </td>
                  </tr>
                </table>
                
                okay.
                .
                <table>
                  <tr>
                    <td>
                           hi
                    </td>
                  </tr>
                </table>
                <p>okay.</p>
                .
            */

            this.Setup(
                "<table>",
                "  <tr>",
                "    <td>",
                "           hi",
                "    </td>",
                "  </tr>",
                "</table>",
                "",
                "okay.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.Text) { Text = "    " },
                new Event(MarkupElementType.Text) { Text = "           hi" },
                new Event(MarkupElementType.Text) { Text = "    " },
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "okay." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 98 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample098()
        {
            /* Specification Example:
                .
                 <div>
                  *hello*
                         <foo><a>
                .
                 <div>
                  *hello*
                         <foo><a>
                .
            */

            this.Setup(
                " <div>",
                "  *hello*",
                "         <foo><a>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = " " },
                new Event(MarkupElementType.Text) { Text = "  *hello*" },
                new Event(MarkupElementType.Text) { Text = "         " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 99 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample099()
        {
            /* Specification Example:
                .
                <DIV CLASS="foo">
                
                *Markdown*
                
                </DIV>
                .
                <DIV CLASS="foo">
                <p><em>Markdown</em></p>
                </DIV>
                .
            */

            this.Setup(
                "<DIV CLASS=\"foo\">",
                "",
                "*Markdown*",
                "",
                "</DIV>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 100 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample100()
        {
            /* Specification Example:
                .
                <div></div>
                ``` c
                int x = 33;
                ```
                .
                <div></div>
                ``` c
                int x = 33;
                ```
                .
            */

            this.Setup(
                "<div></div>",
                "``` c",
                "int x = 33;",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "``` c" },
                new Event(MarkupElementType.Text) { Text = "int x = 33;" },
                new Event(MarkupElementType.Text) { Text = "```" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 101 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample101()
        {
            /* Specification Example:
                .
                <!-- Foo
                bar
                   baz -->
                .
                <!-- Foo
                bar
                   baz -->
                .
            */

            this.Setup(
                "<!-- Foo",
                "bar",
                "   baz -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "   baz -->" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 102 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample102()
        {
            /* Specification Example:
                .
                <?php
                  echo '>';
                ?>
                .
                <?php
                  echo '>';
                ?>
                .
            */

            this.Setup(
                "<?php",
                "  echo '>';",
                "?>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "  echo '>';" },
                new Event(MarkupElementType.Text) { Text = "?>" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 103 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample103()
        {
            /* Specification Example:
                .
                <![CDATA[
                function matchwo(a,b)
                {
                if (a < b && a < 0) then
                  {
                  return 1;
                  }
                else
                  {
                  return 0;
                  }
                }
                ]]>
                .
                <![CDATA[
                function matchwo(a,b)
                {
                if (a < b && a < 0) then
                  {
                  return 1;
                  }
                else
                  {
                  return 0;
                  }
                }
                ]]>
                .
            */

            this.Setup(
                "<![CDATA[",
                "function matchwo(a,b)",
                "{",
                "if (a < b && a < 0) then",
                "  {",
                "  return 1;",
                "  }",
                "else",
                "  {",
                "  return 0;",
                "  }",
                "}",
                "]]>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "function matchwo(a,b)" },
                new Event(MarkupElementType.Text) { Text = "{" },
                new Event(MarkupElementType.Text) { Text = "if (a " },
                new Event(MarkupElementType.Text) { Text = "  {" },
                new Event(MarkupElementType.Text) { Text = "  return 1;" },
                new Event(MarkupElementType.Text) { Text = "  }" },
                new Event(MarkupElementType.Text) { Text = "else" },
                new Event(MarkupElementType.Text) { Text = "  {" },
                new Event(MarkupElementType.Text) { Text = "  return 0;" },
                new Event(MarkupElementType.Text) { Text = "  }" },
                new Event(MarkupElementType.Text) { Text = "}" },
                new Event(MarkupElementType.Text) { Text = "]]>" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 104 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample104()
        {
            /* Specification Example:
                .
                  <!-- foo -->
                
                    <!-- foo -->
                .
                  <!-- foo -->
                <pre><code>&lt;!-- foo --&gt;
                </code></pre>
                .
            */

            this.Setup(
                "  <!-- foo -->",
                "",
                "    <!-- foo -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "&lt;!-- foo --&gt;" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 105 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample105()
        {
            /* Specification Example:
                .
                Foo
                <div>
                bar
                </div>
                .
                <p>Foo</p>
                <div>
                bar
                </div>
                .
            */

            this.Setup(
                "Foo",
                "<div>",
                "bar",
                "</div>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 106 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample106()
        {
            /* Specification Example:
                .
                <div>
                bar
                </div>
                *foo*
                .
                <div>
                bar
                </div>
                *foo*
                .
            */

            this.Setup(
                "<div>",
                "bar",
                "</div>",
                "*foo*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "*foo*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 107 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample107()
        {
            /* Specification Example:
                .
                <div class
                foo
                .
                <div class
                foo
                .
            */

            this.Setup(
                "<div class",
                "foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 108 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample108()
        {
            /* Specification Example:
                .
                <div>
                
                *Emphasized* text.
                
                </div>
                .
                <div>
                <p><em>Emphasized</em> text.</p>
                </div>
                .
            */

            this.Setup(
                "<div>",
                "",
                "*Emphasized* text.",
                "",
                "</div>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 109 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample109()
        {
            /* Specification Example:
                .
                <div>
                *Emphasized* text.
                </div>
                .
                <div>
                *Emphasized* text.
                </div>
                .
            */

            this.Setup(
                "<div>",
                "*Emphasized* text.",
                "</div>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "*Emphasized* text." },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 110 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample110()
        {
            /* Specification Example:
                .
                <table>
                
                <tr>
                
                <td>
                Hi
                </td>
                
                </tr>
                
                </table>
                .
                <table>
                <tr>
                <td>
                Hi
                </td>
                </tr>
                </table>
                .
            */

            this.Setup(
                "<table>",
                "",
                "<tr>",
                "",
                "<td>",
                "Hi",
                "</td>",
                "",
                "</tr>",
                "",
                "</table>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "Hi" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 111 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample111()
        {
            /* Specification Example:
                .
                [foo]: /url "title"
                
                [foo]
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo]: /url \"title\"",
                "",
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 112 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample112()
        {
            /* Specification Example:
                .
                   [foo]: 
                      /url  
                           'the title'  
                
                [foo]
                .
                <p><a href="/url" title="the title">foo</a></p>
                .
            */

            this.Setup(
                "   [foo]: ",
                "      /url  ",
                "           'the title'  ",
                "",
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 113 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample113()
        {
            /* Specification Example:
                .
                [Foo*bar\]]:my_(url) 'title (with parens)'
                
                [Foo*bar\]]
                .
                <p><a href="my_(url)" title="title (with parens)">Foo*bar]</a></p>
                .
            */

            this.Setup(
                "[Foo*bar\\]]:my_(url) 'title (with parens)'",
                "",
                "[Foo*bar\\]]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 114 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample114()
        {
            /* Specification Example:
                .
                [Foo bar]:
                <my url>
                'title'
                
                [Foo bar]
                .
                <p><a href="my%20url" title="title">Foo bar</a></p>
                .
            */

            this.Setup(
                "[Foo bar]:",
                "<my url>",
                "'title'",
                "",
                "[Foo bar]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 115 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample115()
        {
            /* Specification Example:
                .
                [foo]:
                /url
                
                [foo]
                .
                <p><a href="/url">foo</a></p>
                .
            */

            this.Setup(
                "[foo]:",
                "/url",
                "",
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 116 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample116()
        {
            /* Specification Example:
                .
                [foo]:
                
                [foo]
                .
                <p>[foo]:</p>
                <p>[foo]</p>
                .
            */

            this.Setup(
                "[foo]:",
                "",
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]:" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 117 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample117()
        {
            /* Specification Example:
                .
                [foo]
                
                [foo]: url
                .
                <p><a href="url">foo</a></p>
                .
            */

            this.Setup(
                "[foo]",
                "",
                "[foo]: url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 118 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample118()
        {
            /* Specification Example:
                .
                [foo]
                
                [foo]: first
                [foo]: second
                .
                <p><a href="first">foo</a></p>
                .
            */

            this.Setup(
                "[foo]",
                "",
                "[foo]: first",
                "[foo]: second");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 119 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample119()
        {
            /* Specification Example:
                .
                [FOO]: /url
                
                [Foo]
                .
                <p><a href="/url">Foo</a></p>
                .
            */

            this.Setup(
                "[FOO]: /url",
                "",
                "[Foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 120 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample120()
        {
            /* Specification Example:
                .
                [ΑΓΩ]: /φου
                
                [αγω]
                .
                <p><a href="/%CF%86%CE%BF%CF%85">αγω</a></p>
                .
            */

            this.Setup(
                "[ΑΓΩ]: /φου",
                "",
                "[αγω]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 121 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample121()
        {
            /* Specification Example:
                .
                [foo]: /url
                .
                .
            */

            this.Setup(
                "[foo]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 122 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample122()
        {
            /* Specification Example:
                .
                [foo]: /url "title" ok
                .
                <p>[foo]: /url &quot;title&quot; ok</p>
                .
            */

            this.Setup(
                "[foo]: /url \"title\" ok");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]: /url &quot;title&quot; ok" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 123 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample123()
        {
            /* Specification Example:
                .
                    [foo]: /url "title"
                
                [foo]
                .
                <pre><code>[foo]: /url &quot;title&quot;
                </code></pre>
                <p>[foo]</p>
                .
            */

            this.Setup(
                "    [foo]: /url \"title\"",
                "",
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "[foo]: /url &quot;title&quot;" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 124 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample124()
        {
            /* Specification Example:
                .
                ```
                [foo]: /url
                ```
                
                [foo]
                .
                <pre><code>[foo]: /url
                </code></pre>
                <p>[foo]</p>
                .
            */

            this.Setup(
                "```",
                "[foo]: /url",
                "```",
                "",
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "[foo]: /url" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 125 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample125()
        {
            /* Specification Example:
                .
                Foo
                [bar]: /baz
                
                [bar]
                .
                <p>Foo
                [bar]: /baz</p>
                <p>[bar]</p>
                .
            */

            this.Setup(
                "Foo",
                "[bar]: /baz",
                "",
                "[bar]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Text) { Text = "[bar]: /baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[bar]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 126 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample126()
        {
            /* Specification Example:
                .
                # [Foo]
                [foo]: /url
                > bar
                .
                <h1><a href="/url">Foo</a></h1>
                <blockquote>
                <p>bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "# [Foo]",
                "[foo]: /url",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 127 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample127()
        {
            /* Specification Example:
                .
                [foo]: /foo-url "foo"
                [bar]: /bar-url
                  "bar"
                [baz]: /baz-url
                
                [foo],
                [bar],
                [baz]
                .
                <p><a href="/foo-url" title="foo">foo</a>,
                <a href="/bar-url" title="bar">bar</a>,
                <a href="/baz-url">baz</a></p>
                .
            */

            this.Setup(
                "[foo]: /foo-url \"foo\"",
                "[bar]: /bar-url",
                "  \"bar\"",
                "[baz]: /baz-url",
                "",
                "[foo],",
                "[bar],",
                "[baz]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 128 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks07LinkReferenceDefinitionsExample128()
        {
            /* Specification Example:
                .
                [foo]
                
                > [foo]: /url
                .
                <p><a href="/url">foo</a></p>
                <blockquote>
                </blockquote>
                .
            */

            this.Setup(
                "[foo]",
                "",
                "> [foo]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

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
                "",
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
                "",
                "ccc",
                "ddd");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "ccc" },
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
                "",
                "",
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
                new Event(MarkupElementType.Text) { Text = "bbb" },
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
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 137 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks09BlankLinesExample137()
        {
            /* Specification Example:
                .
                  
                
                aaa
                  
                
                # aaa
                
                  
                .
                <p>aaa</p>
                <h1>aaa</h1>
                .
            */

            this.Setup(
                "  ",
                "",
                "aaa",
                "  ",
                "",
                "# aaa",
                "",
                "  ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 138 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample138()
        {
            /* Specification Example:
                .
                > # Foo
                > bar
                > baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "> # Foo",
                "> bar",
                "> baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 139 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample139()
        {
            /* Specification Example:
                .
                ># Foo
                >bar
                > baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "># Foo",
                ">bar",
                "> baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 140 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample140()
        {
            /* Specification Example:
                .
                   > # Foo
                   > bar
                 > baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "   > # Foo",
                "   > bar",
                " > baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 141 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample141()
        {
            /* Specification Example:
                .
                    > # Foo
                    > bar
                    > baz
                .
                <pre><code>&gt; # Foo
                &gt; bar
                &gt; baz
                </code></pre>
                .
            */

            this.Setup(
                "    > # Foo",
                "    > bar",
                "    > baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "&gt; # Foo" },
                new Event(MarkupElementType.Text) { Text = "&gt; bar" },
                new Event(MarkupElementType.Text) { Text = "&gt; baz" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 142 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample142()
        {
            /* Specification Example:
                .
                > # Foo
                > bar
                baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "> # Foo",
                "> bar",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 143 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample143()
        {
            /* Specification Example:
                .
                > bar
                baz
                > foo
                .
                <blockquote>
                <p>bar
                baz
                foo</p>
                </blockquote>
                .
            */

            this.Setup(
                "> bar",
                "baz",
                "> foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 144 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample144()
        {
            /* Specification Example:
                .
                > foo
                ---
                .
                <blockquote>
                <p>foo</p>
                </blockquote>
                <hr />
                .
            */

            this.Setup(
                "> foo",
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 145 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample145()
        {
            /* Specification Example:
                .
                > - foo
                - bar
                .
                <blockquote>
                <ul>
                <li>foo</li>
                </ul>
                </blockquote>
                <ul>
                <li>bar</li>
                </ul>
                .
            */

            this.Setup(
                "> - foo",
                "- bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 146 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample146()
        {
            /* Specification Example:
                .
                >     foo
                    bar
                .
                <blockquote>
                <pre><code>foo
                </code></pre>
                </blockquote>
                <pre><code>bar
                </code></pre>
                .
            */

            this.Setup(
                ">     foo",
                "    bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 147 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample147()
        {
            /* Specification Example:
                .
                > ```
                foo
                ```
                .
                <blockquote>
                <pre><code></code></pre>
                </blockquote>
                <p>foo</p>
                <pre><code></code></pre>
                .
            */

            this.Setup(
                "> ```",
                "foo",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 148 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample148()
        {
            /* Specification Example:
                .
                >
                .
                <blockquote>
                </blockquote>
                .
            */

            this.Setup(
                ">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 149 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample149()
        {
            /* Specification Example:
                .
                >
                >  
                > 
                .
                <blockquote>
                </blockquote>
                .
            */

            this.Setup(
                ">",
                ">  ",
                "> ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 150 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample150()
        {
            /* Specification Example:
                .
                >
                > foo
                >  
                .
                <blockquote>
                <p>foo</p>
                </blockquote>
                .
            */

            this.Setup(
                ">",
                "> foo",
                ">  ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 151 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample151()
        {
            /* Specification Example:
                .
                > foo
                
                > bar
                .
                <blockquote>
                <p>foo</p>
                </blockquote>
                <blockquote>
                <p>bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "> foo",
                "",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 152 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample152()
        {
            /* Specification Example:
                .
                > foo
                > bar
                .
                <blockquote>
                <p>foo
                bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "> foo",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 153 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample153()
        {
            /* Specification Example:
                .
                > foo
                >
                > bar
                .
                <blockquote>
                <p>foo</p>
                <p>bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "> foo",
                ">",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 154 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample154()
        {
            /* Specification Example:
                .
                foo
                > bar
                .
                <p>foo</p>
                <blockquote>
                <p>bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "foo",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 155 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample155()
        {
            /* Specification Example:
                .
                > aaa
                ***
                > bbb
                .
                <blockquote>
                <p>aaa</p>
                </blockquote>
                <hr />
                <blockquote>
                <p>bbb</p>
                </blockquote>
                .
            */

            this.Setup(
                "> aaa",
                "***",
                "> bbb");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 156 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample156()
        {
            /* Specification Example:
                .
                > bar
                baz
                .
                <blockquote>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "> bar",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 157 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample157()
        {
            /* Specification Example:
                .
                > bar
                
                baz
                .
                <blockquote>
                <p>bar</p>
                </blockquote>
                <p>baz</p>
                .
            */

            this.Setup(
                "> bar",
                "",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 158 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample158()
        {
            /* Specification Example:
                .
                > bar
                >
                baz
                .
                <blockquote>
                <p>bar</p>
                </blockquote>
                <p>baz</p>
                .
            */

            this.Setup(
                "> bar",
                ">",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 159 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample159()
        {
            /* Specification Example:
                .
                > > > foo
                bar
                .
                <blockquote>
                <blockquote>
                <blockquote>
                <p>foo
                bar</p>
                </blockquote>
                </blockquote>
                </blockquote>
                .
            */

            this.Setup(
                "> > > foo",
                "bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 160 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample160()
        {
            /* Specification Example:
                .
                >>> foo
                > bar
                >>baz
                .
                <blockquote>
                <blockquote>
                <blockquote>
                <p>foo
                bar
                baz</p>
                </blockquote>
                </blockquote>
                </blockquote>
                .
            */

            this.Setup(
                ">>> foo",
                "> bar",
                ">>baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 161 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample161()
        {
            /* Specification Example:
                .
                >     code
                
                >    not code
                .
                <blockquote>
                <pre><code>code
                </code></pre>
                </blockquote>
                <blockquote>
                <p>not code</p>
                </blockquote>
                .
            */

            this.Setup(
                ">     code",
                "",
                ">    not code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "not code" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 162 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample162()
        {
            /* Specification Example:
                .
                A paragraph
                with two lines.
                
                    indented code
                
                > A block quote.
                .
                <p>A paragraph
                with two lines.</p>
                <pre><code>indented code
                </code></pre>
                <blockquote>
                <p>A block quote.</p>
                </blockquote>
                .
            */

            this.Setup(
                "A paragraph",
                "with two lines.",
                "",
                "    indented code",
                "",
                "> A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 163 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample163()
        {
            /* Specification Example:
                .
                1.  A paragraph
                    with two lines.
                
                        indented code
                
                    > A block quote.
                .
                <ol>
                <li>
                <p>A paragraph
                with two lines.</p>
                <pre><code>indented code
                </code></pre>
                <blockquote>
                <p>A block quote.</p>
                </blockquote>
                </li>
                </ol>
                .
            */

            this.Setup(
                "1.  A paragraph",
                "    with two lines.",
                "",
                "        indented code",
                "",
                "    > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 164 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample164()
        {
            /* Specification Example:
                .
                - one
                
                 two
                .
                <ul>
                <li>one</li>
                </ul>
                <p>two</p>
                .
            */

            this.Setup(
                "- one",
                "",
                " two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 165 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample165()
        {
            /* Specification Example:
                .
                - one
                
                  two
                .
                <ul>
                <li>
                <p>one</p>
                <p>two</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- one",
                "",
                "  two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 166 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample166()
        {
            /* Specification Example:
                .
                 -    one
                
                     two
                .
                <ul>
                <li>one</li>
                </ul>
                <pre><code> two
                </code></pre>
                .
            */

            this.Setup(
                " -    one",
                "",
                "     two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = " two" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 167 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample167()
        {
            /* Specification Example:
                .
                 -    one
                
                      two
                .
                <ul>
                <li>
                <p>one</p>
                <p>two</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                " -    one",
                "",
                "      two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 168 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample168()
        {
            /* Specification Example:
                .
                   > > 1.  one
                >>
                >>     two
                .
                <blockquote>
                <blockquote>
                <ol>
                <li>
                <p>one</p>
                <p>two</p>
                </li>
                </ol>
                </blockquote>
                </blockquote>
                .
            */

            this.Setup(
                "   > > 1.  one",
                ">>",
                ">>     two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 169 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample169()
        {
            /* Specification Example:
                .
                >>- one
                >>
                  >  > two
                .
                <blockquote>
                <blockquote>
                <ul>
                <li>one</li>
                </ul>
                <p>two</p>
                </blockquote>
                </blockquote>
                .
            */

            this.Setup(
                ">>- one",
                ">>",
                "  >  > two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 170 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample170()
        {
            /* Specification Example:
                .
                - foo
                
                  bar
                
                - foo
                
                
                  bar
                
                - ```
                  foo
                
                
                  bar
                  ```
                .
                <ul>
                <li>
                <p>foo</p>
                <p>bar</p>
                </li>
                <li>
                <p>foo</p>
                </li>
                </ul>
                <p>bar</p>
                <ul>
                <li>
                <pre><code>foo
                
                
                bar
                </code></pre>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "",
                "  bar",
                "",
                "- foo",
                "",
                "",
                "  bar",
                "",
                "- ```",
                "  foo",
                "",
                "",
                "  bar",
                "  ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 171 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample171()
        {
            /* Specification Example:
                .
                1.  foo
                
                    ```
                    bar
                    ```
                
                    baz
                
                    > bam
                .
                <ol>
                <li>
                <p>foo</p>
                <pre><code>bar
                </code></pre>
                <p>baz</p>
                <blockquote>
                <p>bam</p>
                </blockquote>
                </li>
                </ol>
                .
            */

            this.Setup(
                "1.  foo",
                "",
                "    ```",
                "    bar",
                "    ```",
                "",
                "    baz",
                "",
                "    > bam");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bam" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 172 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample172()
        {
            /* Specification Example:
                .
                - foo
                
                      bar
                .
                <ul>
                <li>
                <p>foo</p>
                <pre><code>bar
                </code></pre>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "",
                "      bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 173 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample173()
        {
            /* Specification Example:
                .
                  10.  foo
                
                           bar
                .
                <ol start="10">
                <li>
                <p>foo</p>
                <pre><code>bar
                </code></pre>
                </li>
                </ol>
                .
            */

            this.Setup(
                "  10.  foo",
                "",
                "           bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 174 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample174()
        {
            /* Specification Example:
                .
                    indented code
                
                paragraph
                
                    more code
                .
                <pre><code>indented code
                </code></pre>
                <p>paragraph</p>
                <pre><code>more code
                </code></pre>
                .
            */

            this.Setup(
                "    indented code",
                "",
                "paragraph",
                "",
                "    more code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "paragraph" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "more code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 175 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample175()
        {
            /* Specification Example:
                .
                1.     indented code
                
                   paragraph
                
                       more code
                .
                <ol>
                <li>
                <pre><code>indented code
                </code></pre>
                <p>paragraph</p>
                <pre><code>more code
                </code></pre>
                </li>
                </ol>
                .
            */

            this.Setup(
                "1.     indented code",
                "",
                "   paragraph",
                "",
                "       more code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "paragraph" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "more code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 176 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample176()
        {
            /* Specification Example:
                .
                1.      indented code
                
                   paragraph
                
                       more code
                .
                <ol>
                <li>
                <pre><code> indented code
                </code></pre>
                <p>paragraph</p>
                <pre><code>more code
                </code></pre>
                </li>
                </ol>
                .
            */

            this.Setup(
                "1.      indented code",
                "",
                "   paragraph",
                "",
                "       more code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = " indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "paragraph" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "more code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 177 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample177()
        {
            /* Specification Example:
                .
                   foo
                
                bar
                .
                <p>foo</p>
                <p>bar</p>
                .
            */

            this.Setup(
                "   foo",
                "",
                "bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 178 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample178()
        {
            /* Specification Example:
                .
                -    foo
                
                  bar
                .
                <ul>
                <li>foo</li>
                </ul>
                <p>bar</p>
                .
            */

            this.Setup(
                "-    foo",
                "",
                "  bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 179 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample179()
        {
            /* Specification Example:
                .
                -  foo
                
                   bar
                .
                <ul>
                <li>
                <p>foo</p>
                <p>bar</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "-  foo",
                "",
                "   bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 180 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample180()
        {
            /* Specification Example:
                .
                 1.  A paragraph
                     with two lines.
                
                         indented code
                
                     > A block quote.
                .
                <ol>
                <li>
                <p>A paragraph
                with two lines.</p>
                <pre><code>indented code
                </code></pre>
                <blockquote>
                <p>A block quote.</p>
                </blockquote>
                </li>
                </ol>
                .
            */

            this.Setup(
                " 1.  A paragraph",
                "     with two lines.",
                "",
                "         indented code",
                "",
                "     > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 181 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample181()
        {
            /* Specification Example:
                .
                  1.  A paragraph
                      with two lines.
                
                          indented code
                
                      > A block quote.
                .
                <ol>
                <li>
                <p>A paragraph
                with two lines.</p>
                <pre><code>indented code
                </code></pre>
                <blockquote>
                <p>A block quote.</p>
                </blockquote>
                </li>
                </ol>
                .
            */

            this.Setup(
                "  1.  A paragraph",
                "      with two lines.",
                "",
                "          indented code",
                "",
                "      > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 182 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample182()
        {
            /* Specification Example:
                .
                   1.  A paragraph
                       with two lines.
                
                           indented code
                
                       > A block quote.
                .
                <ol>
                <li>
                <p>A paragraph
                with two lines.</p>
                <pre><code>indented code
                </code></pre>
                <blockquote>
                <p>A block quote.</p>
                </blockquote>
                </li>
                </ol>
                .
            */

            this.Setup(
                "   1.  A paragraph",
                "       with two lines.",
                "",
                "           indented code",
                "",
                "       > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 183 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample183()
        {
            /* Specification Example:
                .
                    1.  A paragraph
                        with two lines.
                
                            indented code
                
                        > A block quote.
                .
                <pre><code>1.  A paragraph
                    with two lines.
                
                        indented code
                
                    &gt; A block quote.
                </code></pre>
                .
            */

            this.Setup(
                "    1.  A paragraph",
                "        with two lines.",
                "",
                "            indented code",
                "",
                "        > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "1.  A paragraph" },
                new Event(MarkupElementType.Text) { Text = "    with two lines." },
                new Event(MarkupElementType.Text) { Text = "        indented code" },
                new Event(MarkupElementType.Text) { Text = "    &gt; A block quote." },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 184 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample184()
        {
            /* Specification Example:
                .
                  1.  A paragraph
                with two lines.
                
                          indented code
                
                      > A block quote.
                .
                <ol>
                <li>
                <p>A paragraph
                with two lines.</p>
                <pre><code>indented code
                </code></pre>
                <blockquote>
                <p>A block quote.</p>
                </blockquote>
                </li>
                </ol>
                .
            */

            this.Setup(
                "  1.  A paragraph",
                "with two lines.",
                "",
                "          indented code",
                "",
                "      > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 185 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample185()
        {
            /* Specification Example:
                .
                  1.  A paragraph
                    with two lines.
                .
                <ol>
                <li>A paragraph
                with two lines.</li>
                </ol>
                .
            */

            this.Setup(
                "  1.  A paragraph",
                "    with two lines.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 186 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample186()
        {
            /* Specification Example:
                .
                > 1. > Blockquote
                continued here.
                .
                <blockquote>
                <ol>
                <li>
                <blockquote>
                <p>Blockquote
                continued here.</p>
                </blockquote>
                </li>
                </ol>
                </blockquote>
                .
            */

            this.Setup(
                "> 1. > Blockquote",
                "continued here.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Blockquote" },
                new Event(MarkupElementType.Text) { Text = "continued here." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 187 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample187()
        {
            /* Specification Example:
                .
                > 1. > Blockquote
                > continued here.
                .
                <blockquote>
                <ol>
                <li>
                <blockquote>
                <p>Blockquote
                continued here.</p>
                </blockquote>
                </li>
                </ol>
                </blockquote>
                .
            */

            this.Setup(
                "> 1. > Blockquote",
                "> continued here.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Blockquote" },
                new Event(MarkupElementType.Text) { Text = "continued here." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 188 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample188()
        {
            /* Specification Example:
                .
                - foo
                  - bar
                    - baz
                .
                <ul>
                <li>foo
                <ul>
                <li>bar
                <ul>
                <li>baz</li>
                </ul>
                </li>
                </ul>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "  - bar",
                "    - baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 189 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample189()
        {
            /* Specification Example:
                .
                - foo
                 - bar
                  - baz
                .
                <ul>
                <li>foo</li>
                <li>bar</li>
                <li>baz</li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                " - bar",
                "  - baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 190 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample190()
        {
            /* Specification Example:
                .
                10) foo
                    - bar
                .
                <ol start="10">
                <li>foo
                <ul>
                <li>bar</li>
                </ul>
                </li>
                </ol>
                .
            */

            this.Setup(
                "10) foo",
                "    - bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 191 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample191()
        {
            /* Specification Example:
                .
                10) foo
                   - bar
                .
                <ol start="10">
                <li>foo</li>
                </ol>
                <ul>
                <li>bar</li>
                </ul>
                .
            */

            this.Setup(
                "10) foo",
                "   - bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 192 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample192()
        {
            /* Specification Example:
                .
                - - foo
                .
                <ul>
                <li>
                <ul>
                <li>foo</li>
                </ul>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- - foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 193 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample193()
        {
            /* Specification Example:
                .
                1. - 2. foo
                .
                <ol>
                <li>
                <ul>
                <li>
                <ol start="2">
                <li>foo</li>
                </ol>
                </li>
                </ul>
                </li>
                </ol>
                .
            */

            this.Setup(
                "1. - 2. foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 194 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample194()
        {
            /* Specification Example:
                .
                - foo
                -
                - bar
                .
                <ul>
                <li>foo</li>
                <li></li>
                <li>bar</li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "-",
                "- bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 195 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample195()
        {
            /* Specification Example:
                .
                -
                .
                <ul>
                <li></li>
                </ul>
                .
            */

            this.Setup(
                "-");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 196 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks02ListItemsExample196()
        {
            /* Specification Example:
                .
                - # Foo
                - Bar
                  ---
                  baz
                .
                <ul>
                <li>
                <h1>Foo</h1>
                </li>
                <li>
                <h2>Bar</h2>
                <p>baz</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- # Foo",
                "- Bar",
                "  ---",
                "  baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 197 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample197()
        {
            /* Specification Example:
                .
                - foo
                - bar
                + baz
                .
                <ul>
                <li>foo</li>
                <li>bar</li>
                </ul>
                <ul>
                <li>baz</li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "- bar",
                "+ baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 198 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample198()
        {
            /* Specification Example:
                .
                1. foo
                2. bar
                3) baz
                .
                <ol>
                <li>foo</li>
                <li>bar</li>
                </ol>
                <ol start="3">
                <li>baz</li>
                </ol>
                .
            */

            this.Setup(
                "1. foo",
                "2. bar",
                "3) baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 199 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample199()
        {
            /* Specification Example:
                .
                Foo
                - bar
                - baz
                .
                <p>Foo</p>
                <ul>
                <li>bar</li>
                <li>baz</li>
                </ul>
                .
            */

            this.Setup(
                "Foo",
                "- bar",
                "- baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 200 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample200()
        {
            /* Specification Example:
                .
                The number of windows in my house is
                14.  The number of doors is 6.
                .
                <p>The number of windows in my house is</p>
                <ol start="14">
                <li>The number of doors is 6.</li>
                </ol>
                .
            */

            this.Setup(
                "The number of windows in my house is",
                "14.  The number of doors is 6.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "The number of windows in my house is" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 201 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample201()
        {
            /* Specification Example:
                .
                - foo
                
                - bar
                
                
                - baz
                .
                <ul>
                <li>
                <p>foo</p>
                </li>
                <li>
                <p>bar</p>
                </li>
                </ul>
                <ul>
                <li>baz</li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "",
                "- bar",
                "",
                "",
                "- baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 202 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample202()
        {
            /* Specification Example:
                .
                - foo
                
                
                  bar
                - baz
                .
                <ul>
                <li>foo</li>
                </ul>
                <p>bar</p>
                <ul>
                <li>baz</li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "",
                "",
                "  bar",
                "- baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 203 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample203()
        {
            /* Specification Example:
                .
                - foo
                  - bar
                    - baz
                
                
                      bim
                .
                <ul>
                <li>foo
                <ul>
                <li>bar
                <ul>
                <li>baz</li>
                </ul>
                </li>
                </ul>
                </li>
                </ul>
                <pre><code>  bim
                </code></pre>
                .
            */

            this.Setup(
                "- foo",
                "  - bar",
                "    - baz",
                "",
                "",
                "      bim");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "  bim" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 204 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample204()
        {
            /* Specification Example:
                .
                - foo
                - bar
                
                
                - baz
                - bim
                .
                <ul>
                <li>foo</li>
                <li>bar</li>
                </ul>
                <ul>
                <li>baz</li>
                <li>bim</li>
                </ul>
                .
            */

            this.Setup(
                "- foo",
                "- bar",
                "",
                "",
                "- baz",
                "- bim");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 205 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample205()
        {
            /* Specification Example:
                .
                -   foo
                
                    notcode
                
                -   foo
                
                
                    code
                .
                <ul>
                <li>
                <p>foo</p>
                <p>notcode</p>
                </li>
                <li>
                <p>foo</p>
                </li>
                </ul>
                <pre><code>code
                </code></pre>
                .
            */

            this.Setup(
                "-   foo",
                "",
                "    notcode",
                "",
                "-   foo",
                "",
                "",
                "    code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "notcode" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "code" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 206 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample206()
        {
            /* Specification Example:
                .
                - a
                 - b
                  - c
                   - d
                  - e
                 - f
                - g
                .
                <ul>
                <li>a</li>
                <li>b</li>
                <li>c</li>
                <li>d</li>
                <li>e</li>
                <li>f</li>
                <li>g</li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                " - b",
                "  - c",
                "   - d",
                "  - e",
                " - f",
                "- g");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 207 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample207()
        {
            /* Specification Example:
                .
                - a
                - b
                
                - c
                .
                <ul>
                <li>
                <p>a</p>
                </li>
                <li>
                <p>b</p>
                </li>
                <li>
                <p>c</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "- b",
                "",
                "- c");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 208 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample208()
        {
            /* Specification Example:
                .
                * a
                *
                
                * c
                .
                <ul>
                <li>
                <p>a</p>
                </li>
                <li></li>
                <li>
                <p>c</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "* a",
                "*",
                "",
                "* c");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 209 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample209()
        {
            /* Specification Example:
                .
                - a
                - b
                
                  c
                - d
                .
                <ul>
                <li>
                <p>a</p>
                </li>
                <li>
                <p>b</p>
                <p>c</p>
                </li>
                <li>
                <p>d</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "- b",
                "",
                "  c",
                "- d");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 210 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample210()
        {
            /* Specification Example:
                .
                - a
                - b
                
                  [ref]: /url
                - d
                .
                <ul>
                <li>
                <p>a</p>
                </li>
                <li>
                <p>b</p>
                </li>
                <li>
                <p>d</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "- b",
                "",
                "  [ref]: /url",
                "- d");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 211 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample211()
        {
            /* Specification Example:
                .
                - a
                - ```
                  b
                
                
                  ```
                - c
                .
                <ul>
                <li>a</li>
                <li>
                <pre><code>b
                
                
                </code></pre>
                </li>
                <li>c</li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "- ```",
                "  b",
                "",
                "",
                "  ```",
                "- c");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 212 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample212()
        {
            /* Specification Example:
                .
                - a
                  - b
                
                    c
                - d
                .
                <ul>
                <li>a
                <ul>
                <li>
                <p>b</p>
                <p>c</p>
                </li>
                </ul>
                </li>
                <li>d</li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "  - b",
                "",
                "    c",
                "- d");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 213 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample213()
        {
            /* Specification Example:
                .
                * a
                  > b
                  >
                * c
                .
                <ul>
                <li>a
                <blockquote>
                <p>b</p>
                </blockquote>
                </li>
                <li>c</li>
                </ul>
                .
            */

            this.Setup(
                "* a",
                "  > b",
                "  >",
                "* c");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 214 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample214()
        {
            /* Specification Example:
                .
                - a
                  > b
                  ```
                  c
                  ```
                - d
                .
                <ul>
                <li>a
                <blockquote>
                <p>b</p>
                </blockquote>
                <pre><code>c
                </code></pre>
                </li>
                <li>d</li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "  > b",
                "  ```",
                "  c",
                "  ```",
                "- d");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 215 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample215()
        {
            /* Specification Example:
                .
                - a
                .
                <ul>
                <li>a</li>
                </ul>
                .
            */

            this.Setup(
                "- a");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 216 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample216()
        {
            /* Specification Example:
                .
                - a
                  - b
                .
                <ul>
                <li>a
                <ul>
                <li>b</li>
                </ul>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "  - b");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 217 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample217()
        {
            /* Specification Example:
                .
                * foo
                  * bar
                
                  baz
                .
                <ul>
                <li>
                <p>foo</p>
                <ul>
                <li>bar</li>
                </ul>
                <p>baz</p>
                </li>
                </ul>
                .
            */

            this.Setup(
                "* foo",
                "  * bar",
                "",
                "  baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 218 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark05ContainerBlocks03ListsExample218()
        {
            /* Specification Example:
                .
                - a
                  - b
                  - c
                
                - d
                  - e
                  - f
                .
                <ul>
                <li>
                <p>a</p>
                <ul>
                <li>b</li>
                <li>c</li>
                </ul>
                </li>
                <li>
                <p>d</p>
                <ul>
                <li>e</li>
                <li>f</li>
                </ul>
                </li>
                </ul>
                .
            */

            this.Setup(
                "- a",
                "  - b",
                "  - c",
                "",
                "- d",
                "  - e",
                "  - f");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 219 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines00ListsExample219()
        {
            /* Specification Example:
                .
                `hi`lo`
                .
                <p><code>hi</code>lo`</p>
                .
            */

            this.Setup(
                "`hi`lo`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 220 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample220()
        {
            /* Specification Example:
                .
                \!\"\#\$\%\&\'\(\)\*\+\,\-\.\/\:\;\<\=\>\?\@\[\\\]\^\_\`\{\|\}\~
                .
                <p>!&quot;#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~</p>
                .
            */

            this.Setup(
                "\\!\\\"\\#\\$\\%\\&\\'\\(\\)\\*\\+\\,\\-\\.\\/\\:\\;\\<\\=\\>\\?\\@\\[\\\\\\]\\^\\_\\`\\{\\|\\}\\~");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "!&quot;#$%&amp;'()*+,-./:;&lt;=&gt;?@[\\]^_`{|}~" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 221 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample221()
        {
            /* Specification Example:
                .
                \→\A\a\ \3\φ\«
                .
                <p>\   \A\a\ \3\φ\«</p>
                .
            */

            this.Setup(
                "\\\t\\A\\a\\ \\3\\φ\\«");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "\\   \\A\\a\\ \\3\\φ\\«" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 222 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample222()
        {
            /* Specification Example:
                .
                \*not emphasized*
                \<br/> not a tag
                \[not a link](/foo)
                \`not code`
                1\. not a list
                \* not a list
                \# not a header
                \[foo]: /url "not a reference"
                .
                <p>*not emphasized*
                &lt;br/&gt; not a tag
                [not a link](/foo)
                `not code`
                1. not a list
                * not a list
                # not a header
                [foo]: /url &quot;not a reference&quot;</p>
                .
            */

            this.Setup(
                "\\*not emphasized*",
                "\\<br/> not a tag",
                "\\[not a link](/foo)",
                "\\`not code`",
                "1\\. not a list",
                "\\* not a list",
                "\\# not a header",
                "\\[foo]: /url \"not a reference\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*not emphasized*" },
                new Event(MarkupElementType.Text) { Text = "&lt;br/&gt; not a tag" },
                new Event(MarkupElementType.Text) { Text = "[not a link](/foo)" },
                new Event(MarkupElementType.Text) { Text = "`not code`" },
                new Event(MarkupElementType.Text) { Text = "1. not a list" },
                new Event(MarkupElementType.Text) { Text = "* not a list" },
                new Event(MarkupElementType.Text) { Text = "# not a header" },
                new Event(MarkupElementType.Text) { Text = "[foo]: /url &quot;not a reference&quot;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 223 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample223()
        {
            /* Specification Example:
                .
                \\*emphasis*
                .
                <p>\<em>emphasis</em></p>
                .
            */

            this.Setup(
                "\\\\*emphasis*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "\\" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 224 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample224()
        {
            /* Specification Example:
                .
                foo\
                bar
                .
                <p>foo<br />
                bar</p>
                .
            */

            this.Setup(
                "foo\\",
                "bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 225 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample225()
        {
            /* Specification Example:
                .
                `` \[\` ``
                .
                <p><code>\[\`</code></p>
                .
            */

            this.Setup(
                "`` \\[\\` ``");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 226 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample226()
        {
            /* Specification Example:
                .
                    \[\]
                .
                <pre><code>\[\]
                </code></pre>
                .
            */

            this.Setup(
                "    \\[\\]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "\\[\\]" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 227 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample227()
        {
            /* Specification Example:
                .
                ~~~
                \[\]
                ~~~
                .
                <pre><code>\[\]
                </code></pre>
                .
            */

            this.Setup(
                "~~~",
                "\\[\\]",
                "~~~");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "\\[\\]" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 228 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample228()
        {
            /* Specification Example:
                .
                <http://example.com?find=\*>
                .
                <p><a href="http://example.com?find=%5C*">http://example.com?find=\*</a></p>
                .
            */

            this.Setup(
                "<http://example.com?find=\\*>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 229 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample229()
        {
            /* Specification Example:
                .
                <a href="/bar\/)">
                .
                <p><a href="/bar\/)"></p>
                .
            */

            this.Setup(
                "<a href=\"/bar\\/)\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 230 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample230()
        {
            /* Specification Example:
                .
                [foo](/bar\* "ti\*tle")
                .
                <p><a href="/bar*" title="ti*tle">foo</a></p>
                .
            */

            this.Setup(
                "[foo](/bar\\* \"ti\\*tle\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 231 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample231()
        {
            /* Specification Example:
                .
                [foo]
                
                [foo]: /bar\* "ti\*tle"
                .
                <p><a href="/bar*" title="ti*tle">foo</a></p>
                .
            */

            this.Setup(
                "[foo]",
                "",
                "[foo]: /bar\\* \"ti\\*tle\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 232 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample232()
        {
            /* Specification Example:
                .
                ``` foo\+bar
                foo
                ```
                .
                <pre><code class="language-foo+bar">foo
                </code></pre>
                .
            */

            this.Setup(
                "``` foo\\+bar",
                "foo",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 233 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample233()
        {
            /* Specification Example:
                .
                &nbsp; &amp; &copy; &AElig; &Dcaron; &frac34; &HilbertSpace; &DifferentialD; &ClockwiseContourIntegral;
                .
                <p>  &amp; © Æ Ď ¾ ℋ ⅆ ∲</p>
                .
            */

            this.Setup(
                "&nbsp; &amp; &copy; &AElig; &Dcaron; &frac34; &HilbertSpace; &DifferentialD; &ClockwiseContourIntegral;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "  &amp; © Æ Ď ¾ ℋ ⅆ ∲" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 234 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample234()
        {
            /* Specification Example:
                .
                &#35; &#1234; &#992; &#98765432;
                .
                <p># Ӓ Ϡ �</p>
                .
            */

            this.Setup(
                "&#35; &#1234; &#992; &#98765432;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "# Ӓ Ϡ �" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 235 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample235()
        {
            /* Specification Example:
                .
                &#X22; &#XD06; &#xcab;
                .
                <p>&quot; ആ ಫ</p>
                .
            */

            this.Setup(
                "&#X22; &#XD06; &#xcab;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&quot; ആ ಫ" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 236 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample236()
        {
            /* Specification Example:
                .
                &nbsp &x; &#; &#x; &ThisIsWayTooLongToBeAnEntityIsntIt; &hi?;
                .
                <p>&amp;nbsp &amp;x; &amp;#; &amp;#x; &amp;ThisIsWayTooLongToBeAnEntityIsntIt; &amp;hi?;</p>
                .
            */

            this.Setup(
                "&nbsp &x; &#; &#x; &ThisIsWayTooLongToBeAnEntityIsntIt; &hi?;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&amp;nbsp &amp;x; &amp;#; &amp;#x; &amp;ThisIsWayTooLongToBeAnEntityIsntIt; &amp;hi?;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 237 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample237()
        {
            /* Specification Example:
                .
                &copy
                .
                <p>&amp;copy</p>
                .
            */

            this.Setup(
                "&copy");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&amp;copy" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 238 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample238()
        {
            /* Specification Example:
                .
                &MadeUpEntity;
                .
                <p>&amp;MadeUpEntity;</p>
                .
            */

            this.Setup(
                "&MadeUpEntity;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&amp;MadeUpEntity;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 239 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample239()
        {
            /* Specification Example:
                .
                <a href="&ouml;&ouml;.html">
                .
                <p><a href="&ouml;&ouml;.html"></p>
                .
            */

            this.Setup(
                "<a href=\"&ouml;&ouml;.html\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 240 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample240()
        {
            /* Specification Example:
                .
                [foo](/f&ouml;&ouml; "f&ouml;&ouml;")
                .
                <p><a href="/f%C3%B6%C3%B6" title="föö">foo</a></p>
                .
            */

            this.Setup(
                "[foo](/f&ouml;&ouml; \"f&ouml;&ouml;\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 241 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample241()
        {
            /* Specification Example:
                .
                [foo]
                
                [foo]: /f&ouml;&ouml; "f&ouml;&ouml;"
                .
                <p><a href="/f%C3%B6%C3%B6" title="föö">foo</a></p>
                .
            */

            this.Setup(
                "[foo]",
                "",
                "[foo]: /f&ouml;&ouml; \"f&ouml;&ouml;\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 242 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample242()
        {
            /* Specification Example:
                .
                ``` f&ouml;&ouml;
                foo
                ```
                .
                <pre><code class="language-föö">foo
                </code></pre>
                .
            */

            this.Setup(
                "``` f&ouml;&ouml;",
                "foo",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 243 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample243()
        {
            /* Specification Example:
                .
                `f&ouml;&ouml;`
                .
                <p><code>f&amp;ouml;&amp;ouml;</code></p>
                .
            */

            this.Setup(
                "`f&ouml;&ouml;`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 244 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample244()
        {
            /* Specification Example:
                .
                    f&ouml;f&ouml;
                .
                <pre><code>f&amp;ouml;f&amp;ouml;
                </code></pre>
                .
            */

            this.Setup(
                "    f&ouml;f&ouml;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "f&amp;ouml;f&amp;ouml;" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 245 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample245()
        {
            /* Specification Example:
                .
                `foo`
                .
                <p><code>foo</code></p>
                .
            */

            this.Setup(
                "`foo`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 246 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample246()
        {
            /* Specification Example:
                .
                `` foo ` bar  ``
                .
                <p><code>foo ` bar</code></p>
                .
            */

            this.Setup(
                "`` foo ` bar  ``");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 247 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample247()
        {
            /* Specification Example:
                .
                ` `` `
                .
                <p><code>``</code></p>
                .
            */

            this.Setup(
                "` `` `");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 248 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample248()
        {
            /* Specification Example:
                .
                ``
                foo
                ``
                .
                <p><code>foo</code></p>
                .
            */

            this.Setup(
                "``",
                "foo",
                "``");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 249 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample249()
        {
            /* Specification Example:
                .
                `foo   bar
                  baz`
                .
                <p><code>foo bar baz</code></p>
                .
            */

            this.Setup(
                "`foo   bar",
                "  baz`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 250 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample250()
        {
            /* Specification Example:
                .
                `foo `` bar`
                .
                <p><code>foo `` bar</code></p>
                .
            */

            this.Setup(
                "`foo `` bar`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 251 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample251()
        {
            /* Specification Example:
                .
                `foo\`bar`
                .
                <p><code>foo\</code>bar`</p>
                .
            */

            this.Setup(
                "`foo\\`bar`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 252 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample252()
        {
            /* Specification Example:
                .
                *foo`*`
                .
                <p>*foo<code>*</code></p>
                .
            */

            this.Setup(
                "*foo`*`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 253 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample253()
        {
            /* Specification Example:
                .
                [not a `link](/foo`)
                .
                <p>[not a <code>link](/foo</code>)</p>
                .
            */

            this.Setup(
                "[not a `link](/foo`)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[not a " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 254 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample254()
        {
            /* Specification Example:
                .
                <http://foo.bar.`baz>`
                .
                <p><a href="http://foo.bar.%60baz">http://foo.bar.`baz</a>`</p>
                .
            */

            this.Setup(
                "<http://foo.bar.`baz>`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 255 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample255()
        {
            /* Specification Example:
                .
                <a href="`">`
                .
                <p><a href="`">`</p>
                .
            */

            this.Setup(
                "<a href=\"`\">`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 256 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample256()
        {
            /* Specification Example:
                .
                ```foo``
                .
                <p>```foo``</p>
                .
            */

            this.Setup(
                "```foo``");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "```foo``" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 257 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines03CodeSpanExample257()
        {
            /* Specification Example:
                .
                `foo
                .
                <p>`foo</p>
                .
            */

            this.Setup(
                "`foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "`foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 258 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample258()
        {
            /* Specification Example:
                .
                *foo bar*
                .
                <p><em>foo bar</em></p>
                .
            */

            this.Setup(
                "*foo bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 259 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample259()
        {
            /* Specification Example:
                .
                a * foo bar*
                .
                <p>a * foo bar*</p>
                .
            */

            this.Setup(
                "a * foo bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a * foo bar*" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 260 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample260()
        {
            /* Specification Example:
                .
                foo*bar*
                .
                <p>foo<em>bar</em></p>
                .
            */

            this.Setup(
                "foo*bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 261 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample261()
        {
            /* Specification Example:
                .
                5*6*78
                .
                <p>5<em>6</em>78</p>
                .
            */

            this.Setup(
                "5*6*78");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "5" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 262 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample262()
        {
            /* Specification Example:
                .
                _foo bar_
                .
                <p><em>foo bar</em></p>
                .
            */

            this.Setup(
                "_foo bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 263 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample263()
        {
            /* Specification Example:
                .
                _ foo bar_
                .
                <p>_ foo bar_</p>
                .
            */

            this.Setup(
                "_ foo bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_ foo bar_" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 264 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample264()
        {
            /* Specification Example:
                .
                foo_bar_
                .
                <p>foo_bar_</p>
                .
            */

            this.Setup(
                "foo_bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo_bar_" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 265 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample265()
        {
            /* Specification Example:
                .
                5_6_78
                .
                <p>5_6_78</p>
                .
            */

            this.Setup(
                "5_6_78");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "5_6_78" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 266 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample266()
        {
            /* Specification Example:
                .
                пристаням_стремятся_
                .
                <p>пристаням<em>стремятся</em></p>
                .
            */

            this.Setup(
                "пристаням_стремятся_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "пристаням" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 267 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample267()
        {
            /* Specification Example:
                .
                *foo bar *
                .
                <p>*foo bar *</p>
                .
            */

            this.Setup(
                "*foo bar *");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*foo bar *" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 268 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample268()
        {
            /* Specification Example:
                .
                *foo*bar
                .
                <p><em>foo</em>bar</p>
                .
            */

            this.Setup(
                "*foo*bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 269 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample269()
        {
            /* Specification Example:
                .
                _foo bar _
                .
                <p>_foo bar _</p>
                .
            */

            this.Setup(
                "_foo bar _");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_foo bar _" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 270 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample270()
        {
            /* Specification Example:
                .
                _foo_bar
                .
                <p>_foo_bar</p>
                .
            */

            this.Setup(
                "_foo_bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_foo_bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 271 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample271()
        {
            /* Specification Example:
                .
                _пристаням_стремятся
                .
                <p><em>пристаням</em>стремятся</p>
                .
            */

            this.Setup(
                "_пристаням_стремятся");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 272 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample272()
        {
            /* Specification Example:
                .
                _foo_bar_baz_
                .
                <p><em>foo_bar_baz</em></p>
                .
            */

            this.Setup(
                "_foo_bar_baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 273 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample273()
        {
            /* Specification Example:
                .
                **foo bar**
                .
                <p><strong>foo bar</strong></p>
                .
            */

            this.Setup(
                "**foo bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 274 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample274()
        {
            /* Specification Example:
                .
                ** foo bar**
                .
                <p>** foo bar**</p>
                .
            */

            this.Setup(
                "** foo bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "** foo bar**" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 275 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample275()
        {
            /* Specification Example:
                .
                foo**bar**
                .
                <p>foo<strong>bar</strong></p>
                .
            */

            this.Setup(
                "foo**bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 276 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample276()
        {
            /* Specification Example:
                .
                __foo bar__
                .
                <p><strong>foo bar</strong></p>
                .
            */

            this.Setup(
                "__foo bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 277 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample277()
        {
            /* Specification Example:
                .
                __ foo bar__
                .
                <p>__ foo bar__</p>
                .
            */

            this.Setup(
                "__ foo bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__ foo bar__" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 278 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample278()
        {
            /* Specification Example:
                .
                foo__bar__
                .
                <p>foo__bar__</p>
                .
            */

            this.Setup(
                "foo__bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo__bar__" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 279 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample279()
        {
            /* Specification Example:
                .
                5__6__78
                .
                <p>5__6__78</p>
                .
            */

            this.Setup(
                "5__6__78");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "5__6__78" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 280 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample280()
        {
            /* Specification Example:
                .
                пристаням__стремятся__
                .
                <p>пристаням<strong>стремятся</strong></p>
                .
            */

            this.Setup(
                "пристаням__стремятся__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "пристаням" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 281 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample281()
        {
            /* Specification Example:
                .
                __foo, __bar__, baz__
                .
                <p><strong>foo, <strong>bar</strong>, baz</strong></p>
                .
            */

            this.Setup(
                "__foo, __bar__, baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 282 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample282()
        {
            /* Specification Example:
                .
                **foo bar **
                .
                <p>**foo bar **</p>
                .
            */

            this.Setup(
                "**foo bar **");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**foo bar **" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 283 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample283()
        {
            /* Specification Example:
                .
                **foo**bar
                .
                <p><strong>foo</strong>bar</p>
                .
            */

            this.Setup(
                "**foo**bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 284 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample284()
        {
            /* Specification Example:
                .
                __foo bar __
                .
                <p>__foo bar __</p>
                .
            */

            this.Setup(
                "__foo bar __");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__foo bar __" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 285 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample285()
        {
            /* Specification Example:
                .
                __foo__bar
                .
                <p>__foo__bar</p>
                .
            */

            this.Setup(
                "__foo__bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__foo__bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 286 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample286()
        {
            /* Specification Example:
                .
                __пристаням__стремятся
                .
                <p><strong>пристаням</strong>стремятся</p>
                .
            */

            this.Setup(
                "__пристаням__стремятся");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 287 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample287()
        {
            /* Specification Example:
                .
                __foo__bar__baz__
                .
                <p><strong>foo__bar__baz</strong></p>
                .
            */

            this.Setup(
                "__foo__bar__baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 288 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample288()
        {
            /* Specification Example:
                .
                *foo [bar](/url)*
                .
                <p><em>foo <a href="/url">bar</a></em></p>
                .
            */

            this.Setup(
                "*foo [bar](/url)*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 289 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample289()
        {
            /* Specification Example:
                .
                *foo
                bar*
                .
                <p><em>foo
                bar</em></p>
                .
            */

            this.Setup(
                "*foo",
                "bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 290 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample290()
        {
            /* Specification Example:
                .
                _foo __bar__ baz_
                .
                <p><em>foo <strong>bar</strong> baz</em></p>
                .
            */

            this.Setup(
                "_foo __bar__ baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 291 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample291()
        {
            /* Specification Example:
                .
                _foo _bar_ baz_
                .
                <p><em>foo <em>bar</em> baz</em></p>
                .
            */

            this.Setup(
                "_foo _bar_ baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 292 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample292()
        {
            /* Specification Example:
                .
                __foo_ bar_
                .
                <p><em><em>foo</em> bar</em></p>
                .
            */

            this.Setup(
                "__foo_ bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 293 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample293()
        {
            /* Specification Example:
                .
                *foo *bar**
                .
                <p><em>foo <em>bar</em></em></p>
                .
            */

            this.Setup(
                "*foo *bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 294 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample294()
        {
            /* Specification Example:
                .
                *foo **bar** baz*
                .
                <p><em>foo <strong>bar</strong> baz</em></p>
                .
            */

            this.Setup(
                "*foo **bar** baz*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 295 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample295()
        {
            /* Specification Example:
                .
                *foo**bar**baz*
                .
                <p><em>foo</em><em>bar</em><em>baz</em></p>
                .
            */

            this.Setup(
                "*foo**bar**baz*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 296 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample296()
        {
            /* Specification Example:
                .
                ***foo** bar*
                .
                <p><em><strong>foo</strong> bar</em></p>
                .
            */

            this.Setup(
                "***foo** bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 297 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample297()
        {
            /* Specification Example:
                .
                *foo **bar***
                .
                <p><em>foo <strong>bar</strong></em></p>
                .
            */

            this.Setup(
                "*foo **bar***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 298 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample298()
        {
            /* Specification Example:
                .
                *foo**bar***
                .
                <p><em>foo</em><em>bar</em>**</p>
                .
            */

            this.Setup(
                "*foo**bar***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 299 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample299()
        {
            /* Specification Example:
                .
                *foo **bar *baz* bim** bop*
                .
                <p><em>foo <strong>bar <em>baz</em> bim</strong> bop</em></p>
                .
            */

            this.Setup(
                "*foo **bar *baz* bim** bop*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 300 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample300()
        {
            /* Specification Example:
                .
                *foo [*bar*](/url)*
                .
                <p><em>foo <a href="/url"><em>bar</em></a></em></p>
                .
            */

            this.Setup(
                "*foo [*bar*](/url)*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 301 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample301()
        {
            /* Specification Example:
                .
                ** is not an empty emphasis
                .
                <p>** is not an empty emphasis</p>
                .
            */

            this.Setup(
                "** is not an empty emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "** is not an empty emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 302 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample302()
        {
            /* Specification Example:
                .
                **** is not an empty strong emphasis
                .
                <p>**** is not an empty strong emphasis</p>
                .
            */

            this.Setup(
                "**** is not an empty strong emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**** is not an empty strong emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 303 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample303()
        {
            /* Specification Example:
                .
                **foo [bar](/url)**
                .
                <p><strong>foo <a href="/url">bar</a></strong></p>
                .
            */

            this.Setup(
                "**foo [bar](/url)**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 304 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample304()
        {
            /* Specification Example:
                .
                **foo
                bar**
                .
                <p><strong>foo
                bar</strong></p>
                .
            */

            this.Setup(
                "**foo",
                "bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 305 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample305()
        {
            /* Specification Example:
                .
                __foo _bar_ baz__
                .
                <p><strong>foo <em>bar</em> baz</strong></p>
                .
            */

            this.Setup(
                "__foo _bar_ baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 306 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample306()
        {
            /* Specification Example:
                .
                __foo __bar__ baz__
                .
                <p><strong>foo <strong>bar</strong> baz</strong></p>
                .
            */

            this.Setup(
                "__foo __bar__ baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 307 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample307()
        {
            /* Specification Example:
                .
                ____foo__ bar__
                .
                <p><strong><strong>foo</strong> bar</strong></p>
                .
            */

            this.Setup(
                "____foo__ bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 308 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample308()
        {
            /* Specification Example:
                .
                **foo **bar****
                .
                <p><strong>foo <strong>bar</strong></strong></p>
                .
            */

            this.Setup(
                "**foo **bar****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 309 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample309()
        {
            /* Specification Example:
                .
                **foo *bar* baz**
                .
                <p><strong>foo <em>bar</em> baz</strong></p>
                .
            */

            this.Setup(
                "**foo *bar* baz**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 310 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample310()
        {
            /* Specification Example:
                .
                **foo*bar*baz**
                .
                <p><em><em>foo</em>bar</em>baz**</p>
                .
            */

            this.Setup(
                "**foo*bar*baz**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 311 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample311()
        {
            /* Specification Example:
                .
                ***foo* bar**
                .
                <p><strong><em>foo</em> bar</strong></p>
                .
            */

            this.Setup(
                "***foo* bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 312 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample312()
        {
            /* Specification Example:
                .
                **foo *bar***
                .
                <p><strong>foo <em>bar</em></strong></p>
                .
            */

            this.Setup(
                "**foo *bar***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 313 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample313()
        {
            /* Specification Example:
                .
                **foo *bar **baz**
                bim* bop**
                .
                <p><strong>foo <em>bar <strong>baz</strong>
                bim</em> bop</strong></p>
                .
            */

            this.Setup(
                "**foo *bar **baz**",
                "bim* bop**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bim" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 314 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample314()
        {
            /* Specification Example:
                .
                **foo [*bar*](/url)**
                .
                <p><strong>foo <a href="/url"><em>bar</em></a></strong></p>
                .
            */

            this.Setup(
                "**foo [*bar*](/url)**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 315 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample315()
        {
            /* Specification Example:
                .
                __ is not an empty emphasis
                .
                <p>__ is not an empty emphasis</p>
                .
            */

            this.Setup(
                "__ is not an empty emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__ is not an empty emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 316 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample316()
        {
            /* Specification Example:
                .
                ____ is not an empty strong emphasis
                .
                <p>____ is not an empty strong emphasis</p>
                .
            */

            this.Setup(
                "____ is not an empty strong emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "____ is not an empty strong emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 317 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample317()
        {
            /* Specification Example:
                .
                foo ***
                .
                <p>foo ***</p>
                .
            */

            this.Setup(
                "foo ***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo ***" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 318 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample318()
        {
            /* Specification Example:
                .
                foo *\**
                .
                <p>foo <em>*</em></p>
                .
            */

            this.Setup(
                "foo *\\**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 319 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample319()
        {
            /* Specification Example:
                .
                foo *_*
                .
                <p>foo <em>_</em></p>
                .
            */

            this.Setup(
                "foo *_*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 320 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample320()
        {
            /* Specification Example:
                .
                foo *****
                .
                <p>foo *****</p>
                .
            */

            this.Setup(
                "foo *****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo *****" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 321 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample321()
        {
            /* Specification Example:
                .
                foo **\***
                .
                <p>foo <strong>*</strong></p>
                .
            */

            this.Setup(
                "foo **\\***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 322 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample322()
        {
            /* Specification Example:
                .
                foo **_**
                .
                <p>foo <strong>_</strong></p>
                .
            */

            this.Setup(
                "foo **_**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 323 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample323()
        {
            /* Specification Example:
                .
                **foo*
                .
                <p>*<em>foo</em></p>
                .
            */

            this.Setup(
                "**foo*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 324 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample324()
        {
            /* Specification Example:
                .
                *foo**
                .
                <p><em>foo</em>*</p>
                .
            */

            this.Setup(
                "*foo**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 325 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample325()
        {
            /* Specification Example:
                .
                ***foo**
                .
                <p>*<strong>foo</strong></p>
                .
            */

            this.Setup(
                "***foo**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 326 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample326()
        {
            /* Specification Example:
                .
                ****foo*
                .
                <p>***<em>foo</em></p>
                .
            */

            this.Setup(
                "****foo*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "***" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 327 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample327()
        {
            /* Specification Example:
                .
                **foo***
                .
                <p><strong>foo</strong>*</p>
                .
            */

            this.Setup(
                "**foo***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 328 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample328()
        {
            /* Specification Example:
                .
                *foo****
                .
                <p><em>foo</em>***</p>
                .
            */

            this.Setup(
                "*foo****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 329 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample329()
        {
            /* Specification Example:
                .
                foo ___
                .
                <p>foo ___</p>
                .
            */

            this.Setup(
                "foo ___");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo ___" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 330 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample330()
        {
            /* Specification Example:
                .
                foo _\__
                .
                <p>foo <em>_</em></p>
                .
            */

            this.Setup(
                "foo _\\__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 331 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample331()
        {
            /* Specification Example:
                .
                foo _*_
                .
                <p>foo <em>*</em></p>
                .
            */

            this.Setup(
                "foo _*_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 332 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample332()
        {
            /* Specification Example:
                .
                foo _____
                .
                <p>foo _____</p>
                .
            */

            this.Setup(
                "foo _____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo _____" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 333 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample333()
        {
            /* Specification Example:
                .
                foo __\___
                .
                <p>foo <strong>_</strong></p>
                .
            */

            this.Setup(
                "foo __\\___");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 334 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample334()
        {
            /* Specification Example:
                .
                foo __*__
                .
                <p>foo <strong>*</strong></p>
                .
            */

            this.Setup(
                "foo __*__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 335 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample335()
        {
            /* Specification Example:
                .
                __foo_
                .
                <p>_<em>foo</em></p>
                .
            */

            this.Setup(
                "__foo_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 336 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample336()
        {
            /* Specification Example:
                .
                _foo__
                .
                <p><em>foo</em>_</p>
                .
            */

            this.Setup(
                "_foo__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 337 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample337()
        {
            /* Specification Example:
                .
                ___foo__
                .
                <p>_<strong>foo</strong></p>
                .
            */

            this.Setup(
                "___foo__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 338 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample338()
        {
            /* Specification Example:
                .
                ____foo_
                .
                <p>___<em>foo</em></p>
                .
            */

            this.Setup(
                "____foo_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "___" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 339 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample339()
        {
            /* Specification Example:
                .
                __foo___
                .
                <p><strong>foo</strong>_</p>
                .
            */

            this.Setup(
                "__foo___");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 340 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample340()
        {
            /* Specification Example:
                .
                _foo____
                .
                <p><em>foo</em>___</p>
                .
            */

            this.Setup(
                "_foo____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 341 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample341()
        {
            /* Specification Example:
                .
                **foo**
                .
                <p><strong>foo</strong></p>
                .
            */

            this.Setup(
                "**foo**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 342 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample342()
        {
            /* Specification Example:
                .
                *_foo_*
                .
                <p><em><em>foo</em></em></p>
                .
            */

            this.Setup(
                "*_foo_*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 343 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample343()
        {
            /* Specification Example:
                .
                __foo__
                .
                <p><strong>foo</strong></p>
                .
            */

            this.Setup(
                "__foo__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 344 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample344()
        {
            /* Specification Example:
                .
                _*foo*_
                .
                <p><em><em>foo</em></em></p>
                .
            */

            this.Setup(
                "_*foo*_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 345 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample345()
        {
            /* Specification Example:
                .
                ****foo****
                .
                <p><strong><strong>foo</strong></strong></p>
                .
            */

            this.Setup(
                "****foo****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 346 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample346()
        {
            /* Specification Example:
                .
                ____foo____
                .
                <p><strong><strong>foo</strong></strong></p>
                .
            */

            this.Setup(
                "____foo____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 347 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample347()
        {
            /* Specification Example:
                .
                ******foo******
                .
                <p><strong><strong><strong>foo</strong></strong></strong></p>
                .
            */

            this.Setup(
                "******foo******");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 348 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample348()
        {
            /* Specification Example:
                .
                ***foo***
                .
                <p><strong><em>foo</em></strong></p>
                .
            */

            this.Setup(
                "***foo***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 349 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample349()
        {
            /* Specification Example:
                .
                _____foo_____
                .
                <p><strong><strong><em>foo</em></strong></strong></p>
                .
            */

            this.Setup(
                "_____foo_____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 350 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample350()
        {
            /* Specification Example:
                .
                *foo _bar* baz_
                .
                <p><em>foo _bar</em> baz_</p>
                .
            */

            this.Setup(
                "*foo _bar* baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 351 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample351()
        {
            /* Specification Example:
                .
                **foo*bar**
                .
                <p><em><em>foo</em>bar</em>*</p>
                .
            */

            this.Setup(
                "**foo*bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 352 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample352()
        {
            /* Specification Example:
                .
                **foo **bar baz**
                .
                <p>**foo <strong>bar baz</strong></p>
                .
            */

            this.Setup(
                "**foo **bar baz**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 353 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample353()
        {
            /* Specification Example:
                .
                *foo *bar baz*
                .
                <p>*foo <em>bar baz</em></p>
                .
            */

            this.Setup(
                "*foo *bar baz*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 354 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample354()
        {
            /* Specification Example:
                .
                *[bar*](/url)
                .
                <p>*<a href="/url">bar*</a></p>
                .
            */

            this.Setup(
                "*[bar*](/url)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 355 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample355()
        {
            /* Specification Example:
                .
                _foo [bar_](/url)
                .
                <p>_foo <a href="/url">bar_</a></p>
                .
            */

            this.Setup(
                "_foo [bar_](/url)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 356 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample356()
        {
            /* Specification Example:
                .
                *<img src="foo" title="*"/>
                .
                <p>*<img src="foo" title="*"/></p>
                .
            */

            this.Setup(
                "*<img src=\"foo\" title=\"*\"/>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 357 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample357()
        {
            /* Specification Example:
                .
                **<a href="**">
                .
                <p>**<a href="**"></p>
                .
            */

            this.Setup(
                "**<a href=\"**\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 358 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample358()
        {
            /* Specification Example:
                .
                __<a href="__">
                .
                <p>__<a href="__"></p>
                .
            */

            this.Setup(
                "__<a href=\"__\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 359 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample359()
        {
            /* Specification Example:
                .
                *a `*`*
                .
                <p><em>a <code>*</code></em></p>
                .
            */

            this.Setup(
                "*a `*`*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 360 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample360()
        {
            /* Specification Example:
                .
                _a `_`_
                .
                <p><em>a <code>_</code></em></p>
                .
            */

            this.Setup(
                "_a `_`_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 361 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample361()
        {
            /* Specification Example:
                .
                **a<http://foo.bar?q=**>
                .
                <p>**a<a href="http://foo.bar?q=**">http://foo.bar?q=**</a></p>
                .
            */

            this.Setup(
                "**a<http://foo.bar?q=**>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**a" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 362 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample362()
        {
            /* Specification Example:
                .
                __a<http://foo.bar?q=__>
                .
                <p>__a<a href="http://foo.bar?q=__">http://foo.bar?q=__</a></p>
                .
            */

            this.Setup(
                "__a<http://foo.bar?q=__>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__a" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 363 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample363()
        {
            /* Specification Example:
                .
                [link](/uri "title")
                .
                <p><a href="/uri" title="title">link</a></p>
                .
            */

            this.Setup(
                "[link](/uri \"title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 364 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample364()
        {
            /* Specification Example:
                .
                [link](/uri)
                .
                <p><a href="/uri">link</a></p>
                .
            */

            this.Setup(
                "[link](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 365 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample365()
        {
            /* Specification Example:
                .
                [link]()
                .
                <p><a href="">link</a></p>
                .
            */

            this.Setup(
                "[link]()");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 366 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample366()
        {
            /* Specification Example:
                .
                [link](<>)
                .
                <p><a href="">link</a></p>
                .
            */

            this.Setup(
                "[link](<>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 367 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample367()
        {
            /* Specification Example:
                .
                [link](/my uri)
                .
                <p>[link](/my uri)</p>
                .
            */

            this.Setup(
                "[link](/my uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[link](/my uri)" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 368 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample368()
        {
            /* Specification Example:
                .
                [link](</my uri>)
                .
                <p><a href="/my%20uri">link</a></p>
                .
            */

            this.Setup(
                "[link](</my uri>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 369 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample369()
        {
            /* Specification Example:
                .
                [link](foo
                bar)
                .
                <p>[link](foo
                bar)</p>
                .
            */

            this.Setup(
                "[link](foo",
                "bar)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[link](foo" },
                new Event(MarkupElementType.Text) { Text = "bar)" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 370 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample370()
        {
            /* Specification Example:
                .
                [link]((foo)and(bar))
                .
                <p><a href="(foo)and(bar)">link</a></p>
                .
            */

            this.Setup(
                "[link]((foo)and(bar))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 371 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample371()
        {
            /* Specification Example:
                .
                [link](foo(and(bar)))
                .
                <p>[link](foo(and(bar)))</p>
                .
            */

            this.Setup(
                "[link](foo(and(bar)))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[link](foo(and(bar)))" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 372 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample372()
        {
            /* Specification Example:
                .
                [link](foo(and\(bar\)))
                .
                <p><a href="foo(and(bar))">link</a></p>
                .
            */

            this.Setup(
                "[link](foo(and\\(bar\\)))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 373 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample373()
        {
            /* Specification Example:
                .
                [link](<foo(and(bar))>)
                .
                <p><a href="foo(and(bar))">link</a></p>
                .
            */

            this.Setup(
                "[link](<foo(and(bar))>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 374 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample374()
        {
            /* Specification Example:
                .
                [link](foo\)\:)
                .
                <p><a href="foo):">link</a></p>
                .
            */

            this.Setup(
                "[link](foo\\)\\:)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 375 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample375()
        {
            /* Specification Example:
                .
                [link](foo%20b&auml;)
                .
                <p><a href="foo%20b%C3%A4">link</a></p>
                .
            */

            this.Setup(
                "[link](foo%20b&auml;)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 376 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample376()
        {
            /* Specification Example:
                .
                [link]("title")
                .
                <p><a href="%22title%22">link</a></p>
                .
            */

            this.Setup(
                "[link](\"title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 377 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample377()
        {
            /* Specification Example:
                .
                [link](/url "title")
                [link](/url 'title')
                [link](/url (title))
                .
                <p><a href="/url" title="title">link</a>
                <a href="/url" title="title">link</a>
                <a href="/url" title="title">link</a></p>
                .
            */

            this.Setup(
                "[link](/url \"title\")",
                "[link](/url 'title')",
                "[link](/url (title))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 378 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample378()
        {
            /* Specification Example:
                .
                [link](/url "title \"&quot;")
                .
                <p><a href="/url" title="title &quot;&quot;">link</a></p>
                .
            */

            this.Setup(
                "[link](/url \"title \\\"&quot;\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 379 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample379()
        {
            /* Specification Example:
                .
                [link](/url "title "and" title")
                .
                <p>[link](/url &quot;title &quot;and&quot; title&quot;)</p>
                .
            */

            this.Setup(
                "[link](/url \"title \"and\" title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[link](/url &quot;title &quot;and&quot; title&quot;)" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 380 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample380()
        {
            /* Specification Example:
                .
                [link](/url 'title "and" title')
                .
                <p><a href="/url" title="title &quot;and&quot; title">link</a></p>
                .
            */

            this.Setup(
                "[link](/url 'title \"and\" title')");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 381 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample381()
        {
            /* Specification Example:
                .
                [link](   /uri
                  "title"  )
                .
                <p><a href="/uri" title="title">link</a></p>
                .
            */

            this.Setup(
                "[link](   /uri",
                "  \"title\"  )");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 382 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample382()
        {
            /* Specification Example:
                .
                [link] (/uri)
                .
                <p>[link] (/uri)</p>
                .
            */

            this.Setup(
                "[link] (/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[link] (/uri)" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 383 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample383()
        {
            /* Specification Example:
                .
                [link [foo [bar]]](/uri)
                .
                <p><a href="/uri">link [foo [bar]]</a></p>
                .
            */

            this.Setup(
                "[link [foo [bar]]](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 384 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample384()
        {
            /* Specification Example:
                .
                [link] bar](/uri)
                .
                <p>[link] bar](/uri)</p>
                .
            */

            this.Setup(
                "[link] bar](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[link] bar](/uri)" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 385 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample385()
        {
            /* Specification Example:
                .
                [link [bar](/uri)
                .
                <p>[link <a href="/uri">bar</a></p>
                .
            */

            this.Setup(
                "[link [bar](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[link " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 386 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample386()
        {
            /* Specification Example:
                .
                [link \[bar](/uri)
                .
                <p><a href="/uri">link [bar</a></p>
                .
            */

            this.Setup(
                "[link \\[bar](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 387 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample387()
        {
            /* Specification Example:
                .
                [link *foo **bar** `#`*](/uri)
                .
                <p><a href="/uri">link <em>foo <strong>bar</strong> <code>#</code></em></a></p>
                .
            */

            this.Setup(
                "[link *foo **bar** `#`*](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 388 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample388()
        {
            /* Specification Example:
                .
                [![moon](moon.jpg)](/uri)
                .
                <p><a href="/uri"><img src="moon.jpg" alt="moon" /></a></p>
                .
            */

            this.Setup(
                "[![moon](moon.jpg)](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 389 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample389()
        {
            /* Specification Example:
                .
                [foo [bar](/uri)](/uri)
                .
                <p>[foo <a href="/uri">bar</a>](/uri)</p>
                .
            */

            this.Setup(
                "[foo [bar](/uri)](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 390 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample390()
        {
            /* Specification Example:
                .
                [foo *[bar [baz](/uri)](/uri)*](/uri)
                .
                <p>[foo <em>[bar <a href="/uri">baz</a>](/uri)</em>](/uri)</p>
                .
            */

            this.Setup(
                "[foo *[bar [baz](/uri)](/uri)*](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 391 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample391()
        {
            /* Specification Example:
                .
                *[foo*](/uri)
                .
                <p>*<a href="/uri">foo*</a></p>
                .
            */

            this.Setup(
                "*[foo*](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 392 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample392()
        {
            /* Specification Example:
                .
                [foo *bar](baz*)
                .
                <p><a href="baz*">foo *bar</a></p>
                .
            */

            this.Setup(
                "[foo *bar](baz*)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 393 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample393()
        {
            /* Specification Example:
                .
                [foo <bar attr="](baz)">
                .
                <p>[foo <bar attr="](baz)"></p>
                .
            */

            this.Setup(
                "[foo <bar attr=\"](baz)\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 394 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample394()
        {
            /* Specification Example:
                .
                [foo`](/uri)`
                .
                <p>[foo<code>](/uri)</code></p>
                .
            */

            this.Setup(
                "[foo`](/uri)`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 395 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample395()
        {
            /* Specification Example:
                .
                [foo<http://example.com?search=](uri)>
                .
                <p>[foo<a href="http://example.com?search=%5D(uri)">http://example.com?search=](uri)</a></p>
                .
            */

            this.Setup(
                "[foo<http://example.com?search=](uri)>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 396 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample396()
        {
            /* Specification Example:
                .
                [foo][bar]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo][bar]",
                "",
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 397 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample397()
        {
            /* Specification Example:
                .
                [link [foo [bar]]][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">link [foo [bar]]</a></p>
                .
            */

            this.Setup(
                "[link [foo [bar]]][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 398 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample398()
        {
            /* Specification Example:
                .
                [link \[bar][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">link [bar</a></p>
                .
            */

            this.Setup(
                "[link \\[bar][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 399 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample399()
        {
            /* Specification Example:
                .
                [link *foo **bar** `#`*][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">link <em>foo <strong>bar</strong> <code>#</code></em></a></p>
                .
            */

            this.Setup(
                "[link *foo **bar** `#`*][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 400 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample400()
        {
            /* Specification Example:
                .
                [![moon](moon.jpg)][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri"><img src="moon.jpg" alt="moon" /></a></p>
                .
            */

            this.Setup(
                "[![moon](moon.jpg)][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 401 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample401()
        {
            /* Specification Example:
                .
                [foo [bar](/uri)][ref]
                
                [ref]: /uri
                .
                <p>[foo <a href="/uri">bar</a>]<a href="/uri">ref</a></p>
                .
            */

            this.Setup(
                "[foo [bar](/uri)][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 402 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample402()
        {
            /* Specification Example:
                .
                [foo *bar [baz][ref]*][ref]
                
                [ref]: /uri
                .
                <p>[foo <em>bar <a href="/uri">baz</a></em>]<a href="/uri">ref</a></p>
                .
            */

            this.Setup(
                "[foo *bar [baz][ref]*][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 403 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample403()
        {
            /* Specification Example:
                .
                *[foo*][ref]
                
                [ref]: /uri
                .
                <p>*<a href="/uri">foo*</a></p>
                .
            */

            this.Setup(
                "*[foo*][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 404 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample404()
        {
            /* Specification Example:
                .
                [foo *bar][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">foo *bar</a></p>
                .
            */

            this.Setup(
                "[foo *bar][ref]",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 405 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample405()
        {
            /* Specification Example:
                .
                [foo <bar attr="][ref]">
                
                [ref]: /uri
                .
                <p>[foo <bar attr="][ref]"></p>
                .
            */

            this.Setup(
                "[foo <bar attr=\"][ref]\">",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 406 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample406()
        {
            /* Specification Example:
                .
                [foo`][ref]`
                
                [ref]: /uri
                .
                <p>[foo<code>][ref]</code></p>
                .
            */

            this.Setup(
                "[foo`][ref]`",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 407 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample407()
        {
            /* Specification Example:
                .
                [foo<http://example.com?search=][ref]>
                
                [ref]: /uri
                .
                <p>[foo<a href="http://example.com?search=%5D%5Bref%5D">http://example.com?search=][ref]</a></p>
                .
            */

            this.Setup(
                "[foo<http://example.com?search=][ref]>",
                "",
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 408 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample408()
        {
            /* Specification Example:
                .
                [foo][BaR]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo][BaR]",
                "",
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 409 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample409()
        {
            /* Specification Example:
                .
                [Толпой][Толпой] is a Russian word.
                
                [ТОЛПОЙ]: /url
                .
                <p><a href="/url">Толпой</a> is a Russian word.</p>
                .
            */

            this.Setup(
                "[Толпой][Толпой] is a Russian word.",
                "",
                "[ТОЛПОЙ]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 410 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample410()
        {
            /* Specification Example:
                .
                [Foo
                  bar]: /url
                
                [Baz][Foo bar]
                .
                <p><a href="/url">Baz</a></p>
                .
            */

            this.Setup(
                "[Foo",
                "  bar]: /url",
                "",
                "[Baz][Foo bar]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 411 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample411()
        {
            /* Specification Example:
                .
                [foo] [bar]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo] [bar]",
                "",
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 412 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample412()
        {
            /* Specification Example:
                .
                [foo]
                [bar]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo]",
                "[bar]",
                "",
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 413 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample413()
        {
            /* Specification Example:
                .
                [foo]: /url1
                
                [foo]: /url2
                
                [bar][foo]
                .
                <p><a href="/url1">bar</a></p>
                .
            */

            this.Setup(
                "[foo]: /url1",
                "",
                "[foo]: /url2",
                "",
                "[bar][foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 414 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample414()
        {
            /* Specification Example:
                .
                [bar][foo\!]
                
                [foo!]: /url
                .
                <p>[bar][foo!]</p>
                .
            */

            this.Setup(
                "[bar][foo\\!]",
                "",
                "[foo!]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[bar][foo!]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 415 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample415()
        {
            /* Specification Example:
                .
                [foo][ref[]
                
                [ref[]: /uri
                .
                <p>[foo][ref[]</p>
                <p>[ref[]: /uri</p>
                .
            */

            this.Setup(
                "[foo][ref[]",
                "",
                "[ref[]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo][ref[]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[ref[]: /uri" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 416 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample416()
        {
            /* Specification Example:
                .
                [foo][ref[bar]]
                
                [ref[bar]]: /uri
                .
                <p>[foo][ref[bar]]</p>
                <p>[ref[bar]]: /uri</p>
                .
            */

            this.Setup(
                "[foo][ref[bar]]",
                "",
                "[ref[bar]]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo][ref[bar]]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[ref[bar]]: /uri" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 417 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample417()
        {
            /* Specification Example:
                .
                [[[foo]]]
                
                [[[foo]]]: /url
                .
                <p>[[[foo]]]</p>
                <p>[[[foo]]]: /url</p>
                .
            */

            this.Setup(
                "[[[foo]]]",
                "",
                "[[[foo]]]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[[[foo]]]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[[[foo]]]: /url" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 418 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample418()
        {
            /* Specification Example:
                .
                [foo][ref\[]
                
                [ref\[]: /uri
                .
                <p><a href="/uri">foo</a></p>
                .
            */

            this.Setup(
                "[foo][ref\\[]",
                "",
                "[ref\\[]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 419 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample419()
        {
            /* Specification Example:
                .
                [foo][]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo][]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 420 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample420()
        {
            /* Specification Example:
                .
                [*foo* bar][]
                
                [*foo* bar]: /url "title"
                .
                <p><a href="/url" title="title"><em>foo</em> bar</a></p>
                .
            */

            this.Setup(
                "[*foo* bar][]",
                "",
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 421 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample421()
        {
            /* Specification Example:
                .
                [Foo][]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">Foo</a></p>
                .
            */

            this.Setup(
                "[Foo][]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 422 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample422()
        {
            /* Specification Example:
                .
                [foo] 
                []
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo] ",
                "[]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 423 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample423()
        {
            /* Specification Example:
                .
                [foo]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "[foo]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 424 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample424()
        {
            /* Specification Example:
                .
                [*foo* bar]
                
                [*foo* bar]: /url "title"
                .
                <p><a href="/url" title="title"><em>foo</em> bar</a></p>
                .
            */

            this.Setup(
                "[*foo* bar]",
                "",
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 425 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample425()
        {
            /* Specification Example:
                .
                [[*foo* bar]]
                
                [*foo* bar]: /url "title"
                .
                <p>[<a href="/url" title="title"><em>foo</em> bar</a>]</p>
                .
            */

            this.Setup(
                "[[*foo* bar]]",
                "",
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 426 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample426()
        {
            /* Specification Example:
                .
                [Foo]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">Foo</a></p>
                .
            */

            this.Setup(
                "[Foo]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 427 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample427()
        {
            /* Specification Example:
                .
                \[foo]
                
                [foo]: /url "title"
                .
                <p>[foo]</p>
                .
            */

            this.Setup(
                "\\[foo]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 428 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample428()
        {
            /* Specification Example:
                .
                [foo*]: /url
                
                *[foo*]
                .
                <p>*<a href="/url">foo*</a></p>
                .
            */

            this.Setup(
                "[foo*]: /url",
                "",
                "*[foo*]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 429 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample429()
        {
            /* Specification Example:
                .
                [foo`]: /url
                
                [foo`]`
                .
                <p>[foo<code>]</code></p>
                .
            */

            this.Setup(
                "[foo`]: /url",
                "",
                "[foo`]`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 430 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample430()
        {
            /* Specification Example:
                .
                [foo][bar]
                
                [foo]: /url1
                [bar]: /url2
                .
                <p><a href="/url2">foo</a></p>
                .
            */

            this.Setup(
                "[foo][bar]",
                "",
                "[foo]: /url1",
                "[bar]: /url2");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 431 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample431()
        {
            /* Specification Example:
                .
                [foo][bar][baz]
                
                [baz]: /url
                .
                <p>[foo]<a href="/url">bar</a></p>
                .
            */

            this.Setup(
                "[foo][bar][baz]",
                "",
                "[baz]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 432 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample432()
        {
            /* Specification Example:
                .
                [foo][bar][baz]
                
                [baz]: /url1
                [bar]: /url2
                .
                <p><a href="/url2">foo</a><a href="/url1">baz</a></p>
                .
            */

            this.Setup(
                "[foo][bar][baz]",
                "",
                "[baz]: /url1",
                "[bar]: /url2");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 433 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample433()
        {
            /* Specification Example:
                .
                [foo][bar][baz]
                
                [baz]: /url1
                [foo]: /url2
                .
                <p>[foo]<a href="/url1">bar</a></p>
                .
            */

            this.Setup(
                "[foo][bar][baz]",
                "",
                "[baz]: /url1",
                "[foo]: /url2");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[foo]" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 434 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample434()
        {
            /* Specification Example:
                .
                ![foo](/url "title")
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo](/url \"title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 435 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample435()
        {
            /* Specification Example:
                .
                ![foo *bar*]
                
                [foo *bar*]: train.jpg "train & tracks"
                .
                <p><img src="train.jpg" alt="foo bar" title="train &amp; tracks" /></p>
                .
            */

            this.Setup(
                "![foo *bar*]",
                "",
                "[foo *bar*]: train.jpg \"train & tracks\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 436 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample436()
        {
            /* Specification Example:
                .
                ![foo ![bar](/url)](/url2)
                .
                <p><img src="/url2" alt="foo bar" /></p>
                .
            */

            this.Setup(
                "![foo ![bar](/url)](/url2)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 437 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample437()
        {
            /* Specification Example:
                .
                ![foo [bar](/url)](/url2)
                .
                <p><img src="/url2" alt="foo bar" /></p>
                .
            */

            this.Setup(
                "![foo [bar](/url)](/url2)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 438 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample438()
        {
            /* Specification Example:
                .
                ![foo *bar*][]
                
                [foo *bar*]: train.jpg "train & tracks"
                .
                <p><img src="train.jpg" alt="foo bar" title="train &amp; tracks" /></p>
                .
            */

            this.Setup(
                "![foo *bar*][]",
                "",
                "[foo *bar*]: train.jpg \"train & tracks\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 439 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample439()
        {
            /* Specification Example:
                .
                ![foo *bar*][foobar]
                
                [FOOBAR]: train.jpg "train & tracks"
                .
                <p><img src="train.jpg" alt="foo bar" title="train &amp; tracks" /></p>
                .
            */

            this.Setup(
                "![foo *bar*][foobar]",
                "",
                "[FOOBAR]: train.jpg \"train & tracks\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 440 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample440()
        {
            /* Specification Example:
                .
                ![foo](train.jpg)
                .
                <p><img src="train.jpg" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo](train.jpg)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 441 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample441()
        {
            /* Specification Example:
                .
                My ![foo bar](/path/to/train.jpg  "title"   )
                .
                <p>My <img src="/path/to/train.jpg" alt="foo bar" title="title" /></p>
                .
            */

            this.Setup(
                "My ![foo bar](/path/to/train.jpg  \"title\"   )");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "My " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 442 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample442()
        {
            /* Specification Example:
                .
                ![foo](<url>)
                .
                <p><img src="url" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo](<url>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 443 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample443()
        {
            /* Specification Example:
                .
                ![](/url)
                .
                <p><img src="/url" alt="" /></p>
                .
            */

            this.Setup(
                "![](/url)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 444 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample444()
        {
            /* Specification Example:
                .
                ![foo] [bar]
                
                [bar]: /url
                .
                <p><img src="/url" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo] [bar]",
                "",
                "[bar]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 445 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample445()
        {
            /* Specification Example:
                .
                ![foo] [bar]
                
                [BAR]: /url
                .
                <p><img src="/url" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo] [bar]",
                "",
                "[BAR]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 446 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample446()
        {
            /* Specification Example:
                .
                ![foo][]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo][]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 447 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample447()
        {
            /* Specification Example:
                .
                ![*foo* bar][]
                
                [*foo* bar]: /url "title"
                .
                <p><img src="/url" alt="foo bar" title="title" /></p>
                .
            */

            this.Setup(
                "![*foo* bar][]",
                "",
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 448 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample448()
        {
            /* Specification Example:
                .
                ![Foo][]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="Foo" title="title" /></p>
                .
            */

            this.Setup(
                "![Foo][]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 449 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample449()
        {
            /* Specification Example:
                .
                ![foo] 
                []
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo] ",
                "[]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 450 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample450()
        {
            /* Specification Example:
                .
                ![foo]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 451 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample451()
        {
            /* Specification Example:
                .
                ![*foo* bar]
                
                [*foo* bar]: /url "title"
                .
                <p><img src="/url" alt="foo bar" title="title" /></p>
                .
            */

            this.Setup(
                "![*foo* bar]",
                "",
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 452 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample452()
        {
            /* Specification Example:
                .
                ![[foo]]
                
                [[foo]]: /url "title"
                .
                <p>![[foo]]</p>
                <p>[[foo]]: /url &quot;title&quot;</p>
                .
            */

            this.Setup(
                "![[foo]]",
                "",
                "[[foo]]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "![[foo]]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[[foo]]: /url &quot;title&quot;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 453 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample453()
        {
            /* Specification Example:
                .
                ![Foo]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="Foo" title="title" /></p>
                .
            */

            this.Setup(
                "![Foo]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 454 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample454()
        {
            /* Specification Example:
                .
                \!\[foo]
                
                [foo]: /url "title"
                .
                <p>![foo]</p>
                .
            */

            this.Setup(
                "\\!\\[foo]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "![foo]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 455 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample455()
        {
            /* Specification Example:
                .
                \![foo]
                
                [foo]: /url "title"
                .
                <p>!<a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "\\![foo]",
                "",
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "!" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 456 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample456()
        {
            /* Specification Example:
                .
                <http://foo.bar.baz>
                .
                <p><a href="http://foo.bar.baz">http://foo.bar.baz</a></p>
                .
            */

            this.Setup(
                "<http://foo.bar.baz>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 457 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample457()
        {
            /* Specification Example:
                .
                <http://foo.bar.baz?q=hello&id=22&boolean>
                .
                <p><a href="http://foo.bar.baz?q=hello&amp;id=22&amp;boolean">http://foo.bar.baz?q=hello&amp;id=22&amp;boolean</a></p>
                .
            */

            this.Setup(
                "<http://foo.bar.baz?q=hello&id=22&boolean>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 458 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample458()
        {
            /* Specification Example:
                .
                <irc://foo.bar:2233/baz>
                .
                <p><a href="irc://foo.bar:2233/baz">irc://foo.bar:2233/baz</a></p>
                .
            */

            this.Setup(
                "<irc://foo.bar:2233/baz>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 459 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample459()
        {
            /* Specification Example:
                .
                <MAILTO:FOO@BAR.BAZ>
                .
                <p><a href="MAILTO:FOO@BAR.BAZ">MAILTO:FOO@BAR.BAZ</a></p>
                .
            */

            this.Setup(
                "<MAILTO:FOO@BAR.BAZ>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 460 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample460()
        {
            /* Specification Example:
                .
                <http://foo.bar/baz bim>
                .
                <p>&lt;http://foo.bar/baz bim&gt;</p>
                .
            */

            this.Setup(
                "<http://foo.bar/baz bim>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;http://foo.bar/baz bim&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 461 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample461()
        {
            /* Specification Example:
                .
                <foo@bar.example.com>
                .
                <p><a href="mailto:foo@bar.example.com">foo@bar.example.com</a></p>
                .
            */

            this.Setup(
                "<foo@bar.example.com>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 462 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample462()
        {
            /* Specification Example:
                .
                <foo+special@Bar.baz-bar0.com>
                .
                <p><a href="mailto:foo+special@Bar.baz-bar0.com">foo+special@Bar.baz-bar0.com</a></p>
                .
            */

            this.Setup(
                "<foo+special@Bar.baz-bar0.com>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 463 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample463()
        {
            /* Specification Example:
                .
                <>
                .
                <p>&lt;&gt;</p>
                .
            */

            this.Setup(
                "<>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 464 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample464()
        {
            /* Specification Example:
                .
                <heck://bing.bong>
                .
                <p>&lt;heck://bing.bong&gt;</p>
                .
            */

            this.Setup(
                "<heck://bing.bong>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;heck://bing.bong&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 465 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample465()
        {
            /* Specification Example:
                .
                < http://foo.bar >
                .
                <p>&lt; http://foo.bar &gt;</p>
                .
            */

            this.Setup(
                "< http://foo.bar >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt; http://foo.bar &gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 466 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample466()
        {
            /* Specification Example:
                .
                <foo.bar.baz>
                .
                <p>&lt;foo.bar.baz&gt;</p>
                .
            */

            this.Setup(
                "<foo.bar.baz>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;foo.bar.baz&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 467 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample467()
        {
            /* Specification Example:
                .
                <localhost:5001/foo>
                .
                <p>&lt;localhost:5001/foo&gt;</p>
                .
            */

            this.Setup(
                "<localhost:5001/foo>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;localhost:5001/foo&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 468 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample468()
        {
            /* Specification Example:
                .
                http://example.com
                .
                <p>http://example.com</p>
                .
            */

            this.Setup(
                "http://example.com");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "http://example.com" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 469 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample469()
        {
            /* Specification Example:
                .
                foo@bar.example.com
                .
                <p>foo@bar.example.com</p>
                .
            */

            this.Setup(
                "foo@bar.example.com");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo@bar.example.com" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 470 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample470()
        {
            /* Specification Example:
                .
                <a><bab><c2c>
                .
                <p><a><bab><c2c></p>
                .
            */

            this.Setup(
                "<a><bab><c2c>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 471 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample471()
        {
            /* Specification Example:
                .
                <a/><b2/>
                .
                <p><a/><b2/></p>
                .
            */

            this.Setup(
                "<a/><b2/>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 472 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample472()
        {
            /* Specification Example:
                .
                <a  /><b2
                data="foo" >
                .
                <p><a  /><b2
                data="foo" ></p>
                .
            */

            this.Setup(
                "<a  /><b2",
                "data=\"foo\" >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "data=\"foo\" >" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 473 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample473()
        {
            /* Specification Example:
                .
                <a foo="bar" bam = 'baz <em>"</em>'
                _boolean zoop:33=zoop:33 />
                .
                <p><a foo="bar" bam = 'baz <em>"</em>'
                _boolean zoop:33=zoop:33 /></p>
                .
            */

            this.Setup(
                "<a foo=\"bar\" bam = 'baz <em>\"</em>'",
                "_boolean zoop:33=zoop:33 />");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_boolean zoop:33=zoop:33 />" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 474 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample474()
        {
            /* Specification Example:
                .
                <33> <__>
                .
                <p>&lt;33&gt; &lt;__&gt;</p>
                .
            */

            this.Setup(
                "<33> <__>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;33&gt; &lt;__&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 475 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample475()
        {
            /* Specification Example:
                .
                <a h*#ref="hi">
                .
                <p>&lt;a h*#ref=&quot;hi&quot;&gt;</p>
                .
            */

            this.Setup(
                "<a h*#ref=\"hi\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;a h*#ref=&quot;hi&quot;&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 476 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample476()
        {
            /* Specification Example:
                .
                <a href="hi'> <a href=hi'>
                .
                <p>&lt;a href=&quot;hi'&gt; &lt;a href=hi'&gt;</p>
                .
            */

            this.Setup(
                "<a href=\"hi'> <a href=hi'>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;a href=&quot;hi'&gt; &lt;a href=hi'&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 477 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample477()
        {
            /* Specification Example:
                .
                < a><
                foo><bar/ >
                .
                <p>&lt; a&gt;&lt;
                foo&gt;&lt;bar/ &gt;</p>
                .
            */

            this.Setup(
                "< a><",
                "foo><bar/ >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt; a&gt;&lt;" },
                new Event(MarkupElementType.Text) { Text = "foo&gt;&lt;bar/ &gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 478 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample478()
        {
            /* Specification Example:
                .
                <a href='bar'title=title>
                .
                <p>&lt;a href='bar'title=title&gt;</p>
                .
            */

            this.Setup(
                "<a href='bar'title=title>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;a href='bar'title=title&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 479 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample479()
        {
            /* Specification Example:
                .
                </a>
                </foo >
                .
                <p></a>
                </foo ></p>
                .
            */

            this.Setup(
                "</a>",
                "</foo >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 480 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample480()
        {
            /* Specification Example:
                .
                </a href="foo">
                .
                <p>&lt;/a href=&quot;foo&quot;&gt;</p>
                .
            */

            this.Setup(
                "</a href=\"foo\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;/a href=&quot;foo&quot;&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 481 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample481()
        {
            /* Specification Example:
                .
                foo <!-- this is a
                comment - with hyphen -->
                .
                <p>foo <!-- this is a
                comment - with hyphen --></p>
                .
            */

            this.Setup(
                "foo <!-- this is a",
                "comment - with hyphen -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.Text) { Text = "comment - with hyphen -->" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 482 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample482()
        {
            /* Specification Example:
                .
                foo <!-- not a comment -- two hyphens -->
                .
                <p>foo &lt;!-- not a comment -- two hyphens --&gt;</p>
                .
            */

            this.Setup(
                "foo <!-- not a comment -- two hyphens -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo &lt;!-- not a comment -- two hyphens --&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 483 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample483()
        {
            /* Specification Example:
                .
                foo <?php echo $a; ?>
                .
                <p>foo <?php echo $a; ?></p>
                .
            */

            this.Setup(
                "foo <?php echo $a; ?>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 484 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample484()
        {
            /* Specification Example:
                .
                foo <!ELEMENT br EMPTY>
                .
                <p>foo <!ELEMENT br EMPTY></p>
                .
            */

            this.Setup(
                "foo <!ELEMENT br EMPTY>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 485 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample485()
        {
            /* Specification Example:
                .
                foo <![CDATA[>&<]]>
                .
                <p>foo <![CDATA[>&<]]></p>
                .
            */

            this.Setup(
                "foo <![CDATA[>&<]]>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 486 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample486()
        {
            /* Specification Example:
                .
                <a href="&ouml;">
                .
                <p><a href="&ouml;"></p>
                .
            */

            this.Setup(
                "<a href=\"&ouml;\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 487 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample487()
        {
            /* Specification Example:
                .
                <a href="\*">
                .
                <p><a href="\*"></p>
                .
            */

            this.Setup(
                "<a href=\"\\*\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 488 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines08RawHTMLExample488()
        {
            /* Specification Example:
                .
                <a href="\"">
                .
                <p>&lt;a href=&quot;&quot;&quot;&gt;</p>
                .
            */

            this.Setup(
                "<a href=\"\\\"\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&lt;a href=&quot;&quot;&quot;&gt;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 489 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample489()
        {
            /* Specification Example:
                .
                foo  
                baz
                .
                <p>foo<br />
                baz</p>
                .
            */

            this.Setup(
                "foo  ",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 490 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample490()
        {
            /* Specification Example:
                .
                foo\
                baz
                .
                <p>foo<br />
                baz</p>
                .
            */

            this.Setup(
                "foo\\",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 491 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample491()
        {
            /* Specification Example:
                .
                foo       
                baz
                .
                <p>foo<br />
                baz</p>
                .
            */

            this.Setup(
                "foo       ",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 492 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample492()
        {
            /* Specification Example:
                .
                foo  
                     bar
                .
                <p>foo<br />
                bar</p>
                .
            */

            this.Setup(
                "foo  ",
                "     bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 493 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample493()
        {
            /* Specification Example:
                .
                foo\
                     bar
                .
                <p>foo<br />
                bar</p>
                .
            */

            this.Setup(
                "foo\\",
                "     bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 494 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample494()
        {
            /* Specification Example:
                .
                *foo  
                bar*
                .
                <p><em>foo<br />
                bar</em></p>
                .
            */

            this.Setup(
                "*foo  ",
                "bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 495 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample495()
        {
            /* Specification Example:
                .
                *foo\
                bar*
                .
                <p><em>foo<br />
                bar</em></p>
                .
            */

            this.Setup(
                "*foo\\",
                "bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 496 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample496()
        {
            /* Specification Example:
                .
                `code  
                span`
                .
                <p><code>code span</code></p>
                .
            */

            this.Setup(
                "`code  ",
                "span`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 497 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample497()
        {
            /* Specification Example:
                .
                `code\
                span`
                .
                <p><code>code\ span</code></p>
                .
            */

            this.Setup(
                "`code\\",
                "span`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 498 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample498()
        {
            /* Specification Example:
                .
                <a href="foo  
                bar">
                .
                <p><a href="foo  
                bar"></p>
                .
            */

            this.Setup(
                "<a href=\"foo  ",
                "bar\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar\">" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 499 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample499()
        {
            /* Specification Example:
                .
                <a href="foo\
                bar">
                .
                <p><a href="foo\
                bar"></p>
                .
            */

            this.Setup(
                "<a href=\"foo\\",
                "bar\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar\">" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 500 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample500()
        {
            /* Specification Example:
                .
                foo\
                .
                <p>foo\</p>
                .
            */

            this.Setup(
                "foo\\");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo\\" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 501 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample501()
        {
            /* Specification Example:
                .
                foo
                .
                <p>foo</p>
                .
            */

            this.Setup(
                "foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 502 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample502()
        {
            /* Specification Example:
                .
                ### foo\
                .
                <h3>foo\</h3>
                .
            */

            this.Setup(
                "### foo\\");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 503 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample503()
        {
            /* Specification Example:
                .
                ### foo
                .
                <h3>foo</h3>
                .
            */

            this.Setup(
                "### foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 504 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines10SoftLineBreaksExample504()
        {
            /* Specification Example:
                .
                foo
                baz
                .
                <p>foo
                baz</p>
                .
            */

            this.Setup(
                "foo",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 505 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines10SoftLineBreaksExample505()
        {
            /* Specification Example:
                .
                foo 
                 baz
                .
                <p>foo
                baz</p>
                .
            */

            this.Setup(
                "foo ",
                " baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 506 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines11StringsExample506()
        {
            /* Specification Example:
                .
                hello $.;'there
                .
                <p>hello $.;'there</p>
                .
            */

            this.Setup(
                "hello $.;'there");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "hello $.;'there" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 507 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines11StringsExample507()
        {
            /* Specification Example:
                .
                Foo χρῆν
                .
                <p>Foo χρῆν</p>
                .
            */

            this.Setup(
                "Foo χρῆν");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo χρῆν" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 508 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines11StringsExample508()
        {
            /* Specification Example:
                .
                Multiple     spaces
                .
                <p>Multiple     spaces</p>
                .
            */

            this.Setup(
                "Multiple     spaces");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Multiple     spaces" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }
}
