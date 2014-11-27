// <copyright file="CommonMarkSpec04LeafBlocks04IndentedCodeBlocksTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec04LeafBlocks04IndentedCodeBlocksTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "  indented code block" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                "    - one");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "<a/>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "*hi*" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "- one" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
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
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "chunk2" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "chunk3" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "  chunk2" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty);

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                new Event(MarkupElementType.BeginHeading) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 1 },
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginHeading) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 2 },
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                "    ",
                "    foo",
                "    ",
                string.Empty);

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
