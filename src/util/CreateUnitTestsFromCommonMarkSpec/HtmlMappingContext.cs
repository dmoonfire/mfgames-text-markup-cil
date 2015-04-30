// <copyright file="HtmlMappingContext.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace CreateUnitTestsFromCommonMarkSpec
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Manages the contextual state of the HTML elements along with generating the
    /// textual lines for the unit test.
    /// </summary>
    public class HtmlMappingContext
    {
        #region Fields

        /// <summary>
        /// </summary>
        private readonly HashSet<string> context;

        /// <summary>
        /// </summary>
        private readonly HtmlMapping[] mappings;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// </summary>
        public HtmlMappingContext()
        {
            this.mappings = new[]
                {
                    HtmlMapping.CreateSingle("hr", "HorizontalRule"), 
                    HtmlMapping.CreatePair("p", "Paragraph"), 
                    new HtmlMapping(
                        "CodeBlock", 
                        "<pre><code>", 
                        "BeginCodeBlock", 
                        "</code></pre>", 
                        "EndCodeBlock", 
                        0), 
                    HtmlMapping.CreatePair("code", "CodeSpan"), 
                    HtmlMapping.CreatePair("blockquote", "Blockquote"), 
                    HtmlMapping.CreatePair("em", "Italic"), 
                    HtmlMapping.CreatePair("bold", "Bold"), 
                    HtmlMapping.CreatePair("ol", "OrderedList"), 
                    HtmlMapping.CreatePair("ul", "UnorderedList"), 
                    HtmlMapping.CreatePair("li", "ListItem"), 
                    HtmlMapping.CreatePair("h1", "Header", 1), 
                    HtmlMapping.CreatePair("h2", "Header", 2), 
                    HtmlMapping.CreatePair("h3", "Header", 3), 
                    HtmlMapping.CreatePair("h4", "Header", 4), 
                    HtmlMapping.CreatePair("h5", "Header", 5), 
                    HtmlMapping.CreatePair("h6", "Header", 6), 
                    HtmlMapping.CreatePair("a", "Anchor"), 
                };
            this.context = new HashSet<string>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="type">
        /// </param>
        public void Add(string type)
        {
            this.context.Add(type);
        }

        /// <summary>
        /// </summary>
        /// <param name="type">
        /// </param>
        /// <returns>
        /// </returns>
        public bool Contains(string type)
        {
            return this.context.Contains(type);
        }

        /// <summary>
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <param name="events">
        /// </param>
        /// <returns>
        /// </returns>
        public bool MatchLine(
            ref string line, 
            out IEnumerable<string> events)
        {
            // Go through our mapping and look for a match.
            foreach (HtmlMapping mapping in this.mappings)
            {
                bool isBegin;
                string pairType;

                if (mapping.MatchLine(
                    ref line, out events, out pairType, out isBegin))
                {
                    // Paragraph has some special rules if we are in a HTML context and
                    // start a code block, heading, or paragraph.
                    if (isBegin && this.Contains("Html"))
                    {
                        switch (pairType)
                        {
                            case "Paragraph":
                            case "Heading":
                            case "CodeBlock":
                                List<string> newEvents = events.ToList();
                                newEvents.Insert(0, "EndHtml)");
                                this.Remove("Html");
                                events = newEvents;
                                break;
                        }
                    }

                    // If we have a pair type, then add or remove it.
                    if (pairType != null)
                    {
                        if (isBegin)
                        {
                            this.context.Add(pairType);
                        }
                        else
                        {
                            this.context.Remove(pairType);
                        }
                    }

                    // We have a match so we need to process it.
                    return true;
                }
            }

            // If we got through the loop, we don't have a match.
            events = null;
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="type">
        /// </param>
        public void Remove(string type)
        {
            this.context.Remove(type);
        }

        #endregion
    }
}