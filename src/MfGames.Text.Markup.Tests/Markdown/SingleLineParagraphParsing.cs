// <copyright file="SingleLineParagraphParsing.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using NUnit.Framework;

    /// <summary>
    /// Tests parsing a single markdown line with no additional processing.
    /// </summary>
    [TestFixture]
    public class SingleLineParagraphParsing : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies the element types of the recorded events.
        /// </summary>
        [Test]
        public void VerifyRecordedEvents()
        {
            this.Setup();

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
        public void VerifyRecordedText()
        {
            this.Setup();

            Assert.AreEqual(
                "One two three.", 
                this.Events[3]);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up this test.
        /// </summary>
        protected void Setup()
        {
            // Call the base implementation to set up the test.
            this.Setup("One two three.");
        }

        #endregion
    }
}