// <copyright file="BeginContentState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;

namespace MfGames.Text.Markup.Markdown
{
	internal class BeginContentState : MarkdownState
	{
		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			// Figure out what our next state based on the contents. The text
			// is already loaded into the Markdown.
			string text = markdown.BlockText;
			MarkdownState nextState;

			if (text == null)
			{
				nextState = new EndContentState();
			}
			else if (MarkdownRegex.CodeBlock.IsMatch(text))
			{
				nextState = new CodeBlockState();
			}
			else
			{
				throw new InvalidOperationException("Still noep!");
			}

			// Set the state and finish up.
			markdown.SetState(
				MarkupElementType.BeginContent,
				nextState);
		}

		#endregion
	}
}
