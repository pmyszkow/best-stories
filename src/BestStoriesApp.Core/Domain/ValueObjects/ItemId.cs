using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class ItemId : IEquatable<ItemId>
    {
        private ItemId(int value)
        {
            Value = value;
        }

        public static ItemId FromInt(int value)
        {
            return new ItemId(value);
        }

        public int Value { get; }

        public static ItemId DETACHED { get; } = new ItemId(-1);

        public override string ToString() => Value.ToString();

        private sealed class ValueEqualityComparer : IEqualityComparer<ItemId>
        {
            public bool Equals(ItemId x, ItemId y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(ItemId obj)
            {
                return obj.Value;
            }
        }

        public static IEqualityComparer<ItemId> ValueComparer { get; } = new ValueEqualityComparer();

        public bool Equals(ItemId other)
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
            return Equals((ItemId)obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(ItemId left, ItemId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ItemId left, ItemId right)
        {
            return !Equals(left, right);
        }
    }
}