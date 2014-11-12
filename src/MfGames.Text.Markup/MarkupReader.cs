// <copyright file="MarkupReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup
{
    using System;
    using System.IO;

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
            this.TextReader = reader;
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

        #region Properties

        /// <summary>
        /// Gets the text reader associated with the reader.
        /// </summary>
        protected TextReader TextReader { get; private set; }

        #endregion

        public abstract MarkupElementType ElementType { get; }

        #region Public Methods and Operators

        /// <summary>
        /// Reads the next significant element from the marked-up file.
        /// </summary>
        /// <returns>True if there is another element available.</returns>
        public abstract bool Read();

        #endregion
    }
}
