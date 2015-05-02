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
		#region Fields

		private bool firstLine;

		#endregion

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

			UnderlyingReader = reader;
			LineIndex++;
			firstLine = true;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets a flag whether the reader should read a YAML block
		/// as a single line.
		/// </summary>
		public bool HasYaml { get; set; }

		public Func<string, bool> IsSingleLineFunc { get; set; }
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
			// Clear flags so we don't do additional processing.
			bool startedAtFirstLine = firstLine;
			firstLine = false;

			// Grab the next line and see if we have special processing for it.
			string line = UnderlyingReader.ReadLine();
			var buffer = new StringBuilder();

			if (line != null && startedAtFirstLine && HasYaml)
			{
				// If the first line has a "---", then we read the entire YAML
				// block into memory and return that.
				if (line.StartsWith("---"))
				{
					buffer.Append(line);
					line = UnderlyingReader.ReadLine();

					while (line != null && line != "---")
					{
						buffer.AppendFormat("\n{0}", line);
						line = UnderlyingReader.ReadLine();
					}

					if (line != null)
					{
						buffer.AppendFormat("\n{0}", line);
					}

					string yamlResults = buffer.ToString();
					return yamlResults;
				}
			}

			// Read until the end of the buffer or the first non-blank line.
			while (line != null && line == "")
			{
				line = UnderlyingReader.ReadLine();
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
			buffer.Append(line);

			// Check to see if this is a single line element. If it is, then we
			// stop reading the line.
			if (!IsSingleLineElement(line))
			{
				// Read until we get a blank or null.
				line = UnderlyingReader.ReadLine();

				while (!string.IsNullOrEmpty(line))
				{
					buffer.AppendFormat("\n{0}", line);
					line = UnderlyingReader.ReadLine();
				}
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

				if (block == null)
				{
					break;
				}

				yield return block;
			}
		}

		#endregion

		#region Methods

		private bool IsSingleLineElement(string line)
		{
			if (IsSingleLineFunc == null)
			{
				return false;
			}

			bool results = IsSingleLineFunc(line);
			return results;
		}

		#endregion
	}
}
