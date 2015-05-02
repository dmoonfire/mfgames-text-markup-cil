// <copyright file="BeginDocumentState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	/// <summary>
	/// Represents the initial internal staet for the parser.
	/// </summary>
	internal class BeginDocumentState : MarkdownState
	{
		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			markdown.SetState(
				MarkupElementType.BeginDocument,
				new EndDocumentState());
		}

		#endregion
	}
}
