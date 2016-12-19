using System;
using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        [TestCase('l', typeof(Rotate))]
        [TestCase('r', typeof(Rotate))]
        [TestCase('f', typeof(Translate))]
        [TestCase('b', typeof(Translate))]
        public void Execute_ReturnsType(char candidate, Type expectedType)
        {
            var testCommand = new Command(candidate);
            var strategy = testCommand.CreateAction();
            Assert.That(strategy.GetType(), Is.EqualTo(expectedType));
        }

        [TestCaseSource(nameof(RotateTestCases))]
        public void Rotate_ChangesOrientationTo(char candidate, CardinalDirection endFacing)
        {
            var startingPosition = new Position(0, 0, North, new Grid());
            var rotateCommand = new Command(candidate);
            var rotation = rotateCommand.CreateAction();
            var endingPosition = rotation.Act(startingPosition);
            Assert.That(endingPosition.Orientation, Is.EqualTo(endFacing));
        }

        private static IEnumerable<TestCaseData> RotateTestCases()
        {
            yield return new TestCaseData('l', West);
            yield return new TestCaseData('r', East);
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_ChangesPositionTo(char candidate, int endX)
        {
            var startingPosition = new Position(1, 0, East, new Grid());
            var translateCommand = new Command(candidate);
            var translation = translateCommand.CreateAction();
            var endingPosition = translation.Act(startingPosition);
            Assert.That(endingPosition.Coordinates, Is.EqualTo(new int[] { endX, 0 }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData('f', 2);
            yield return new TestCaseData('b', 0);
        }
    }
}
