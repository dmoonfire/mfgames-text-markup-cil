// <copyright file="CommonMarkSpec06Inlines11TextualContentTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines11TextualContentTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec06Inlines11TextualContentTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 546 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines11TextualContentExample546()
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
                new Event(MarkupElementType.Text) { Text = "hello $.;'there" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 547 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines11TextualContentExample547()
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
                new Event(MarkupElementType.Text) { Text = "Foo χρῆν" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 548 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines11TextualContentExample548()
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
                new Event(MarkupElementType.Text) { Text = "Multiple     spaces" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
