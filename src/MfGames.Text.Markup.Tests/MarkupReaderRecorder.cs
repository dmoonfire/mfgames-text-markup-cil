// <copyright file="MarkupReaderRecorder.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests
{
    /// <summary>
    /// A test base set up to record events from a MarkupReader and then
    /// allow inspection of the results.
    /// </summary>
    public abstract class MarkupReaderRecorderTestsBase
    {
        #region Methods

        /// <summary>
        /// Sets up the common functionality of the unit test, which may include
        /// one or more operations that are then verified or tested in the [Test]
        /// methods of the class.
        /// </summary>
        protected virtual void Setup()
        {
        }

        #endregion
    }
}