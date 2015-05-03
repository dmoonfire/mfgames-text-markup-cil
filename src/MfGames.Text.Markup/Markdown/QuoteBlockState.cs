// <copyright file="QuoteBlockState.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Collections.Generic;
using System.Linq;

namespace MfGames.Text.Markup.Markdown
{
	internal class QuoteBlockState : ContainerMarkdownState
	{
		#region Fields

		private MarkdownReader reader;

		#endregion

		#region Properties

		protected override MarkupElementType BeginElementType
		{
			get { return MarkupElementType.BeginQuoteBlock; }
		}

		protected override MarkupElementType EndElementType
		{
			get { return MarkupElementType.EndQuoteBlock; }
		}

		#endregion

		#region Methods

		protected override void PrepareContents(MarkdownReader markdown)
		{
			// Strip off the quote lines from the input. The actually ">" isn't
			// required in lines, so we blindly replace it if it is present.
			// The regex also handles nested block quotes by not removing the
			// second one.
			List<string> splitted = markdown.BlockText.Split('\n').ToList();
			string[] stripped = splitted
				.Select(line => MarkdownRegex.BlockQuote.Replace(line, ""))
				.ToArray();

			// Create a Markdown reader with the same options as ourselves.
			var options = new MarkdownOptions(markdown.Options)
			{
				Fragment = true
			};

			reader = new MarkdownReader(stripped, options);
		}

		protected override bool ProcessContents(MarkdownReader markdown)
		{
			// Because this uses a nested reader, we simply call the internal
			// reader until we are done processing.
			bool hasData = reader.Read();

			if (!hasData)
			{
				return false;
			}

			// Copy the inner reader into the outer reader.
			markdown.Set(reader, this);
			return true;
		}

		#endregion
	}
}
