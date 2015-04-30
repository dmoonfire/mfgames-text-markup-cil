// <copyright file="CommonMarkSpec03BlocksAndInlines01PrecedenceTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec03BlocksAndInlines01PrecedenceTests :
        MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 3 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark03BlocksAndInlines01PrecedenceExample003()
        {
            /* Specification Example:
                .
                - `one
                - two`
                .
                <ul>
                <li>`one</li>
                <li>two`</li>
                </ul>
                .
            */
            this.Setup(
                "- `one", 
                "- two`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginUnorderedList), 
                new Event(MarkupElementType.BeginListItem), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "`one"
                    }, 
                new Event(MarkupElementType.EndListItem), 
                new Event(MarkupElementType.BeginListItem), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "two`"
                    }, 
                new Event(MarkupElementType.EndListItem), 
                new Event(MarkupElementType.EndUnorderedList), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion
}