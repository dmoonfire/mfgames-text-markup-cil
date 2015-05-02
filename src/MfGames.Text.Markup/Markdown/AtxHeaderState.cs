// <copyright file="AtxHeaderState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Text.RegularExpressions;

namespace MfGames.Text.Markup.Markdown
{
	internal class AtxHeaderState : ContainerMarkdownState
	{
		#region Fields

		private string text;

		#endregion

		#region Properties

		protected override MarkupElementType BeginElementType
		{
			get { return MarkupElementType.BeginHeader; }
		}

		protected override MarkupElementType EndElementType
		{
			get { return MarkupElementType.EndHeader; }
		}

		#endregion

		#region Methods

		protected override void PrepareContents(MarkdownReader markdown)
		{
			Match match = MarkdownRegex.AtxHeader.Match(markdown.BlockText);

			Level = match.Groups[1].Value.Trim().Replace(" ", "").Length;
			text = match.Groups[2].Value.Trim().ExpandTabStops();
		}

		protected override bool ProcessContents(MarkdownReader markdown)
		{
			// If we have a blank text, then we're done.
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}

			// Otherwise, set the text and return ourselves.
			markdown.SetText(text);
			markdown.SetState(MarkupElementType.Text, this);

			// Clear the text flag so we know to end.
			text = null;
			return true;
		}

		#endregion
	}
}
