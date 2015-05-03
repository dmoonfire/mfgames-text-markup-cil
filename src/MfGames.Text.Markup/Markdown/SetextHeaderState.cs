// <copyright file="SetextHeaderState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class SetextHeaderState : TextContainerMarkdownState
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
			string[] parts = markdown.BlockText.Split('\n');
			string text = parts[0].Trim().ExpandTabStops();

			Level = parts[1].Trim().StartsWith("=") ? 1 : 2;
			Inline = new InlineState(this, text);
		}

		#endregion
	}
}
