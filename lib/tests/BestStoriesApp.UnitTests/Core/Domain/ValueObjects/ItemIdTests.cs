using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;
using System;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    public class ItemIdTests
    {
        [Test]
        public void FromIntCreatesInstanceContainingValueFromArgument()
        {
            const int itemIdValue = 1;

            var itemId = ItemId.FromInt(itemIdValue);

            Assert.AreEqual(itemIdValue, itemId.Value);
        }

        [Test]
        public void FromIntThrowsExceptionIfArgumentLowerThanOrEqualToZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ItemId.FromInt(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => ItemId.FromInt(-1));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(-1, ItemId.DETACHED.Value);
        }

        [Test]
        public void ToStringReturnsContainedValueString()
        {
            const int itemIdValue = 1;

            var itemId = ItemId.FromInt(itemIdValue);

            Assert.AreEqual(itemId.Value.ToString(), itemId.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftItemId = ItemId.FromInt(1);

            var rightItemId = ItemId.FromInt(1);

            Assert.IsTrue(leftItemId == rightItemId);

            Assert.IsTrue(leftItemId.Equals(leftItemId));
            Assert.IsTrue(leftItemId.Equals(rightItemId));

            Assert.IsTrue(leftItemId.Equals((object)leftItemId));
            Assert.IsTrue(leftItemId.Equals((object)rightItemId));

            var comparer = ItemId.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftItemId, leftItemId));
            Assert.IsTrue(comparer.Equals(leftItemId, rightItemId));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftItemId = ItemId.FromInt(1);

            var rightItemId = ItemId.FromInt(2);

            Assert.IsTrue(leftItemId != rightItemId);

            Assert.IsTrue(!leftItemId.Equals(null));
            Assert.IsTrue(!leftItemId.Equals(rightItemId));

            Assert.IsTrue(!leftItemId.Equals((object)null));
            Assert.IsTrue(!leftItemId.Equals((object)rightItemId));

            var comparer = ItemId.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightItemId));
            Assert.IsTrue(!comparer.Equals(leftItemId, null));
            Assert.IsTrue(!comparer.Equals(leftItemId, rightItemId));
        }
    }
}