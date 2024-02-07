using System;
using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    [TestFixture]
    public class CountTests
    {
        [Test]
        public void FromIntCreatesInstanceContainingValueFromArgument()
        {
            const int countValue = 1;

            var count = Count.FromInt(countValue);

            Assert.AreEqual(countValue, count.Value);
        }

        [Test]
        public void FromIntThrowsExceptionIfArgumentLowerThanZero()
        {
            Assert.DoesNotThrow(() => Count.FromInt(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => Count.FromInt(-1));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(0, Count.ZERO.Value);
        }

        [Test]
        public void ToStringReturnsContainedValueString()
        {
            const int countValue = 1;

            var count = Count.FromInt(countValue);

            Assert.AreEqual(count.Value.ToString(), count.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftCount = Count.FromInt(1);

            var rightCount = Count.FromInt(1);

            Assert.IsTrue(leftCount == rightCount);

            Assert.IsTrue(leftCount.Equals(leftCount));
            Assert.IsTrue(leftCount.Equals(rightCount));

            Assert.IsTrue(leftCount.Equals((object) leftCount));
            Assert.IsTrue(leftCount.Equals((object) rightCount));

            var comparer = Count.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftCount, leftCount));
            Assert.IsTrue(comparer.Equals(leftCount, rightCount));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftCount = Count.FromInt(1);

            var rightCount = Count.FromInt(2);

            Assert.IsTrue(leftCount != rightCount);

            Assert.IsTrue(!leftCount.Equals(null));
            Assert.IsTrue(!leftCount.Equals(rightCount));

            Assert.IsTrue(!leftCount.Equals((object) null));
            Assert.IsTrue(!leftCount.Equals((object) rightCount));

            var comparer = Count.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightCount));
            Assert.IsTrue(!comparer.Equals(leftCount, null));
            Assert.IsTrue(!comparer.Equals(leftCount, rightCount));
        }
    }
}