// <copyright file="SimpleMarkdownParsing.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using MfGames.Text.Markup.Markdown;

    using NUnit.Framework;

    /// <summary>
    /// Tests parsing a single markdown line with no additional processing.
    /// </summary>
    [TestFixture]
    public class SimpleMarkdownParsing : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAsterixBreakEvents()
        {
            this.Setup(
                "One two three.", 
                string.Empty, 
                "***", 
                string.Empty, 
                "Four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.Break, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader1Events()
        {
            this.Setup("# Header");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader2Events()
        {
            this.Setup("## Header");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader3Events()
        {
            this.Setup("### Header");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader4Events()
        {
            this.Setup("#### Header");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader5Events()
        {
            this.Setup("##### Header");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader6Events()
        {
            this.Setup("###### Header");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyBoldEvents()
        {
            this.Setup("One **two** three");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.BeginBold, 
                MarkupElementType.Text, 
                MarkupElementType.EndBold, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyCodeSpanEvents()
        {
            this.Setup("One `two` three");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.BeginCodeSpan, 
                MarkupElementType.Text, 
                MarkupElementType.EndCodeSpan, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyDashBreakEvents()
        {
            this.Setup(
                "One two three.", 
                string.Empty, 
                "---", 
                string.Empty, 
                "Four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.Break, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyDoubleBlockquoteEvents()
        {
            this.Setup(
                "> One two three", 
                ">", 
                "> Four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyDoubleParagraphEvents()
        {
            this.Setup(
                "One two three.", 
                string.Empty, 
                "Four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyItalicEvents()
        {
            this.Setup("One *two* three");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.BeginItalic, 
                MarkupElementType.Text, 
                MarkupElementType.EndItalic, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyLazyBlockquoteEvents()
        {
            this.Setup(
                "> One two three", 
                "four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.Whitespace, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySetextHeader1Events()
        {
            this.Setup(
                "Header", 
                "======");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySetextHeader2Events()
        {
            this.Setup(
                "Header", 
                "------");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginHeading, 
                MarkupElementType.Text, 
                MarkupElementType.EndHeading, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySingleBlockEvents()
        {
            this.Setup(
                new MarkdownOptions
                    {
                        TreatNewLinesAsBreaks = false, 
                    }, 
                "One two three", 
                "four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.Whitespace, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySingleBlockWithBreaksEvents()
        {
            this.Setup(
                new MarkdownOptions
                    {
                        TreatNewLinesAsBreaks = true, 
                    }, 
                "One two three", 
                "four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySingleBlockquoteEvents()
        {
            this.Setup("> One two three");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySingleLineEvents()
        {
            this.Setup("One two three.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySingleLineText()
        {
            this.Setup("One two three.");

            Assert.AreEqual(
                "One two three.", 
                this.Events[3].Text);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyUnderscoreBreakEvents()
        {
            this.Setup(
                "One two three.", 
                string.Empty, 
                "___", 
                string.Empty, 
                "Four five six.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.Break, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyYamlMetadataEvents()
        {
            this.Setup(
                "---", 
                "meta: data", 
                "---", 
                "One two three.");

            this.AssertEventElementTypes(
                MarkupElementType.BeginDocument, 
                MarkupElementType.BeginMetadata, 
                MarkupElementType.YamlMetadata, 
                MarkupElementType.EndMetadata, 
                MarkupElementType.BeginContent, 
                MarkupElementType.BeginBlockquote, 
                MarkupElementType.BeginParagraph, 
                MarkupElementType.Text, 
                MarkupElementType.EndParagraph, 
                MarkupElementType.EndBlockquote, 
                MarkupElementType.EndContent, 
                MarkupElementType.EndDocument);
        }

        #endregion
    }
}