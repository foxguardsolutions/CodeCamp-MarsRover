using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void GetLocation_WithoutMovement_Returns()
        {
            var testRover = new Rover(1, 0, North);
            Assert.That(testRover.GetLocation(), Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void GetOrientation_WithoutMovement_Returns()
        {
            var testRover = new Rover(1, 0, North);
            Assert.That(testRover.GetOrientation(), Is.EqualTo(North));
        }

        [TestCaseSource(nameof(MoveTestCases))]
        public void GetLocation_AfterMove_Returns(int startX, int startY, CardinalDirection startFacing, bool isMovingForward, int endX, int endY)
        {
            var testRover = new Rover(startX, startY, startFacing);
            testRover.Move(isMovingForward);
            Assert.That(testRover.GetLocation(), Is.EqualTo(new int[] { endX, endY }));
        }

        [TestCaseSource(nameof(MoveTestCases))]
        public void GetOrientation_AfterMove_Returns(int startX, int startY, CardinalDirection startFacing, bool isMovingForward, int endX, int endY)
        {
            var testRover = new Rover(startX, startY, startFacing);
            testRover.Move(isMovingForward);
            Assert.That(testRover.GetOrientation(), Is.EqualTo(startFacing));
        }

        private static IEnumerable<TestCaseData> MoveTestCases()
        {
            yield return new TestCaseData(1, 0, North, true, 2, 0);
            yield return new TestCaseData(2, 0, North, true, 3, 0);
            yield return new TestCaseData(2, 1, North, true, 3, 1);
            yield return new TestCaseData(2, 1, South, true, 1, 1);
            yield return new TestCaseData(2, 1, East, true, 2, 2);
            yield return new TestCaseData(2, 1, West, true, 2, 0);
            yield return new TestCaseData(1, 0, North, false, 0, 0);
            yield return new TestCaseData(2, 0, North, false, 1, 0);
            yield return new TestCaseData(2, 1, North, false, 1, 1);
            yield return new TestCaseData(2, 1, South, false, 3, 1);
            yield return new TestCaseData(2, 1, East, false, 2, 0);
            yield return new TestCaseData(2, 1, West, false, 2, 2);
        }

        [TestCaseSource(nameof(TurnTestCases))]
        public void GetOrientation_AfterTurn_Returns(CardinalDirection startFacing, CardinalDirection endFacing)
        {
            var testRover = new Rover(0, 0, startFacing);
            testRover.Turn();
            Assert.That(testRover.GetOrientation(), Is.EqualTo(endFacing));
        }

        private static IEnumerable<TestCaseData> TurnTestCases()
        {
            yield return new TestCaseData(North, East);
            yield return new TestCaseData(East, South);
            yield return new TestCaseData(West, North);
        }
    }
}
