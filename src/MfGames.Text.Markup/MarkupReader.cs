// <copyright file="MarkupReader.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;
using System.IO;

using MfGames.Text.Markup.IO;

namespace MfGames.Text.Markup
{
	/// <summary>
	/// Common base class for all markup readers.
	/// </summary>
	public abstract class MarkupReader
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MarkupReader"/> class.
		/// </summary>
		/// <param name="reader">
		/// The reader.
		/// </param>
		protected MarkupReader(TextReader reader)
		{
			this.Input = new BlockReader(reader);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MarkupReader"/> class.
		/// </summary>
		/// <param name="lines">
		/// The lines.
		/// </param>
		protected MarkupReader(string[] lines)
			: this(new StringReader(
				string.Join(
					Environment.NewLine,
					lines)))
		{
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the type of the element of the current state.
		/// </summary>
		/// <value>
		/// The type of the element.
		/// </value>
		public abstract MarkupElementType ElementType { get; }

		/// <summary>
		/// Gets the element-specific level of the current element.
		/// </summary>
		public int Level { get; protected set; }

		/// <summary>
		/// Gets or sets the text of the current state.
		/// </summary>
		public string Text { get; protected set; }

		#endregion

		#region Properties

		/// <summary>
		/// </summary>
		protected BlockReader Input { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Reads the next significant element from the marked-up file.
		/// </summary>
		/// <returns>True if there is another element available.</returns>
		public abstract bool Read();

		#endregion

		#region Methods

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		protected virtual void Dispose(bool isDisposing)
		{
		}

		/// <summary>
		/// Resets the internal state to a known value.
		/// </summary>
		protected virtual void Reset()
		{
			Text = null;
			Level = 0;
		}

		#endregion
	}
}
