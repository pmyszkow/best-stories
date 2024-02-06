using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class UserId : IEquatable<UserId>
    {
        private UserId(int value)
        {
            Value = value;
        }

        public static UserId FromInt(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(UserId)} value must be greater than zero.");

            return new UserId(value);
        }

        public int Value { get; }

        public static UserId DETACHED { get; } = new UserId(-1);

        public override string ToString() => Value.ToString();

        private sealed class ValueEqualityComparer : IEqualityComparer<UserId>
        {
            public bool Equals(UserId x, UserId y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(UserId obj)
            {
                return obj.Value;
            }
        }

        public static IEqualityComparer<UserId> ValueComparer { get; } = new ValueEqualityComparer();

        public bool Equals(UserId other)
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
            return Equals((UserId)obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(UserId left, UserId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserId left, UserId right)
        {
            return !Equals(left, right);
        }
    }
}