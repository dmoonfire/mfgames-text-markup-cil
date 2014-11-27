// <copyright file="CommonMarkSpec06Inlines06ImagesTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines06ImagesTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 434 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample434()
        {
            /* Specification Example:
                .
                ![foo](/url "title")
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo](/url \"title\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 435 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample435()
        {
            /* Specification Example:
                .
                ![foo *bar*]
                
                [foo *bar*]: train.jpg "train & tracks"
                .
                <p><img src="train.jpg" alt="foo bar" title="train &amp; tracks" /></p>
                .
            */

            this.Setup(
                "![foo *bar*]",
                string.Empty,
                "[foo *bar*]: train.jpg \"train & tracks\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"train.jpg\" alt=\"foo bar\" title=\"train &amp; tracks\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 436 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample436()
        {
            /* Specification Example:
                .
                ![foo ![bar](/url)](/url2)
                .
                <p><img src="/url2" alt="foo bar" /></p>
                .
            */

            this.Setup(
                "![foo ![bar](/url)](/url2)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url2\" alt=\"foo bar\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 437 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample437()
        {
            /* Specification Example:
                .
                ![foo [bar](/url)](/url2)
                .
                <p><img src="/url2" alt="foo bar" /></p>
                .
            */

            this.Setup(
                "![foo [bar](/url)](/url2)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url2\" alt=\"foo bar\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 438 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample438()
        {
            /* Specification Example:
                .
                ![foo *bar*][]
                
                [foo *bar*]: train.jpg "train & tracks"
                .
                <p><img src="train.jpg" alt="foo bar" title="train &amp; tracks" /></p>
                .
            */

            this.Setup(
                "![foo *bar*][]",
                string.Empty,
                "[foo *bar*]: train.jpg \"train & tracks\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"train.jpg\" alt=\"foo bar\" title=\"train &amp; tracks\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 439 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample439()
        {
            /* Specification Example:
                .
                ![foo *bar*][foobar]
                
                [FOOBAR]: train.jpg "train & tracks"
                .
                <p><img src="train.jpg" alt="foo bar" title="train &amp; tracks" /></p>
                .
            */

            this.Setup(
                "![foo *bar*][foobar]",
                string.Empty,
                "[FOOBAR]: train.jpg \"train & tracks\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"train.jpg\" alt=\"foo bar\" title=\"train &amp; tracks\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 440 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample440()
        {
            /* Specification Example:
                .
                ![foo](train.jpg)
                .
                <p><img src="train.jpg" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo](train.jpg)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"train.jpg\" alt=\"foo\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 441 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample441()
        {
            /* Specification Example:
                .
                My ![foo bar](/path/to/train.jpg  "title"   )
                .
                <p>My <img src="/path/to/train.jpg" alt="foo bar" title="title" /></p>
                .
            */

            this.Setup(
                "My ![foo bar](/path/to/train.jpg  \"title\"   )");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "My " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/path/to/train.jpg\" alt=\"foo bar\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 442 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample442()
        {
            /* Specification Example:
                .
                ![foo](<url>)
                .
                <p><img src="url" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo](<url>)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"url\" alt=\"foo\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 443 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample443()
        {
            /* Specification Example:
                .
                ![](/url)
                .
                <p><img src="/url" alt="" /></p>
                .
            */

            this.Setup(
                "![](/url)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 444 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample444()
        {
            /* Specification Example:
                .
                ![foo] [bar]
                
                [bar]: /url
                .
                <p><img src="/url" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo] [bar]",
                string.Empty,
                "[bar]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 445 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample445()
        {
            /* Specification Example:
                .
                ![foo] [bar]
                
                [BAR]: /url
                .
                <p><img src="/url" alt="foo" /></p>
                .
            */

            this.Setup(
                "![foo] [bar]",
                string.Empty,
                "[BAR]: /url");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 446 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample446()
        {
            /* Specification Example:
                .
                ![foo][]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo][]",
                string.Empty,
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 447 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample447()
        {
            /* Specification Example:
                .
                ![*foo* bar][]
                
                [*foo* bar]: /url "title"
                .
                <p><img src="/url" alt="foo bar" title="title" /></p>
                .
            */

            this.Setup(
                "![*foo* bar][]",
                string.Empty,
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo bar\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 448 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample448()
        {
            /* Specification Example:
                .
                ![Foo][]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="Foo" title="title" /></p>
                .
            */

            this.Setup(
                "![Foo][]",
                string.Empty,
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"Foo\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 449 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample449()
        {
            /* Specification Example:
                .
                ![foo] 
                []
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo] ",
                "[]",
                string.Empty,
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 450 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample450()
        {
            /* Specification Example:
                .
                ![foo]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="foo" title="title" /></p>
                .
            */

            this.Setup(
                "![foo]",
                string.Empty,
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 451 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample451()
        {
            /* Specification Example:
                .
                ![*foo* bar]
                
                [*foo* bar]: /url "title"
                .
                <p><img src="/url" alt="foo bar" title="title" /></p>
                .
            */

            this.Setup(
                "![*foo* bar]",
                string.Empty,
                "[*foo* bar]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"foo bar\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 452 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample452()
        {
            /* Specification Example:
                .
                ![[foo]]
                
                [[foo]]: /url "title"
                .
                <p>![[foo]]</p>
                <p>[[foo]]: /url &quot;title&quot;</p>
                .
            */

            this.Setup(
                "![[foo]]",
                string.Empty,
                "[[foo]]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "![[foo]]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "[[foo]]: /url \"title\"" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 453 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample453()
        {
            /* Specification Example:
                .
                ![Foo]
                
                [foo]: /url "title"
                .
                <p><img src="/url" alt="Foo" title="title" /></p>
                .
            */

            this.Setup(
                "![Foo]",
                string.Empty,
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"/url\" alt=\"Foo\" title=\"title\" /></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 454 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample454()
        {
            /* Specification Example:
                .
                \!\[foo]
                
                [foo]: /url "title"
                .
                <p>![foo]</p>
                .
            */

            this.Setup(
                "\\!\\[foo]",
                string.Empty,
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "![foo]" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 455 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines06ImagesExample455()
        {
            /* Specification Example:
                .
                \![foo]
                
                [foo]: /url "title"
                .
                <p>!<a href="/url" title="title">foo</a></p>
                .
            */

            this.Setup(
                "\\![foo]",
                string.Empty,
                "[foo]: /url \"title\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "!" },
                new Event(MarkupElementType.BeginAnchor) { Href="/url", Title="title" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
