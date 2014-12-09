// <copyright file="CommonMarkSpec04LeafBlocks09BlankLinesTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec04LeafBlocks09BlankLinesTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 137 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark04LeafBlocks09BlankLinesExample137()
        {
            /* Specification Example:
                .
                  
                
                aaa
                  
                
                # aaa
                
                  
                .
                <p>aaa</p>
                <h1>aaa</h1>
                .
            */

            this.Setup(
                "  ",
                string.Empty,
                "aaa",
                "  ",
                string.Empty,
                "# aaa",
                string.Empty,
                "  ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
