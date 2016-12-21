using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class TranslateTests
    {
        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_ChangesPositionTo(int startX, int startY, CardinalDirection startFacing, bool isMovingForward, int endX, int endY)
        {
            var startingPosition = new Position(startX, startY, startFacing, new Grid());
            var translation = new Translate(isMovingForward);
            var endingPosition = translation.Act(startingPosition);
            Assert.That(endingPosition.Coordinates, Is.EqualTo(new int[] { endX, endY }));
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_DoesNotChangeOrientation(int startX, int startY, CardinalDirection startFacing, bool isMovingForward, int endX, int endY)
        {
            var startingPosition = new Position(startX, startY, startFacing, new Grid());
            var translation = new Translate(isMovingForward);
            var endingPosition = translation.Act(startingPosition);
            Assert.That(endingPosition.Orientation, Is.EqualTo(startFacing));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(1, 0, E, true, 2, 0);
            yield return new TestCaseData(2, 0, E, true, 3, 0);
            yield return new TestCaseData(2, 1, E, true, 3, 1);
            yield return new TestCaseData(2, 1, W, true, 1, 1);
            yield return new TestCaseData(2, 1, N, true, 2, 2);
            yield return new TestCaseData(2, 1, S, true, 2, 0);
            yield return new TestCaseData(1, 0, E, false, 0, 0);
            yield return new TestCaseData(2, 0, E, false, 1, 0);
            yield return new TestCaseData(2, 1, E, false, 1, 1);
            yield return new TestCaseData(2, 1, W, false, 3, 1);
            yield return new TestCaseData(2, 1, N, false, 2, 0);
            yield return new TestCaseData(2, 1, S, false, 2, 2);
            yield return new TestCaseData(0, 1, W, true, 999, 1);
        }
    }
}
