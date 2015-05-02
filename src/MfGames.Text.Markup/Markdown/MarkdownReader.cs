// <copyright file="MarkdownReader.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;
using System.IO;

namespace MfGames.Text.Markup.Markdown
{
	/// <summary>
	/// Implements a Markdown reader that parses various flavors of Markdown based
	/// on configuration settings.
	/// </summary>
	public class MarkdownReader : MarkupReader, IDisposable
	{
		#region Fields

		/// <summary>
		/// Contains the internal state.
		/// </summary>
		private MarkupElementType elementType;

		private MarkdownState state;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MarkdownReader"/> class.
		/// </summary>
		/// <param name="lines">
		/// The lines.
		/// </param>
		/// <param name="options">
		/// The options.
		/// </param>
		public MarkdownReader(
			string[] lines,
			MarkdownOptions options = null)
			: base(lines)
		{
			this.Options = options ?? MarkdownOptions.DefaultOptions;
			state = new BeginDocumentState();
			Input.IsSingleLineFunc = IsSingleLineElement;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MarkdownReader"/> class.
		/// </summary>
		/// <param name="reader">
		/// The reader.
		/// </param>
		/// <param name="options">
		/// The options.
		/// </param>
		public MarkdownReader(
			TextReader reader,
			MarkdownOptions options = null)
			: base(reader)
		{
			this.Options = options ?? MarkdownOptions.DefaultOptions;
			state = new BeginDocumentState();
			Input.IsSingleLineFunc = IsSingleLineElement;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the type of the element.
		/// </summary>
		/// <value>
		/// The type of the element.
		/// </value>
		public override MarkupElementType ElementType
		{
			get { return this.elementType; }
		}

		/// <summary>
		/// Gets the options associated with the reader.
		/// </summary>
		public MarkdownOptions Options { get; private set; }

		#endregion

		#region Properties

		internal string BlockText { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Reads the next significant element from the marked-up file.
		/// </summary>
		/// <returns>
		/// True if there is another element available.
		/// </returns>
		public override bool Read()
		{
			// This entire process is based on an internal state machine. We
			// need this because there are a number of states that don't touch
			// the underlying buffer. If we don't have a current state, then we
			// are done processing.
			if (state == null)
			{
				return false;
			}

			MarkdownState currentState = state;

			// Reset our internal values. This also erases the current state
			// but we expect currentState to replace it.
			Reset();

			// Process the current state.
			currentState.Process(this);

			// We assume that if we have a state, then we are still reading.
			return true;
		}

		#endregion

		#region Methods

		internal MarkdownState GetNextBlockState(bool readNextBlock = true)
		{
			// See if we need to read the next block.
			if (readNextBlock)
			{
				ReadNextBlock();
			}

			// Figure out what our next state based on the contents. The text
			// is already loaded into the Markdown.
			string text = BlockText.ExpandTabStops();
			MarkdownState nextState;

			if (text == null)
			{
				nextState = new EndContentState();
			}
			else if (MarkdownRegex.CodeBlock.IsMatch(text))
			{
				nextState = new CodeBlockState();
			}
			else if (MarkdownRegex.HorizontalRule.IsMatch(text))
			{
				nextState = new HorizontalRuleState();
			}
			else
			{
				nextState = new ParagraphState();
			}

			return nextState;
		}

		internal string ReadNextBlock()
		{
			BlockText = Input.ReadBlock();
			return BlockText;
		}

		internal void SetState(
			MarkupElementType nextElementType,
			MarkdownState nextState)
		{
			elementType = nextElementType;
			state = nextState;
		}

		internal void SetText(string nextText)
		{
			Text = nextText;
		}

		protected override void Reset()
		{
			base.Reset();
			state = null;
		}

		private bool IsSingleLineElement(string line)
		{
			if (line == null)
			{
				return false;
			}

			if (MarkdownRegex.HorizontalRule.IsMatch(line))
			{
				return true;
			}

			return false;
		}

		#endregion
	}
}
