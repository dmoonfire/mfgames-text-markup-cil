﻿// <copyright file="CommonMarkRegexTests.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System.Text.RegularExpressions;

using MfGames.Text.Markup.Markdown;

using Xunit;

namespace MfGames.Text.Markup.Tests.Markdown
{
	/// <summary>
	/// Tests the various regular expressions against the CommonMark specification
	/// examples.
	/// </summary>
	public class CommonMarkRegexTests
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example023AtxHeader1()
		{
			Match matches = MarkdownRegex.AtxHeader.Match(
				"# foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example023AtxHeader2()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("## foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"##",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example023AtxHeader3()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("### foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example023AtxHeader4()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("#### foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"####",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example023AtxHeader5()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("##### foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#####",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example023AtxHeader6()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("###### foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"######",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example024AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("####### foo");

			Assert.Equal(
				false,
				matches.Success);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example025AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("#5 foo");

			Assert.Equal(
				false,
				matches.Success);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example026AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(@"\## foo");

			Assert.Equal(
				false,
				matches.Success);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example028AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(
					"#               foo            ");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>
		/// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
		/// </summary>
		[Fact]
		public void Example029AtxHeader1()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(" ### foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example029AtxHeader2()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("  ## foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"##",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example029AtxHeader3()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("   # foo");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example030AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("    # foo");

			Assert.Equal(
				false,
				matches.Success);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example032AtxHeader1()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("## foo ##");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"##",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example032AtxHeader2()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(
					"  ###   foo    ###");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example033AtxHeader1()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(
					"# foo #####################");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example033AtxHeader2()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("##### foo #");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#####",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example034AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("### foo ###   ");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example035AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("### foo ### b");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo ### b",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example036AtxHeader()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("# foo#");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#",
				matches.Groups[1].Value);
			Assert.Equal(
				"foo#",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example037AtxHeader1()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(@"### foo \###");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				@"foo \###",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example037AtxHeader2()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(@"### foo #\##");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				@"foo #\##",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example037AtxHeader3()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match(@"# foo \#");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#",
				matches.Groups[1].Value);
			Assert.Equal(
				@"foo \#",
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example040AtxHeader1()
		{
			Match matches = MarkdownRegex.AtxHeader.Match("## ");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"##",
				matches.Groups[1].Value);
			Assert.Equal(
				string.Empty,
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example040AtxHeader2()
		{
			Match matches = MarkdownRegex.AtxHeader.Match("#");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"#",
				matches.Groups[1].Value);
			Assert.Equal(
				string.Empty,
				matches.Groups[2].Value);
		}

		/// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
		[Fact]
		public void Example040AtxHeader3()
		{
			Match matches =
				MarkdownRegex.AtxHeader.Match("### ###");

			Assert.Equal(
				true,
				matches.Success);
			Assert.Equal(
				3,
				matches.Groups.Count);
			Assert.Equal(
				"###",
				matches.Groups[1].Value);
			Assert.Equal(
				string.Empty,
				matches.Groups[2].Value);
		}

		[Fact]
		public void HorizontalBreak()
		{
			Match matches = MarkdownRegex.HorizontalRule.Match("***");

			Assert.Equal(true, matches.Success);
		}

		[Fact]
		public void TooShortHorizontalBreak()
		{
			Match matches = MarkdownRegex.HorizontalRule.Match("**");

			Assert.Equal(false, matches.Success);
		}

		[Fact]
		public void TooShortHorizontalBreakWithNewlines()
		{
			Match matches = MarkdownRegex.HorizontalRule.Match("**\n**");

			Assert.Equal(false, matches.Success);
		}

		#endregion
	}
}
