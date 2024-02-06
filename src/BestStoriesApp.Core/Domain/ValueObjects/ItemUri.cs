using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class ItemUri : IEquatable<ItemUri>
    {
        private ItemUri(string value)
        {
            Value = value;
        }

        public static ItemUri FromString(string value)
        {
            return new ItemUri(value);
        }

        public string Value { get; }

        public static ItemUri NULL { get; } = new ItemUri(null);

        public override string ToString() => Value;

        private sealed class ValueEqualityComparer : IEqualityComparer<ItemUri>
        {
            public bool Equals(ItemUri x, ItemUri y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(ItemUri obj)
            {
                return (obj.Value != null ? obj.Value.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<ItemUri> ValueComparer { get; } = new ValueEqualityComparer();

        public bool Equals(ItemUri other)
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
            return Equals((ItemUri)obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public static bool operator ==(ItemUri left, ItemUri right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ItemUri left, ItemUri right)
        {
            return !Equals(left, right);
        }
    }
}