// <copyright file="MarkdownReaderRecorderTestsBase.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;
using System.Collections.Generic;

using MfGames.Text.Markup.Markdown;

using Xunit.Abstractions;

namespace MfGames.Text.Markup.Tests.Markdown
{
	/// <summary>
	/// Contains common testing setup and methods for Markdown files.
	/// </summary>
	public abstract class MarkdownReaderRecorderTestsBase :
		MarkupReaderRecorderTestsBase
	{
		#region Constructors and Destructors

		protected MarkdownReaderRecorderTestsBase(ITestOutputHelper output)
			: base(output)
		{
		}

		#endregion

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
			bool matches = Events.Count == elementTypes.Length;

			if (!matches)
			{
				Output.WriteLine(
					"Recorded events had {0:N0} items but expected {1:N0}",
					Events.Count,
					elementTypes.Length);
			}

			// If they still match, then compare each item.
			if (matches)
			{
				for (var i = 0; i < Events.Count; i++)
				{
					if (Events[i] != elementTypes[i])
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

				Output.WriteLine("");
				Output.WriteLine("Expected did not match recorded:");
				Output.WriteLine("");
				Output.WriteLine(
					FormatLine,
					"Expected".PadRight(FormatWidth),
					"Actual".PadRight(FormatWidth),
					"  ",
					"  #",
					"Comparison");
				Output.WriteLine(
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
					Events.Count,
					elementTypes.Length);

				for (var i = 0; i < maxSize; i++)
				{
					// Figure out the element.
					string expected = i < elementTypes.Length
						? elementTypes[i].ElementType.ToString()
						: string.Empty;
					string actual = i < Events.Count
						? Events[i].ElementType.ToString()
						: string.Empty;

					// Write out the elements.
					Output.WriteLine(
						FormatLine,
						expected.PadRight(FormatWidth),
						actual.PadRight(FormatWidth),
						expected == actual ? "==" : "!=",
						i.ToString()
							.PadLeft(3),
						FormatDifferences(
							i < elementTypes.Length ? elementTypes[i] : null,
							i < Events.Count ? Events[i] : null));
				}
			}

			// If we aren't matching, then fail the tasks.
			if (!matches)
			{
				throw new InvalidOperationException("Expected results did not match.");
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
			Setup(
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
			Output.WriteLine("Input:");

			foreach (string line in buffer)
			{
				Output.WriteLine("  {0}", line);
			}

			Output.WriteLine("");

			// Create the Markdown reader using the given strings as a source.
			using (var reader = new MarkdownReader(
				buffer,
				options))
			{
				Record(reader);
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="name">
		/// </param>
		/// <param name="expected">
		/// </param>
		/// <param name="actual">
		/// </param>
		/// <param name="messages">
		/// </param>
		/// <typeparam name="TCompare">
		/// </typeparam>
		private static void AppendDifference<TCompare>(
			string name,
			TCompare expected,
			TCompare actual,
			List<string> messages)
		{
			var expectedObject = (object)expected;
			var actualObject = (object)actual;

			bool compareNulls = expectedObject == null && actualObject != null;
			bool compareObjects = expectedObject != null
				&& !expected.Equals(actual);

			if (compareNulls ||
				compareObjects)
			{
				string expectedFormatted = expectedObject == null
					? "<null>"
					: expectedObject.ToString()
						.Replace("\\", "\\\\")
						.Replace("\n", "\\n")
						.Replace("\r", "\\r")
						.Replace(" ", "\\s");
				string actualFormatted = actualObject == null
					? "<null>"
					: actualObject.ToString()
						.Replace("\\", "\\\\")
						.Replace("\n", "\\n")
						.Replace("\r", "\\r")
						.Replace(" ", "\\s");
				messages.Add(
					string.Format(
						"{0}: {1} != {2}",
						name,
						expectedFormatted,
						actualFormatted));
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
			AppendDifference(
				"Text",
				expected.Text,
				actual.Text,
				messages);
			AppendDifference("Href", expected.Href, actual.Href, messages);
			AppendDifference(
				"Language",
				expected.Language,
				actual.Language,
				messages);
			AppendDifference("Level", expected.Level, actual.Level, messages);
			AppendDifference("Title", expected.Title, actual.Title, messages);

			// Combine everything together.
			return string.Join(
				"; ",
				messages.ToArray());
		}

		#endregion
	}
}
