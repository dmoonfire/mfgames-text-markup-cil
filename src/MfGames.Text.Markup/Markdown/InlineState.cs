// <copyright file="InlineState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Linq;
using System.Text;

namespace MfGames.Text.Markup.Markdown
{
	internal class InlineState : MarkdownState
	{
		#region Fields

		private readonly ParagraphState paragraphState;

		private string text;

		#endregion

		#region Constructors and Destructors

		public InlineState(ParagraphState paragraphState, string text)
		{
			this.paragraphState = paragraphState;
			this.text = string.Join(
				"\n",
				text
					.Split('\n')
					.Select(t => t.TrimStart())
					.Select(t => t.ExpandTabStops()));
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
			// If the text is blank, then we're done.
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}

			// Carve out the next significant block or operation.
			string token = PopToken();

			// Based on the token, update the state.
			if (token == "\n")
			{
				markdown.SetState(MarkupElementType.NewLine, this);
			}
			else if (token == "\r")
			{
				markdown.SetState(MarkupElementType.LineBreak, this);
			}
			else
			{
				// If we are at the end, then trim it.
				if (text.Length == 0)
				{
					token = token.TrimEnd();
				}

				// Add the token.
				markdown.SetText(token);
				markdown.SetState(MarkupElementType.Text, this);
			}

			return true;

			//

			//// Otherwise, grab the first line.
			//string line = lines[0].TrimStart().ExpandTabStops();

			//lines.RemoveAt(0);

			//// We have an explict line break if the line has two or more spaces
			//// and we aren't the last line.
			//needLineBreak = line.EndsWith("  ") && lines.Count > 0;

			//// We only have newlines if we still have more lines.
			//needNewline = lines.Count > 0;

			//// Set the state and indicate we have more to parse.
			//markdown.SetText(line.TrimEnd());
			//markdown.SetState(MarkupElementType.Text, this);

			//return true;
		}

		#endregion

		#region Methods

		private bool IsEscapeChar(string input, int index)
		{
			// If we don't have a backslash, then no escaping.
			char c1 = input[index];

			if (c1 != '\\')
			{
				return false;
			}

			// If we are at the end of the input, we're done.
			if (index + 1 == input.Length)
			{
				return false;
			}

			// The escaping rules are slightly complicated. Quotations can be
			// escaped, but everything else can't be.
			char c2 = input[index + 1];

			switch (c2)
			{
				case '!':
				case '"':
				case '#':
				case '$':
				case '%':
				case '&':
				case '\'':
				case '(':
				case ')':
				case '*':
				case '+':
				case ',':
				case '-':
				case '.':
				case '/':
				case ':':
				case ';':
				case '<':
				case '=':
				case '>':
				case '?':
				case '@':
				case '[':
				case '\\':
				case ']':
				case '^':
				case '_':
				case '`':
				case '{':
				case '|':
				case '}':
				case '~':
					return true;

				default:
					return false;
			}
		}

		private bool IsLineBreak(string input, int index, ref int length)
		{
			// We need to have at least two spaces leading into a newline.
			int spaces = input[index] == ' ' ? 1 : 0;

			if (spaces == 0)
			{
				return false;
			}

			for (int i = index + 1; i < input.Length; i++)
			{
				spaces += text[i] == ' ' ? 1 : 0;

				if (text[i] == '\n')
				{
					if (spaces >= 2)
					{
						length = i - 1;
						return true;
					}

					return false;
				}
			}

			return false;
		}

		private string PopToken()
		{
			// If the first character is a escape, then we include two.
			char c = text[0];
			var buffer = new StringBuilder();
			var length = 1;

			if (IsEscapeChar(text, 0))
			{
				c = text[1];
				buffer.Append(c);
				length++;
			}
			else if (IsLineBreak(text, 0, ref length))
			{
				buffer.Length = 0;
				buffer.Append("\r");
				c = '\r';
			}
			else
			{
				buffer.Append(c);
			}

			// Build up the token. This will be either a text block or a
			// Markdown control. It can also be a newline.
			bool done = c == '\n' || c == '\r';
			var temp = 0;

			while (!done && length < text.Length)
			{
				c = text[length];

				if (c == '\n')
				{
					// If the token up to this point is only spaces, then a
					// newline has a line break in front of it.
					if (string.IsNullOrWhiteSpace(buffer.ToString()))
					{
						buffer.Length = 0;
						buffer.Append("\r");
						break;
					}
					else
					{
						string newText = buffer.ToString().TrimEnd();

						buffer.Length = 0;
						buffer.Append(newText);
					}

					// For everything else, just break it here.
					done = true;
				}
				else if (IsEscapeChar(text, length))
				{
					// Escape character, include the next automatically.
					buffer.Append(text[length + 1]);
					length += 2;
				}
				else if (IsLineBreak(text, length, ref length))
				{
					// We have a line break, which we want as a separate token.
					break;
				}
				else if (c == '*' || c == '_' || c == '~')
				{
					// Formatting is its own tokens.
					break;
				}
				else
				{
					// Just add the character to the buffer.
					buffer.Append(c);
					length++;
				}
			}

			// Remove the token from the text.
			text = text.Substring(length);
			string token = buffer.ToString();
			return token;
		}

		#endregion
	}
}
