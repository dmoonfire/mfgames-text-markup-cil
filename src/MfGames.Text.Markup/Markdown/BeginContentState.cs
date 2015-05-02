// <copyright file="BeginContentState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class BeginContentState : MarkdownState
	{
		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			MarkdownState nextState = markdown.GetNextBlockState(false);

			markdown.SetState(MarkupElementType.BeginContent, nextState);
		}

		#endregion
	}
}
