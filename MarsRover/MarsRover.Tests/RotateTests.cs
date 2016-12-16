using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RotateTests
    {
        [TestCaseSource(nameof(RotateTestCases))]
        public void Rotate_ChangesOrientationTo(CardinalDirection startFacing, bool isTurningClockwise, CardinalDirection endFacing)
        {
            var startingPosition = new Position(0, 0, startFacing);
            var rotation = new Rotate(isTurningClockwise);
            var endingPosition = rotation.Act(startingPosition);
            Assert.That(endingPosition.Orientation, Is.EqualTo(endFacing));
        }

        private static IEnumerable<TestCaseData> RotateTestCases()
        {
            yield return new TestCaseData(North, true, East);
            yield return new TestCaseData(East, true, South);
            yield return new TestCaseData(West, true, North);
            yield return new TestCaseData(East, false, North);
            yield return new TestCaseData(North, false, West);
        }
    }
}
