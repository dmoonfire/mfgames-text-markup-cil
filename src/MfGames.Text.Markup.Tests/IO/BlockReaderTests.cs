// <copyright file="BlockReaderTests.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MfGames.Text.Markup.IO;

using Xunit;

namespace MfGames.Text.Markup.Tests.IO
{
	/// <summary>
	/// Verifies the processing of text readers.
	/// </summary>
	public class BlockReaderTests
	{
		#region Public Methods and Operators

		[Fact]
		public void CreateWithNull()
		{
			Assert.Throws<ArgumentNullException>(() => new BlockReader(null));
		}

		[Fact]
		public void ReadBlankString()
		{
			var input = new[]
			{
				"",
			};

			using (BlockReader blockReader = CreateBlockTextReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						(string)null
					},
					blocks);
			}
		}

		[Fact]
		public void ReadSingleMultilineBlock()
		{
			var input = new[]
			{
				"Line 1",
				"continues here.",
			};

			using (BlockReader blockReader = CreateBlockTextReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1\ncontinues here.",
						null
					},
					blocks);
			}
		}

		[Fact]
		public void ReadSingleShortBlock()
		{
			var input = new[]
			{
				"Line 1.",
			};

			using (BlockReader blockReader = CreateBlockTextReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1.",
						null
					},
					blocks);
			}
		}

		[Fact]
		public void ReadSingleShortBlockWithBlankFooter()
		{
			var input = new[]
			{
				"Line 1.",
				"",
			};

			using (BlockReader blockReader = CreateBlockTextReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1.",
						null
					},
					blocks);
			}
		}

		[Fact]
		public void ReadSingleShortBlockWithBlankLeader()
		{
			var input = new[]
			{
				"",
				"Line 1.",
			};

			using (BlockReader blockReader = CreateBlockTextReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1.",
						null
					},
					blocks);
			}
		}

		[Fact]
		public void ReadTwoShortBlocks()
		{
			var input = new[]
			{
				"Line 1.",
				"",
				"Line 2."
			};

			using (BlockReader blockReader = CreateBlockTextReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1.",
						"Line 2.",
						null
					},
					blocks);
			}
		}

		[Fact]
		public void ReadTwoShortBlocksWithExtraSpace()
		{
			var input = new[]
			{
				"Line 1.",
				"",
				"",
				"Line 2."
			};

			using (BlockReader blockReader = CreateBlockTextReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1.",
						"Line 2.",
						null
					},
					blocks);
			}
		}

		#endregion

		#region Methods

		private BlockReader CreateBlockTextReader(params string[] input)
		{
			string combined = string.Join(Environment.NewLine, input);
			var textReader = new StringReader(combined);
			var blockReader = new BlockReader(textReader);
			return blockReader;
		}

		#endregion
	}
}
