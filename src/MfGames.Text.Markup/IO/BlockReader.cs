// <copyright file="BlockReader.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MfGames.Text.Markup.IO
{
	/// <summary>
	/// A specialized reader that wraps around a TextReader and reads data
	/// a block at a time. This is aware of the YAML headers and will retrieve
	/// the entire configuration block as a single paragraph.
	/// </summary>
	public class BlockReader : IDisposable
	{
		#region Constructors and Destructors

		/// <summary>
		/// </summary>
		/// <param name="reader">
		/// </param>
		public BlockReader(TextReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}

			this.UnderlyingReader = reader;
			this.LineIndex++;
		}

		#endregion

		#region Public Properties

		public int LineIndex { get; private set; }
		public TextReader UnderlyingReader { get; set; }

		#endregion

		#region Public Methods and Operators

		public void Dispose()
		{
			if (UnderlyingReader != null)
			{
				UnderlyingReader.Dispose();
				UnderlyingReader = null;
			}
		}

		public string ReadBlock()
		{
			// Read until the end of the buffer or the first non-blank line.
			string line;

			while (true)
			{
				line = UnderlyingReader.ReadLine();

				if (line != null && line == "")
				{
					continue;
				}

				break;
			}

			// If we have a null line, then we are done reading entirely.
			if (line == null)
			{
				return null;
			}

			// There is at least one text line, so create a buffer to hold
			// the multiple lines. We will normalize the line endings to "\n"
			// in the process of reading, but we only do that for each
			// additional line.
			var buffer = new StringBuilder();

			buffer.Append(line);

			// Read until we get a blank or null.
			line = UnderlyingReader.ReadLine();

			while (!string.IsNullOrEmpty(line))
			{
				buffer.AppendFormat("\n{0}", line);
				line = UnderlyingReader.ReadLine();
			}

			// Return the results. This also means that the reader is on the
			// blank or null, but this function can handle initial text.
			string results = buffer.ToString();
			return results;
		}

		public IEnumerable<string> ReadBlocks()
		{
			while (true)
			{
				string block = ReadBlock();

				yield return block;

				if (block == null)
				{
					break;
				}
			}
		}

		#endregion
	}
}
