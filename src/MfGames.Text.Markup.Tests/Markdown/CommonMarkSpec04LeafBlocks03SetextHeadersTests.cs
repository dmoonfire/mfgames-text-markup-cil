// <copyright file="CommonMarkSpec04LeafBlocks03SetextHeadersTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec04LeafBlocks03SetextHeadersTests :
        MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                string.Empty, 
                "Foo *bar*", 
                "---------");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 1
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo "
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 1
                    }, 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo "
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
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
                string.Empty, 
                "Foo", 
                "=");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 1
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 1
                    }, 
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
                string.Empty, 
                "  Foo", 
                "-----", 
                string.Empty, 
                "  Foo", 
                "  ===");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 1
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 1
                    }, 
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
                string.Empty, 
                "    Foo", 
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginCodeBlock), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "---"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "---"
                    }, 
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
                string.Empty, 
                "Foo", 
                "--- -");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "= ="
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo\\"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
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
                string.Empty, 
                "<a title=\"a lot", 
                "---", 
                "of dashes\"/>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "`Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "`"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<a title=\"a lot"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "of dashes\"/>"
                    }, 
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
                new Event(MarkupElementType.BeginBlockquote), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndBlockquote), 
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
                new Event(MarkupElementType.BeginUnorderedList), 
                new Event(MarkupElementType.BeginListItem), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndListItem), 
                new Event(MarkupElementType.EndUnorderedList), 
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
                string.Empty, 
                "Foo", 
                "Bar", 
                "===");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Bar"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.HorizontalRule), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Bar"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "==="
                    }, 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Bar"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Baz"
                    }, 
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
                string.Empty, 
                "====");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "===="
                    }, 
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
                new Event(MarkupElementType.BeginUnorderedList), 
                new Event(MarkupElementType.BeginListItem), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndListItem), 
                new Event(MarkupElementType.EndUnorderedList), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.BeginBlockquote), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndBlockquote), 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "> foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion
}