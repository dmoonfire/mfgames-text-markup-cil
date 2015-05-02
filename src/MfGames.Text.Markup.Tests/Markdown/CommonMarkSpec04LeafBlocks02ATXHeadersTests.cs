// <copyright file="CommonMarkSpec04LeafBlocks02ATXHeadersTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using Xunit;
    using Xunit.Abstractions;

    #region Designer generated code

    /// <summary>
    /// Tests various examples from the CommonMark specifiction.
    /// </summary>
    public class CommonMarkSpec04LeafBlocks02ATXHeadersTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec04LeafBlocks02ATXHeadersTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 23 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample023()
        {
            /* Specification Example:
                .
                # foo
                ## foo
                ### foo
                #### foo
                ##### foo
                ###### foo
                .
                <h1>foo</h1>
                <h2>foo</h2>
                <h3>foo</h3>
                <h4>foo</h4>
                <h5>foo</h5>
                <h6>foo</h6>
                .
            */

            this.Setup(
                "# foo",
                "## foo",
                "### foo",
                "#### foo",
                "##### foo",
                "###### foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginHeader) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 2 },
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.BeginHeader) { Level = 4 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 4 },
                new Event(MarkupElementType.BeginHeader) { Level = 5 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 5 },
                new Event(MarkupElementType.BeginHeader) { Level = 6 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 6 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 24 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample024()
        {
            /* Specification Example:
                .
                ####### foo
                .
                <p>####### foo</p>
                .
            */

            this.Setup(
                "####### foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "####### foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 25 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample025()
        {
            /* Specification Example:
                .
                #5 bolt
                .
                <p>#5 bolt</p>
                .
            */

            this.Setup(
                "#5 bolt");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "#5 bolt" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 26 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample026()
        {
            /* Specification Example:
                .
                \## foo
                .
                <p>## foo</p>
                .
            */

            this.Setup(
                "\\## foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "## foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 27 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample027()
        {
            /* Specification Example:
                .
                # foo *bar* \*baz\*
                .
                <h1>foo <em>bar</em> *baz*</h1>
                .
            */

            this.Setup(
                "# foo *bar* \\*baz\\*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = " *baz*" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 28 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample028()
        {
            /* Specification Example:
                .
                #                  foo                     
                .
                <h1>foo</h1>
                .
            */

            this.Setup(
                "#                  foo                     ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 29 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample029()
        {
            /* Specification Example:
                .
                 ### foo
                  ## foo
                   # foo
                .
                <h3>foo</h3>
                <h2>foo</h2>
                <h1>foo</h1>
                .
            */

            this.Setup(
                " ### foo",
                "  ## foo",
                "   # foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.BeginHeader) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 2 },
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 30 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample030()
        {
            /* Specification Example:
                .
                    # foo
                .
                <pre><code># foo
                </code></pre>
                .
            */

            this.Setup(
                "    # foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "# foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 31 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample031()
        {
            /* Specification Example:
                .
                foo
                    # bar
                .
                <p>foo
                # bar</p>
                .
            */

            this.Setup(
                "foo",
                "    # bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "# bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 32 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample032()
        {
            /* Specification Example:
                .
                ## foo ##
                  ###   bar    ###
                .
                <h2>foo</h2>
                <h3>bar</h3>
                .
            */

            this.Setup(
                "## foo ##",
                "  ###   bar    ###");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 2 },
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 33 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample033()
        {
            /* Specification Example:
                .
                # foo ##################################
                ##### foo ##
                .
                <h1>foo</h1>
                <h5>foo</h5>
                .
            */

            this.Setup(
                "# foo ##################################",
                "##### foo ##");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginHeader) { Level = 5 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 5 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 34 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample034()
        {
            /* Specification Example:
                .
                ### foo ###     
                .
                <h3>foo</h3>
                .
            */

            this.Setup(
                "### foo ###     ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 35 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample035()
        {
            /* Specification Example:
                .
                ### foo ### b
                .
                <h3>foo ### b</h3>
                .
            */

            this.Setup(
                "### foo ### b");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "foo ### b" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 36 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample036()
        {
            /* Specification Example:
                .
                # foo#
                .
                <h1>foo#</h1>
                .
            */

            this.Setup(
                "# foo#");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "foo#" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 37 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample037()
        {
            /* Specification Example:
                .
                ### foo \###
                ## foo #\##
                # foo \#
                .
                <h3>foo ###</h3>
                <h2>foo ###</h2>
                <h1>foo #</h1>
                .
            */

            this.Setup(
                "### foo \\###",
                "## foo #\\##",
                "# foo \\#");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "foo ###" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.BeginHeader) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "foo ###" },
                new Event(MarkupElementType.EndHeader) { Level = 2 },
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "foo #" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 38 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample038()
        {
            /* Specification Example:
                .
                ****
                ## foo
                ****
                .
                <hr />
                <h2>foo</h2>
                <hr />
                .
            */

            this.Setup(
                "****",
                "## foo",
                "****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginHeader) { Level = 2 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 2 },
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 39 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample039()
        {
            /* Specification Example:
                .
                Foo bar
                # baz
                Bar foo
                .
                <p>Foo bar</p>
                <h1>baz</h1>
                <p>Bar foo</p>
                .
            */

            this.Setup(
                "Foo bar",
                "# baz",
                "Bar foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Bar foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 40 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks02ATXHeadersExample040()
        {
            /* Specification Example:
                .
                ## 
                #
                ### ###
                .
                <h2></h2>
                <h1></h1>
                <h3></h3>
                .
            */

            this.Setup(
                "## ",
                "#",
                "### ###");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 2 },
                new Event(MarkupElementType.EndHeader) { Level = 2 },
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
