// <copyright file="CommonMarkSpec06Inlines08RawHTMLTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines08RawHTMLTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec06Inlines08RawHTMLTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 509 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample509()
        {
            /* Specification Example:
                .
                <a><bab><c2c>
                .
                <p><a><bab><c2c></p>
                .
            */

            this.Setup(
                "<a><bab><c2c>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<bab><c2c></p>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 510 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample510()
        {
            /* Specification Example:
                .
                <a/><b2/>
                .
                <p><a/><b2/></p>
                .
            */

            this.Setup(
                "<a/><b2/>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<a/><b2/></p>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 511 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample511()
        {
            /* Specification Example:
                .
                <a  /><b2
                data="foo" >
                .
                <p><a  /><b2
                data="foo" ></p>
                .
            */

            this.Setup(
                "<a  /><b2",
                "data=\"foo\" >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<b2" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "data=\"foo\" >" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 512 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample512()
        {
            /* Specification Example:
                .
                <a foo="bar" bam = 'baz <em>"</em>'
                _boolean zoop:33=zoop:33 />
                .
                <p><a foo="bar" bam = 'baz <em>"</em>'
                _boolean zoop:33=zoop:33 /></p>
                .
            */

            this.Setup(
                "<a foo=\"bar\" bam = 'baz <em>\"</em>'",
                "_boolean zoop:33=zoop:33 />");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<a foo=\"bar\" bam = 'baz <em>\"</em>'" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "_boolean zoop:33=zoop:33 />" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 513 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample513()
        {
            /* Specification Example:
                .
                <33> <__>
                .
                <p>&lt;33&gt; &lt;__&gt;</p>
                .
            */

            this.Setup(
                "<33> <__>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<33> <__>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 514 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample514()
        {
            /* Specification Example:
                .
                <a h*#ref="hi">
                .
                <p>&lt;a h*#ref=&quot;hi&quot;&gt;</p>
                .
            */

            this.Setup(
                "<a h*#ref=\"hi\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<a h*#ref=\"hi\">" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 515 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample515()
        {
            /* Specification Example:
                .
                <a href="hi'> <a href=hi'>
                .
                <p>&lt;a href=&quot;hi'&gt; &lt;a href=hi'&gt;</p>
                .
            */

            this.Setup(
                "<a href=\"hi'> <a href=hi'>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<a href=\"hi'> <a href=hi'>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 516 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample516()
        {
            /* Specification Example:
                .
                < a><
                foo><bar/ >
                .
                <p>&lt; a&gt;&lt;
                foo&gt;&lt;bar/ &gt;</p>
                .
            */

            this.Setup(
                "< a><",
                "foo><bar/ >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "< a><" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "foo><bar/ >" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 517 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample517()
        {
            /* Specification Example:
                .
                <a href='bar'title=title>
                .
                <p>&lt;a href='bar'title=title&gt;</p>
                .
            */

            this.Setup(
                "<a href='bar'title=title>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<a href='bar'title=title>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 518 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample518()
        {
            /* Specification Example:
                .
                </a>
                </foo >
                .
                <p></a>
                </foo ></p>
                .
            */

            this.Setup(
                "</a>",
                "</foo >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "</foo ></p>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 519 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample519()
        {
            /* Specification Example:
                .
                </a href="foo">
                .
                <p>&lt;/a href=&quot;foo&quot;&gt;</p>
                .
            */

            this.Setup(
                "</a href=\"foo\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "</a href=\"foo\">" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 520 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample520()
        {
            /* Specification Example:
                .
                foo <!-- this is a
                comment - with hyphen -->
                .
                <p>foo <!-- this is a
                comment - with hyphen --></p>
                .
            */

            this.Setup(
                "foo <!-- this is a",
                "comment - with hyphen -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<!-- this is a" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "comment - with hyphen -->" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 521 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample521()
        {
            /* Specification Example:
                .
                foo <!-- not a comment -- two hyphens -->
                .
                <p>foo &lt;!-- not a comment -- two hyphens --&gt;</p>
                .
            */

            this.Setup(
                "foo <!-- not a comment -- two hyphens -->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo <!-- not a comment -- two hyphens -->" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 522 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample522()
        {
            /* Specification Example:
                .
                foo <!--> foo -->
                
                foo <!-- foo--->
                .
                <p>foo &lt;!--&gt; foo --&gt;</p>
                <p>foo &lt;!-- foo---&gt;</p>
                .
            */

            this.Setup(
                "foo <!--> foo -->",
                string.Empty,
                "foo <!-- foo--->");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo <!--> foo -->" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo <!-- foo--->" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 523 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample523()
        {
            /* Specification Example:
                .
                foo <?php echo $a; ?>
                .
                <p>foo <?php echo $a; ?></p>
                .
            */

            this.Setup(
                "foo <?php echo $a; ?>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<?php echo $a; ?></p>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 524 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample524()
        {
            /* Specification Example:
                .
                foo <!ELEMENT br EMPTY>
                .
                <p>foo <!ELEMENT br EMPTY></p>
                .
            */

            this.Setup(
                "foo <!ELEMENT br EMPTY>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<!ELEMENT br EMPTY></p>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 525 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample525()
        {
            /* Specification Example:
                .
                foo <![CDATA[>&<]]>
                .
                <p>foo <![CDATA[>&<]]></p>
                .
            */

            this.Setup(
                "foo <![CDATA[>&<]]>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<![CDATA[>&<]]></p>" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 526 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample526()
        {
            /* Specification Example:
                .
                <a href="&ouml;">
                .
                <p><a href="&ouml;"></p>
                .
            */

            this.Setup(
                "<a href=\"&ouml;\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="&ouml;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 527 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample527()
        {
            /* Specification Example:
                .
                <a href="\*">
                .
                <p><a href="\*"></p>
                .
            */

            this.Setup(
                "<a href=\"\\*\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="\\*" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 528 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines08RawHTMLExample528()
        {
            /* Specification Example:
                .
                <a href="\"">
                .
                <p>&lt;a href=&quot;&quot;&quot;&gt;</p>
                .
            */

            this.Setup(
                "<a href=\"\\\"\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<a href=\"\"\">" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
