using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class Count : IEquatable<Count>
    {
        private Count(int value)
        {
            Value = value;
        }

        public static Count FromInt(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Count)} value must not be lower than zero.");

            return new Count(value);
        }

        public int Value { get; }

        public static Count ZERO { get; } = new Count(0);

        public override string ToString() => Value.ToString();

        private sealed class ValueEqualityComparer : IEqualityComparer<Count>
        {
            public bool Equals(Count x, Count y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(Count obj)
            {
                return obj.Value;
            }
        }

        public static IEqualityComparer<Count> ValueComparer { get; } = new ValueEqualityComparer();

        public bool Equals(Count other)
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
            return Equals((Count)obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Count left, Count right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Count left, Count right)
        {
            return !Equals(left, right);
        }
    }
}