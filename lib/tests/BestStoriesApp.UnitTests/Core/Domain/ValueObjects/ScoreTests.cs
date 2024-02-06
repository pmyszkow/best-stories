using BestStoriesApp.Core.Domain.ValueObjects;
using NUnit.Framework;
using System;

namespace BestStoriesApp.UnitTests.Core.Domain.ValueObjects
{
    public class ScoreTests
    {
        [Test]
        public void FromIntCreatesInstanceContainingValueFromArgument()
        {
            const int scoreValue = 1;

            var score = Score.FromInt(scoreValue);

            Assert.AreEqual(scoreValue, score.Value);
        }

        [Test]
        public void FromIntThrowsExceptionIfArgumentLowerThanZero()
        {
            Assert.DoesNotThrow(() => Score.FromInt(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => Score.FromInt(-1));
        }

        [Test]
        public void FactoryPropertiesReturnsInstanceContainingValueCorrespondingToPropertyName()
        {
            Assert.AreEqual(0, Score.ZERO.Value);
        }

        [Test]
        public void ToStringReturnsContainedValueString()
        {
            const int scoreValue = 1;

            var score = Score.FromInt(scoreValue);

            Assert.AreEqual(score.Value.ToString(), score.ToString());
        }

        [Test]
        public void EqualityMembersReturnTrueIfContainedValuesAreEqual()
        {
            var leftScore = Score.FromInt(1);

            var rightScore = Score.FromInt(1);

            Assert.IsTrue(leftScore == rightScore);

            Assert.IsTrue(leftScore.Equals(leftScore));
            Assert.IsTrue(leftScore.Equals(rightScore));

            Assert.IsTrue(leftScore.Equals((object)leftScore));
            Assert.IsTrue(leftScore.Equals((object)rightScore));

            var comparer = Score.ValueComparer;
            Assert.IsTrue(comparer.Equals(null, null));
            Assert.IsTrue(comparer.Equals(leftScore, leftScore));
            Assert.IsTrue(comparer.Equals(leftScore, rightScore));
        }

        [Test]
        public void NotEqualityMembersReturnTrueIfContainedValuesAreNotEqual()
        {
            var leftScore = Score.FromInt(1);

            var rightScore = Score.FromInt(2);

            Assert.IsTrue(leftScore != rightScore);

            Assert.IsTrue(!leftScore.Equals(null));
            Assert.IsTrue(!leftScore.Equals(rightScore));

            Assert.IsTrue(!leftScore.Equals((object)null));
            Assert.IsTrue(!leftScore.Equals((object)rightScore));

            var comparer = Score.ValueComparer;
            Assert.IsTrue(!comparer.Equals(null, rightScore));
            Assert.IsTrue(!comparer.Equals(leftScore, null));
            Assert.IsTrue(!comparer.Equals(leftScore, rightScore));
        }
    }
}