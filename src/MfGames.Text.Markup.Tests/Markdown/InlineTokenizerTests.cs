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
					new InlineToken("abc def", MarkupElementType.Text)
				},
				tokens);
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
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("\n", MarkupElementType.NewLine),
					new InlineToken("def", MarkupElementType.Text)
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
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("\r", MarkupElementType.LineBreak),
					new InlineToken("\n", MarkupElementType.NewLine),
					new InlineToken("def", MarkupElementType.Text)
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
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("\n", MarkupElementType.NewLine),
					new InlineToken("def", MarkupElementType.Text)
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
		public void OpenItalic()
		{
			const string Text = "*abc";
			var tokenizer = new InlineTokenizer();
			List<InlineToken> tokens = tokenizer.Tokenize(Text);

			Assert.Equal(
				new[]
				{
					new InlineToken("*abc", MarkupElementType.Text)
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
					new InlineToken("**", MarkupElementType.BeginBold),
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("**", MarkupElementType.EndBold),
					new InlineToken("*", MarkupElementType.BeginItalic),
					new InlineToken("def", MarkupElementType.Text),
					new InlineToken("*", MarkupElementType.EndItalic)
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
					new InlineToken("*", MarkupElementType.BeginItalic),
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("*", MarkupElementType.EndItalic),
					new InlineToken("**", MarkupElementType.BeginBold),
					new InlineToken("def", MarkupElementType.Text),
					new InlineToken("**", MarkupElementType.EndBold)
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
					new InlineToken("**", MarkupElementType.BeginBold),
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("**", MarkupElementType.EndBold)
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
					new InlineToken("**", MarkupElementType.BeginBold),
					new InlineToken("*", MarkupElementType.BeginItalic),
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("*", MarkupElementType.EndItalic),
					new InlineToken("**", MarkupElementType.EndBold)
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
					new InlineToken("*", MarkupElementType.BeginItalic),
					new InlineToken("abc", MarkupElementType.Text),
					new InlineToken("*", MarkupElementType.EndItalic)
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
					new InlineToken("abc", MarkupElementType.Text)
				},
				tokens);
		}

		#endregion
	}
}
