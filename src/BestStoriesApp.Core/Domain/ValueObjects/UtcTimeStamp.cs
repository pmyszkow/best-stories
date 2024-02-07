using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class UtcTimeStamp : IEquatable<UtcTimeStamp>
    {
        private static readonly DateTime _unixEpochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private UtcTimeStamp(DateTime value)
        {
            Value = value;
        }

        public static UtcTimeStamp FromUnixTimeStamp(UnixTimeStamp unixTimeStamp)
        {
            if (unixTimeStamp == null) 
                throw new ArgumentNullException(nameof(unixTimeStamp));

            var utcTimeStamp = _unixEpochDateTime.AddSeconds(unixTimeStamp.Value);

            return new UtcTimeStamp(utcTimeStamp);
        }

        public DateTime Value { get; }

        public override string ToString() => $"{Value:yyyy-MM-ddTHH:mm:sszzz}";

        private sealed class ValueEqualityComparer : IEqualityComparer<UtcTimeStamp>
        {
            public bool Equals(UtcTimeStamp x, UtcTimeStamp y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value.Equals(y.Value);
            }

            public int GetHashCode(UtcTimeStamp obj)
            {
                return obj.Value.GetHashCode();
            }
        }

        public static IEqualityComparer<UtcTimeStamp> ValueComparer { get; } = new ValueEqualityComparer();


        public bool Equals(UtcTimeStamp other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UtcTimeStamp)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(UtcTimeStamp left, UtcTimeStamp right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UtcTimeStamp left, UtcTimeStamp right)
        {
            return !Equals(left, right);
        }
    }
}