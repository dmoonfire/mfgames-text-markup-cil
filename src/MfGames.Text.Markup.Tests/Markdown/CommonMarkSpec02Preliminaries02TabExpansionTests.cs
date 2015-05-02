// <copyright file="CommonMarkSpec02Preliminaries02TabExpansionTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec02Preliminaries02TabExpansionTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec02Preliminaries02TabExpansionTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 1 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark02Preliminaries02TabExpansionExample001()
        {
            /* Specification Example:
                .
                →foo→baz→→bim
                .
                <pre><code>foo baz     bim
                </code></pre>
                .
            */

            this.Setup(
                "\tfoo\tbaz\t\tbim");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo baz     bim" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 2 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark02Preliminaries02TabExpansionExample002()
        {
            /* Specification Example:
                .
                    a→a
                    ὐ→a
                .
                <pre><code>a   a
                ὐ   a
                </code></pre>
                .
            */

            this.Setup(
                "    a\ta",
                "    ὐ\ta");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "a   a" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "ὐ   a" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
