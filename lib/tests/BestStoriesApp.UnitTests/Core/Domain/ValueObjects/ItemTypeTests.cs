using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    [TestFixture]
    public class ItemTypeTests
    {
        [Test]
        public void FromStringReturnsInstanceCorrespondingToArgument()
        {
            Assert.AreEqual(ItemType.Story, ItemType.FromString("Story"));
            Assert.AreEqual(ItemType.Comment, ItemType.FromString("Comment"));
        }

        [Test]
        public void FromStringReturnsInstanceCorrespondingToTrimmedArgument()
        {
            Assert.AreEqual(ItemType.Story, ItemType.FromString("   Story   "));
            Assert.AreEqual(ItemType.Comment, ItemType.FromString("   Comment   "));
        }

        [Test]
        public void FromStringReturnsInstanceCorrespondingToArgumentIgnoringCase()
        {
            Assert.AreEqual(ItemType.Story, ItemType.FromString("STORY"));
            Assert.AreEqual(ItemType.Comment, ItemType.FromString("COMMENT"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FromStringReturnsNullInstanceIfArgumentIsNullOrWhiteSpace(string argument)
        {
            Assert.AreEqual(ItemType.NULL, ItemType.FromString(argument));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(null, ItemType.NULL.Value);
            Assert.AreEqual("STORY", ItemType.Story.Value);
            Assert.AreEqual("COMMENT", ItemType.Comment.Value);
        }

        [Test]
        public void ToStringReturnsContainedValue()
        {
            var itemType = ItemType.Story;

            Assert.AreEqual(itemType.Value, itemType.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftItemType = ItemType.Story;

            var rightItemType = ItemType.Story;

            Assert.IsTrue(leftItemType == rightItemType);

            Assert.IsTrue(leftItemType.Equals(leftItemType));
            Assert.IsTrue(leftItemType.Equals(rightItemType));

            Assert.IsTrue(leftItemType.Equals((object)leftItemType));
            Assert.IsTrue(leftItemType.Equals((object)rightItemType));

            var comparer = ItemType.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftItemType, leftItemType));
            Assert.IsTrue(comparer.Equals(leftItemType, rightItemType));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftItemType = ItemType.Story;

            var rightItemType = ItemType.Comment;

            Assert.IsTrue(leftItemType != rightItemType);

            Assert.IsTrue(!leftItemType.Equals(null));
            Assert.IsTrue(!leftItemType.Equals(rightItemType));

            Assert.IsTrue(!leftItemType.Equals((object)null));
            Assert.IsTrue(!leftItemType.Equals((object)rightItemType));

            var comparer = ItemType.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightItemType));
            Assert.IsTrue(!comparer.Equals(leftItemType, null));
            Assert.IsTrue(!comparer.Equals(leftItemType, rightItemType));
        }
    }
}