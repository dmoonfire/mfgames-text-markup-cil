// <copyright file="CommonMarkSpec04LeafBlocks06HTMLBlocksTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec04LeafBlocks06HTMLBlocksTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec04LeafBlocks06HTMLBlocksTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 97 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample097()
        {
            /* Specification Example:
                .
                <table>
                  <tr>
                    <td>
                           hi
                    </td>
                  </tr>
                </table>
                
                okay.
                .
                <table>
                  <tr>
                    <td>
                           hi
                    </td>
                  </tr>
                </table>
                <p>okay.</p>
                .
            */

            this.Setup(
                "<table>",
                "  <tr>",
                "    <td>",
                "           hi",
                "    </td>",
                "  </tr>",
                "</table>",
                string.Empty,
                "okay.");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<table>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.Text) { Text = "<tr>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "    " },
                new Event(MarkupElementType.Text) { Text = "<td>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "           hi" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "    " },
                new Event(MarkupElementType.Text) { Text = "</td>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.Text) { Text = "</tr>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "</table>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "okay." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 98 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample098()
        {
            /* Specification Example:
                .
                 <div>
                  *hello*
                         <foo><a>
                .
                 <div>
                  *hello*
                         <foo><a>
                .
            */

            this.Setup(
                " <div>",
                "  *hello*",
                "         <foo><a>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = " " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  *hello*" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "         " },
                new Event(MarkupElementType.Text) { Text = "<foo><a>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 99 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample099()
        {
            /* Specification Example:
                .
                <DIV CLASS="foo">
                
                *Markdown*
                
                </DIV>
                .
                <DIV CLASS="foo">
                <p><em>Markdown</em></p>
                </DIV>
                .
            */

            this.Setup(
                "<DIV CLASS=\"foo\">",
                string.Empty,
                "*Markdown*",
                string.Empty,
                "</DIV>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<DIV CLASS=\"foo\">" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "Markdown" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "</DIV>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 100 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample100()
        {
            /* Specification Example:
                .
                <div></div>
                ``` c
                int x = 33;
                ```
                .
                <div></div>
                ``` c
                int x = 33;
                ```
                .
            */

            this.Setup(
                "<div></div>",
                "``` c",
                "int x = 33;",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<div></div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "``` c" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "int x = 33;" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "```" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 101 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample101()
        {
            /* Specification Example:
                .
                <!-- Foo
                bar
                   baz -->
                .
                <!-- Foo
                bar
                   baz -->
                .
            */

            this.Setup(
                "<!-- Foo",
                "bar",
                "   baz -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<!-- Foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "   baz -->" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 102 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample102()
        {
            /* Specification Example:
                .
                <?php
                  echo '>';
                ?>
                .
                <?php
                  echo '>';
                ?>
                .
            */

            this.Setup(
                "<?php",
                "  echo '>';",
                "?>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<?php" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  echo '>';" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "?>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 103 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample103()
        {
            /* Specification Example:
                .
                <![CDATA[
                function matchwo(a,b)
                {
                if (a < b && a < 0) then
                  {
                  return 1;
                  }
                else
                  {
                  return 0;
                  }
                }
                ]]>
                .
                <![CDATA[
                function matchwo(a,b)
                {
                if (a < b && a < 0) then
                  {
                  return 1;
                  }
                else
                  {
                  return 0;
                  }
                }
                ]]>
                .
            */

            this.Setup(
                "<![CDATA[",
                "function matchwo(a,b)",
                "{",
                "if (a < b && a < 0) then",
                "  {",
                "  return 1;",
                "  }",
                "else",
                "  {",
                "  return 0;",
                "  }",
                "}",
                "]]>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<![CDATA[" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "function matchwo(a,b)" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "{" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "if (a " },
                new Event(MarkupElementType.Text) { Text = "< b && a < 0) then" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  {" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  return 1;" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  }" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "else" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  {" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  return 0;" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "  }" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "}" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "]]>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 104 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample104()
        {
            /* Specification Example:
                .
                  <!-- foo -->
                
                    <!-- foo -->
                .
                  <!-- foo -->
                <pre><code>&lt;!-- foo --&gt;
                </code></pre>
                .
            */

            this.Setup(
                "  <!-- foo -->",
                string.Empty,
                "    <!-- foo -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.Text) { Text = "  " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<!-- foo -->" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "<!-- foo -->" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 105 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample105()
        {
            /* Specification Example:
                .
                Foo
                <div>
                bar
                </div>
                .
                <p>Foo</p>
                <div>
                bar
                </div>
                .
            */

            this.Setup(
                "Foo",
                "<div>",
                "bar",
                "</div>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "</div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 106 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample106()
        {
            /* Specification Example:
                .
                <div>
                bar
                </div>
                *foo*
                .
                <div>
                bar
                </div>
                *foo*
                .
            */

            this.Setup(
                "<div>",
                "bar",
                "</div>",
                "*foo*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "</div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "*foo*" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 107 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample107()
        {
            /* Specification Example:
                .
                <div class
                foo
                .
                <div class
                foo
                .
            */

            this.Setup(
                "<div class",
                "foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<div class" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 108 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample108()
        {
            /* Specification Example:
                .
                <div>
                
                *Emphasized* text.
                
                </div>
                .
                <div>
                <p><em>Emphasized</em> text.</p>
                </div>
                .
            */

            this.Setup(
                "<div>",
                string.Empty,
                "*Emphasized* text.",
                string.Empty,
                "</div>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "Emphasized" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = " text." },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "</div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 109 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample109()
        {
            /* Specification Example:
                .
                <div>
                *Emphasized* text.
                </div>
                .
                <div>
                *Emphasized* text.
                </div>
                .
            */

            this.Setup(
                "<div>",
                "*Emphasized* text.",
                "</div>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "*Emphasized* text." },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "</div>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 110 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark04LeafBlocks06HTMLBlocksExample110()
        {
            /* Specification Example:
                .
                <table>
                
                <tr>
                
                <td>
                Hi
                </td>
                
                </tr>
                
                </table>
                .
                <table>
                <tr>
                <td>
                Hi
                </td>
                </tr>
                </table>
                .
            */

            this.Setup(
                "<table>",
                string.Empty,
                "<tr>",
                string.Empty,
                "<td>",
                "Hi",
                "</td>",
                string.Empty,
                "</tr>",
                string.Empty,
                "</table>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<table>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "<tr>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "<td>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "Hi" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "</td>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "</tr>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "</table>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
