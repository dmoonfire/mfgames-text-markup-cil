// <copyright file="CommonMarkSpec06Inlines06ImagesTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines06ImagesTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec06Inlines06ImagesTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 471 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample471()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 472 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample472()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 473 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample473()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 474 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample474()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 475 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample475()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 476 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample476()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 477 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample477()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 478 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample478()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 479 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample479()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 480 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample480()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 481 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample481()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 482 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample482()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 483 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample483()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 484 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample484()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 485 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample485()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 486 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample486()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 487 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample487()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 488 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample488()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 489 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample489()
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
        /// Verifies example 490 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample490()
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
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 491 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample491()
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
        /// Verifies example 492 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark06Inlines06ImagesExample492()
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
