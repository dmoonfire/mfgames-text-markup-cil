// <copyright file="TextContainerMarkdownState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal abstract class TextContainerMarkdownState : ContainerMarkdownState
	{
		#region Properties

		protected InlineState Inline { get; set; }

		#endregion

		#region Methods

		protected override void PrepareContents(MarkdownReader markdown)
		{
			Inline = new InlineState(this, markdown.BlockText);
		}

		protected override bool ProcessContents(MarkdownReader markdown)
		{
			// Process the inline for the first time. It will inject itself
			// into the processing until its done and then it will come back
			// to this one.
			bool hasMore = Inline.ProcessContents(markdown);
			return hasMore;
		}

		#endregion
	}
}
