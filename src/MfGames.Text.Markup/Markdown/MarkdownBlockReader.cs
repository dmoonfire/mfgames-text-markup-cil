// <copyright file="MarkdownBlockReader.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.IO;
using System.Text;

namespace MfGames.Text.Markup.Markdown
{
	public class MarkdownBlockReader : BlockReader
	{
		#region Constructors and Destructors

		public MarkdownBlockReader(TextReader reader)
			: base(reader)
		{
		}

		#endregion

		#region Methods

		protected override bool IsBlockEnd(int index, string line)
		{
			if (index == 1 && MarkdownRegex.SetextHeader.IsMatch(line))
			{
				return true;
			}

			return false;
		}

		protected override bool IsBlockStart(
			StringBuilder buffer,
			int index,
			string line)
		{
			// If we have a blank line and the initial is indented, we consider
			// it part of the code block. All other blank lines are breaks.
			string existing = buffer.ToString();
			bool existingIsIndented = existing.StartsWith("    ");

			if (string.IsNullOrWhiteSpace(line))
			{
				return !existingIsIndented;
			}

			// If the scope of an indent block is different than the beginning,
			// then we treat them as a block barrier.
			bool lineIsIndented = line.StartsWith("    ");

			if (existingIsIndented != lineIsIndented)
			{
				return true;
			}

			// Atx headers are always breaks.
			if (MarkdownRegex.AtxHeader.IsMatch(line))
			{
				return true;
			}

			// The "---" can be used for both a header and a break. However, on
			// the second line of a block, it can only be a heading, which is
			// the end of a block, so we skip it.
			if (index == 1 &&
				MarkdownRegex.NonHeaderHorizontalRule.IsMatch(line))
			{
				return true;
			}

			// Rules out of - are okay as long as there is at least one space
			// in them.
			if (index == 1 &&
				MarkdownRegex.NonHeaderDashHorizontalRule.IsMatch(line))
			{
				return true;
			}

			// Breaks can appear in any other line. There is a overlap with
			// this and headers, but the index above catches that.
			if (index > 1 && MarkdownRegex.HorizontalRule.IsMatch(line))
			{
				return true;
			}

			// For everything else, it isn't.
			return false;
		}

		protected override bool IsSingleLineBlock(string line)
		{
			if (MarkdownRegex.HorizontalRule.IsMatch(line))
			{
				return true;
			}

			return false;
		}

		#endregion
	}
}
