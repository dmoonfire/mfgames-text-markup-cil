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

			using (BlockReader blockReader = CreateBlockReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new string[]
					{
					},
					blocks);
			}
		}

		[Fact]
		public void ReadInvalidYamlWithPreceedingBlank()
		{
			var input = new[]
			{
				"",
				"---",
				"title: Title",
				"---",
				"Line 1"
			};

			using (BlockReader blockReader = CreateYamlReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"---\ntitle: Title\n---\nLine 1"
					},
					blocks);
			}
		}

		[Fact]
		public void ReadInvalidYamlWithPreceedingText()
		{
			var input = new[]
			{
				"Line 1",
				"",
				"---",
				"title: Title",
				"---",
			};

			using (BlockReader blockReader = CreateYamlReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1",
						"---\ntitle: Title\n---"
					},
					blocks);
			}
		}

		[Fact]
		public void ReadMissingYaml()
		{
			var input = new[]
			{
				"Line 1"
			};

			using (BlockReader blockReader = CreateYamlReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1"
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

			using (BlockReader blockReader = CreateBlockReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1\ncontinues here."
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

			using (BlockReader blockReader = CreateBlockReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1."
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

			using (BlockReader blockReader = CreateBlockReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1."
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

			using (BlockReader blockReader = CreateBlockReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1."
					},
					blocks);
			}
		}

		[Fact]
		public void ReadStandaloneYaml()
		{
			var input = new[]
			{
				"---",
				"title: Title",
				"---"
			};

			using (BlockReader blockReader = CreateYamlReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"---\ntitle: Title\n---"
					},
					blocks);
			}
		}

		[Fact]
		public void ReadStandaloneYamlWithNewline()
		{
			var input = new[]
			{
				"---",
				"text: >",
				"  line 1.",
				"",
				"  line 2.",
				"---"
			};

			using (BlockReader blockReader = CreateYamlReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"---\ntext: >\n  line 1.\n\n  line 2.\n---"
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

			using (BlockReader blockReader = CreateBlockReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1.",
						"Line 2."
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

			using (BlockReader blockReader = CreateBlockReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"Line 1.",
						"Line 2."
					},
					blocks);
			}
		}

		[Fact]
		public void ReadYaml()
		{
			var input = new[]
			{
				"---",
				"title: Title",
				"---",
				"",
				"Line 1"
			};

			using (BlockReader blockReader = CreateYamlReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"---\ntitle: Title\n---",
						"Line 1"
					},
					blocks);
			}
		}

		[Fact]
		public void ReadYamlWithoutBlank()
		{
			var input = new[]
			{
				"---",
				"title: Title",
				"---",
				"Line 1"
			};

			using (BlockReader blockReader = CreateYamlReader(input))
			{
				List<string> blocks = blockReader.ReadBlocks().ToList();
				Assert.Equal(
					new[]
					{
						"---\ntitle: Title\n---",
						"Line 1"
					},
					blocks);
			}
		}

		#endregion

		#region Methods

		private BlockReader CreateBlockReader(params string[] input)
		{
			string combined = string.Join(Environment.NewLine, input);
			var textReader = new StringReader(combined);
			var blockReader = new BlockReader(textReader);
			return blockReader;
		}

		private BlockReader CreateYamlReader(params string[] input)
		{
			string combined = string.Join(Environment.NewLine, input);
			var textReader = new StringReader(combined);
			var blockReader = new BlockReader(textReader) { HasYaml = true };
			return blockReader;
		}

		#endregion
	}
}
