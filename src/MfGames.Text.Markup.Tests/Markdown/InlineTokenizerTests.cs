// <copyright file="InlineTokenizerTests.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Collections.Generic;

using MfGames.Text.Markup.Markdown;

using Xunit;

namespace MfGames.Text.Markup.Tests.Markdown
{
	public class InlineTokenizerTests
	{
		#region Public Methods and Operators

		[Fact]
		public void DoubleWordToken()
		{
			const string Text = "abc def";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("abc def", 0, 7, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void EscapedHash()
		{
			var token = new InlineToken("\\#", 0, 2, MarkupElementType.Text);

			Assert.Equal("#", token.StateText);
		}

		[Fact]
		public void HandleBlankInput()
		{
			const string Text = "";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(new InlineToken[] { }, tokens);
		}

		[Fact]
		public void NewLine()
		{
			const string Text = "abc\ndef";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("abc", 0, 3, MarkupElementType.Text),
					new InlineToken("\n", 3, 1, MarkupElementType.NewLine),
					new InlineToken("def", 4, 3, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void NewLineAndLineBreak()
		{
			const string Text = "abc  \ndef";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("abc", 0, 3, MarkupElementType.Text),
					new InlineToken("\r", 3, 2, MarkupElementType.LineBreak),
					new InlineToken("\n", 5, 1, MarkupElementType.NewLine),
					new InlineToken("def", 6, 3, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void NewLineAndSpace()
		{
			const string Text = "abc \ndef";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("abc", 0, 4, MarkupElementType.Text),
					new InlineToken("\n", 4, 1, MarkupElementType.NewLine),
					new InlineToken("def", 5, 3, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void NewLineWithLeadingSpace()
		{
			const string Text = "abc\n    def";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("abc", 0, 3, MarkupElementType.Text),
					new InlineToken("\n", 3, 1, MarkupElementType.NewLine),
					new InlineToken("def", 4, 7, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void NullReturnsNull()
		{
			const string Text = null;
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				null,
				tokens);
		}

		[Fact]
		public void OpenBold()
		{
			const string Text = "**abc";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("**abc", 0, 5, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void OpenInnerBold()
		{
			const string Text = "def**abc";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("def**abc", 0, 8, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void OpenInnerBoldWithItalic()
		{
			const string Text = "def**abc*";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("def*", 0, 4, MarkupElementType.Text),
					new InlineToken("*", 4, 1, MarkupElementType.BeginItalic),
					new InlineToken("abc", 5, 3, MarkupElementType.Text),
					new InlineToken("*", 8, 1, MarkupElementType.EndItalic)
				},
				tokens);
		}

		[Fact]
		public void OpenInnerItalic()
		{
			const string Text = "def*abc";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("def*abc", 0, 7, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void OpenItalic()
		{
			const string Text = "*abc";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("*abc", 0, 4, MarkupElementType.Text)
				},
				tokens);
		}

		[Fact]
		public void SequentialBoldItalic()
		{
			const string Text = "**abc***def*";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("**", 0, 2, MarkupElementType.BeginBold),
					new InlineToken("abc", 2, 3, MarkupElementType.Text),
					new InlineToken("**", 5, 2, MarkupElementType.EndBold),
					new InlineToken("*", 7, 1, MarkupElementType.BeginItalic),
					new InlineToken("def", 8, 3, MarkupElementType.Text),
					new InlineToken("*", 11, 1, MarkupElementType.EndItalic)
				},
				tokens);
		}

		[Fact]
		public void SequentialItalicBold()
		{
			const string Text = "*abc***def**";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("*", 0, 1, MarkupElementType.BeginItalic),
					new InlineToken("abc", 1, 3, MarkupElementType.Text),
					new InlineToken("*", 4, 1, MarkupElementType.EndItalic),
					new InlineToken("**", 5, 2, MarkupElementType.BeginBold),
					new InlineToken("def", 7, 3, MarkupElementType.Text),
					new InlineToken("**", 10, 2, MarkupElementType.EndBold)
				},
				tokens);
		}

		[Fact]
		public void SimpleBold()
		{
			const string Text = "**abc**";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("**", 0, 2, MarkupElementType.BeginBold),
					new InlineToken("abc", 2, 3, MarkupElementType.Text),
					new InlineToken("**", 5, 2, MarkupElementType.EndBold)
				},
				tokens);
		}

		[Fact]
		public void SimpleBoldItalic()
		{
			const string Text = "***abc***";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("**", 0, 2, MarkupElementType.BeginBold),
					new InlineToken("*", 2, 1, MarkupElementType.BeginItalic),
					new InlineToken("abc", 3, 3, MarkupElementType.Text),
					new InlineToken("*", 6, 1, MarkupElementType.EndItalic),
					new InlineToken("**", 7, 2, MarkupElementType.EndBold)
				},
				tokens);
		}

		[Fact]
		public void SimpleItalic()
		{
			const string Text = "*abc*";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("*", 0, 1, MarkupElementType.BeginItalic),
					new InlineToken("abc", 1, 3, MarkupElementType.Text),
					new InlineToken("*", 4, 1, MarkupElementType.EndItalic)
				},
				tokens);
		}

		[Fact]
		public void SingleWordToken()
		{
			const string Text = "abc";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("abc", 0, 3, MarkupElementType.Text)
				},
				tokens);
		}

		#endregion
	}
}
