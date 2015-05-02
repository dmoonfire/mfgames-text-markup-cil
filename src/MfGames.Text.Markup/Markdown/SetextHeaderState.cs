// <copyright file="SetextHeaderState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class SetextHeaderState : ContainerMarkdownState
	{
		#region Fields

		private string text;

		#endregion

		#region Properties

		protected override MarkupElementType BeginElementType
		{
			get { return MarkupElementType.BeginHeader; }
		}

		protected override MarkupElementType EndElementType
		{
			get { return MarkupElementType.EndHeader; }
		}

		#endregion

		#region Methods

		protected override void PrepareContents(MarkdownReader markdown)
		{
			string[] parts = markdown.BlockText.Split('\n');

			text = parts[0].Trim().ExpandTabStops();
			Level = parts[1].Trim().StartsWith("=") ? 1 : 2;
		}

		protected override bool ProcessContents(MarkdownReader markdown)
		{
			// If we have a blank text, then we're done.
			if (text == null)
			{
				return false;
			}

			// Otherwise, set the text and return ourselves.
			markdown.SetText(text);
			markdown.SetState(MarkupElementType.Text, this);

			// Clear the text flag so we know to end.
			text = null;
			return true;
		}

		#endregion
	}
}
