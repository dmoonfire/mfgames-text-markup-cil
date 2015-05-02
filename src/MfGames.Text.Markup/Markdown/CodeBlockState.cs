// <copyright file="CodeBlockState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Collections.Generic;

namespace MfGames.Text.Markup.Markdown
{
	internal class CodeBlockState : ContainerMarkdownState
	{
		#region Fields

		private List<string> lines;

		private bool needNewline;

		#endregion

		#region Constructors and Destructors

		public CodeBlockState()
		{
			lines = new List<string>();
		}

		#endregion

		#region Properties

		protected override MarkupElementType BeginElementType
		{
			get { return MarkupElementType.BeginCodeBlock; }
		}

		protected override MarkupElementType EndElementType
		{
			get { return MarkupElementType.EndCodeBlock; }
		}

		#endregion

		#region Methods

		protected override void PrepareContents(MarkdownReader markdown)
		{
			lines = new List<string>(markdown.BlockText.Split('\n'));
		}

		protected override bool ProcessContents(MarkdownReader markdown)
		{
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
			string line = lines[0];

			lines.RemoveAt(0);

			// Set the Markdown, remove the prefix, and send it on. In code
			// blocks, we always have a trailing newline.
			line = MarkdownRegex.CodeBlock.Replace(line, "");

			needNewline = true;
			markdown.SetText(line);
			markdown.SetState(MarkupElementType.Text, this);

			return true;
		}

		#endregion
	}
}
