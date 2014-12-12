// <copyright file="Event.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a single recorded event from a reader.
    /// </summary>
    public class Event : IEquatable<Event>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="markupElementType">
        /// Type of the markup element.
        /// </param>
        public Event(MarkupElementType markupElementType)
        {
            this.ElementType = markupElementType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        public Event(MarkupReader reader)
        {
            this.ElementType = reader.ElementType;
            this.Text = reader.Text;
            this.Level = reader.Level;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        /// <value>
        /// The type of the element.
        /// </value>
        public MarkupElementType ElementType { get; private set; }

        /// <summary>
        /// Gets or sets the href attribute of an anchor.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the level of heading or bullet lists.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets the text element at the point of the event.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the title attribute of an anchor.
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator ==(Event left, 
            Event right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// </summary>
        /// <param name="left">
        /// </param>
        /// <param name="right">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator !=(Event left, 
            Event right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// </returns>
        public bool Equals(Event other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ElementType == other.ElementType
                && string.Equals(this.Href, other.Href)
                && string.Equals(this.Language, other.Language)
                && this.Level == other.Level
                && string.Equals(this.Text, other.Text)
                && string.Equals(this.Title, other.Title);
        }

        /// <summary>
        /// </summary>
        /// <param name="obj">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Event)obj);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)this.ElementType;
                hashCode = (hashCode * 397)
                    ^ (this.Href != null ? this.Href.GetHashCode() : 0);
                hashCode = (hashCode * 397)
                    ^ (this.Language != null ? this.Language.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.Level;
                hashCode = (hashCode * 397)
                    ^ (this.Text != null ? this.Text.GetHashCode() : 0);
                hashCode = (hashCode * 397)
                    ^ (this.Title != null ? this.Title.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            // Write out the event with default information.
            var buffer = new StringBuilder();

            buffer.Append(this.ElementType);

            // Add the optional fields.
            if (this.Text != null)
            {
                buffer.AppendFormat(
                    ", Text: {0}", 
                    this.Text);
            }

            // Return the resulting buffer.
            return buffer.ToString();
        }

        #endregion
    }
}