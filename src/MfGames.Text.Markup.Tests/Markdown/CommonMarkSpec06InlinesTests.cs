// <copyright file="CommonMarkSpec06InlinesTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06InlinesTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 219 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines00ListsExample219()
        {
            /* Specification Example:
                .
                `hi`lo`
                .
                <p><code>hi</code>lo`</p>
                .
            */

            this.Setup(
                "`hi`lo`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "hi" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.Text) { Text = "lo`" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
