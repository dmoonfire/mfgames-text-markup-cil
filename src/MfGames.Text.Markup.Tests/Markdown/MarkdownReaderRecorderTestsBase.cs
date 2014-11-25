// <copyright file="MarkdownReaderRecorderTestsBase.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using System;
    using System.Collections.Generic;

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
        protected void AssertEventElementTypes(params Event[] elementTypes)
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
                    if (this.Events[i] != elementTypes[i])
                    {
                        matches = false;
                    }
                }
            }

            // If we don't match, then display the list.
            if (!matches)
            {
                // Add a little bit of a header.
                const string FormatLine = "{3} {0} {2} {1} {4}";
                const int FormatWidth = 20;

                Console.WriteLine();
                Console.WriteLine("Expected did not match recorded:");
                Console.WriteLine();
                Console.WriteLine(
                    FormatLine, 
                    "Expected".PadRight(FormatWidth), 
                    "Actual".PadRight(FormatWidth), 
                    "  ", 
                    "  #", 
                    "Comparison");
                Console.WriteLine(
                    FormatLine, 
                    new string(
                        '-', 
                        FormatWidth), 
                    new string(
                        '-', 
                        FormatWidth), 
                    "--", 
                    "---", 
                    new string(
                        '-', 
                        30));

                // Write out the lines.
                int maxSize = Math.Max(
                    this.Events.Count, 
                    elementTypes.Length);

                for (int i = 0; i < maxSize; i++)
                {
                    // Figure out the element.
                    string expected = i < elementTypes.Length
                        ? elementTypes[i].ElementType.ToString()
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
                            .PadLeft(3), 
                        this.FormatDifferences(
                            i < elementTypes.Length ? elementTypes[i] : null, 
                            i < this.Events.Count ? this.Events[i] : null));
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
            // Report the input lines.
            Console.WriteLine("Input:");

            foreach (string line in buffer)
                Console.WriteLine("  {0}", line);

            Console.WriteLine();

            // Create the Markdown reader using the given strings as a source.
            using (var reader = new MarkdownReader(
                buffer, 
                options))
            {
                this.Record(reader);
            }
        }

        /// <summary>
        /// Formats the differences between two events.
        /// </summary>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The actual.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        private string FormatDifferences(
            Event expected, 
            Event actual)
        {
            // Build up a list of strings of differences.
            var messages = new List<string>();

            // If either are null, we can't compare.
            if (expected == null || actual == null)
            {
                return string.Empty;
            }

            // Compare the elements.
            if (expected.Text != actual.Text)
            {
                messages.Add(
                    string.Format(
                        "{0}: {1} != {2}", 
                        "Text", 
                        expected.Text ?? "<null>", 
                        actual.Text ?? "<null>"));
            }

            // Combine everything together.
            return string.Join(
                "; ", 
                messages.ToArray());
        }

        #endregion
    }
}