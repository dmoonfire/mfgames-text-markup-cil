// <copyright file="StringExtensions.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Text;

namespace MfGames.Text.Markup.Markdown
{
	public static class StringExtensions
	{
		#region Public Methods and Operators

		/// <summary>
		/// Expands the tabs in the text to tab stops.
		/// </summary>
		public static string ExpandTabStops(this string text, int tabStop = 4)
		{
			// If we have a null or blank, then just return it.
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			// Loop through and add each character in time.
			var buffer = new StringBuilder();

			foreach (char c in text)
			{
				if (c == '\t')
				{
					// For tabs, we insert them as spaces but expand them out
					// to the tab stops. But we have to make sure we add at
					// least one.
					buffer.Append(" ");

					while (buffer.Length % tabStop != 0)
					{
						buffer.Append(" ");
					}
				}
				else
				{
					buffer.Append(c);
				}
			}

			// Return the resulting string.
			string results = buffer.ToString();
			return results;
		}

		#endregion
	}
}
