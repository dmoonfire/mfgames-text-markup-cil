// <copyright file="CommonMarkSpec06Inlines09HardLineBreaksTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines09HardLineBreaksTests :
        MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<br />"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<br />"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<br />"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<br />"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<br />"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<br />"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<br />"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "code span"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "code\\ span"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
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
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<a href=\"foo  "
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar\">"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<a href=\"foo\\"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar\">"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo\\"
                    }, 
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
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 3
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo\\"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 3
                    }, 
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
                new Event(MarkupElementType.BeginHeader)
                    {
                        Level = 3
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndHeader)
                    {
                        Level = 3
                    }, 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion
}