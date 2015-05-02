// <copyright file="CommonMarkSpec06Inlines03CodeSpansTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines03CodeSpansTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec06Inlines03CodeSpansTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 253 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample253()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 254 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample254()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "foo ` bar" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 255 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample255()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "``" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 256 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample256()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 257 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample257()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "foo bar baz" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 258 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample258()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "foo `` bar" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 259 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample259()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "foo\\" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.Text) { Text = "bar`" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 260 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample260()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 261 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample261()
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
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "link](/foo" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.Text) { Text = ")" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 262 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample262()
        {
            /* Specification Example:
                .
                `<a href="`">`
                .
                <p><code>&lt;a href=&quot;</code>&quot;&gt;`</p>
                .
            */

            this.Setup(
                "`<a href=\"`\">`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "<a href=\"" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.Text) { Text = "\">`" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 263 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample263()
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
                new Event(MarkupElementType.BeginAnchor) { Href="`" },
                new Event(MarkupElementType.Text) { Text = "`" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 264 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample264()
        {
            /* Specification Example:
                .
                `<http://foo.bar.`baz>`
                .
                <p><code>&lt;http://foo.bar.</code>baz&gt;`</p>
                .
            */

            this.Setup(
                "`<http://foo.bar.`baz>`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "<http://foo.bar." },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.Text) { Text = "baz>`" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 265 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample265()
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
                new Event(MarkupElementType.BeginAnchor) { Href="http://foo.bar.%60baz" },
                new Event(MarkupElementType.Text) { Text = "http://foo.bar.`baz" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.Text) { Text = "`" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 266 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample266()
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
        /// Verifies example 267 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines03CodeSpansExample267()
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

        #endregion
    }

    #endregion

}
