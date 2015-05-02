// <copyright file="HorizontalRuleState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class HorizontalRuleState : MarkdownState
	{
		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			MarkdownState nextState = markdown.GetNextBlockState();

			markdown.SetState(MarkupElementType.HorizontalRule, nextState);
		}

		#endregion
	}
}
