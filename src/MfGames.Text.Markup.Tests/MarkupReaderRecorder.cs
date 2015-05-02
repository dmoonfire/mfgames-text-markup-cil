// <copyright file="MarkupReaderRecorder.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests
{
	using System;
	using System.Collections.Generic;

    using Xunit;

    /// <summary>
    /// A test base set up to record events from a MarkupReader and then
    /// allow inspection of the results.
    /// </summary>
    public abstract class MarkupReaderRecorderTestsBase
    {
        #region Properties

        /// <summary>
        /// </summary>
        protected List<Event> Events { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Records the events from a specified reader.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        protected virtual void Record(MarkupReader reader)
        {
            // Create a new list of events and go through them.
            this.Events = new List<Event>();

            while (reader.Read())
            {
                // Record the event.
                var state = new Event(reader);

                this.Events.Add(state);

                // If we have more than a thousand events, we are probably in a loop.
                if (this.Events.Count > 1000)
                {
					throw new IndexOutOfRangeException(
						"Exceeded 1,000 events, possible loop.");
                }
            }
        }

        #endregion
    }
}