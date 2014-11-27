// <copyright file="CommonMarkSpec05ContainerBlocks02ListItemsTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec05ContainerBlocks02ListItemsTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                string.Empty,
                "    indented code",
                string.Empty,
                "> A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
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
                string.Empty,
                "        indented code",
                string.Empty,
                "    > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
                " two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "  two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "     two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = " two" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                "      two");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndBlockquote),
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
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "one" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "two" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndBlockquote),
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
                string.Empty,
                "  bar",
                string.Empty,
                "- foo",
                string.Empty,
                string.Empty,
                "  bar",
                string.Empty,
                "- ```",
                "  foo",
                string.Empty,
                string.Empty,
                "  bar",
                "  ```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "    ```",
                "    bar",
                "    ```",
                string.Empty,
                "    baz",
                string.Empty,
                "    > bam");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bam" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
                "      bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "           bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<ol start=\"10\">" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
                "paragraph",
                string.Empty,
                "    more code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "paragraph" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "more code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                "   paragraph",
                string.Empty,
                "       more code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "paragraph" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "more code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
                "   paragraph",
                string.Empty,
                "       more code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = " indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "paragraph" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "more code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
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
                string.Empty,
                "  bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "   bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "         indented code",
                string.Empty,
                "     > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
                "          indented code",
                string.Empty,
                "      > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
                "           indented code",
                string.Empty,
                "       > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                string.Empty,
                "            indented code",
                string.Empty,
                "        > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "1.  A paragraph" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "    with two lines." },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "        indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "    > A block quote." },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                "          indented code",
                string.Empty,
                "      > A block quote.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "indented code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "A block quote." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "A paragraph" },
                new Event(MarkupElementType.Text) { Text = "with two lines." },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
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
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Blockquote" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "continued here." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.EndBlockquote),
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
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Blockquote" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "continued here." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.EndBlockquote),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<ol start=\"10\">" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
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
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<ol start=\"10\">" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<ol start=\"2\">" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginHeading) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndHeading) { Level = 1 },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginHeading) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "Bar" },
                new Event(MarkupElementType.EndHeading) { Level = 2 },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
