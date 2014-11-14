// <copyright file="Event.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests
{
    using System;

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
        /// Gets the text element at the point of the event.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the level of heading or bullet lists.
        /// </summary>
        public int Level { get; set; }

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
            return Equals(
                left, 
                right);
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
            return !Equals(
                left, 
                right);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// </returns>
        public bool Equals(Event other)
        {
            if (ReferenceEquals(
                null, 
                other))
            {
                return false;
            }

            if (ReferenceEquals(
                this, 
                other))
            {
                return true;
            }

            return this.ElementType == other.ElementType
                && string.Equals(
                    this.Text, 
                    other.Text);
        }

        /// <summary>
        /// </summary>
        /// <param name="obj">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(
                null, 
                obj))
            {
                return false;
            }

            if (ReferenceEquals(
                this, 
                obj))
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
                return ((int)this.ElementType * 397)
                    ^ (this.Text != null ? this.Text.GetHashCode() : 0);
            }
        }

        #endregion
    }
}