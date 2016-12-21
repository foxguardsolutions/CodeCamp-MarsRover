using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RotateTests
    {
        [TestCaseSource(nameof(RotateTestCases))]
        public void Rotate_ChangesOrientationTo(CardinalDirection startFacing, bool isTurningCounterclockwise, CardinalDirection endFacing)
        {
            var startingPosition = new Position(0, 0, startFacing, new Grid());
            var rotation = new Rotate(isTurningCounterclockwise);
            var endingPosition = rotation.Act(startingPosition);
            Assert.That(endingPosition.Orientation, Is.EqualTo(endFacing));
        }

        private static IEnumerable<TestCaseData> RotateTestCases()
        {
            yield return new TestCaseData(N, true, W);
            yield return new TestCaseData(E, true, N);
            yield return new TestCaseData(S, true, E);
            yield return new TestCaseData(N, false, E);
            yield return new TestCaseData(E, false, S);
        }
    }
}
