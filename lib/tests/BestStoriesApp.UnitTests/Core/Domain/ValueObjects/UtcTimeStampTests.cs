using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;
using System;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    [TestFixture]
    public class UtcTimeStampTests
    {
        private static readonly DateTime _unixEpochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [Test]
        public void FromUnixTimeStampCreatesInstanceContainingValueFromArgument()
        {
            var unixTimeTimeStamp = UnixTimeStamp.FromInt(0);
            var expectedUtcTimeStampValue = _unixEpochDateTime.AddSeconds(unixTimeTimeStamp.Value);

            var utcTimeStamp = UtcTimeStamp.FromUnixTimeStamp(unixTimeTimeStamp);

            Assert.AreEqual(expectedUtcTimeStampValue, utcTimeStamp.Value);
        }
        
        [Test]
        public void ToStringReturnsContainedValueString()
        {
            var unixTimeTimeStamp = UnixTimeStamp.FromInt(0);
            var utcTimeStamp = UtcTimeStamp.FromUnixTimeStamp(unixTimeTimeStamp);

            Assert.AreEqual($"{utcTimeStamp.Value:yyyy-MM-ddTHH:mm:sszzz}", utcTimeStamp.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftUnixTimeTimeStamp = UnixTimeStamp.FromInt(0);
            var leftTimeStamp = UtcTimeStamp.FromUnixTimeStamp(leftUnixTimeTimeStamp);

            var rightUnixTimeTimeStamp = UnixTimeStamp.FromInt(0);
            var rightTimeStamp = UtcTimeStamp.FromUnixTimeStamp(rightUnixTimeTimeStamp);

            Assert.IsTrue(leftTimeStamp == rightTimeStamp);

            Assert.IsTrue(leftTimeStamp.Equals(leftTimeStamp));
            Assert.IsTrue(leftTimeStamp.Equals(rightTimeStamp));

            Assert.IsTrue(leftTimeStamp.Equals((object)leftTimeStamp));
            Assert.IsTrue(leftTimeStamp.Equals((object)rightTimeStamp));

            var comparer = UtcTimeStamp.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftTimeStamp, leftTimeStamp));
            Assert.IsTrue(comparer.Equals(leftTimeStamp, rightTimeStamp));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftUnixTimeTimeStamp = UnixTimeStamp.FromInt(0);
            var leftTimeStamp = UtcTimeStamp.FromUnixTimeStamp(leftUnixTimeTimeStamp);

            var rightUnixTimeTimeStamp = UnixTimeStamp.FromInt(1);
            var rightTimeStamp = UtcTimeStamp.FromUnixTimeStamp(rightUnixTimeTimeStamp);

            Assert.IsTrue(leftTimeStamp != rightTimeStamp);

            Assert.IsTrue(!leftTimeStamp.Equals(null));
            Assert.IsTrue(!leftTimeStamp.Equals(rightTimeStamp));

            Assert.IsTrue(!leftTimeStamp.Equals((object)null));
            Assert.IsTrue(!leftTimeStamp.Equals((object)rightTimeStamp));

            var comparer = UtcTimeStamp.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightTimeStamp));
            Assert.IsTrue(!comparer.Equals(leftTimeStamp, null));
            Assert.IsTrue(!comparer.Equals(leftTimeStamp, rightTimeStamp));
        }
    }
}