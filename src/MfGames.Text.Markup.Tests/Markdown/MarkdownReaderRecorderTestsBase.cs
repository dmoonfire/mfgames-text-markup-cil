// <copyright file="MarkdownReaderRecorderTestsBase.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using System;

    using MfGames.Text.Markup.Markdown;

    using NUnit.Framework;

    /// <summary>
    /// Contains common testing setup and methods for Markdown files.
    /// </summary>
    public abstract class MarkdownReaderRecorderTestsBase :
        MarkupReaderRecorderTestsBase
    {
        #region Methods

        /// <summary>
        /// Asserts that the list of recorded events element types matches the provided
        /// list.
        /// </summary>
        /// <param name="elementTypes">
        /// The element types.
        /// </param>
        protected void AssertEventElementTypes(
            params MarkupElementType[] elementTypes)
        {
            // First check the lenghts of the arrays.
            bool matches = this.Events.Count == elementTypes.Length;

            if (!matches)
            {
                Console.WriteLine(
                    "Recorded events had {0:N0} items but expected {1:N0}", 
                    this.Events.Count, 
                    elementTypes.Length);
            }

            // If they still match, then compare each item.
            if (matches)
            {
                for (int i = 0; i < this.Events.Count; i++)
                {
                    // Compare the item, if they are identical, then we don't report it.
                    if (this.Events[i].ElementType == elementTypes[i])
                    {
                        continue;
                    }

                    // Report an inconsistency.
                    Console.WriteLine(
                        "Element {0} does not match: Expected {1}, Recorded {2}", 
                        i, 
                        elementTypes[i], 
                        this.Events[i].ElementType);
                    matches = false;
                }
            }

            // If we don't match, then display the list.
            if (!matches)
            {
                // Add a little bit of a header.
                const string FormatLine = "{3} {0} {2} {1}";
                const int FormatWidth = 20;

                Console.WriteLine();
                Console.WriteLine("Expected did not match recorded:");
                Console.WriteLine();
                Console.WriteLine(
                    FormatLine, 
                    "Expected".PadRight(FormatWidth), 
                    "Actual".PadRight(FormatWidth), 
                    "  ", 
                    "  #");
                Console.WriteLine(
                    FormatLine, 
                    new string(
                        '-', 
                        FormatWidth), 
                    new string(
                        '-', 
                        FormatWidth), 
                    "--", 
                    "---");

                // Write out the lines.
                int maxSize = Math.Max(
                    this.Events.Count, 
                    elementTypes.Length);

                for (int i = 0; i < maxSize; i++)
                {
                    // Figure out the element.
                    string expected = i < elementTypes.Length
                        ? elementTypes[i].ToString()
                        : string.Empty;
                    string actual = i < this.Events.Count
                        ? this.Events[i].ElementType.ToString()
                        : string.Empty;

                    // Write out the elements.
                    Console.WriteLine(
                        FormatLine, 
                        expected.PadRight(FormatWidth), 
                        actual.PadRight(FormatWidth), 
                        expected == actual ? "==" : "!=", 
                        i.ToString()
                            .PadLeft(3));
                }
            }

            // If we aren't matching, then fail the tasks.
            if (!matches)
            {
                Assert.Fail("Expected results did not match.");
            }
        }

        /// <summary>
        /// Sets up a test by creating a MarkdownReader based on the given buffer and then
        /// records the events as they happen.
        /// </summary>
        /// <param name="buffer">
        /// An arrow of lines to parse as a Markdown file.
        /// </param>
        protected void Setup(params string[] buffer)
        {
            this.Setup(
                MarkdownOptions.DefaultOptions, 
                buffer);
        }

        /// <summary>
        /// Sets up a test by creating a MarkdownReader based on the given buffer and then
        /// records the events as they happen.
        /// </summary>
        /// <param name="options">
        /// The options to pass into the reader.
        /// </param>
        /// <param name="buffer">
        /// An arrow of lines to parse as a Markdown file.
        /// </param>
        protected void Setup(
            MarkdownOptions options, 
            params string[] buffer)
        {
            // Create the Markdown reader using the given strings as a source.
            using (var reader = new MarkdownReader(
                buffer, 
                options))
            {
                this.Record(reader);
            }
        }

        #endregion
    }
}