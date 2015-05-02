// <copyright file="CommonMarkSpec05ContainerBlocks01BlockQuotesTests.cs" company="Moonfire Games">
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
    public class CommonMarkSpec05ContainerBlocks01BlockQuotesTests : MarkdownReaderRecorderTestsBase
    {
        #region Constructors and Destructors
        
        public CommonMarkSpec05ContainerBlocks01BlockQuotesTests(ITestOutputHelper output)
        	: base(output)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies example 141 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample141()
        {
            /* Specification Example:
                .
                > # Foo
                > bar
                > baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "> # Foo",
                "> bar",
                "> baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 142 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample142()
        {
            /* Specification Example:
                .
                ># Foo
                >bar
                > baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "># Foo",
                ">bar",
                "> baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 143 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample143()
        {
            /* Specification Example:
                .
                   > # Foo
                   > bar
                 > baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "   > # Foo",
                "   > bar",
                " > baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 144 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample144()
        {
            /* Specification Example:
                .
                    > # Foo
                    > bar
                    > baz
                .
                <pre><code>&gt; # Foo
                &gt; bar
                &gt; baz
                </code></pre>
                .
            */

            this.Setup(
                "    > # Foo",
                "    > bar",
                "    > baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "> # Foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "> bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "> baz" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 145 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample145()
        {
            /* Specification Example:
                .
                > # Foo
                > bar
                baz
                .
                <blockquote>
                <h1>Foo</h1>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "> # Foo",
                "> bar",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginHeader) { Level = 1 },
                new Event(MarkupElementType.Text) { Text = "Foo" },
                new Event(MarkupElementType.EndHeader) { Level = 1 },
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 146 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample146()
        {
            /* Specification Example:
                .
                > bar
                baz
                > foo
                .
                <blockquote>
                <p>bar
                baz
                foo</p>
                </blockquote>
                .
            */

            this.Setup(
                "> bar",
                "baz",
                "> foo");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 147 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample147()
        {
            /* Specification Example:
                .
                > foo
                ---
                .
                <blockquote>
                <p>foo</p>
                </blockquote>
                <hr />
                .
            */

            this.Setup(
                "> foo",
                "---");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 148 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample148()
        {
            /* Specification Example:
                .
                > - foo
                - bar
                .
                <blockquote>
                <ul>
                <li>foo</li>
                </ul>
                </blockquote>
                <ul>
                <li>bar</li>
                </ul>
                .
            */

            this.Setup(
                "> - foo",
                "- bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginUnorderedList),
                new Event(MarkupElementType.BeginListItem),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndListItem),
                new Event(MarkupElementType.EndUnorderedList),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 149 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample149()
        {
            /* Specification Example:
                .
                >     foo
                    bar
                .
                <blockquote>
                <pre><code>foo
                </code></pre>
                </blockquote>
                <pre><code>bar
                </code></pre>
                .
            */

            this.Setup(
                ">     foo",
                "    bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 150 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample150()
        {
            /* Specification Example:
                .
                > ```
                foo
                ```
                .
                <blockquote>
                <pre><code></code></pre>
                </blockquote>
                <p>foo</p>
                <pre><code></code></pre>
                .
            */

            this.Setup(
                "> ```",
                "foo",
                "```");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 151 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample151()
        {
            /* Specification Example:
                .
                >
                .
                <blockquote>
                </blockquote>
                .
            */

            this.Setup(
                ">");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 152 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample152()
        {
            /* Specification Example:
                .
                >
                >  
                > 
                .
                <blockquote>
                </blockquote>
                .
            */

            this.Setup(
                ">",
                ">  ",
                "> ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 153 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample153()
        {
            /* Specification Example:
                .
                >
                > foo
                >  
                .
                <blockquote>
                <p>foo</p>
                </blockquote>
                .
            */

            this.Setup(
                ">",
                "> foo",
                ">  ");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 154 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample154()
        {
            /* Specification Example:
                .
                > foo
                
                > bar
                .
                <blockquote>
                <p>foo</p>
                </blockquote>
                <blockquote>
                <p>bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "> foo",
                string.Empty,
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 155 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample155()
        {
            /* Specification Example:
                .
                > foo
                > bar
                .
                <blockquote>
                <p>foo
                bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "> foo",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 156 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample156()
        {
            /* Specification Example:
                .
                > foo
                >
                > bar
                .
                <blockquote>
                <p>foo</p>
                <p>bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "> foo",
                ">",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 157 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample157()
        {
            /* Specification Example:
                .
                foo
                > bar
                .
                <p>foo</p>
                <blockquote>
                <p>bar</p>
                </blockquote>
                .
            */

            this.Setup(
                "foo",
                "> bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 158 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample158()
        {
            /* Specification Example:
                .
                > aaa
                ***
                > bbb
                .
                <blockquote>
                <p>aaa</p>
                </blockquote>
                <hr />
                <blockquote>
                <p>bbb</p>
                </blockquote>
                .
            */

            this.Setup(
                "> aaa",
                "***",
                "> bbb");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "aaa" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.HorizontalRule),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bbb" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 159 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample159()
        {
            /* Specification Example:
                .
                > bar
                baz
                .
                <blockquote>
                <p>bar
                baz</p>
                </blockquote>
                .
            */

            this.Setup(
                "> bar",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 160 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample160()
        {
            /* Specification Example:
                .
                > bar
                
                baz
                .
                <blockquote>
                <p>bar</p>
                </blockquote>
                <p>baz</p>
                .
            */

            this.Setup(
                "> bar",
                string.Empty,
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 161 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample161()
        {
            /* Specification Example:
                .
                > bar
                >
                baz
                .
                <blockquote>
                <p>bar</p>
                </blockquote>
                <p>baz</p>
                .
            */

            this.Setup(
                "> bar",
                ">",
                "baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 162 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample162()
        {
            /* Specification Example:
                .
                > > > foo
                bar
                .
                <blockquote>
                <blockquote>
                <blockquote>
                <p>foo
                bar</p>
                </blockquote>
                </blockquote>
                </blockquote>
                .
            */

            this.Setup(
                "> > > foo",
                "bar");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 163 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample163()
        {
            /* Specification Example:
                .
                >>> foo
                > bar
                >>baz
                .
                <blockquote>
                <blockquote>
                <blockquote>
                <p>foo
                bar
                baz</p>
                </blockquote>
                </blockquote>
                </blockquote>
                .
            */

            this.Setup(
                ">>> foo",
                "> bar",
                ">>baz");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "foo" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "bar" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.Text) { Text = "baz" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        /// <summary>
        /// Verifies example 164 of the CommonMark specification.
        /// </summary>
        [Fact]
        public void VerifyCommonMark05ContainerBlocks01BlockQuotesExample164()
        {
            /* Specification Example:
                .
                >     code
                
                >    not code
                .
                <blockquote>
                <pre><code>code
                </code></pre>
                </blockquote>
                <blockquote>
                <p>not code</p>
                </blockquote>
                .
            */

            this.Setup(
                ">     code",
                string.Empty,
                ">    not code");

            this.AssertEventElementTypes(
                new Event(MarkupElementType.BeginDocument),
                new Event(MarkupElementType.BeginContent),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginCodeBlock),
                new Event(MarkupElementType.Text) { Text = "code" },
                new Event(MarkupElementType.NewLine),
                new Event(MarkupElementType.EndCodeBlock),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.BeginBlockquote),
                new Event(MarkupElementType.BeginParagraph),
                new Event(MarkupElementType.Text) { Text = "not code" },
                new Event(MarkupElementType.EndParagraph),
                new Event(MarkupElementType.EndBlockquote),
                new Event(MarkupElementType.EndContent), 
                new Event(MarkupElementType.EndDocument));
        }

        #endregion
    }

    #endregion

}
