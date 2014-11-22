// <copyright file="Program.cs" company="Moonfire Games">
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

    /// <summary>
    /// A command-line utility for creating a unit tests from the CommonMark
    /// specification file. This assumes the specification is copied into
    /// the same directory as the executable and the output file is also
    /// located in the same tree.
    /// </summary>
    public class Program
    {
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
                const string OutputFile =
                    @"..\..\..\..\..\src\MfGames.Text.Markup.Tests\Markdown\CommonMarkSpecTests.cs";

                using (
                    FileStream stream = File.Open(OutputFile, FileMode.Create))
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    WriteHeader(writer);
                    ConvertSpec(reader, writer);
                    WriteFooter(writer);
                }
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
        /// Converts the spec file into a NUnit test file.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <param name="writer">
        /// The writer.
        /// </param>
        private static void ConvertSpec(
            StreamReader reader, 
            StreamWriter writer)
        {
            // Loop through all the lines.
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
            StreamWriter writer, 
            string[] output)
        {
            // Go through the output lines and process each one.
            var events = new List<string>();

            foreach (string outputLine in output)
            {
                // Go through the line until it is blank.
                string line = outputLine;

                while (line.Length > 0)
                {
                    // If we have a paragraph, then we need to add that item.
                    var keywords = new[,]
                        {
                            {
                               "<hr />", "HorizontalRule" 
                            }, 
                            {
                               "<p>", "BeginParagraph" 
                            }, 
                            {
                               "</p>", "EndParagraph" 
                            }, 
                            {
                               "<pre><code>", "BeginCodeBlock" 
                            }, 
                            {
                               "</code></pre>", "EndCodeBlock" 
                            }, 
                        };

                    bool foundKeyword = false;

                    for (int index0 = 0;
                        index0 < keywords.GetLength(0);
                        index0++)
                    {
                        if (line.StartsWith(keywords[index0, 0]))
                        {
                            events.Add(keywords[index0, 1] + ")");
                            line = line.Substring(keywords[index0, 0].Length);
                            foundKeyword = true;
                            break;
                        }
                    }

                    if (foundKeyword)
                    {
                        continue;
                    }

                    // Look for a element tag.
                    int index = line.IndexOf("<");
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
                            .Replace("\"", "\\\"");

                        // Write out the text line.
                        events.Add(
                            string.Format(
                                "Text) {1} Text = \"{0}\" {2}", 
                                text, 
                                "{", 
                                "}"));
                        continue;
                    }

                    break;
                }
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
            writer.WriteLine("}");
        }

        /// <summary>
        /// </summary>
        /// <param name="writer">
        /// </param>
        private static void WriteHeader(StreamWriter writer)
        {
            writer.WriteLine(
                "// <copyright file=\"CommonMarkSpecTests.cs\" company=\"Moonfire Games\">");
            writer.WriteLine(
                "//     Copyright (c) Moonfire Games. Some Rights Reserved.");
            writer.WriteLine("// </copyright>");
            writer.WriteLine(
                "// MIT Licensed (http://opensource.org/licenses/MIT)");
            writer.WriteLine("namespace MfGames.Text.Markup.Tests.Markdown");
            writer.WriteLine("{");

            // writer.WriteLine("    using System;");
            // writer.WriteLine(string.Empty);
            // writer.WriteLine("    using MfGames.Text.Markup.Markdown;");
            // writer.WriteLine(string.Empty);
            writer.WriteLine("    using NUnit.Framework;");
            writer.WriteLine(string.Empty);
            writer.WriteLine("    /// <summary>");
            writer.WriteLine(
                "    /// Tests various examples from the CommonMark specifiction.");
            writer.WriteLine("    /// </summary>");
            writer.WriteLine("    [TestFixture]");
            writer.WriteLine(
                "    public class CommonMarkSpecTests : MarkdownReaderRecorderTestsBase");
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
            StreamWriter writer, 
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

                writer.WriteLine(
                    "                \"{0}\"{1}", 
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