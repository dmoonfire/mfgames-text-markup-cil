// <copyright file="MarkupReaderRecorder.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;
using System.Collections.Generic;

using Xunit.Abstractions;

namespace MfGames.Text.Markup.Tests
{
	/// <summary>
	/// A test base set up to record events from a MarkupReader and then
	/// allow inspection of the results.
	/// </summary>
	public abstract class MarkupReaderRecorderTestsBase
	{
		#region Constructors and Destructors

		protected MarkupReaderRecorderTestsBase(ITestOutputHelper output)
		{
			Output = output;
		}

		#endregion

		#region Properties

		/// <summary>
		/// </summary>
		protected List<Event> Events { get; private set; }

		protected ITestOutputHelper Output { get; set; }

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
