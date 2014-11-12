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
        public void VerifySingleLineText()
        {
            this.Setup("One two three.");

            Assert.AreEqual(
                "One two three.", 
                this.Events[3].Text);
        }

        #endregion
    }
}