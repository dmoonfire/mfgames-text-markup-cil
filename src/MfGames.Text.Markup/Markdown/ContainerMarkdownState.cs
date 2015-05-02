// <copyright file="ContainerMarkdownState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal abstract class ContainerMarkdownState : MarkdownState
	{
		#region Fields

		private bool sentBegin;

		#endregion

		#region Properties

		protected abstract MarkupElementType BeginElementType { get; }
		protected abstract MarkupElementType EndElementType { get; }
		protected int Level { get; set; }

		#endregion

		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			// Send the begin element if we haven't already.
			if (!sentBegin)
			{
				sentBegin = true;
				PrepareContents(markdown);
				markdown.SetLevel(Level);
				markdown.SetState(BeginElementType, this);
				return;
			}

			// See if we can send the contents of the container.
			bool hasMore = ProcessContents(markdown);

			if (hasMore)
			{
				return;
			}

			// Read in the next line and figure out the state.
			MarkdownState nextState = markdown.GetNextBlockState();

			markdown.SetLevel(Level);
			markdown.SetState(EndElementType, nextState);
		}

		#endregion

		#region Methods

		protected virtual void PrepareContents(MarkdownReader markdown)
		{
		}

		protected abstract bool ProcessContents(MarkdownReader markdown);

		#endregion
	}
}
