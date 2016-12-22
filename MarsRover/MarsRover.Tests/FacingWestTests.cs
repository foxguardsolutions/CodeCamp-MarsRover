using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class FacingWestTests
    {
        private IOrientation _facingWestState;

        [SetUp]
        public void SetUp()
        {
            _facingWestState = new FacingWest();
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_ReturnsPositionWithCoordinates(int initialX, int initialY, bool isMovingForward, int finalX, int finalY)
        {
            var initialPosition = new Position(initialX, initialY, new Grid());
            var finalPosition = _facingWestState.Translate(initialPosition, isMovingForward);
            Assert.That(finalPosition.Coordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(1, 1, true, 0, 1);
            yield return new TestCaseData(2, 0, true, 1, 0);
            yield return new TestCaseData(2, 0, false, 3, 0);
        }
    }
}
