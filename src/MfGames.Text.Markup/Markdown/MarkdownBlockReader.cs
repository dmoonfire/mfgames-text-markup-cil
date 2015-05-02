// <copyright file="MarkdownBlockReader.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.IO;

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

		protected override bool IsNewBlockLine(int index, string line)
		{
			// Header lines only apply to the second line.
			if (index == 1)
			{
				if (MarkdownRegex.SetextHeader.IsMatch(line))
				{
					return true;
				}
			}

			// Breaks can appear in any other line. There is a overlap with
			// this and headers, but the index above catches that.
			if (MarkdownRegex.HorizontalRule.IsMatch(line))
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
