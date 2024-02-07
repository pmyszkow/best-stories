using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;
using System;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    public class UserIdTests
    {
        [Test]
        public void FromStringCreatesInstanceContainingValueFromArgument()
        {
            const string userIdValue = "UserId";

            var userId = UserId.FromString(userIdValue);

            Assert.AreEqual(userIdValue, userId.Value);
        }

        [Test]
        public void FromStringCreatesInstanceContainingValueParsedFromTrimmedArgument()
        {
            const string userIdValue = "   UserId   ";

            var userId = UserId.FromString(userIdValue);

            Assert.AreEqual(userIdValue.Trim(), userId.Value);
        }
        
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FromStringReturnsNullInstanceIfArgumentIsNullOrWhiteSpace(string argument)
        {
            Assert.AreEqual(UserId.NULL, UserId.FromString(argument));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(null, UserId.NULL.Value);
        }

        [Test]
        public void ToStringReturnsContainedValueString()
        {
            const string userIdValue = "UserId";

            var userId = UserId.FromString(userIdValue);

            Assert.AreEqual(userId.Value, userId.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftUserId = UserId.FromString("UserId");

            var rightUserId = UserId.FromString("UserId");

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
            var leftUserId = UserId.FromString("LeftUserId");

            var rightUserId = UserId.FromString("RightUserId");

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