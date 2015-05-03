// <copyright file="ParagraphState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class ParagraphState : ContainerMarkdownState
	{
		#region Fields

		private InlineState inline;

		#endregion

		#region Properties

		protected override MarkupElementType BeginElementType
		{
			get { return MarkupElementType.BeginParagraph; }
		}

		protected override MarkupElementType EndElementType
		{
			get { return MarkupElementType.EndParagraph; }
		}

		#endregion

		#region Methods

		protected override void PrepareContents(MarkdownReader markdown)
		{
			inline = new InlineState(this, markdown.BlockText);
		}

		protected override bool ProcessContents(MarkdownReader markdown)
		{
			// Process the inline for the first time. It will inject itself
			// into the processing until its done and then it will come back
			// to this one.
			bool hasMore = inline.ProcessContents(markdown);
			return hasMore;
		}

		#endregion
	}
}
