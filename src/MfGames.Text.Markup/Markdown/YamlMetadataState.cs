// <copyright file="YamlMetadataState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	internal class YamlMetadataState : MarkdownState
	{
		#region Fields

		private bool sentBegin;

		private bool sentMetadata;

		#endregion

		#region Public Methods and Operators

		public override void Process(MarkdownReader markdown)
		{
			if (!sentBegin)
			{
				sentBegin = true;
				markdown.SetState(MarkupElementType.BeginMetadata, this);
				return;
			}

			if (!sentMetadata)
			{
				sentMetadata = true;
				markdown.SetText(markdown.BlockText);
				markdown.ReadNextBlock();
				markdown.SetState(MarkupElementType.YamlMetadata, this);
				return;
			}

			markdown.SetState(
				MarkupElementType.EndMetadata,
				new BeginContentState());
		}

		#endregion
	}
}
