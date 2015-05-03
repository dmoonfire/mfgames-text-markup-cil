// <copyright file="InlineToken.cs" company="Moonfire Games">
//   Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// <license>
//   MIT License (MIT)
// </license>

using System;

namespace MfGames.Text.Markup.Markdown
{
	public class InlineToken : IEquatable<InlineToken>
	{
		#region Constructors and Destructors

		public InlineToken(
			string text,
			int textIndex,
			int textLength,
			MarkupElementType elementType)
		{
			Text = text;
			TextIndex = textIndex;
			TextLength = textLength;
			ElementType = elementType;
		}

		#endregion

		#region Public Properties

		public MarkupElementType ElementType { get; private set; }
		public string Text { get; private set; }
		public int TextIndex { get; private set; }
		public int TextLength { get; private set; }

		#endregion

		#region Public Methods and Operators

		public static bool operator ==(InlineToken left, InlineToken right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(InlineToken left, InlineToken right)
		{
			return !Equals(left, right);
		}

		public void Append(char c, int length)
		{
			Text += c;
			TextLength += length;
		}

		public void Append(string newText, int length)
		{
			Text += newText;
			TextLength += length;
		}

		public void Append(InlineToken token)
		{
			Text += token.Text;
			TextLength += token.TextLength;
		}

		public bool Equals(InlineToken other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return ElementType == other.ElementType && string.Equals(Text, other.Text)
				&& TextIndex == other.TextIndex && TextLength == other.TextLength;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((InlineToken)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (int)ElementType;
				hashCode = (hashCode * 397) ^ (Text != null ? Text.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ TextIndex;
				hashCode = (hashCode * 397) ^ TextLength;
				return hashCode;
			}
		}

		public override string ToString()
		{
			return string.Format(
				"{0} ({1}:{3}): {2}",
				ElementType,
				TextIndex,
				Text,
				TextLength);
		}

		public void Trim()
		{
			Text = Text.Trim();
		}

		#endregion
	}
}
