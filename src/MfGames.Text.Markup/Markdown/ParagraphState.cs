// <copyright file="ParagraphState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class ParagraphState : TextContainerMarkdownState
	{
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
	}
}
