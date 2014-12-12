// <copyright file="MarkupReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup
{
    using System;
    using System.IO;

    using MfGames.Text.Markup.Markdown;

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
            this.Input = new InputBuffer(reader);
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
        protected InputBuffer Input { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Reads the next significant element from the marked-up file.
        /// </summary>
        /// <returns>True if there is another element available.</returns>
        public abstract bool Read();

        #endregion

        #region Methods

        /// <summary>
        /// Resets the internal state to a known value.
        /// </summary>
        protected void ResetState()
        {
            this.Text = null;
            this.Level = 0;
        }

        #endregion
    }
}