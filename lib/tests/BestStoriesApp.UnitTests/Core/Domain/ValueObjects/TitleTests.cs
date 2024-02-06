using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    public class TitleTests
    {
        [Test]
        public void FromStringCreatesInstanceContainingValueFromArgument()
        {
            const string titleValue = "Title";

            var title = Title.FromString(titleValue);

            Assert.AreEqual(titleValue, title.Value);
        }

        [Test]
        public void FromStringCreatesInstanceContainingValueFromTrimmedArgument()
        {
            const string titleValue = "   Title   ";

            var title = Title.FromString(titleValue);

            Assert.AreEqual(titleValue.Trim(), title.Value);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FromStringReturnsNullInstanceIfArgumentIsNullOrWhiteSpace(string argument)
        {
            Assert.AreEqual(Title.NULL, Title.FromString(argument));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(null, Title.NULL.Value);
        }

        [Test]
        public void ToStringReturnsContainedValue()
        {
            const string titleValue = "Title";

            var title = Title.FromString(titleValue);

            Assert.AreEqual(title.Value, title.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftTitle = Title.FromInt(1);

            var rightTitle = Title.FromInt(1);

            Assert.IsTrue(leftTitle == rightTitle);

            Assert.IsTrue(leftTitle.Equals(leftTitle));
            Assert.IsTrue(leftTitle.Equals(rightTitle));

            Assert.IsTrue(leftTitle.Equals((object)leftTitle));
            Assert.IsTrue(leftTitle.Equals((object)rightTitle));

            var comparer = Title.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftTitle, leftTitle));
            Assert.IsTrue(comparer.Equals(leftTitle, rightTitle));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftTitle = Title.FromInt(1);

            var rightTitle = Title.FromInt(2);

            Assert.IsTrue(leftTitle != rightTitle);

            Assert.IsTrue(!leftTitle.Equals(null));
            Assert.IsTrue(!leftTitle.Equals(rightTitle));

            Assert.IsTrue(!leftTitle.Equals((object)null));
            Assert.IsTrue(!leftTitle.Equals((object)rightTitle));

            var comparer = Title.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightTitle));
            Assert.IsTrue(!comparer.Equals(leftTitle, null));
            Assert.IsTrue(!comparer.Equals(leftTitle, rightTitle));
        }
    }
}