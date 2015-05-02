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
			// Figure out the next state.
			string text = markdown.ReadNextBlock();
			MarkdownState nextState;

			if (text == null)
			{
				// Nothing to read, so nothing to parse.
				nextState = new EndDocumentState();
			}
			else if (markdown.Options.AllowMetadata && text.StartsWith("---"))
			{
				// This is a YAML metadata block.
				nextState = new YamlMetadataState();
			}
			else
			{
				// Everything else is just content.
				nextState = new BeginContentState();
			}

			// Set the state and return.
			markdown.SetState(
				MarkupElementType.BeginDocument,
				nextState);
		}

		#endregion
	}
}
