﻿// <copyright file="CommonMarkSpec06Inlines01BackslashEscapesTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using Xunit;
    using Xunit.Abstractions;

    #region Designer generated code

    /// <summary>
    /// Tests various examples from the CommonMark specifiction.
    /// </summary>
    public class CommonMarkSpec06Inlines01BackslashEscapesTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec06Inlines01BackslashEscapesTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 228 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample228()
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
                new Event(MarkupElementType.Text) { Text = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 229 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample229()
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
        /// Verifies example 230 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample230()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "<br/> not a tag" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "[not a link](/foo)" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "`not code`" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "1. not a list" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "* not a list" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "# not a header" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "[foo]: /url \"not a reference\"" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 231 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample231()
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
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "emphasis" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 232 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample232()
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
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<br />" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 233 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample233()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "\\[\\`" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 234 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample234()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 235 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample235()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 236 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample236()
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
                new Event(MarkupElementType.BeginAnchor) { Href="http://example.com?find=%5C*" },
                new Event(MarkupElementType.Text) { Text = "http://example.com?find=\\*" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 237 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample237()
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
                new Event(MarkupElementType.BeginAnchor) { Href="/bar\\/)" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 238 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample238()
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
                new Event(MarkupElementType.BeginAnchor) { Href="/bar*", Title="ti*tle" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 239 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample239()
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
                string.Empty,
                "[foo]: /bar\\* \"ti\\*tle\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/bar*", Title="ti*tle" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 240 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines01BackslashEscapesExample240()
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
                new Event(MarkupElementType.BeginCodeBlock) { Language = "foo+bar"},
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
