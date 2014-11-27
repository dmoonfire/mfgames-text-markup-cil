// <copyright file="CommonMarkSpec05ContainerBlocks03ListsTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec05ContainerBlocks03ListsTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginOrderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<ol start=\"3\">" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
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
                new Event(MarkupElementType.BeginUnorderedList),
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
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<ol start=\"14\">" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "The number of doors is 6." },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndOrderedList),
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
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
                string.Empty,
                "- bar",
                string.Empty,
                string.Empty,
                "- baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                string.Empty,
                "  bar",
                "- baz");

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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                string.Empty,
                "      bim");

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
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "  bim" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                string.Empty,
                "- baz",
                "- bim");

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
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bim" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "    notcode",
                string.Empty,
                "-   foo",
                string.Empty,
                string.Empty,
                "    code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "notcode" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "code" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "e" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "f" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "g" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "- c");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "* c");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "  c",
                "- d");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "  [ref]: /url",
                "- d");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                string.Empty,
                "  ```",
                "- c");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "    c",
                "- d");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "  baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
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
                string.Empty,
                "- d",
                "  - e",
                "  - f");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "b" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "c" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "d" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "e" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "f" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
