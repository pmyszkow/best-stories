using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class Score : IEquatable<Score>
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

        public static IEqualityComparer<Score> ValueComparer { get; } = new ValueEqualityComparer();

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
    }
}