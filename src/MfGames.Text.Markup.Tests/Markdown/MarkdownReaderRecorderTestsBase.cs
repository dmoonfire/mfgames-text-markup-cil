// <copyright file="MarkdownReaderRecorderTestsBase.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    /// <summary>
    /// Contains common testing setup and methods for Markdown files.
    /// </summary>
    public abstract class MarkdownReaderRecorderTestsBase :
        MarkupReaderRecorderTestsBase
    {
        #region Methods

        /// <summary>
        /// Sets up a test by creating a MarkdownReader based on the given buffer and then
        /// records the events as they happen.
        /// </summary>
        /// <param name="buffer">
        /// An arrow of lines to parse as a Markdown file.
        /// </param>
        protected void Setup(params string[] buffer)
        {
            // Call the base implementation to set up the test.
            this.Setup();

            // Create the Markdown reader using the given strings as a source.
            using (var reader = new MarkdownReader(buffer))
            {
                Record(reader);
            }
        }

        #endregion
    }
}