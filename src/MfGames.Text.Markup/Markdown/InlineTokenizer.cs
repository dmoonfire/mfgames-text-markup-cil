// <copyright file="InlineTokenizer.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

		[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
		private static bool AddEmphasis(
			List<InlineToken> tokens,
			char emphasisType,
			string text,
			ref int index)
		{
			// We need to consider both italic and bold when we figure out
			// what to do. We also need to know the previous state in the case
			// when we are closing both of them off at the same time.
			string singleType = emphasisType.ToString();
			string doubledType = singleType + emphasisType;
			string tripledType = doubledType + emphasisType;

			MarkupElementType previousItalic = GetPreviousType(
				tokens,
				MarkupElementType.EndItalic,
				singleType,
				MarkupElementType.BeginItalic,
				MarkupElementType.EndItalic);
			MarkupElementType previousBold = GetPreviousType(
				tokens,
				MarkupElementType.EndBold,
				doubledType,
				MarkupElementType.BeginBold,
				MarkupElementType.EndBold);
			MarkupElementType previous = GetPreviousType(
				tokens,
				MarkupElementType.EndBold,
				new[] { singleType, doubledType },
				MarkupElementType.BeginBold,
				MarkupElementType.EndBold,
				MarkupElementType.BeginItalic,
				MarkupElementType.EndItalic);

			// Markdown also uses doubled-characters for bold, so we need to
			// see if this is a italic or a bold request. We can't simply assume
			// bold because when closing tags, we need to know which one when
			// dealing with tripled ones.
			string substring = text.Substring(index);
			bool isTripled = substring.StartsWith(tripledType);
			bool isDoubled = !isTripled && substring.StartsWith(doubledType);
			bool isSingle = !isTripled && !isDoubled;

			// For single, we just handle italics.
			InlineToken token;

			if (isSingle)
			{
				token = new InlineToken(
					singleType,
					previousItalic == MarkupElementType.EndItalic
						? MarkupElementType.BeginItalic
						: MarkupElementType.EndItalic);
			}
			else if (isDoubled)
			{
				token = new InlineToken(
					doubledType,
					previousBold == MarkupElementType.EndBold
						? MarkupElementType.BeginBold
						: MarkupElementType.EndBold);
				index++;
			}
			else
			{
				// Bump the index to handle the fact we just consumed three
				// characters, but then call a function since the rules can be
				// complicated for how to add and remove.
				index += 2;
				AddEmphasis3(
					tokens,
					singleType,
					doubledType,
					previousItalic,
					previousBold,
					previous);
				return true;
			}

			tokens.Add(token);
			return true;
		}

		private static void AddEmphasis3(
			List<InlineToken> tokens,
			string singleType,
			string doubleType,
			MarkupElementType previousItalic,
			MarkupElementType previousBold,
			MarkupElementType previous)
		{
			// We have to close tags that were opened first.
			var types = new List<MarkupElementType>();
			var handledItalic = false;
			var handledBold = false;

			if (previous == MarkupElementType.BeginItalic)
			{
				types.Add(MarkupElementType.EndItalic);
				handledItalic = true;

				if (previousBold == MarkupElementType.BeginBold)
				{
					types.Add(MarkupElementType.EndBold);
					handledBold = true;
				}
			}
			else if (previous == MarkupElementType.BeginBold)
			{
				types.Add(MarkupElementType.EndBold);
				handledBold = true;

				if (previousItalic == MarkupElementType.BeginItalic)
				{
					types.Add(MarkupElementType.EndItalic);
					handledItalic = true;
				}
			}

			// Now, if we didn't just close them, we need to open the other
			// one. According to CommonMark, we always prefer bold over italic
			// while opening tags.
			if (!handledBold)
			{
				types.Add(MarkupElementType.BeginBold);
			}

			if (!handledItalic)
			{
				types.Add(MarkupElementType.BeginItalic);
			}

			// Now add the actual tokens to the list.
			foreach (MarkupElementType type in types)
			{
				// Figure out the text of the token.
				string text = null;

				switch (type)
				{
					case MarkupElementType.BeginItalic:
					case MarkupElementType.EndItalic:
						text = singleType;
						break;

					case MarkupElementType.BeginBold:
					case MarkupElementType.EndBold:
						text = doubleType;
						break;
				}

				// Create and add the token to the list.
				var token = new InlineToken(text, type);
				tokens.Add(token);
			}
		}

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

		private static MarkupElementType GetPreviousType(
			List<InlineToken> tokens,
			MarkupElementType defaultElementType,
			string searchText,
			params MarkupElementType[] searchElementTypes)
		{
			return GetPreviousType(
				tokens,
				defaultElementType,
				new[] { searchText },
				searchElementTypes);
		}

		private static MarkupElementType GetPreviousType(
			List<InlineToken> tokens,
			MarkupElementType defaultElementType,
			string[] searchTexts,
			params MarkupElementType[] searchElementTypes)
		{
			// Go backwards through the list.
			for (int index = tokens.Count - 1; index >= 0; index--)
			{
				// If the token doesn't match, then we don't match.
				InlineToken token = tokens[index];
				bool foundText = searchTexts.Any(s => token.Text == s);

				if (!foundText)
				{
					continue;
				}

				// Make sure we are of the right type.
				bool foundElementType = searchElementTypes
					.Any(s => token.ElementType == s);

				if (foundElementType)
				{
					return token.ElementType;
				}
			}

			// If we got this far, we couldn't find any. So use the default.
			return defaultElementType;
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

				case '*':
				case '_':
					if (AddEmphasis(tokens, c, text, ref index))
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
