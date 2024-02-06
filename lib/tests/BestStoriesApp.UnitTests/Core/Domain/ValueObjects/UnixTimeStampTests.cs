using System;
using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    public class UnixTimeStampTests
    {
        [Test]
        public void FromIntCreatesInstanceContainingValueFromArgument()
        {
            const int unixTimeStampValue = 1;

            var unixTimeStamp = UnixTimeStamp.FromInt(unixTimeStampValue);

            Assert.AreEqual(unixTimeStampValue, unixTimeStamp.Value);
        }


        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(0, UnixTimeStamp.ZERO.Value);
        }

        [Test]
        public void ToStringReturnsContainedValueString()
        {
            const int unixTimeStampValue = 1;

            var unixTimeStamp = UnixTimeStamp.FromInt(unixTimeStampValue);

            Assert.AreEqual(unixTimeStamp.Value.ToString(), unixTimeStamp.ToString());
        }

        [Test]
        public void ToUtcDateTimeStringReturnsUtcDateTimeStringCorrespondingToUnixTimestamp()
        {
            Assert.AreEqual($"{new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Utc):yyyy-MM-ddTHH:mm:sszzz}", UnixTimeStamp.ZERO.ToUtcDateTimeString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftTimeStamp = UnixTimeStamp.FromInt(1);

            var rightTimeStamp = UnixTimeStamp.FromInt(1);

            Assert.IsTrue(leftTimeStamp == rightTimeStamp);

            Assert.IsTrue(leftTimeStamp.Equals(leftTimeStamp));
            Assert.IsTrue(leftTimeStamp.Equals(rightTimeStamp));

            Assert.IsTrue(leftTimeStamp.Equals((object)leftTimeStamp));
            Assert.IsTrue(leftTimeStamp.Equals((object)rightTimeStamp));

            var comparer = UnixTimeStamp.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftTimeStamp, leftTimeStamp));
            Assert.IsTrue(comparer.Equals(leftTimeStamp, rightTimeStamp));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftTimeStamp = UnixTimeStamp.FromInt(1);

            var rightTimeStamp = UnixTimeStamp.FromInt(2);

            Assert.IsTrue(leftTimeStamp != rightTimeStamp);

            Assert.IsTrue(!leftTimeStamp.Equals(null));
            Assert.IsTrue(!leftTimeStamp.Equals(rightTimeStamp));

            Assert.IsTrue(!leftTimeStamp.Equals((object)null));
            Assert.IsTrue(!leftTimeStamp.Equals((object)rightTimeStamp));

            var comparer = UnixTimeStamp.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightTimeStamp));
            Assert.IsTrue(!comparer.Equals(leftTimeStamp, null));
            Assert.IsTrue(!comparer.Equals(leftTimeStamp, rightTimeStamp));
        }
    }
}