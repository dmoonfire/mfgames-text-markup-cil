// <copyright file="CommonMarkSpec04LeafBlocks07LinkReferenceDefinitionsTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec04LeafBlocks07LinkReferenceDefinitionsTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                string.Empty,
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/url", Title="title" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/url", Title="the title" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "[Foo*bar\\]]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="my_(url)", Title="title (with parens)" },
                new Event(MarkupElementType.Text) { Text = "Foo*bar]" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "[Foo bar]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="my%20url", Title="title" },
                new Event(MarkupElementType.Text) { Text = "Foo bar" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
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
                string.Empty,
                "[foo]: url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="url" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "[foo]: first",
                "[foo]: second");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="first" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "[Foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "[αγω]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/%CF%86%CE%BF%CF%85" },
                new Event(MarkupElementType.Text) { Text = "αγω" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                new Event(MarkupElementType.Text) { Text = "[foo]: /url \"title\" ok" },
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
                string.Empty,
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "[foo]: /url \"title\"" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                "[foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "[foo]: /url" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                string.Empty,
                "[bar]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
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
                new Event(MarkupElementType.BeginHeading) { Level = 1 },
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndHeading) { Level = 1 },
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
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
                string.Empty,
                "[foo],",
                "[bar],",
                "[baz]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/foo-url", Title="foo" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.Text) { Text = "," },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginAnchor) { Href="/bar-url", Title="bar" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.Text) { Text = "," },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.BeginAnchor) { Href="/baz-url" },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
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
                string.Empty,
                "> [foo]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
