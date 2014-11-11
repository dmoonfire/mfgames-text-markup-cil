// <copyright file="SingleLineParagraphParsing.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using NUnit.Framework;

    /// <summary>
    /// </summary>
    [TestFixture]
    public class SingleLineParagraphParsing : MarkdownReaderRecorderTestsBase
    {
        #region Methods

        /// <summary>
        /// </summary>
        protected override void Setup()
        {
            // Call the base implementation to set up the test.
            base.Setup("One two three.");
        }

        #endregion
    }
}