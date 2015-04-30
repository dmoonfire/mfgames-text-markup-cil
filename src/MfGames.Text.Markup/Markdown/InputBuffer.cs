// <copyright file="InputBuffer.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System.IO;

    using MfGames.IO;

    /// <summary>
    /// A container class that manages the input for a given reader.
    /// </summary>
    public class InputBuffer
    {
        #region Constructors and Destructors

        /// <summary>
        /// </summary>
        /// <param name="reader">
        /// </param>
        public InputBuffer(TextReader reader)
        {
            this.Reader = new PeekableTextReaderAdapter(reader);
            this.CurrentLine = this.Reader.ReadLine();
            this.LineIndex++;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// </summary>
        public bool CurrentIsBlank
        {
            get
            {
                return this.CurrentLine != null && this.CurrentLine.Length == 0;
            }
        }

        /// <summary>
        /// </summary>
        public string CurrentLine { get; set; }

        /// <summary>
        /// </summary>
        public bool IsEndOfBuffer
        {
            get
            {
                return this.CurrentLine == null
                    && this.Reader.PeekLine(0) == null;
            }
        }

        /// <summary>
        /// </summary>
        public int LineIndex { get; private set; }

        /// <summary>
        /// </summary>
        public string NextLine
        {
            get
            {
                return this.Reader.PeekLine(0);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the text reader associated with the reader.
        /// </summary>
        private PeekableTextReaderAdapter Reader { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        public void ReadNext()
        {
            this.CurrentLine = this.Reader.ReadLine();
            this.LineIndex++;
        }

        /// <summary>
        /// </summary>
        /// <param name="linePrefix">
        /// </param>
        public void RemoveFromCurrent(string linePrefix)
        {
            this.CurrentLine = this.CurrentLine.Substring(linePrefix.Length);
        }

        #endregion
    }
}