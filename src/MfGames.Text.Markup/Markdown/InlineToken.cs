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

		public InlineToken(string text, MarkupElementType elementType)
		{
			Text = text;
			ElementType = elementType;
		}

		#endregion

		#region Public Properties

		public MarkupElementType ElementType { get; private set; }
		public string Text { get; internal set; }

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

			return string.Equals(Text, other.Text);
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
			return (Text != null ? Text.GetHashCode() : 0);
		}

		#endregion
	}
}
