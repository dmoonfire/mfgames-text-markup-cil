// <copyright file="InlineTokenizer.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MfGames.Text.Markup.Markdown
{
	/// <summary>
	/// Specialized class for tokenizing an input string.
	/// </summary>
	public class InlineTokenizer
	{
		#region Static Fields

		public static readonly Regex EndItalicRegex;

		private static readonly Regex BeginItalicRegex;

		private static readonly Regex LineBreakRegex;

		#endregion

		#region Constructors and Destructors

		static InlineTokenizer()
		{
			LineBreakRegex = new Regex(@"^( {2,})\n");
			BeginItalicRegex = new Regex(@"^[ ]?([\*_])\b.*\b\1\B");
			EndItalicRegex = new Regex(@"^\b([\*_])\B");
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Converts the text of a single paragraph into a series of tokens
		/// that can be easily processed for the MarkdownReader.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public List<InlineToken> Tokenize(string text)
		{
			// If we have a null text, then return a null list. Likewise,
			// strings with only spaces are a simple blank list.
			var tokens = new List<InlineToken>();

			if (text == null)
			{
				return null;
			}

			if (text.All(c => c == ' '))
			{
				return tokens;
			}

			// Fortunately, CommonMark doesn't allow things like italics to
			// cross over the paragraph boundaries. This means that a single
			// paragraphs's text is self-contained for purposes of italics and
			// spans and everything else.
			//
			// However, the rules for some of the tags (such as emphasis and
			// strong) can be complicated by on right-hand and left-hand rules.
			// Regular expressions can be a bit complicated so what we do is
			// buildup the tokens, then verify their correctness. For some of
			// them, if they are not correct, we try an alternate.
			//
			// We also want to avoid recursion (though that would make it
			// easier) because highly complicated sentences would eventually
			// exceed the stack.

			// Start by doing the "best guess" approach to the line.
			for (var index = 0; index < text.Length; index++)
			{
				AddCharacterToken(tokens, text, ref index);
			}

			// Return the list of resulting tokens.
			return tokens;
		}

		#endregion

		#region Methods

		private static bool AddSpaceToken(
			List<InlineToken> tokens,
			string text,
			ref int index)
		{
			string spaceSubstring = text.Substring(index);
			Match spaceMatch = LineBreakRegex.Match(spaceSubstring);

			if (spaceMatch.Success)
			{
				TrimPreviousTextToken(tokens);
				tokens.Add(
					new InlineToken(
						"\r",
						MarkupElementType.LineBreak));
				index += spaceMatch.Groups[1].Value.Length - 1;
				return true;
			}

			return false;
		}

		private static void TrimPreviousTextToken(List<InlineToken> tokens)
		{
			InlineToken token = tokens.LastOrDefault();

			if (token != null && token.ElementType == MarkupElementType.Text)
			{
				token.Text = token.Text.TrimEnd();
			}
		}

		private void AddCharacterToken(
			List<InlineToken> tokens,
			string text,
			ref int index)
		{
			// Grab the character and use that to determine what token we are
			// going to add or append to.
			char c = text[index];

			switch (c)
			{
				case '\n':
					TrimPreviousTextToken(tokens);
					tokens.Add(new InlineToken("\n", MarkupElementType.NewLine));
					return;

				case ' ':
					if (AddSpaceToken(tokens, text, ref index))
					{
						return;
					}

					break;
			}

			// If we fall back, we want to append to the previous token if it
			// is a text one, otherwise, create a new text token.
			InlineToken token = tokens.Count > 0 ? tokens[tokens.Count - 1] : null;

			if (token != null && token.ElementType != MarkupElementType.Text)
			{
				token = null;
			}

			if (token == null)
			{
				token = new InlineToken("", MarkupElementType.Text);
				tokens.Add(token);
			}

			// Append to either the created or previous token.
			token.Text += c;
		}

		#endregion
	}
}
