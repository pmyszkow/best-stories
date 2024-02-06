using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;
using System;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    public class UserIdTests
    {
        [Test]
        public void FromIntCreatesInstanceContainingValueFromArgument()
        {
            const int userIdValue = 1;

            var userId = UserId.FromInt(userIdValue);

            Assert.AreEqual(userIdValue, userId.Value);
        }

        [Test]
        public void FromIntThrowsExceptionIfArgumentLowerThanOrEqualToZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => UserId.FromInt(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => UserId.FromInt(-1));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(0, UserId.ZERO.Value);
        }

        [Test]
        public void ToStringReturnsContainedValueString()
        {
            const int userIdValue = 1;

            var userId = UserId.FromInt(userIdValue);

            Assert.AreEqual(userId.Value.ToString(), userId.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftUserId = UserId.FromInt(1);

            var rightUserId = UserId.FromInt(1);

            Assert.IsTrue(leftUserId == rightUserId);

            Assert.IsTrue(leftUserId.Equals(leftUserId));
            Assert.IsTrue(leftUserId.Equals(rightUserId));

            Assert.IsTrue(leftUserId.Equals((object)leftUserId));
            Assert.IsTrue(leftUserId.Equals((object)rightUserId));

            var comparer = UserId.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftUserId, leftUserId));
            Assert.IsTrue(comparer.Equals(leftUserId, rightUserId));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftUserId = UserId.FromInt(1);

            var rightUserId = UserId.FromInt(2);

            Assert.IsTrue(leftUserId != rightUserId);

            Assert.IsTrue(!leftUserId.Equals(null));
            Assert.IsTrue(!leftUserId.Equals(rightUserId));

            Assert.IsTrue(!leftUserId.Equals((object)null));
            Assert.IsTrue(!leftUserId.Equals((object)rightUserId));

            var comparer = UserId.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightUserId));
            Assert.IsTrue(!comparer.Equals(leftUserId, null));
            Assert.IsTrue(!comparer.Equals(leftUserId, rightUserId));
        }
    }
}