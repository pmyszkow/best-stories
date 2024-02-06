using System;
using System.Collections.Generic;

namespace BestStoriesApp.Core.Domain.ValueObjects
{
    public class Title : IEquatable<Title>
    {
        private Title(string value)
        {
            Value = value;
        }

        public static Title FromString(string value)
        {
            return new Title(value);
        }

        public string Value { get; }

        public static Title NULL { get; } = new Title(null);

        public override string ToString() => Value;

        private sealed class ValueEqualityComparer : IEqualityComparer<Title>
        {
            public bool Equals(Title x, Title y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(Title obj)
            {
                return (obj.Value != null ? obj.Value.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<Title> ValueComparer { get; } = new ValueEqualityComparer();

        public bool Equals(Title other)
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
            return Equals((Title)obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public static bool operator ==(Title left, Title right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Title left, Title right)
        {
            return !Equals(left, right);
        }
    }
}