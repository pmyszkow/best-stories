using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class Score : IEquatable<Score>, IComparable<Score>, IComparable
    {
        private Score(int value)
        {
            Value = value;
        }

        public static Score FromInt(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Score)} value must not be lower than zero.");

            return new Score(value);
        }

        public int Value { get; }

        public static Score ZERO { get; } = new Score(0);

        public override string ToString() => Value.ToString();

        private sealed class ValueEqualityComparer : IEqualityComparer<Score>
        {
            public bool Equals(Score x, Score y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(Score obj)
            {
                return obj.Value;
            }
        }

        public static IEqualityComparer<Score> EqualityComparer { get; } = new ValueEqualityComparer();

        public bool Equals(Score other)
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
            return Equals((Score)obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Score left, Score right)
        {
            return Equals(left, right);
        }


        public static bool operator !=(Score left, Score right)
        {
            return !Equals(left, right);
        }

        private sealed class ValueRelationalComparer : IComparer<Score>
        {
            public int Compare(Score x, Score y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return x.Value.CompareTo(y.Value);
            }
        }

        public static IComparer<Score> Comparer { get; } = new ValueRelationalComparer();

        public int CompareTo(Score other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is Score other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Score)}");
        }

        public static bool operator <(Score left, Score right)
        {
            return Comparer<Score>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Score left, Score right)
        {
            return Comparer<Score>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Score left, Score right)
        {
            return Comparer<Score>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Score left, Score right)
        {
            return Comparer<Score>.Default.Compare(left, right) >= 0;
        }
    }
}