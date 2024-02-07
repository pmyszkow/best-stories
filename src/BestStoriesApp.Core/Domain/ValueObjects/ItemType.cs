using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class ItemType : IEquatable<ItemType>
    {
        private const string STORY_VALUE = "STORY";
        private const string COMMENT_VALUE = "COMMENT";

        private ItemType(string value)
        {
            Value = value;
        }

        public static ItemType FromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return NULL;

            switch (value.Trim().ToUpper())
            {
                case STORY_VALUE:
                    return Story;
                case COMMENT_VALUE:
                    return Comment;
                default:
                    throw new ArgumentException(nameof(value), $"{nameof(ItemType)} value must be Story,... or etc.");
            }
        }


        public string Value { get; }

        public static ItemType NULL { get; } = new ItemType(null);

        public static ItemType Story { get; } = new ItemType(STORY_VALUE);

        public static ItemType Comment { get; } = new ItemType(COMMENT_VALUE);

        public override string ToString() => Value;

        private sealed class ValueEqualityComparer : IEqualityComparer<ItemType>
        {
            public bool Equals(ItemType x, ItemType y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(ItemType obj)
            {
                return (obj.Value != null ? obj.Value.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<ItemType> ValueComparer { get; } = new ValueEqualityComparer();


        public bool Equals(ItemType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ItemType)obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public static bool operator ==(ItemType left, ItemType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ItemType left, ItemType right)
        {
            return !Equals(left, right);
        }
    }
}