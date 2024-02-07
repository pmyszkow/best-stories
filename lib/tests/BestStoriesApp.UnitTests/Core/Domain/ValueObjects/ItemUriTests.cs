using System;
using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    public class ItemUriTests
    {
        [Test]
        public void FromStringCreatesInstanceContainingValueFromArgument()
        {
            const string itemUriValue = "https://github.com/uBlockOrigin/uBlock-issues/issues/745";

            var itemUri = ItemUri.FromString(itemUriValue);

            Assert.AreEqual(itemUriValue, itemUri.Value);
        }

        [Test]
        public void FromStringCreatesInstanceContainingValueParsedFromTrimmedArgument()
        {
            const string itemUriValue = "   https://github.com/uBlockOrigin/uBlock-issues/issues/745   ";

            var itemUri = ItemUri.FromString(itemUriValue);

            Assert.AreEqual(itemUriValue.Trim(), itemUri.Value);
        }

        [Test]
        public void FromStringThrowsExceptionIfArgumentIsNotFullyQualified()
        {
            const string invalidItemUriValue = "/uBlockOrigin/uBlock-issues/issues/745";

            Assert.Throws<UriFormatException>(() => ItemUri.FromString(invalidItemUriValue));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FromStringReturnsNullInstanceIfArgumentIsNullOrWhiteSpace(string argument)
        {
            Assert.AreEqual(ItemUri.NULL, ItemUri.FromString(argument));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(null, ItemUri.NULL.Value);
        }

        [Test]
        public void ToStringReturnsContainedValueString()
        {
            const string itemUriValue = "https://github.com/uBlockOrigin/uBlock-issues/issues/745";

            var itemUri = ItemUri.FromString(itemUriValue);

            Assert.AreEqual(itemUri.Value, itemUri.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftItemUri = ItemUri.FromString("https://github.com/uBlockOrigin/uBlock-issues/issues/745");

            var rightItemUri = ItemUri.FromString("https://github.com/uBlockOrigin/uBlock-issues/issues/745");

            Assert.IsTrue(leftItemUri == rightItemUri);

            Assert.IsTrue(leftItemUri.Equals(leftItemUri));
            Assert.IsTrue(leftItemUri.Equals(rightItemUri));

            Assert.IsTrue(leftItemUri.Equals((object)leftItemUri));
            Assert.IsTrue(leftItemUri.Equals((object)rightItemUri));

            var comparer = ItemUri.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftItemUri, leftItemUri));
            Assert.IsTrue(comparer.Equals(leftItemUri, rightItemUri));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftItemUri = ItemUri.FromString("https://github.com/uBlockOrigin/uBlock-issues/issues/745");

            var rightItemUri = ItemUri.FromString("https://github.com/uBlockOrigin/uBlock-issues/issues/746");

            Assert.IsTrue(leftItemUri != rightItemUri);

            Assert.IsTrue(!leftItemUri.Equals(null));
            Assert.IsTrue(!leftItemUri.Equals(rightItemUri));

            Assert.IsTrue(!leftItemUri.Equals((object)null));
            Assert.IsTrue(!leftItemUri.Equals((object)rightItemUri));

            var comparer = ItemUri.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightItemUri));
            Assert.IsTrue(!comparer.Equals(leftItemUri, null));
            Assert.IsTrue(!comparer.Equals(leftItemUri, rightItemUri));
        }
    }
}