// <copyright file="SimpleMarkdownParsing.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using System;

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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.HorizontalRule), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader1Events()
        {
            this.Setup("# Header");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginHeading) { Level = 1 }, 
                new Event(MarkupElementType.Text) { Text = "Header" }, 
                new Event(MarkupElementType.EndHeading) { Level = 1 }, 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader2Events()
        {
            this.Setup("## Header");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeading) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 2 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader3Events()
        {
            this.Setup("### Header");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeading) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 3 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader4Events()
        {
            this.Setup("#### Header");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeading) { Level = 4 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 4 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader5Events()
        {
            this.Setup("##### Header");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeading) { Level = 5 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 5 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyAtxHeader6Events()
        {
            this.Setup("###### Header");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeading) { Level = 6 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 6 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyBoldEvents()
        {
            this.Setup("One **two** three");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One "
                    }, 
                new Event(MarkupElementType.BeginBold), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "two"
                    }, 
                new Event(MarkupElementType.EndBold), 
                new Event(MarkupElementType.Text)
                    {
                        Text = " three"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyCodeSpanEvents()
        {
            this.Setup("One `two` three");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One "
                    }, 
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "two"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = " three"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.HorizontalRule), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginBlockquote), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndBlockquote), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyItalicEvents()
        {
            this.Setup("One *two* three");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One "
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "two"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = " three"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginBlockquote), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three"
                    }, 
                new Event(MarkupElementType.Whitespace)
                    {
                        Text = Environment.NewLine
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndBlockquote), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeading) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 1 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeading) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "Header" },
                new Event(MarkupElementType.EndHeading) { Level = 2 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three"
                    }, 
                new Event(MarkupElementType.Whitespace)
                    {
                        Text = Environment.NewLine
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySingleBlockquoteEvents()
        {
            this.Setup("> One two three");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginBlockquote), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndBlockquote), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifySingleLineEvents()
        {
            this.Setup("One two three.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.HorizontalRule), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Four five six."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
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
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginMetadata), 
                new Event(MarkupElementType.YamlMetadata)
                    {
                        Text = @"---
meta: data
---
"
                    }, 
                new Event(MarkupElementType.EndMetadata), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "One two three."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }
}