using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class FacingNorthTests
    {
        private IOrientation _facingNorthState;

        [SetUp]
        public void SetUp()
        {
            _facingNorthState = new FacingNorth();
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_ReturnsPositionWithCoordinates(int initialX, int initialY, bool isMovingForward, int finalX, int finalY)
        {
            var initialPosition = new Position(initialX, initialY);
            var finalPosition = _facingNorthState.Translate(initialPosition, isMovingForward);
            Assert.That(finalPosition.Coordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(0, 1, true, 0, 2);
            yield return new TestCaseData(0, 2, true, 0, 3);
            yield return new TestCaseData(0, 2, false, 0, 1);
        }
    }
}
