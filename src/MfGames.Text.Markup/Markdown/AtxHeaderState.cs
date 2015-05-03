// <copyright file="AtxHeaderState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Text.RegularExpressions;

namespace MfGames.Text.Markup.Markdown
{
	internal class AtxHeaderState : TextContainerMarkdownState
	{
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
			string text = match.Groups[2].Value.Trim().ExpandTabStops();

			Level = match.Groups[1].Value.Trim().Replace(" ", "").Length;
			Inline = new InlineState(this, text);
		}

		#endregion
	}
}
