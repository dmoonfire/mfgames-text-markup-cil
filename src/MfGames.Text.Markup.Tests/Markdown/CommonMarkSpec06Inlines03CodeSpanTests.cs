// <copyright file="CommonMarkSpec06Inlines03CodeSpanTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines03CodeSpanTests :
        MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo ` bar"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "``"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo bar baz"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo `` bar"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo\\"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar`"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "*foo"
                    }, 
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "*"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "[not a "
                    }, 
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link](/foo"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = ")"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "http://foo.bar.%60baz"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "http://foo.bar.`baz"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "`"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "`"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "`"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "```foo``"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "`foo"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion
}