// <copyright file="HtmlMapping.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace CreateUnitTestsFromCommonMarkSpec
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains a translation between the HTML elements and the corresponding
    /// markup event type, along with contextual processing.
    /// </summary>
    public class HtmlMapping
    {
        #region Constructors and Destructors

        /// <summary>
        /// </summary>
        /// <param name="pairType">
        /// </param>
        /// <param name="startElement">
        /// </param>
        /// <param name="startType">
        /// </param>
        /// <param name="endElement">
        /// </param>
        /// <param name="endType">
        /// </param>
        /// <param name="level">
        /// </param>
        public HtmlMapping(
            string pairType, 
            string startElement, 
            string startType, 
            string endElement, 
            string endType, 
            int level)
        {
            this.PairType = pairType;
            this.StartElement = startElement;
            this.StartType = startType;
            this.EndElement = endElement;
            this.EndType = endType;
            this.Level = level;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// </summary>
        public string EndElement { get; private set; }

        /// <summary>
        /// </summary>
        public string EndType { get; private set; }

        /// <summary>
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// </summary>
        public string PairType { get; private set; }

        /// <summary>
        /// </summary>
        public string StartElement { get; private set; }

        /// <summary>
        /// </summary>
        public string StartType { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="element">
        /// </param>
        /// <param name="typeSuffix">
        /// </param>
        /// <param name="level">
        /// </param>
        /// <returns>
        /// </returns>
        public static HtmlMapping CreatePair(
            string element, 
            string typeSuffix, 
            int level = 0)
        {
            return new HtmlMapping(
                typeSuffix, 
                string.Format("<{0}>", element), 
                "Begin" + typeSuffix, 
                string.Format("</{0}>", element), 
                "End" + typeSuffix, 
                level);
        }

        /// <summary>
        /// </summary>
        /// <param name="element">
        /// </param>
        /// <param name="type">
        /// </param>
        /// <returns>
        /// </returns>
        public static HtmlMapping CreateSingle(
            string element, 
            string type)
        {
            return new HtmlMapping(
                type, 
                string.Format("<{0} />", element), 
                type, 
                null, 
                null, 
                0);
        }

        /// <summary>
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <param name="events">
        /// </param>
        /// <param name="pairType">
        /// </param>
        /// <param name="isBegin">
        /// </param>
        /// <returns>
        /// </returns>
        public bool MatchLine(
            ref string line, 
            out IEnumerable<string> events, 
            out string pairType, 
            out bool isBegin)
        {
            // Check to see if we have a match on the start.
            if (line.StartsWith(this.StartElement))
            {
                // Add in the event description.
                if (this.EndElement == null)
                {
                    events = new[] { this.GetTypeLine() };
                }
                else
                {
                    events = new[] { "Begin" + this.GetTypeLine() };
                }

                // Pull it off the line.
                line = line.Substring(this.StartElement.Length);
                pairType = this.EndElement == null ? null : this.PairType;
                isBegin = true;
                return true;
            }

            // Check to see if we can match the end.
            if (this.EndElement != null && line.StartsWith(this.EndElement))
            {
                // Add in the event description.
                events = new[] { "End" + this.GetTypeLine() };

                // Pull it off the line.
                line = line.Substring(this.EndElement.Length);
                pairType = this.EndElement == null ? null : this.PairType;
                isBegin = false;
                return true;
            }

            // If we don't have a match, then we don't have a match.
            events = null;
            pairType = null;
            isBegin = true;
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private string GetTypeLine()
        {
            // Start with the basic pair.
            var buffer = new StringBuilder();

            buffer.Append(this.PairType);
            buffer.Append(")");

            // If we have a level, then add it.
            if (this.Level > 0)
            {
                buffer.Append(" { Level = ");
                buffer.Append(this.Level);
                buffer.Append(" }");
            }

            // Return the resulting string.
            return buffer.ToString();
        }

        #endregion
    }
}