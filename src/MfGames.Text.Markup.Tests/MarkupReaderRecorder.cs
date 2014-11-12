// <copyright file="MarkupReaderRecorder.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests
{
    using System.Collections.Generic;

    /// <summary>
    /// A test base set up to record events from a MarkupReader and then
    /// allow inspection of the results.
    /// </summary>
    public abstract class MarkupReaderRecorderTestsBase
    {
        #region Properties

        /// <summary>
        /// </summary>
        protected List<MarkupReaderRecordedEvent> Events { get; private set; }

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
            this.Events = new List<MarkupReaderRecordedEvent>();

            while (reader.Read())
            {
                var state = new MarkupReaderRecordedEvent(reader);

                this.Events.Add(state);
            }
        }

        #endregion
    }
}