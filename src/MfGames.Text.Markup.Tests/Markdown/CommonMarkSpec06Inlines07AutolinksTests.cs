// <copyright file="CommonMarkSpec06Inlines07AutolinksTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using NUnit.Framework;

    #region Designer generated code

    /// <summary>
    /// Tests various examples from the CommonMark specifiction.
    /// </summary>
    [TestFixture]
    public class CommonMarkSpec06Inlines07AutolinksTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 456 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample456()
        {
            /* Specification Example:
                .
                <http://foo.bar.baz>
                .
                <p><a href="http://foo.bar.baz">http://foo.bar.baz</a></p>
                .
            */

            this.Setup(
                "<http://foo.bar.baz>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="http://foo.bar.baz" },
                new Event(MarkupElementType.Text) { Text = "http://foo.bar.baz" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 457 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample457()
        {
            /* Specification Example:
                .
                <http://foo.bar.baz?q=hello&id=22&boolean>
                .
                <p><a href="http://foo.bar.baz?q=hello&amp;id=22&amp;boolean">http://foo.bar.baz?q=hello&amp;id=22&amp;boolean</a></p>
                .
            */

            this.Setup(
                "<http://foo.bar.baz?q=hello&id=22&boolean>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="http://foo.bar.baz?q=hello&amp;id=22&amp;boolean" },
                new Event(MarkupElementType.Text) { Text = "http://foo.bar.baz?q=hello&id=22&boolean" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 458 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample458()
        {
            /* Specification Example:
                .
                <irc://foo.bar:2233/baz>
                .
                <p><a href="irc://foo.bar:2233/baz">irc://foo.bar:2233/baz</a></p>
                .
            */

            this.Setup(
                "<irc://foo.bar:2233/baz>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="irc://foo.bar:2233/baz" },
                new Event(MarkupElementType.Text) { Text = "irc://foo.bar:2233/baz" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 459 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample459()
        {
            /* Specification Example:
                .
                <MAILTO:FOO@BAR.BAZ>
                .
                <p><a href="MAILTO:FOO@BAR.BAZ">MAILTO:FOO@BAR.BAZ</a></p>
                .
            */

            this.Setup(
                "<MAILTO:FOO@BAR.BAZ>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="MAILTO:FOO@BAR.BAZ" },
                new Event(MarkupElementType.Text) { Text = "MAILTO:FOO@BAR.BAZ" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 460 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample460()
        {
            /* Specification Example:
                .
                <http://foo.bar/baz bim>
                .
                <p>&lt;http://foo.bar/baz bim&gt;</p>
                .
            */

            this.Setup(
                "<http://foo.bar/baz bim>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<http://foo.bar/baz bim>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 461 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample461()
        {
            /* Specification Example:
                .
                <foo@bar.example.com>
                .
                <p><a href="mailto:foo@bar.example.com">foo@bar.example.com</a></p>
                .
            */

            this.Setup(
                "<foo@bar.example.com>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="mailto:foo@bar.example.com" },
                new Event(MarkupElementType.Text) { Text = "foo@bar.example.com" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 462 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample462()
        {
            /* Specification Example:
                .
                <foo+special@Bar.baz-bar0.com>
                .
                <p><a href="mailto:foo+special@Bar.baz-bar0.com">foo+special@Bar.baz-bar0.com</a></p>
                .
            */

            this.Setup(
                "<foo+special@Bar.baz-bar0.com>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="mailto:foo+special@Bar.baz-bar0.com" },
                new Event(MarkupElementType.Text) { Text = "foo+special@Bar.baz-bar0.com" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 463 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample463()
        {
            /* Specification Example:
                .
                <>
                .
                <p>&lt;&gt;</p>
                .
            */

            this.Setup(
                "<>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 464 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample464()
        {
            /* Specification Example:
                .
                <heck://bing.bong>
                .
                <p>&lt;heck://bing.bong&gt;</p>
                .
            */

            this.Setup(
                "<heck://bing.bong>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<heck://bing.bong>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 465 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample465()
        {
            /* Specification Example:
                .
                < http://foo.bar >
                .
                <p>&lt; http://foo.bar &gt;</p>
                .
            */

            this.Setup(
                "< http://foo.bar >");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "< http://foo.bar >" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 466 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample466()
        {
            /* Specification Example:
                .
                <foo.bar.baz>
                .
                <p>&lt;foo.bar.baz&gt;</p>
                .
            */

            this.Setup(
                "<foo.bar.baz>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<foo.bar.baz>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 467 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample467()
        {
            /* Specification Example:
                .
                <localhost:5001/foo>
                .
                <p>&lt;localhost:5001/foo&gt;</p>
                .
            */

            this.Setup(
                "<localhost:5001/foo>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "<localhost:5001/foo>" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 468 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample468()
        {
            /* Specification Example:
                .
                http://example.com
                .
                <p>http://example.com</p>
                .
            */

            this.Setup(
                "http://example.com");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "http://example.com" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 469 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines07AutolinksExample469()
        {
            /* Specification Example:
                .
                foo@bar.example.com
                .
                <p>foo@bar.example.com</p>
                .
            */

            this.Setup(
                "foo@bar.example.com");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo@bar.example.com" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
