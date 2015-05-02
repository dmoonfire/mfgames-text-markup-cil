// <copyright file="BlockTextReader.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.IO;

namespace MfGames.Text.Markup.Markdown
{
	/// <summary>
	/// A specialized reader that wraps around a TextReader and reads data
	/// a block at a time. This is aware of the YAML headers and will retrieve
	/// the entire configuration block as a single paragraph.
	/// </summary>
	public class BlockTextReader
	{
		#region Constructors and Destructors

		/// <summary>
		/// </summary>
		/// <param name="reader">
		/// </param>
		public BlockTextReader(TextReader reader)
		{
			this.UnderlyingReader = reader;
			this.LineIndex++;
		}

		#endregion

		#region Public Properties

		public int LineIndex { get; private set; }
		public TextReader UnderlyingReader { get; set; }

		#endregion
	}
}
