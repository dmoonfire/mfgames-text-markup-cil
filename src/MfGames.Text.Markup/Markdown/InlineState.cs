// <copyright file="InlineState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Collections.Generic;

namespace MfGames.Text.Markup.Markdown
{
	internal class InlineState : MarkdownState
	{
		#region Fields

		private readonly ParagraphState paragraphState;

		private readonly List<InlineToken> tokens;

		#endregion

		#region Constructors and Destructors

		public InlineState(ParagraphState paragraphState, string text)
		{
			// Parse the text of the paragraph into its tokens.
			var tokenizer = new InlineTokenizer();

			this.paragraphState = paragraphState;
			tokens = tokenizer.Tokenize(text);
		}

		#endregion

		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			bool hasMore = ProcessContents(markdown);

			if (!hasMore)
			{
				paragraphState.Process(markdown);
			}
		}

		public bool ProcessContents(MarkdownReader markdown)
		{
			// If we ran out of tokens, we are done.
			if (tokens.Count == 0)
			{
				return false;
			}

			// Carve out the next significant block or operation.
			InlineToken token = tokens[0];

			tokens.RemoveAt(0);

			// Set the state of the token.
			markdown.SetText(token.StateText);
			markdown.SetState(token.ElementType, this);

			return true;
		}

		#endregion
	}
}
