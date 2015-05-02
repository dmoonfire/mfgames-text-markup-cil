// <copyright file="CommonMarkSpec06Inlines09HardLineBreaksTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines09HardLineBreaksTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec06Inlines09HardLineBreaksTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 529 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample529()
        {
            /* Specification Example:
                .
                foo  
                baz
                .
                <p>foo<br />
                baz</p>
                .
            */

            this.Setup(
                "foo  ",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.LineBreak),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 530 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample530()
        {
            /* Specification Example:
                .
                foo\
                baz
                .
                <p>foo<br />
                baz</p>
                .
            */

            this.Setup(
                "foo\\",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.LineBreak),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 531 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample531()
        {
            /* Specification Example:
                .
                foo       
                baz
                .
                <p>foo<br />
                baz</p>
                .
            */

            this.Setup(
                "foo       ",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.LineBreak),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 532 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample532()
        {
            /* Specification Example:
                .
                foo  
                     bar
                .
                <p>foo<br />
                bar</p>
                .
            */

            this.Setup(
                "foo  ",
                "     bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.LineBreak),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 533 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample533()
        {
            /* Specification Example:
                .
                foo\
                     bar
                .
                <p>foo<br />
                bar</p>
                .
            */

            this.Setup(
                "foo\\",
                "     bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.LineBreak),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 534 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample534()
        {
            /* Specification Example:
                .
                *foo  
                bar*
                .
                <p><em>foo<br />
                bar</em></p>
                .
            */

            this.Setup(
                "*foo  ",
                "bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.LineBreak),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 535 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample535()
        {
            /* Specification Example:
                .
                *foo\
                bar*
                .
                <p><em>foo<br />
                bar</em></p>
                .
            */

            this.Setup(
                "*foo\\",
                "bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.LineBreak),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 536 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample536()
        {
            /* Specification Example:
                .
                `code  
                span`
                .
                <p><code>code span</code></p>
                .
            */

            this.Setup(
                "`code  ",
                "span`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "code span" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 537 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample537()
        {
            /* Specification Example:
                .
                `code\
                span`
                .
                <p><code>code\ span</code></p>
                .
            */

            this.Setup(
                "`code\\",
                "span`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "code\\ span" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 538 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample538()
        {
            /* Specification Example:
                .
                <a href="foo  
                bar">
                .
                <p><a href="foo  
                bar"></p>
                .
            */

            this.Setup(
                "<a href=\"foo  ",
                "bar\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<a href=\"foo  " },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar\">" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 539 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample539()
        {
            /* Specification Example:
                .
                <a href="foo\
                bar">
                .
                <p><a href="foo\
                bar"></p>
                .
            */

            this.Setup(
                "<a href=\"foo\\",
                "bar\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<a href=\"foo\\" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar\">" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 540 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample540()
        {
            /* Specification Example:
                .
                foo\
                .
                <p>foo\</p>
                .
            */

            this.Setup(
                "foo\\");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo\\" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 541 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample541()
        {
            /* Specification Example:
                .
                foo  
                .
                <p>foo</p>
                .
            */

            this.Setup(
                "foo  ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 542 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample542()
        {
            /* Specification Example:
                .
                ### foo\
                .
                <h3>foo\</h3>
                .
            */

            this.Setup(
                "### foo\\");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "foo\\" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 543 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines09HardLineBreaksExample543()
        {
            /* Specification Example:
                .
                ### foo  
                .
                <h3>foo</h3>
                .
            */

            this.Setup(
                "### foo  ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginHeader) { Level = 3 },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndHeader) { Level = 3 },
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
