// <copyright file="YamlMetadataState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;

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
				// Normalize the YAML.
				string yaml = markdown.BlockText
					.Replace("\r\n", "\n")
					.Replace("\n", Environment.NewLine)
					+ Environment.NewLine;

				// Send the metadata for reading.
				sentMetadata = true;
				markdown.SetText(yaml);
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
