// <copyright file="CommonMarkSpec06Inlines11StringsTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines11StringsTests :
        MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 506 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines11StringsExample506()
        {
            /* Specification Example:
                .
                hello $.;'there
                .
                <p>hello $.;'there</p>
                .
            */
            this.Setup(
                "hello $.;'there");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "hello $.;'there"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 507 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines11StringsExample507()
        {
            /* Specification Example:
                .
                Foo χρῆν
                .
                <p>Foo χρῆν</p>
                .
            */
            this.Setup(
                "Foo χρῆν");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo χρῆν"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 508 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines11StringsExample508()
        {
            /* Specification Example:
                .
                Multiple     spaces
                .
                <p>Multiple     spaces</p>
                .
            */
            this.Setup(
                "Multiple     spaces");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Multiple     spaces"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion
}