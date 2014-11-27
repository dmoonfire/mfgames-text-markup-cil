﻿// <copyright file="Program.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace CreateUnitTestsFromCommonMarkSpec
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A command-line utility for creating a unit tests from the CommonMark
    /// specification file. This assumes the specification is copied into
    /// the same directory as the executable and the output file is also
    /// located in the same tree.
    /// </summary>
    public class Program
    {
        #region Static Fields

        /// <summary>
        /// Contains the regular expression for identifying an anchor tag.
        /// </summary>
        private static readonly Regex AnchorRegex = new Regex("^<a ([^><]+)>");

        /// <summary>
        /// </summary>
        private static readonly Regex AttributeRegex =
            new Regex("^\\s*([\\w:]+)=(['\"])(.*?)\\2");

        /// <summary>
        /// </summary>
        private static readonly Regex FenceOptionsRegex =
            new Regex(
                "^<pre><code class=\"language-([^\\s]+)\"(?: data-options=\"(.*?)\")?>");

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Main entry point into the application.
        /// </summary>
        /// <param name="args">
        /// The command-line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            // This is a brute force parsing program. It picks up what it
            // needs from the input file and writes out a unit test that
            // is mostly in the correct format.
            using (
                StreamReader reader = File.OpenText("commonmark-spec-0.12.txt"))
            {
                ConvertSpec(reader);
            }

            // Pause a little so we can see it run.
            if (false)
            {
                Console.Write("Press any key> ");
                Console.ReadKey();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <param name="context">
        /// </param>
        /// <param name="events">
        /// </param>
        /// <returns>
        /// </returns>
        private static bool CheckAnchor(
            ref string line, 
            HtmlMappingContext context, 
            List<string> events)
        {
            // See if we have a match on the anchor tag.
            Match match = AnchorRegex.Match(line);

            if (!match.Success)
            {
                return false;
            }

            // Add the context for inside the anchor.
            context.Add("Anchor");

            // Create the event line with the language.
            var buffer = new StringBuilder();

            buffer.Append("BeginAnchor) {");

            // Parse various elements of the anchor tag.
            var args = new Dictionary<string, string>();
            string attributes = match.Groups[1].Value;

            while (true)
            {
                // Handle the inner match.
                Match innerMatch = AttributeRegex.Match(attributes);

                if (!innerMatch.Success)
                {
                    break;
                }

                // Trim it back.
                attributes = attributes
                    .Substring(innerMatch.Groups[0].Value.Length);

                // Save the values in the object.
                string key = innerMatch.Groups[1].Value;
                string normalized = char.ToUpper(key[0]) + key.Substring(1);
                string value = innerMatch.Groups[3].Value
                    .Replace("\\", "\\\\");

                args[normalized] = value;
            }

            // Process the variables.
            List<string> keys = args.Keys.OrderBy(s => s).ToList();

            for (int index = 0; index < keys.Count; index++)
            {
                // Add in the comma, if we need one.
                if (index > 0)
                {
                    buffer.Append(",");
                }

                // Add in the key/value pair.
                string key = keys[index];

                buffer.AppendFormat(
                    " {0}=\"{1}\"", 
                    key, 
                    args[key]);
            }

            // Finish up the event and add it.
            buffer.Append(" }");
            events.Add(buffer.ToString());

            // Trim off the matched part and continue to avoid an error.
            line = line.Substring(match.Groups[0].Value.Length);
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <param name="context">
        /// </param>
        /// <param name="events">
        /// </param>
        /// <returns>
        /// </returns>
        private static bool CheckFence(
            ref string line, 
            HtmlMappingContext context, 
            List<string> events)
        {
            // See if we have a match on the fence.
            Match match = FenceOptionsRegex.Match(line);

            if (!match.Success)
            {
                return false;
            }

            // Add the context.
            context.Add("CodeBlock");

            // Create the event line with the language.
            var buffer = new StringBuilder();

            buffer.Append("BeginCodeBlock) { Language = \"");
            buffer.Append(match.Groups[1].Value);
            buffer.Append("\"");

            // Add the options, if we have one.
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value))
            {
                buffer.Append(", Options = \"");
                buffer.Append(match.Groups[2].Value);
                buffer.Append("\"");
            }

            // Finish up the event and add it.
            buffer.Append("}");
            events.Add(buffer.ToString());

            // Trim off the matched part and continue to avoid an error.
            line = line.Substring(match.Groups[0].Value.Length);
            return true;
        }

        /// <summary>
        /// Converts the spec file into a NUnit test file.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        private static void ConvertSpec(StreamReader reader)
        {
            // Loop through all the lines.
            TextWriter writer = null;
            int sectionNumber = 0;
            int subSectionNumber = 0;
            int exampleNumber = 0;
            string sectionTitle = null;
            string subSectionTitle = null;

            while (true)
            {
                // Read in the next line, break out if we hit a null.
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                // If the line starts with "# ", then it is a header section.
                if (line.StartsWith("# "))
                {
                    // If we have a writer, then close it off so we can write a
                    // new one if needed.
                    if (writer != null)
                    {
                        WriteFooter(writer);
                        writer.Close();
                        writer = null;
                    }

                    // Pull out the parts so we can use them later.
                    string[] parts = line
                        .Substring(2)
                        .Split(' ')
                        .Select(s => char.ToUpper(s[0]) + s.Substring(1))
                        .ToArray();
                    sectionTitle = string.Join(string.Empty, parts);

                    sectionNumber++;
                    subSectionNumber = 0;

                    // Report where we are.
                    Console.WriteLine(
                        "{0}. {1}", 
                        sectionNumber.ToString().PadLeft(2), 
                        sectionTitle);

                    continue;
                }

                if (line.StartsWith("## "))
                {
                    // If we have a writer, then close it off so we can write a
                    // new one if needed.
                    if (writer != null)
                    {
                        WriteFooter(writer);
                        writer.Close();
                        writer = null;
                    }

                    // Pull out the parts so we can use them later.
                    string[] parts = line
                        .Substring(3)
                        .Split(' ')
                        .Select(s => char.ToUpper(s[0]) + s.Substring(1))
                        .ToArray();
                    subSectionTitle = string.Join(string.Empty, parts);

                    subSectionNumber++;

                    // Report where we are.
                    Console.WriteLine(
                        "  {0}. {1}", 
                        subSectionNumber.ToString().PadLeft(2), 
                        subSectionTitle);

                    continue;
                }

                // If the line is exactly a period, then we have two blocks
                // following this.
                if (line == ".")
                {
                    // We have an example, so see if we have a unit test file
                    // to write them into. If we don't, then create it.
                    if (writer == null)
                    {
                        // Open up the writer name.
                        string className = subSectionNumber > 0
                            ? string.Format(
                                "CommonMarkSpec{0}{1}{2}{3}Tests",
                                sectionNumber.ToString().PadLeft(2, '0'),
                                sectionTitle,
                                subSectionNumber.ToString().PadLeft(2, '0'),
                                subSectionTitle)
                            : string.Format(
                                "CommonMarkSpec{0}{1}Tests",
                                sectionNumber.ToString().PadLeft(2, '0'),
                                sectionTitle);
                        string outputFilename = string.Format(
                            @"{0}\MfGames.Text.Markup.Tests\Markdown\{1}.cs",
                            @"..\..\..\..\..\src",
                            className);
                        var stream = File.Open(outputFilename, FileMode.Create);

                        writer = new StreamWriter(stream, Encoding.UTF8);
                         
                        // Write out the header for this file.
                        WriteHeader(writer, className);
                    }

                    // Increment the example counter.
                    exampleNumber++;

                    // Pull out the two elements of the sample.
                    string[] input = ReadUntilPeriod(reader);
                    string[] output = ReadUntilPeriod(reader);

                    // Write out the unit test.
                    WriteUnitTest(
                        writer, 
                        sectionNumber, 
                        sectionTitle, 
                        subSectionNumber, 
                        subSectionTitle, 
                        exampleNumber, 
                        input, 
                        output);
                }
            }

            // Finish off the writer if we have one open.
            if (writer != null)
            {
                WriteFooter(writer);
                writer.Close();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="reader">
        /// </param>
        /// <returns>
        /// </returns>
        private static string[] ReadUntilPeriod(StreamReader reader)
        {
            // Go through the lines and build up a list of the sample.
            var lines = new List<string>();

            while (true)
            {
                // Read in the next line, break out if we hit a null.
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                // If the line is a period, we are done.
                if (line == ".")
                {
                    break;
                }

                // Otherwise, add the line to the list.
                lines.Add(line);
            }

            // Return the resulting lines.
            return lines.ToArray();
        }

        /// <summary>
        /// </summary>
        /// <param name="writer">
        /// </param>
        /// <param name="output">
        /// </param>
        private static void WriteExpectedOutput(
            TextWriter writer, 
            string[] output)
        {
            // Go through the output lines and process each one while generating a list
            // of unit test event lines for the verification process. We also keep track
            // of context because we need to know if we are inside a paragraph or not
            // for handling newlines.
            var events = new List<string>();
            var context = new HtmlMappingContext();

            foreach (string outputLine in output)
            {
                // Go through the line until it is blank.
                string line = outputLine;

                while (line.Length > 0)
                {
                    // Check to see if we have HTML elements that match. If we do, add
                    // the events and try again.
                    IEnumerable<string> contextEvents;

                    if (context.MatchLine(ref line, out contextEvents))
                    {
                        events.AddRange(contextEvents);
                        continue;
                    }

                    // Look for a element tag.
                    int index = line.IndexOf("<", StringComparison.Ordinal);
                    string text = null;

                    if (index > 0)
                    {
                        // Pull out the text until the next element.
                        text = line.Substring(0, index);
                        line = line.Substring(index);
                    }
                    else if (index < 0)
                    {
                        // Just grab the entire line.
                        text = line;
                        line = string.Empty;
                    }

                    if (text != null)
                    {
                        // Normalize the text.
                        text = text
                            .Replace("\\", "\\\\")
                            .Replace("\"", "\\\"")
                            .Replace("&lt;", "<")
                            .Replace("&gt;", ">")
                            .Replace("&quot;", "\\\"")
                            .Replace("&amp;", "&");

                        // Write out the text line.
                        events.Add(
                            string.Format(
                                "Text) {1} Text = \"{0}\" {2}", 
                                text, 
                                "{", 
                                "}"));
                        continue;
                    }

                    // See if we have some special conditions.
                    if (CheckFence(ref line, context, events))
                    {
                        continue;
                    }

                    if (CheckAnchor(ref line, context, events))
                    {
                        continue;
                    }

                    // For everything else, we think it is a HTML tag.
                    Console.WriteLine("  {0}: Cannot handle element: " + line);

                    // Add the event, if we have one.
                    if (!context.Contains("Html"))
                    {
                        events.Add("BeginHtml)");
                        context.Add("Html");
                    }

                    // Just grab the entire line.
                    text = line
                        .Replace("\\", "\\\\")
                        .Replace("\"", "\\\"");
                    line = string.Empty;
                    events.Add(
                        string.Format(
                            "Text) {1} Text = \"{0}\" {2}", 
                            text, 
                            "{", 
                            "}"));
                }

                // When we get here, we've reached the end of the line. We need to
                // see if we are reporting a newline or not.
                if (context.Contains("Paragraph")
                    || context.Contains("CodeBlock") || context.Contains("Html"))
                {
                    events.Add(
                        string.Format(
                            "Whitespace) {1} Text = \"{0}\" {2}", 
                            @"\r\n", 
                            "{", 
                            "}"));
                }
            }

            // If we still have an HTML context, then add that.
            if (context.Contains("Html"))
            {
                events.Add("EndHtml)");
            }

            // Write out the events.
            foreach (string e in events)
            {
                writer.WriteLine(
                    "                new Event(MarkupElementType.{0},", e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="writer">
        /// </param>
        private static void WriteFooter(TextWriter writer)
        {
            writer.WriteLine("        #endregion");
            writer.WriteLine("    }");
            writer.WriteLine(string.Empty);
            writer.WriteLine("    #endregion");
            writer.WriteLine(string.Empty);
            writer.WriteLine("}");
        }

        /// <summary>
        /// </summary>
        /// <param name="writer">
        /// </param>
        private static void WriteHeader(TextWriter writer, string className)
        {
            writer.WriteLine(
                "// <copyright file=\"{0}.cs\" company=\"Moonfire Games\">", className);
            writer.WriteLine(
                "//     Copyright (c) Moonfire Games. Some Rights Reserved.");
            writer.WriteLine("// </copyright>");
            writer.WriteLine(
                "// MIT Licensed (http://opensource.org/licenses/MIT)");
            writer.WriteLine("namespace MfGames.Text.Markup.Tests.Markdown");
            writer.WriteLine("{");

            writer.WriteLine("    using NUnit.Framework;");
            writer.WriteLine(string.Empty);
            writer.WriteLine("    #region Designer generated code");
            writer.WriteLine(string.Empty);
            writer.WriteLine("    /// <summary>");
            writer.WriteLine(
                "    /// Tests various examples from the CommonMark specifiction.");
            writer.WriteLine("    /// </summary>");
            writer.WriteLine("    [TestFixture]");
            writer.WriteLine(
                "    public class {0} : MarkdownReaderRecorderTestsBase", className);
            writer.WriteLine("    {");
            writer.WriteLine("        #region Public Methods and Operators");
            writer.WriteLine(string.Empty);
        }

        /// <summary>
        /// </summary>
        /// <param name="writer">
        /// </param>
        /// <param name="sectionNumber">
        /// </param>
        /// <param name="sectionTitle">
        /// </param>
        /// <param name="subSectionNumber">
        /// </param>
        /// <param name="subSectionTitle">
        /// </param>
        /// <param name="exampleNumber">
        /// </param>
        /// <param name="input">
        /// </param>
        /// <param name="output">
        /// </param>
        private static void WriteUnitTest(
            TextWriter writer, 
            int sectionNumber, 
            string sectionTitle, 
            int subSectionNumber, 
            string subSectionTitle, 
            int exampleNumber, 
            string[] input, 
            string[] output)
        {
            // Write out the unit test header.
            writer.WriteLine("        /// <summary>");
            writer.WriteLine(
                "        /// Verifies example {0} of the CommonMark specification.", 
                exampleNumber);
            writer.WriteLine("        /// </summary>");
            writer.WriteLine("        [Test]");
            writer.WriteLine(
                "        public void VerifyCommonMark{0}{1}{2}{3}Example{4}()", 
                sectionNumber.ToString().PadLeft(2, '0'), 
                sectionTitle, 
                subSectionNumber.ToString().PadLeft(2, '0'), 
                subSectionTitle, 
                exampleNumber.ToString().PadLeft(3, '0'));
            writer.WriteLine("        {");

            // Go through the samples and write them out as comments.
            writer.WriteLine("            /* Specification Example:");
            writer.WriteLine("                .");

            foreach (string line in input)
            {
                writer.WriteLine("                {0}", line);
            }

            writer.WriteLine("                .");

            foreach (string line in output)
            {
                writer.WriteLine("                {0}", line);
            }

            writer.WriteLine("                .");
            writer.WriteLine("            */");

            // Write the bridge between the example and the setup.
            writer.WriteLine(string.Empty);
            writer.WriteLine("            this.Setup(");

            // Go through the input.
            for (int i = 0; i < input.Length; i++)
            {
                string normalized = input[i]
                    .Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("→", "\\t");

                if (normalized.Length == 0)
                {
                    normalized = "string.Empty";
                }
                else
                {
                    normalized = "\"" + normalized + "\"";
                }

                writer.WriteLine(
                    "                {0}{1}", 
                    normalized, 
                    i + 1 == input.Length ? ");" : ",");
            }

            // Finish up the input processing and start the output.
            writer.WriteLine(string.Empty);
            writer.WriteLine("            this.AssertEventElementTypes(");
            writer.WriteLine(
                "                new Event(MarkupElementType.BeginDocument),");
            writer.WriteLine(
                "                new Event(MarkupElementType.BeginContent),");

            // Figure out what the output should be.
            WriteExpectedOutput(writer, output);

            // Finish up the output processing and the test.
            writer.WriteLine(
                "                new Event(MarkupElementType.EndContent), ");
            writer.WriteLine(
                "                new Event(MarkupElementType.EndDocument));");
            writer.WriteLine("        }");
            writer.WriteLine(string.Empty);
        }

        #endregion
    }
}