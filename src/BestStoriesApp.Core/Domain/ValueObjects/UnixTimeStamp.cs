using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class UnixTimeStamp : IEquatable<UnixTimeStamp>
    {
        private readonly DateTime _unixEpochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private UnixTimeStamp(int value)
        {
            Value = value;
        }

        public static UnixTimeStamp FromInt(int value)
        {
            return new UnixTimeStamp(value);
        }

        public int Value { get; }

        public static UnixTimeStamp ZERO { get; } = new UnixTimeStamp(0);

        public string ToUtcDateTimeString()
        {
            var utcDateTime = _unixEpochDateTime.AddSeconds(Value);

            return $"{utcDateTime:yyyy-MM-ddTHH:mm:sszzz}";
        }

        public override string ToString() => Value.ToString();

        private sealed class ValueEqualityComparer : IEqualityComparer<UnixTimeStamp>
        {
            public bool Equals(UnixTimeStamp x, UnixTimeStamp y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(UnixTimeStamp obj)
            {
                return obj.Value;
            }
        }

        public static IEqualityComparer<UnixTimeStamp> ValueComparer { get; } = new ValueEqualityComparer();

        public bool Equals(UnixTimeStamp other)
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
            return Equals((UnixTimeStamp)obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(UnixTimeStamp left, UnixTimeStamp right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnixTimeStamp left, UnixTimeStamp right)
        {
            return !Equals(left, right);
        }
    }
}