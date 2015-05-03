// <copyright file="MarkdownRules.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	public static class MarkdownRules
	{
		#region Public Methods and Operators

		public static bool IsPunctuation(char c)
		{
			switch (c)
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

		#endregion
	}
}
