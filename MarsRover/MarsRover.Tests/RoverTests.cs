using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void GetLocation_WithoutMovement_Returns()
        {
            var testRover = new Rover(1, 0, CardinalDirection.North);
            Assert.That(testRover.GetLocation(), Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void GetOrientation_WithoutMovement_Returns()
        {
            var testRover = new Rover(1, 0, CardinalDirection.North);
            Assert.That(testRover.GetOrientation(), Is.EqualTo(CardinalDirection.North));
        }

        [TestCaseSource(nameof(MoveTestCases))]
        public void GetLocation_AfterMove_Returns(int startX, int startY, CardinalDirection startFacing, int endX, int endY)
        {
            var testRover = new Rover(startX, startY, startFacing);
            testRover.Move();
            Assert.That(testRover.GetLocation(), Is.EqualTo(new int[] { endX, endY }));
        }

        [TestCaseSource(nameof(MoveTestCases))]
        public void GetOrientation_AfterMove_Returns(int startX, int startY, CardinalDirection startFacing, int endX, int endY)
        {
            var testRover = new Rover(startX, startY, startFacing);
            testRover.Move();
            Assert.That(testRover.GetOrientation(), Is.EqualTo(startFacing));
        }

        private static IEnumerable<TestCaseData> MoveTestCases()
        {
            yield return new TestCaseData(1, 0, CardinalDirection.North, 2, 0);
            yield return new TestCaseData(2, 0, CardinalDirection.North, 3, 0);
            yield return new TestCaseData(2, 1, CardinalDirection.North, 3, 1);
            yield return new TestCaseData(2, 1, CardinalDirection.South, 1, 1);
            yield return new TestCaseData(2, 1, CardinalDirection.East, 2, 2);
            yield return new TestCaseData(2, 1, CardinalDirection.West, 2, 0);
        }
    }
}
