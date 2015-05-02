// <copyright file="CodeBlockState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class CodeBlockState : ContainerMarkdownState
	{
		#region Properties

		protected override MarkupElementType BeginElementType
		{
			get { return MarkupElementType.BeginCodeBlock; }
		}

		protected override MarkupElementType EndElementType
		{
			get { return MarkupElementType.EndCodeBlock; }
		}

		#endregion
	}

	internal abstract class ContainerMarkdownState : MarkdownState
	{
		#region Fields

		private bool sentBegin;

		private bool sentContents;

		#endregion

		#region Properties

		protected abstract MarkupElementType BeginElementType { get; }
		protected abstract MarkupElementType EndElementType { get; }

		#endregion

		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			if (!sentBegin)
			{
				sentBegin = true;
				markdown.SetState(BeginElementType, this);
				return;
			}

			if (!sentContents)
			{
				//sentContents = true;
				//markdown.SetText(markdown.BlockText);
				//markdown.ReadNextBlock();
				//markdown.SetState(MarkupElementType.YamlMetadata, this);
				//return;
			}

			markdown.SetState(
				EndElementType,
				new EndContentState());
		}

		#endregion
	}
}
