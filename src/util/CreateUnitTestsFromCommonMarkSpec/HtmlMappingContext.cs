using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUnitTestsFromCommonMarkSpec
{
    /// <summary>
    /// Manages the contextual state of the HTML elements along with generating the
    /// textual lines for the unit test.
    /// </summary>
    public class HtmlMappingContext
    {
        public HtmlMappingContext()
        {
            mappings = new HtmlMapping[]
                {
                    HtmlMapping.CreateSingle("hr", "HorizontalRule"),
                    HtmlMapping.CreatePair("p", "Paragraph"),
                    new HtmlMapping(
                        "CodeBlock",
                        "<pre><code>",
                        "BeginCodeBlock",
                        "</code></pre>",
                        "EndCodeBlock", 0),
                    HtmlMapping.CreatePair("em", "Italic"),
                    HtmlMapping.CreatePair("bold", "Bold"),
                    HtmlMapping.CreatePair("ol", "OrderedList"),
                    HtmlMapping.CreatePair("ul", "UnorderedList"),
                    HtmlMapping.CreatePair("li", "ListItem"),
                    HtmlMapping.CreatePair("h1", "Heading", 1),
                    HtmlMapping.CreatePair("h2", "Heading", 2),
                    HtmlMapping.CreatePair("h3", "Heading", 3),
                    HtmlMapping.CreatePair("h4", "Heading", 4),
                    HtmlMapping.CreatePair("h5", "Heading", 5),
                    HtmlMapping.CreatePair("h6", "Heading", 6),
                };
            this.context = new HashSet<string>();
        }

        private HtmlMapping[] mappings;

        private HashSet<string> context;

        public bool MatchLine(ref string line,
            out IEnumerable<string> events)
        {
            // Go through our mapping and look for a match.
            foreach (var mapping in mappings)
            {
                bool isBegin;
                string pairType;

                if (mapping.MatchLine(ref line, out events, out pairType, out isBegin))
                {
                    // If we have a pair type, then add or remove it.
                    if (pairType != null)
                    {
                        if (isBegin)
                            context.Add(pairType);
                        else
                        {
                            context.Remove(pairType);
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

        public bool Contains(string type)
        {
            return this.context.Contains(type);
        }
    }
}
