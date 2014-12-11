// <copyright file="CommonMarkSpec06Inlines05LinksTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines05LinksTests :
        MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 363 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample363()
        {
            /* Specification Example:
                .
                [link](/uri "title")
                .
                <p><a href="/uri" title="title">link</a></p>
                .
            */
            this.Setup(
                "[link](/uri \"title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 364 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample364()
        {
            /* Specification Example:
                .
                [link](/uri)
                .
                <p><a href="/uri">link</a></p>
                .
            */
            this.Setup(
                "[link](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 365 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample365()
        {
            /* Specification Example:
                .
                [link]()
                .
                <p><a href="">link</a></p>
                .
            */
            this.Setup(
                "[link]()");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = string.Empty
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 366 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample366()
        {
            /* Specification Example:
                .
                [link](<>)
                .
                <p><a href="">link</a></p>
                .
            */
            this.Setup(
                "[link](<>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = string.Empty
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 367 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample367()
        {
            /* Specification Example:
                .
                [link](/my uri)
                .
                <p>[link](/my uri)</p>
                .
            */
            this.Setup(
                "[link](/my uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[link](/my uri)"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 368 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample368()
        {
            /* Specification Example:
                .
                [link](</my uri>)
                .
                <p><a href="/my%20uri">link</a></p>
                .
            */
            this.Setup(
                "[link](</my uri>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/my%20uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 369 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample369()
        {
            /* Specification Example:
                .
                [link](foo
                bar)
                .
                <p>[link](foo
                bar)</p>
                .
            */
            this.Setup(
                "[link](foo", 
                "bar)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[link](foo"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar)"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 370 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample370()
        {
            /* Specification Example:
                .
                [link]((foo)and(bar))
                .
                <p><a href="(foo)and(bar)">link</a></p>
                .
            */
            this.Setup(
                "[link]((foo)and(bar))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "(foo)and(bar)"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 371 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample371()
        {
            /* Specification Example:
                .
                [link](foo(and(bar)))
                .
                <p>[link](foo(and(bar)))</p>
                .
            */
            this.Setup(
                "[link](foo(and(bar)))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[link](foo(and(bar)))"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 372 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample372()
        {
            /* Specification Example:
                .
                [link](foo(and\(bar\)))
                .
                <p><a href="foo(and(bar))">link</a></p>
                .
            */
            this.Setup(
                "[link](foo(and\\(bar\\)))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "foo(and(bar))"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 373 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample373()
        {
            /* Specification Example:
                .
                [link](<foo(and(bar))>)
                .
                <p><a href="foo(and(bar))">link</a></p>
                .
            */
            this.Setup(
                "[link](<foo(and(bar))>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "foo(and(bar))"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 374 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample374()
        {
            /* Specification Example:
                .
                [link](foo\)\:)
                .
                <p><a href="foo):">link</a></p>
                .
            */
            this.Setup(
                "[link](foo\\)\\:)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "foo):"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 375 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample375()
        {
            /* Specification Example:
                .
                [link](foo%20b&auml;)
                .
                <p><a href="foo%20b%C3%A4">link</a></p>
                .
            */
            this.Setup(
                "[link](foo%20b&auml;)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "foo%20b%C3%A4"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 376 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample376()
        {
            /* Specification Example:
                .
                [link]("title")
                .
                <p><a href="%22title%22">link</a></p>
                .
            */
            this.Setup(
                "[link](\"title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "%22title%22"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 377 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample377()
        {
            /* Specification Example:
                .
                [link](/url "title")
                [link](/url 'title')
                [link](/url (title))
                .
                <p><a href="/url" title="title">link</a>
                <a href="/url" title="title">link</a>
                <a href="/url" title="title">link</a></p>
                .
            */
            this.Setup(
                "[link](/url \"title\")", 
                "[link](/url 'title')", 
                "[link](/url (title))");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 378 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample378()
        {
            /* Specification Example:
                .
                [link](/url "title \"&quot;")
                .
                <p><a href="/url" title="title &quot;&quot;">link</a></p>
                .
            */
            this.Setup(
                "[link](/url \"title \\\"&quot;\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title &quot;&quot;"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 379 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample379()
        {
            /* Specification Example:
                .
                [link](/url "title "and" title")
                .
                <p>[link](/url &quot;title &quot;and&quot; title&quot;)</p>
                .
            */
            this.Setup(
                "[link](/url \"title \"and\" title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[link](/url \"title \"and\" title\")"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 380 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample380()
        {
            /* Specification Example:
                .
                [link](/url 'title "and" title')
                .
                <p><a href="/url" title="title &quot;and&quot; title">link</a></p>
                .
            */
            this.Setup(
                "[link](/url 'title \"and\" title')");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title &quot;and&quot; title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 381 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample381()
        {
            /* Specification Example:
                .
                [link](   /uri
                  "title"  )
                .
                <p><a href="/uri" title="title">link</a></p>
                .
            */
            this.Setup(
                "[link](   /uri", 
                "  \"title\"  )");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 382 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample382()
        {
            /* Specification Example:
                .
                [link] (/uri)
                .
                <p>[link] (/uri)</p>
                .
            */
            this.Setup(
                "[link] (/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[link] (/uri)"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 383 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample383()
        {
            /* Specification Example:
                .
                [link [foo [bar]]](/uri)
                .
                <p><a href="/uri">link [foo [bar]]</a></p>
                .
            */
            this.Setup(
                "[link [foo [bar]]](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link [foo [bar]]"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 384 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample384()
        {
            /* Specification Example:
                .
                [link] bar](/uri)
                .
                <p>[link] bar](/uri)</p>
                .
            */
            this.Setup(
                "[link] bar](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[link] bar](/uri)"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 385 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample385()
        {
            /* Specification Example:
                .
                [link [bar](/uri)
                .
                <p>[link <a href="/uri">bar</a></p>
                .
            */
            this.Setup(
                "[link [bar](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[link "
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 386 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample386()
        {
            /* Specification Example:
                .
                [link \[bar](/uri)
                .
                <p><a href="/uri">link [bar</a></p>
                .
            */
            this.Setup(
                "[link \\[bar](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link [bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 387 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample387()
        {
            /* Specification Example:
                .
                [link *foo **bar** `#`*](/uri)
                .
                <p><a href="/uri">link <em>foo <strong>bar</strong> <code>#</code></em></a></p>
                .
            */
            this.Setup(
                "[link *foo **bar** `#`*](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link "
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo "
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text =
                            "<strong>bar</strong> <code>#</code></em></a></p>"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 388 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample388()
        {
            /* Specification Example:
                .
                [![moon](moon.jpg)](/uri)
                .
                <p><a href="/uri"><img src="moon.jpg" alt="moon" /></a></p>
                .
            */
            this.Setup(
                "[![moon](moon.jpg)](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<img src=\"moon.jpg\" alt=\"moon\" /></a></p>"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 389 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample389()
        {
            /* Specification Example:
                .
                [foo [bar](/uri)](/uri)
                .
                <p>[foo <a href="/uri">bar</a>](/uri)</p>
                .
            */
            this.Setup(
                "[foo [bar](/uri)](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo "
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "](/uri)"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 390 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample390()
        {
            /* Specification Example:
                .
                [foo *[bar [baz](/uri)](/uri)*](/uri)
                .
                <p>[foo <em>[bar <a href="/uri">baz</a>](/uri)</em>](/uri)</p>
                .
            */
            this.Setup(
                "[foo *[bar [baz](/uri)](/uri)*](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo "
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[bar "
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "](/uri)"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "](/uri)"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 391 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample391()
        {
            /* Specification Example:
                .
                *[foo*](/uri)
                .
                <p>*<a href="/uri">foo*</a></p>
                .
            */
            this.Setup(
                "*[foo*](/uri)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "*"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo*"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 392 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample392()
        {
            /* Specification Example:
                .
                [foo *bar](baz*)
                .
                <p><a href="baz*">foo *bar</a></p>
                .
            */
            this.Setup(
                "[foo *bar](baz*)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "baz*"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo *bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 393 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample393()
        {
            /* Specification Example:
                .
                [foo <bar attr="](baz)">
                .
                <p>[foo <bar attr="](baz)"></p>
                .
            */
            this.Setup(
                "[foo <bar attr=\"](baz)\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo "
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<bar attr=\"](baz)\"></p>"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 394 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample394()
        {
            /* Specification Example:
                .
                [foo`](/uri)`
                .
                <p>[foo<code>](/uri)</code></p>
                .
            */
            this.Setup(
                "[foo`](/uri)`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo"
                    }, 
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "](/uri)"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 395 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample395()
        {
            /* Specification Example:
                .
                [foo<http://example.com?search=](uri)>
                .
                <p>[foo<a href="http://example.com?search=%5D(uri)">http://example.com?search=](uri)</a></p>
                .
            */
            this.Setup(
                "[foo<http://example.com?search=](uri)>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "http://example.com?search=%5D(uri)"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "http://example.com?search=](uri)"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 396 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample396()
        {
            /* Specification Example:
                .
                [foo][bar]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */
            this.Setup(
                "[foo][bar]", 
                string.Empty, 
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 397 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample397()
        {
            /* Specification Example:
                .
                [link [foo [bar]]][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">link [foo [bar]]</a></p>
                .
            */
            this.Setup(
                "[link [foo [bar]]][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link [foo [bar]]"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 398 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample398()
        {
            /* Specification Example:
                .
                [link \[bar][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">link [bar</a></p>
                .
            */
            this.Setup(
                "[link \\[bar][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link [bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 399 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample399()
        {
            /* Specification Example:
                .
                [link *foo **bar** `#`*][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">link <em>foo <strong>bar</strong> <code>#</code></em></a></p>
                .
            */
            this.Setup(
                "[link *foo **bar** `#`*][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "link "
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo "
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text =
                            "<strong>bar</strong> <code>#</code></em></a></p>"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 400 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample400()
        {
            /* Specification Example:
                .
                [![moon](moon.jpg)][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri"><img src="moon.jpg" alt="moon" /></a></p>
                .
            */
            this.Setup(
                "[![moon](moon.jpg)][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<img src=\"moon.jpg\" alt=\"moon\" /></a></p>"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 401 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample401()
        {
            /* Specification Example:
                .
                [foo [bar](/uri)][ref]
                
                [ref]: /uri
                .
                <p>[foo <a href="/uri">bar</a>]<a href="/uri">ref</a></p>
                .
            */
            this.Setup(
                "[foo [bar](/uri)][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo "
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "]"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "ref"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 402 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample402()
        {
            /* Specification Example:
                .
                [foo *bar [baz][ref]*][ref]
                
                [ref]: /uri
                .
                <p>[foo <em>bar <a href="/uri">baz</a></em>]<a href="/uri">ref</a></p>
                .
            */
            this.Setup(
                "[foo *bar [baz][ref]*][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo "
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar "
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "]"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "ref"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 403 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample403()
        {
            /* Specification Example:
                .
                *[foo*][ref]
                
                [ref]: /uri
                .
                <p>*<a href="/uri">foo*</a></p>
                .
            */
            this.Setup(
                "*[foo*][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "*"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo*"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 404 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample404()
        {
            /* Specification Example:
                .
                [foo *bar][ref]
                
                [ref]: /uri
                .
                <p><a href="/uri">foo *bar</a></p>
                .
            */
            this.Setup(
                "[foo *bar][ref]", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo *bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 405 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample405()
        {
            /* Specification Example:
                .
                [foo <bar attr="][ref]">
                
                [ref]: /uri
                .
                <p>[foo <bar attr="][ref]"></p>
                .
            */
            this.Setup(
                "[foo <bar attr=\"][ref]\">", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo "
                    }, 
                new Event(MarkupElementType.BeginHtml), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "<bar attr=\"][ref]\"></p>"
                    }, 
                new Event(MarkupElementType.NewLine)
                    {
                        Text = "\r\n"
                    }, 
                new Event(MarkupElementType.EndHtml), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 406 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample406()
        {
            /* Specification Example:
                .
                [foo`][ref]`
                
                [ref]: /uri
                .
                <p>[foo<code>][ref]</code></p>
                .
            */
            this.Setup(
                "[foo`][ref]`", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo"
                    }, 
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "][ref]"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 407 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample407()
        {
            /* Specification Example:
                .
                [foo<http://example.com?search=][ref]>
                
                [ref]: /uri
                .
                <p>[foo<a href="http://example.com?search=%5D%5Bref%5D">http://example.com?search=][ref]</a></p>
                .
            */
            this.Setup(
                "[foo<http://example.com?search=][ref]>", 
                string.Empty, 
                "[ref]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "http://example.com?search=%5D%5Bref%5D"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "http://example.com?search=][ref]"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 408 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample408()
        {
            /* Specification Example:
                .
                [foo][BaR]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */
            this.Setup(
                "[foo][BaR]", 
                string.Empty, 
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 409 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample409()
        {
            /* Specification Example:
                .
                [Толпой][Толпой] is a Russian word.
                
                [ТОЛПОЙ]: /url
                .
                <p><a href="/url">Толпой</a> is a Russian word.</p>
                .
            */
            this.Setup(
                "[Толпой][Толпой] is a Russian word.", 
                string.Empty, 
                "[ТОЛПОЙ]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Толпой"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.Text)
                    {
                        Text = " is a Russian word."
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 410 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample410()
        {
            /* Specification Example:
                .
                [Foo
                  bar]: /url
                
                [Baz][Foo bar]
                .
                <p><a href="/url">Baz</a></p>
                .
            */
            this.Setup(
                "[Foo", 
                "  bar]: /url", 
                string.Empty, 
                "[Baz][Foo bar]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Baz"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 411 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample411()
        {
            /* Specification Example:
                .
                [foo] [bar]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */
            this.Setup(
                "[foo] [bar]", 
                string.Empty, 
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 412 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample412()
        {
            /* Specification Example:
                .
                [foo]
                [bar]
                
                [bar]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */
            this.Setup(
                "[foo]", 
                "[bar]", 
                string.Empty, 
                "[bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 413 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample413()
        {
            /* Specification Example:
                .
                [foo]: /url1
                
                [foo]: /url2
                
                [bar][foo]
                .
                <p><a href="/url1">bar</a></p>
                .
            */
            this.Setup(
                "[foo]: /url1", 
                string.Empty, 
                "[foo]: /url2", 
                string.Empty, 
                "[bar][foo]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url1"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 414 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample414()
        {
            /* Specification Example:
                .
                [bar][foo\!]
                
                [foo!]: /url
                .
                <p>[bar][foo!]</p>
                .
            */
            this.Setup(
                "[bar][foo\\!]", 
                string.Empty, 
                "[foo!]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[bar][foo!]"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 415 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample415()
        {
            /* Specification Example:
                .
                [foo][ref[]
                
                [ref[]: /uri
                .
                <p>[foo][ref[]</p>
                <p>[ref[]: /uri</p>
                .
            */
            this.Setup(
                "[foo][ref[]", 
                string.Empty, 
                "[ref[]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo][ref[]"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[ref[]: /uri"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 416 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample416()
        {
            /* Specification Example:
                .
                [foo][ref[bar]]
                
                [ref[bar]]: /uri
                .
                <p>[foo][ref[bar]]</p>
                <p>[ref[bar]]: /uri</p>
                .
            */
            this.Setup(
                "[foo][ref[bar]]", 
                string.Empty, 
                "[ref[bar]]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo][ref[bar]]"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[ref[bar]]: /uri"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 417 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample417()
        {
            /* Specification Example:
                .
                [[[foo]]]
                
                [[[foo]]]: /url
                .
                <p>[[[foo]]]</p>
                <p>[[[foo]]]: /url</p>
                .
            */
            this.Setup(
                "[[[foo]]]", 
                string.Empty, 
                "[[[foo]]]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[[[foo]]]"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[[[foo]]]: /url"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 418 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample418()
        {
            /* Specification Example:
                .
                [foo][ref\[]
                
                [ref\[]: /uri
                .
                <p><a href="/uri">foo</a></p>
                .
            */
            this.Setup(
                "[foo][ref\\[]", 
                string.Empty, 
                "[ref\\[]: /uri");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/uri"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 419 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample419()
        {
            /* Specification Example:
                .
                [foo][]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */
            this.Setup(
                "[foo][]", 
                string.Empty, 
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 420 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample420()
        {
            /* Specification Example:
                .
                [*foo* bar][]
                
                [*foo* bar]: /url "title"
                .
                <p><a href="/url" title="title"><em>foo</em> bar</a></p>
                .
            */
            this.Setup(
                "[*foo* bar][]", 
                string.Empty, 
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = " bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 421 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample421()
        {
            /* Specification Example:
                .
                [Foo][]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">Foo</a></p>
                .
            */
            this.Setup(
                "[Foo][]", 
                string.Empty, 
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 422 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample422()
        {
            /* Specification Example:
                .
                [foo] 
                []
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */
            this.Setup(
                "[foo] ", 
                "[]", 
                string.Empty, 
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 423 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample423()
        {
            /* Specification Example:
                .
                [foo]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">foo</a></p>
                .
            */
            this.Setup(
                "[foo]", 
                string.Empty, 
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 424 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample424()
        {
            /* Specification Example:
                .
                [*foo* bar]
                
                [*foo* bar]: /url "title"
                .
                <p><a href="/url" title="title"><em>foo</em> bar</a></p>
                .
            */
            this.Setup(
                "[*foo* bar]", 
                string.Empty, 
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = " bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 425 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample425()
        {
            /* Specification Example:
                .
                [[*foo* bar]]
                
                [*foo* bar]: /url "title"
                .
                <p>[<a href="/url" title="title"><em>foo</em> bar</a>]</p>
                .
            */
            this.Setup(
                "[[*foo* bar]]", 
                string.Empty, 
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "["
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.BeginItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndItalic), 
                new Event(MarkupElementType.Text)
                    {
                        Text = " bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "]"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 426 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample426()
        {
            /* Specification Example:
                .
                [Foo]
                
                [foo]: /url "title"
                .
                <p><a href="/url" title="title">Foo</a></p>
                .
            */
            this.Setup(
                "[Foo]", 
                string.Empty, 
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url", 
                        Title = "title"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "Foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 427 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample427()
        {
            /* Specification Example:
                .
                \[foo]
                
                [foo]: /url "title"
                .
                <p>[foo]</p>
                .
            */
            this.Setup(
                "\\[foo]", 
                string.Empty, 
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo]"
                    }, 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 428 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample428()
        {
            /* Specification Example:
                .
                [foo*]: /url
                
                *[foo*]
                .
                <p>*<a href="/url">foo*</a></p>
                .
            */
            this.Setup(
                "[foo*]: /url", 
                string.Empty, 
                "*[foo*]");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "*"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo*"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 429 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample429()
        {
            /* Specification Example:
                .
                [foo`]: /url
                
                [foo`]`
                .
                <p>[foo<code>]</code></p>
                .
            */
            this.Setup(
                "[foo`]: /url", 
                string.Empty, 
                "[foo`]`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo"
                    }, 
                new Event(MarkupElementType.BeginCodeSpan), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "]"
                    }, 
                new Event(MarkupElementType.EndCodeSpan), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 430 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample430()
        {
            /* Specification Example:
                .
                [foo][bar]
                
                [foo]: /url1
                [bar]: /url2
                .
                <p><a href="/url2">foo</a></p>
                .
            */
            this.Setup(
                "[foo][bar]", 
                string.Empty, 
                "[foo]: /url1", 
                "[bar]: /url2");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url2"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 431 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample431()
        {
            /* Specification Example:
                .
                [foo][bar][baz]
                
                [baz]: /url
                .
                <p>[foo]<a href="/url">bar</a></p>
                .
            */
            this.Setup(
                "[foo][bar][baz]", 
                string.Empty, 
                "[baz]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo]"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 432 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample432()
        {
            /* Specification Example:
                .
                [foo][bar][baz]
                
                [baz]: /url1
                [bar]: /url2
                .
                <p><a href="/url2">foo</a><a href="/url1">baz</a></p>
                .
            */
            this.Setup(
                "[foo][bar][baz]", 
                string.Empty, 
                "[baz]: /url1", 
                "[bar]: /url2");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url2"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "foo"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url1"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "baz"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 433 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines05LinksExample433()
        {
            /* Specification Example:
                .
                [foo][bar][baz]
                
                [baz]: /url1
                [foo]: /url2
                .
                <p>[foo]<a href="/url1">bar</a></p>
                .
            */
            this.Setup(
                "[foo][bar][baz]", 
                string.Empty, 
                "[baz]: /url1", 
                "[foo]: /url2");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument), 
                new Event(MarkupElementType.BeginContent), 
                new Event(MarkupElementType.BeginParagraph), 
                new Event(MarkupElementType.Text)
                    {
                        Text = "[foo]"
                    }, 
                new Event(MarkupElementType.BeginAnchor)
                    {
                        Href = "/url1"
                    }, 
                new Event(MarkupElementType.Text)
                    {
                        Text = "bar"
                    }, 
                new Event(MarkupElementType.EndAnchor), 
                new Event(MarkupElementType.EndParagraph), 
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion
}