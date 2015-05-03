// <copyright file="MarkdownOptions.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

namespace MfGames.Text.Markup.Markdown
{
	/// <summary>
	/// Defines the options used for both reading and writing. This includes formatting
	/// options and some of the mutually exclusive sets.
	/// </summary>
	public class MarkdownOptions
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes static members of the <see cref="MarkdownOptions"/> class.
		/// </summary>
		static MarkdownOptions()
		{
			DefaultOptions = new MarkdownOptions();
		}

		public MarkdownOptions()
		{
		}

		public MarkdownOptions(MarkdownOptions options)
			: this()
		{
			AllowMetadata = options.AllowMetadata;
			TreatNewLinesAsBreaks = options.TreatNewLinesAsBreaks;
			Fragment = options.Fragment;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Contains the static default options for Markdown.
		/// </summary>
		public static MarkdownOptions DefaultOptions { get; private set; }

		/// <summary>
		/// Gets or sets a flag whether metadata can be included in the input file.
		/// </summary>
		public bool AllowMetadata { get; set; }

		/// <summary>
		/// Gets or sets a flag whether the document and content flags will
		/// be emitted.
		/// </summary>
		public bool Fragment { get; set; }

		/// <summary>
		/// Gets or sets whether newline are treated as breaks or just continuation
		/// characters of the same block.
		/// </summary>
		public bool TreatNewLinesAsBreaks { get; set; }

		#endregion
	}
}
