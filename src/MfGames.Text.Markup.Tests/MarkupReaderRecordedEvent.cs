// <copyright file="MarkupReaderRecordedEvent.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests
{
    /// <summary>
    /// Represents a single recorded event from a reader.
    /// </summary>
    public class MarkupReaderRecordedEvent
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkupReaderRecordedEvent"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public MarkupReaderRecordedEvent(MarkupReader reader)
        {
            this.ElementType = reader.ElementType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        /// <value>
        /// The type of the element.
        /// </value>
        public MarkupElementType ElementType { get; private set; }

        #endregion
    }
}