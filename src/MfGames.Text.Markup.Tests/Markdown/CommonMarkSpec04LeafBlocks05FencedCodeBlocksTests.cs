// <copyright file="CommonMarkSpec04LeafBlocks05FencedCodeBlocksTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec04LeafBlocks05FencedCodeBlocksTests :
        MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                new Event(MarkupElementType.Text)
                    {
                        Text = "<"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = " >"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "<"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = " >"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "~~~"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "```"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "```"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "~~~"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                string.Empty, 
                "```", 
                "aaa");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginCodeBlock), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "```"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                string.Empty, 
                "  ", 
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginCodeBlock), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "  "
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = " aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "```"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "```"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "    ```"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "~~~ ~~"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginCodeBlock), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndCodeBlock), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 2
                    }, 
                new Event(MarkupElementType.BeginCodeBlock), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndCodeBlock), 
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 1
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 1
                    }, 
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
                new Event(MarkupElementType.BeginCodeBlock)
                    {
                        Language = "ruby"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "def foo(x)"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "  return 3"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "end"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.BeginCodeBlock)
                    {
                        Language = "ruby"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "def foo(x)"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "  return 3"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "end"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
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
                new Event(MarkupElementType.BeginCodeBlock)
                    {
                        Language = ";"
                    }, 
                new Event(MarkupElementType.EndCodeBlock), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "aa"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "``` aaa"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndCodeBlock), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion
}