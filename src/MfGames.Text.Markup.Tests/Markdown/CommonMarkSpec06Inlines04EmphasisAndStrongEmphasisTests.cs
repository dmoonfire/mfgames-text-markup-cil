// <copyright file="CommonMarkSpec06Inlines04EmphasisAndStrongEmphasisTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec06Inlines04EmphasisAndStrongEmphasisTests : MarkdownReaderRecorderTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 258 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample258()
        {
            /* Specification Example:
                .
                *foo bar*
                .
                <p><em>foo bar</em></p>
                .
            */

            this.Setup(
                "*foo bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 259 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample259()
        {
            /* Specification Example:
                .
                a * foo bar*
                .
                <p>a * foo bar*</p>
                .
            */

            this.Setup(
                "a * foo bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "a * foo bar*" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 260 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample260()
        {
            /* Specification Example:
                .
                foo*bar*
                .
                <p>foo<em>bar</em></p>
                .
            */

            this.Setup(
                "foo*bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 261 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample261()
        {
            /* Specification Example:
                .
                5*6*78
                .
                <p>5<em>6</em>78</p>
                .
            */

            this.Setup(
                "5*6*78");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "5" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "6" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "78" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 262 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample262()
        {
            /* Specification Example:
                .
                _foo bar_
                .
                <p><em>foo bar</em></p>
                .
            */

            this.Setup(
                "_foo bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 263 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample263()
        {
            /* Specification Example:
                .
                _ foo bar_
                .
                <p>_ foo bar_</p>
                .
            */

            this.Setup(
                "_ foo bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_ foo bar_" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 264 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample264()
        {
            /* Specification Example:
                .
                foo_bar_
                .
                <p>foo_bar_</p>
                .
            */

            this.Setup(
                "foo_bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo_bar_" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 265 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample265()
        {
            /* Specification Example:
                .
                5_6_78
                .
                <p>5_6_78</p>
                .
            */

            this.Setup(
                "5_6_78");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "5_6_78" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 266 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample266()
        {
            /* Specification Example:
                .
                пристаням_стремятся_
                .
                <p>пристаням<em>стремятся</em></p>
                .
            */

            this.Setup(
                "пристаням_стремятся_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "пристаням" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "стремятся" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 267 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample267()
        {
            /* Specification Example:
                .
                *foo bar *
                .
                <p>*foo bar *</p>
                .
            */

            this.Setup(
                "*foo bar *");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*foo bar *" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 268 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample268()
        {
            /* Specification Example:
                .
                *foo*bar
                .
                <p><em>foo</em>bar</p>
                .
            */

            this.Setup(
                "*foo*bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 269 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample269()
        {
            /* Specification Example:
                .
                _foo bar _
                .
                <p>_foo bar _</p>
                .
            */

            this.Setup(
                "_foo bar _");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_foo bar _" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 270 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample270()
        {
            /* Specification Example:
                .
                _foo_bar
                .
                <p>_foo_bar</p>
                .
            */

            this.Setup(
                "_foo_bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_foo_bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 271 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample271()
        {
            /* Specification Example:
                .
                _пристаням_стремятся
                .
                <p><em>пристаням</em>стремятся</p>
                .
            */

            this.Setup(
                "_пристаням_стремятся");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "пристаням" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "стремятся" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 272 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample272()
        {
            /* Specification Example:
                .
                _foo_bar_baz_
                .
                <p><em>foo_bar_baz</em></p>
                .
            */

            this.Setup(
                "_foo_bar_baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo_bar_baz" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 273 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample273()
        {
            /* Specification Example:
                .
                **foo bar**
                .
                <p><strong>foo bar</strong></p>
                .
            */

            this.Setup(
                "**foo bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo bar</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 274 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample274()
        {
            /* Specification Example:
                .
                ** foo bar**
                .
                <p>** foo bar**</p>
                .
            */

            this.Setup(
                "** foo bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "** foo bar**" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 275 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample275()
        {
            /* Specification Example:
                .
                foo**bar**
                .
                <p>foo<strong>bar</strong></p>
                .
            */

            this.Setup(
                "foo**bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>bar</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 276 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample276()
        {
            /* Specification Example:
                .
                __foo bar__
                .
                <p><strong>foo bar</strong></p>
                .
            */

            this.Setup(
                "__foo bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo bar</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 277 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample277()
        {
            /* Specification Example:
                .
                __ foo bar__
                .
                <p>__ foo bar__</p>
                .
            */

            this.Setup(
                "__ foo bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__ foo bar__" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 278 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample278()
        {
            /* Specification Example:
                .
                foo__bar__
                .
                <p>foo__bar__</p>
                .
            */

            this.Setup(
                "foo__bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo__bar__" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 279 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample279()
        {
            /* Specification Example:
                .
                5__6__78
                .
                <p>5__6__78</p>
                .
            */

            this.Setup(
                "5__6__78");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "5__6__78" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 280 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample280()
        {
            /* Specification Example:
                .
                пристаням__стремятся__
                .
                <p>пристаням<strong>стремятся</strong></p>
                .
            */

            this.Setup(
                "пристаням__стремятся__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "пристаням" },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>стремятся</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 281 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample281()
        {
            /* Specification Example:
                .
                __foo, __bar__, baz__
                .
                <p><strong>foo, <strong>bar</strong>, baz</strong></p>
                .
            */

            this.Setup(
                "__foo, __bar__, baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo, <strong>bar</strong>, baz</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 282 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample282()
        {
            /* Specification Example:
                .
                **foo bar **
                .
                <p>**foo bar **</p>
                .
            */

            this.Setup(
                "**foo bar **");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**foo bar **" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 283 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample283()
        {
            /* Specification Example:
                .
                **foo**bar
                .
                <p><strong>foo</strong>bar</p>
                .
            */

            this.Setup(
                "**foo**bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong>bar</p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 284 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample284()
        {
            /* Specification Example:
                .
                __foo bar __
                .
                <p>__foo bar __</p>
                .
            */

            this.Setup(
                "__foo bar __");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__foo bar __" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 285 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample285()
        {
            /* Specification Example:
                .
                __foo__bar
                .
                <p>__foo__bar</p>
                .
            */

            this.Setup(
                "__foo__bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__foo__bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 286 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample286()
        {
            /* Specification Example:
                .
                __пристаням__стремятся
                .
                <p><strong>пристаням</strong>стремятся</p>
                .
            */

            this.Setup(
                "__пристаням__стремятся");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>пристаням</strong>стремятся</p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 287 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample287()
        {
            /* Specification Example:
                .
                __foo__bar__baz__
                .
                <p><strong>foo__bar__baz</strong></p>
                .
            */

            this.Setup(
                "__foo__bar__baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo__bar__baz</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 288 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample288()
        {
            /* Specification Example:
                .
                *foo [bar](/url)*
                .
                <p><em>foo <a href="/url">bar</a></em></p>
                .
            */

            this.Setup(
                "*foo [bar](/url)*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 289 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample289()
        {
            /* Specification Example:
                .
                *foo
                bar*
                .
                <p><em>foo
                bar</em></p>
                .
            */

            this.Setup(
                "*foo",
                "bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 290 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample290()
        {
            /* Specification Example:
                .
                _foo __bar__ baz_
                .
                <p><em>foo <strong>bar</strong> baz</em></p>
                .
            */

            this.Setup(
                "_foo __bar__ baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>bar</strong> baz</em></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 291 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample291()
        {
            /* Specification Example:
                .
                _foo _bar_ baz_
                .
                <p><em>foo <em>bar</em> baz</em></p>
                .
            */

            this.Setup(
                "_foo _bar_ baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = " baz" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 292 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample292()
        {
            /* Specification Example:
                .
                __foo_ bar_
                .
                <p><em><em>foo</em> bar</em></p>
                .
            */

            this.Setup(
                "__foo_ bar_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = " bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 293 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample293()
        {
            /* Specification Example:
                .
                *foo *bar**
                .
                <p><em>foo <em>bar</em></em></p>
                .
            */

            this.Setup(
                "*foo *bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 294 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample294()
        {
            /* Specification Example:
                .
                *foo **bar** baz*
                .
                <p><em>foo <strong>bar</strong> baz</em></p>
                .
            */

            this.Setup(
                "*foo **bar** baz*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>bar</strong> baz</em></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 295 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample295()
        {
            /* Specification Example:
                .
                *foo**bar**baz*
                .
                <p><em>foo</em><em>bar</em><em>baz</em></p>
                .
            */

            this.Setup(
                "*foo**bar**baz*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 296 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample296()
        {
            /* Specification Example:
                .
                ***foo** bar*
                .
                <p><em><strong>foo</strong> bar</em></p>
                .
            */

            this.Setup(
                "***foo** bar*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong> bar</em></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 297 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample297()
        {
            /* Specification Example:
                .
                *foo **bar***
                .
                <p><em>foo <strong>bar</strong></em></p>
                .
            */

            this.Setup(
                "*foo **bar***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>bar</strong></em></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 298 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample298()
        {
            /* Specification Example:
                .
                *foo**bar***
                .
                <p><em>foo</em><em>bar</em>**</p>
                .
            */

            this.Setup(
                "*foo**bar***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "**" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 299 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample299()
        {
            /* Specification Example:
                .
                *foo **bar *baz* bim** bop*
                .
                <p><em>foo <strong>bar <em>baz</em> bim</strong> bop</em></p>
                .
            */

            this.Setup(
                "*foo **bar *baz* bim** bop*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>bar <em>baz</em> bim</strong> bop</em></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 300 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample300()
        {
            /* Specification Example:
                .
                *foo [*bar*](/url)*
                .
                <p><em>foo <a href="/url"><em>bar</em></a></em></p>
                .
            */

            this.Setup(
                "*foo [*bar*](/url)*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 301 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample301()
        {
            /* Specification Example:
                .
                ** is not an empty emphasis
                .
                <p>** is not an empty emphasis</p>
                .
            */

            this.Setup(
                "** is not an empty emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "** is not an empty emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 302 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample302()
        {
            /* Specification Example:
                .
                **** is not an empty strong emphasis
                .
                <p>**** is not an empty strong emphasis</p>
                .
            */

            this.Setup(
                "**** is not an empty strong emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**** is not an empty strong emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 303 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample303()
        {
            /* Specification Example:
                .
                **foo [bar](/url)**
                .
                <p><strong>foo <a href="/url">bar</a></strong></p>
                .
            */

            this.Setup(
                "**foo [bar](/url)**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <a href=\"/url\">bar</a></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 304 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample304()
        {
            /* Specification Example:
                .
                **foo
                bar**
                .
                <p><strong>foo
                bar</strong></p>
                .
            */

            this.Setup(
                "**foo",
                "bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.Text) { Text = "</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 305 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample305()
        {
            /* Specification Example:
                .
                __foo _bar_ baz__
                .
                <p><strong>foo <em>bar</em> baz</strong></p>
                .
            */

            this.Setup(
                "__foo _bar_ baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <em>bar</em> baz</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 306 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample306()
        {
            /* Specification Example:
                .
                __foo __bar__ baz__
                .
                <p><strong>foo <strong>bar</strong> baz</strong></p>
                .
            */

            this.Setup(
                "__foo __bar__ baz__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <strong>bar</strong> baz</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 307 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample307()
        {
            /* Specification Example:
                .
                ____foo__ bar__
                .
                <p><strong><strong>foo</strong> bar</strong></p>
                .
            */

            this.Setup(
                "____foo__ bar__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong><strong>foo</strong> bar</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 308 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample308()
        {
            /* Specification Example:
                .
                **foo **bar****
                .
                <p><strong>foo <strong>bar</strong></strong></p>
                .
            */

            this.Setup(
                "**foo **bar****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <strong>bar</strong></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 309 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample309()
        {
            /* Specification Example:
                .
                **foo *bar* baz**
                .
                <p><strong>foo <em>bar</em> baz</strong></p>
                .
            */

            this.Setup(
                "**foo *bar* baz**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <em>bar</em> baz</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 310 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample310()
        {
            /* Specification Example:
                .
                **foo*bar*baz**
                .
                <p><em><em>foo</em>bar</em>baz**</p>
                .
            */

            this.Setup(
                "**foo*bar*baz**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "baz**" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 311 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample311()
        {
            /* Specification Example:
                .
                ***foo* bar**
                .
                <p><strong><em>foo</em> bar</strong></p>
                .
            */

            this.Setup(
                "***foo* bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong><em>foo</em> bar</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 312 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample312()
        {
            /* Specification Example:
                .
                **foo *bar***
                .
                <p><strong>foo <em>bar</em></strong></p>
                .
            */

            this.Setup(
                "**foo *bar***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <em>bar</em></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 313 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample313()
        {
            /* Specification Example:
                .
                **foo *bar **baz**
                bim* bop**
                .
                <p><strong>foo <em>bar <strong>baz</strong>
                bim</em> bop</strong></p>
                .
            */

            this.Setup(
                "**foo *bar **baz**",
                "bim* bop**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <em>bar <strong>baz</strong>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.Text) { Text = "bim" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = " bop" },
                new Event(MarkupElementType.Text) { Text = "</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 314 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample314()
        {
            /* Specification Example:
                .
                **foo [*bar*](/url)**
                .
                <p><strong>foo <a href="/url"><em>bar</em></a></strong></p>
                .
            */

            this.Setup(
                "**foo [*bar*](/url)**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo <a href=\"/url\"><em>bar</em></a></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 315 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample315()
        {
            /* Specification Example:
                .
                __ is not an empty emphasis
                .
                <p>__ is not an empty emphasis</p>
                .
            */

            this.Setup(
                "__ is not an empty emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__ is not an empty emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 316 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample316()
        {
            /* Specification Example:
                .
                ____ is not an empty strong emphasis
                .
                <p>____ is not an empty strong emphasis</p>
                .
            */

            this.Setup(
                "____ is not an empty strong emphasis");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "____ is not an empty strong emphasis" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 317 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample317()
        {
            /* Specification Example:
                .
                foo ***
                .
                <p>foo ***</p>
                .
            */

            this.Setup(
                "foo ***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo ***" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 318 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample318()
        {
            /* Specification Example:
                .
                foo *\**
                .
                <p>foo <em>*</em></p>
                .
            */

            this.Setup(
                "foo *\\**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 319 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample319()
        {
            /* Specification Example:
                .
                foo *_*
                .
                <p>foo <em>_</em></p>
                .
            */

            this.Setup(
                "foo *_*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 320 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample320()
        {
            /* Specification Example:
                .
                foo *****
                .
                <p>foo *****</p>
                .
            */

            this.Setup(
                "foo *****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo *****" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 321 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample321()
        {
            /* Specification Example:
                .
                foo **\***
                .
                <p>foo <strong>*</strong></p>
                .
            */

            this.Setup(
                "foo **\\***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>*</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 322 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample322()
        {
            /* Specification Example:
                .
                foo **_**
                .
                <p>foo <strong>_</strong></p>
                .
            */

            this.Setup(
                "foo **_**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>_</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 323 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample323()
        {
            /* Specification Example:
                .
                **foo*
                .
                <p>*<em>foo</em></p>
                .
            */

            this.Setup(
                "**foo*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 324 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample324()
        {
            /* Specification Example:
                .
                *foo**
                .
                <p><em>foo</em>*</p>
                .
            */

            this.Setup(
                "*foo**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 325 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample325()
        {
            /* Specification Example:
                .
                ***foo**
                .
                <p>*<strong>foo</strong></p>
                .
            */

            this.Setup(
                "***foo**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 326 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample326()
        {
            /* Specification Example:
                .
                ****foo*
                .
                <p>***<em>foo</em></p>
                .
            */

            this.Setup(
                "****foo*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "***" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 327 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample327()
        {
            /* Specification Example:
                .
                **foo***
                .
                <p><strong>foo</strong>*</p>
                .
            */

            this.Setup(
                "**foo***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong>*</p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 328 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample328()
        {
            /* Specification Example:
                .
                *foo****
                .
                <p><em>foo</em>***</p>
                .
            */

            this.Setup(
                "*foo****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "***" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 329 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample329()
        {
            /* Specification Example:
                .
                foo ___
                .
                <p>foo ___</p>
                .
            */

            this.Setup(
                "foo ___");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo ___" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 330 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample330()
        {
            /* Specification Example:
                .
                foo _\__
                .
                <p>foo <em>_</em></p>
                .
            */

            this.Setup(
                "foo _\\__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 331 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample331()
        {
            /* Specification Example:
                .
                foo _*_
                .
                <p>foo <em>*</em></p>
                .
            */

            this.Setup(
                "foo _*_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 332 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample332()
        {
            /* Specification Example:
                .
                foo _____
                .
                <p>foo _____</p>
                .
            */

            this.Setup(
                "foo _____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo _____" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 333 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample333()
        {
            /* Specification Example:
                .
                foo __\___
                .
                <p>foo <strong>_</strong></p>
                .
            */

            this.Setup(
                "foo __\\___");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>_</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 334 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample334()
        {
            /* Specification Example:
                .
                foo __*__
                .
                <p>foo <strong>*</strong></p>
                .
            */

            this.Setup(
                "foo __*__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>*</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 335 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample335()
        {
            /* Specification Example:
                .
                __foo_
                .
                <p>_<em>foo</em></p>
                .
            */

            this.Setup(
                "__foo_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 336 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample336()
        {
            /* Specification Example:
                .
                _foo__
                .
                <p><em>foo</em>_</p>
                .
            */

            this.Setup(
                "_foo__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 337 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample337()
        {
            /* Specification Example:
                .
                ___foo__
                .
                <p>_<strong>foo</strong></p>
                .
            */

            this.Setup(
                "___foo__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 338 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample338()
        {
            /* Specification Example:
                .
                ____foo_
                .
                <p>___<em>foo</em></p>
                .
            */

            this.Setup(
                "____foo_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "___" },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 339 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample339()
        {
            /* Specification Example:
                .
                __foo___
                .
                <p><strong>foo</strong>_</p>
                .
            */

            this.Setup(
                "__foo___");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong>_</p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 340 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample340()
        {
            /* Specification Example:
                .
                _foo____
                .
                <p><em>foo</em>___</p>
                .
            */

            this.Setup(
                "_foo____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "___" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 341 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample341()
        {
            /* Specification Example:
                .
                **foo**
                .
                <p><strong>foo</strong></p>
                .
            */

            this.Setup(
                "**foo**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 342 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample342()
        {
            /* Specification Example:
                .
                *_foo_*
                .
                <p><em><em>foo</em></em></p>
                .
            */

            this.Setup(
                "*_foo_*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 343 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample343()
        {
            /* Specification Example:
                .
                __foo__
                .
                <p><strong>foo</strong></p>
                .
            */

            this.Setup(
                "__foo__");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>foo</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 344 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample344()
        {
            /* Specification Example:
                .
                _*foo*_
                .
                <p><em><em>foo</em></em></p>
                .
            */

            this.Setup(
                "_*foo*_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 345 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample345()
        {
            /* Specification Example:
                .
                ****foo****
                .
                <p><strong><strong>foo</strong></strong></p>
                .
            */

            this.Setup(
                "****foo****");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong><strong>foo</strong></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 346 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample346()
        {
            /* Specification Example:
                .
                ____foo____
                .
                <p><strong><strong>foo</strong></strong></p>
                .
            */

            this.Setup(
                "____foo____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong><strong>foo</strong></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 347 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample347()
        {
            /* Specification Example:
                .
                ******foo******
                .
                <p><strong><strong><strong>foo</strong></strong></strong></p>
                .
            */

            this.Setup(
                "******foo******");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong><strong><strong>foo</strong></strong></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 348 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample348()
        {
            /* Specification Example:
                .
                ***foo***
                .
                <p><strong><em>foo</em></strong></p>
                .
            */

            this.Setup(
                "***foo***");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong><em>foo</em></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 349 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample349()
        {
            /* Specification Example:
                .
                _____foo_____
                .
                <p><strong><strong><em>foo</em></strong></strong></p>
                .
            */

            this.Setup(
                "_____foo_____");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong><strong><em>foo</em></strong></strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 350 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample350()
        {
            /* Specification Example:
                .
                *foo _bar* baz_
                .
                <p><em>foo _bar</em> baz_</p>
                .
            */

            this.Setup(
                "*foo _bar* baz_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo _bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = " baz_" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 351 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample351()
        {
            /* Specification Example:
                .
                **foo*bar**
                .
                <p><em><em>foo</em>bar</em>*</p>
                .
            */

            this.Setup(
                "**foo*bar**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 352 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample352()
        {
            /* Specification Example:
                .
                **foo **bar baz**
                .
                <p>**foo <strong>bar baz</strong></p>
                .
            */

            this.Setup(
                "**foo **bar baz**");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**foo " },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<strong>bar baz</strong></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 353 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample353()
        {
            /* Specification Example:
                .
                *foo *bar baz*
                .
                <p>*foo <em>bar baz</em></p>
                .
            */

            this.Setup(
                "*foo *bar baz*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*foo " },
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "bar baz" },
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 354 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample354()
        {
            /* Specification Example:
                .
                *[bar*](/url)
                .
                <p>*<a href="/url">bar*</a></p>
                .
            */

            this.Setup(
                "*[bar*](/url)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.Text) { Text = "bar*" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 355 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample355()
        {
            /* Specification Example:
                .
                _foo [bar_](/url)
                .
                <p>_foo <a href="/url">bar_</a></p>
                .
            */

            this.Setup(
                "_foo [bar_](/url)");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "_foo " },
                new Event(MarkupElementType.BeginAnchor) { Href="/url" },
                new Event(MarkupElementType.Text) { Text = "bar_" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 356 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample356()
        {
            /* Specification Example:
                .
                *<img src="foo" title="*"/>
                .
                <p>*<img src="foo" title="*"/></p>
                .
            */

            this.Setup(
                "*<img src=\"foo\" title=\"*\"/>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.BeginHtml),
                new Event(MarkupElementType.Text) { Text = "<img src=\"foo\" title=\"*\"/></p>" },
                new Event(MarkupElementType.Whitespace) { Text = "\r\n" },
                new Event(MarkupElementType.EndHtml),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 357 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample357()
        {
            /* Specification Example:
                .
                **<a href="**">
                .
                <p>**<a href="**"></p>
                .
            */

            this.Setup(
                "**<a href=\"**\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**" },
                new Event(MarkupElementType.BeginAnchor) { Href="**" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 358 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample358()
        {
            /* Specification Example:
                .
                __<a href="__">
                .
                <p>__<a href="__"></p>
                .
            */

            this.Setup(
                "__<a href=\"__\">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__" },
                new Event(MarkupElementType.BeginAnchor) { Href="__" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 359 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample359()
        {
            /* Specification Example:
                .
                *a `*`*
                .
                <p><em>a <code>*</code></em></p>
                .
            */

            this.Setup(
                "*a `*`*");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "a " },
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "*" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 360 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample360()
        {
            /* Specification Example:
                .
                _a `_`_
                .
                <p><em>a <code>_</code></em></p>
                .
            */

            this.Setup(
                "_a `_`_");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.BeginItalic),
                new Event(MarkupElementType.Text) { Text = "a " },
                new Event(MarkupElementType.BeginCodeSpan),
                new Event(MarkupElementType.Text) { Text = "_" },
                new Event(MarkupElementType.EndCodeSpan),
                new Event(MarkupElementType.EndItalic),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 361 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample361()
        {
            /* Specification Example:
                .
                **a<http://foo.bar?q=**>
                .
                <p>**a<a href="http://foo.bar?q=**">http://foo.bar?q=**</a></p>
                .
            */

            this.Setup(
                "**a<http://foo.bar?q=**>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "**a" },
                new Event(MarkupElementType.BeginAnchor) { Href="http://foo.bar?q=**" },
                new Event(MarkupElementType.Text) { Text = "http://foo.bar?q=**" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 362 of the CommonMark specification.
        /// </summary>
        [Test]
        public void VerifyCommonMark06Inlines04EmphasisAndStrongEmphasisExample362()
        {
            /* Specification Example:
                .
                __a<http://foo.bar?q=__>
                .
                <p>__a<a href="http://foo.bar?q=__">http://foo.bar?q=__</a></p>
                .
            */

            this.Setup(
                "__a<http://foo.bar?q=__>");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "__a" },
                new Event(MarkupElementType.BeginAnchor) { Href="http://foo.bar?q=__" },
                new Event(MarkupElementType.Text) { Text = "http://foo.bar?q=__" },
                new Event(MarkupElementType.EndAnchor),
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
