// <copyright file="CommonMarkSpec06Inlines02EntitiesTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines02EntitiesTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 233 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample233()
        {
            /* Specification Example:
                .
                &nbsp; &amp; &copy; &AElig; &Dcaron; &frac34; &HilbertSpace; &DifferentialD; &ClockwiseContourIntegral;
                .
                <p>  &amp; © Æ Ď ¾ ℋ ⅆ ∲</p>
                .
            */

            this.Setup(
                "&nbsp; &amp; &copy; &AElig; &Dcaron; &frac34; &HilbertSpace; &DifferentialD; &ClockwiseContourIntegral;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "  & © Æ Ď ¾ ℋ ⅆ ∲" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 234 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample234()
        {
            /* Specification Example:
                .
                &#35; &#1234; &#992; &#98765432;
                .
                <p># Ӓ Ϡ �</p>
                .
            */

            this.Setup(
                "&#35; &#1234; &#992; &#98765432;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "# Ӓ Ϡ �" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 235 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample235()
        {
            /* Specification Example:
                .
                &#X22; &#XD06; &#xcab;
                .
                <p>&quot; ആ ಫ</p>
                .
            */

            this.Setup(
                "&#X22; &#XD06; &#xcab;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "\" ആ ಫ" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 236 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample236()
        {
            /* Specification Example:
                .
                &nbsp &x; &#; &#x; &ThisIsWayTooLongToBeAnEntityIsntIt; &hi?;
                .
                <p>&amp;nbsp &amp;x; &amp;#; &amp;#x; &amp;ThisIsWayTooLongToBeAnEntityIsntIt; &amp;hi?;</p>
                .
            */

            this.Setup(
                "&nbsp &x; &#; &#x; &ThisIsWayTooLongToBeAnEntityIsntIt; &hi?;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&nbsp &x; &#; &#x; &ThisIsWayTooLongToBeAnEntityIsntIt; &hi?;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 237 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample237()
        {
            /* Specification Example:
                .
                &copy
                .
                <p>&amp;copy</p>
                .
            */

            this.Setup(
                "&copy");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&copy" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 238 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample238()
        {
            /* Specification Example:
                .
                &MadeUpEntity;
                .
                <p>&amp;MadeUpEntity;</p>
                .
            */

            this.Setup(
                "&MadeUpEntity;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "&MadeUpEntity;" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 239 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample239()
        {
            /* Specification Example:
                .
                <a href="&ouml;&ouml;.html">
                .
                <p><a href="&ouml;&ouml;.html"></p>
                .
            */

            this.Setup(
                "<a href=\"&ouml;&ouml;.html\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="&ouml;&ouml;.html" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 240 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample240()
        {
            /* Specification Example:
                .
                [foo](/f&ouml;&ouml; "f&ouml;&ouml;")
                .
                <p><a href="/f%C3%B6%C3%B6" title="föö">foo</a></p>
                .
            */

            this.Setup(
                "[foo](/f&ouml;&ouml; \"f&ouml;&ouml;\")");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/f%C3%B6%C3%B6", Title="föö" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 241 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample241()
        {
            /* Specification Example:
                .
                [foo]
                
                [foo]: /f&ouml;&ouml; "f&ouml;&ouml;"
                .
                <p><a href="/f%C3%B6%C3%B6" title="föö">foo</a></p>
                .
            */

            this.Setup(
                "[foo]",
                string.Empty,
                "[foo]: /f&ouml;&ouml; \"f&ouml;&ouml;\"");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginAnchor) { Href="/f%C3%B6%C3%B6", Title="föö" },
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 242 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample242()
        {
            /* Specification Example:
                .
                ``` f&ouml;&ouml;
                foo
                ```
                .
                <pre><code class="language-föö">foo
                </code></pre>
                .
            */

            this.Setup(
                "``` f&ouml;&ouml;",
                "foo",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock) { Language = "föö"},
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 243 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample243()
        {
            /* Specification Example:
                .
                `f&ouml;&ouml;`
                .
                <p><code>f&amp;ouml;&amp;ouml;</code></p>
                .
            */

            this.Setup(
                "`f&ouml;&ouml;`");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "f&ouml;&ouml;" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 244 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines02EntitiesExample244()
        {
            /* Specification Example:
                .
                    f&ouml;f&ouml;
                .
                <pre><code>f&amp;ouml;f&amp;ouml;
                </code></pre>
                .
            */

            this.Setup(
                "    f&ouml;f&ouml;");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "f&ouml;f&ouml;" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
