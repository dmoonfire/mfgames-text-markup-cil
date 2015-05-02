// <copyright file="MarkdownState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	/// <summary>
	/// Represents the logic for a single state inside the Markdown processor.
	/// </summary>
	internal abstract class MarkdownState
	{
		#region Public Methods and Operators

		public abstract void Process(MarkdownReader markdown);

		#endregion
	}
}
