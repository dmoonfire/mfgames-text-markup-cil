// <copyright file="EndContentState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class EndContentState : MarkdownState
	{
		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			markdown.SetState(
				MarkupElementType.EndContent,
				new EndDocumentState());
		}

		#endregion
	}
}
