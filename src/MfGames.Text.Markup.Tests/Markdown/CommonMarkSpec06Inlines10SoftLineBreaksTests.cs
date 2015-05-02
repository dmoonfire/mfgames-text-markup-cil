// <copyright file="CommonMarkSpec06Inlines10SoftLineBreaksTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using Xunit;

    #region Designer generated code

    /// <summary>
    /// Tests various examples from the CommonMark specifiction.
    /// </summary>
    public class CommonMarkSpec06Inlines10SoftLineBreaksTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 504 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines10SoftLineBreaksExample504()
        {
            /* Specification Example:
                .
                foo
                baz
                .
                <p>foo
                baz</p>
                .
            */

            this.Setup(
                "foo",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 505 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines10SoftLineBreaksExample505()
        {
            /* Specification Example:
                .
                foo 
                 baz
                .
                <p>foo
                baz</p>
                .
            */

            this.Setup(
                "foo ",
                " baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
