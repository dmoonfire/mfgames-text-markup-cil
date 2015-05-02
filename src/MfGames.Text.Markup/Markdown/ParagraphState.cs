// <copyright file="ParagraphState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Collections.Generic;

namespace MfGames.Text.Markup.Markdown
{
	internal class ParagraphState : ContainerMarkdownState
	{
		#region Fields

		private List<string> lines;

		private bool needLineBreak;

		private bool needNewline;

		#endregion

		#region Constructors and Destructors

		public ParagraphState()
		{
			lines = new List<string>();
		}

		#endregion

		#region Properties

		protected override MarkupElementType BeginElementType
		{
			get { return MarkupElementType.BeginParagraph; }
		}

		protected override MarkupElementType EndElementType
		{
			get { return MarkupElementType.EndParagraph; }
		}

		#endregion

		#region Methods

		protected override void PrepareContents(MarkdownReader markdown)
		{
			lines = new List<string>(markdown.BlockText.Split('\n'));
		}

		protected override bool ProcessContents(MarkdownReader markdown)
		{
			// If we need a line break, then send that out.
			if (needLineBreak)
			{
				needLineBreak = false;
				markdown.SetState(MarkupElementType.LineBreak, this);
				return true;
			}

			// If we need a newline, then send that out.
			if (needNewline)
			{
				needNewline = false;
				markdown.SetState(MarkupElementType.NewLine, this);
				return true;
			}

			// If we have no more lines, we're done.
			if (lines.Count == 0)
			{
				return false;
			}

			// Otherwise, grab the first line.
			string line = lines[0].TrimStart().ExpandTabStops();

			lines.RemoveAt(0);

			// We have an explict line break if the line has two or more spaces
			// and we aren't the last line.
			needLineBreak = line.EndsWith("  ") && lines.Count > 0;

			// We only have newlines if we still have more lines.
			needNewline = lines.Count > 0;

			// Set the state and indicate we have more to parse.
			markdown.SetText(line.TrimEnd());
			markdown.SetState(MarkupElementType.Text, this);

			return true;
		}

		#endregion
	}
}
