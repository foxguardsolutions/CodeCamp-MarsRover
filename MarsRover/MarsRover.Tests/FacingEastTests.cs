using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class FacingEastTests
    {
        private IOrientation _facingEastState;

        [SetUp]
        public void SetUp()
        {
            _facingEastState = new FacingEast();
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_ReturnsPositionWithCoordinates(int initialX, int initialY, bool isMovingForward, int finalX, int finalY)
        {
            var initialPosition = new Position(initialX, initialY, new Grid());
            var finalPosition = _facingEastState.Translate(initialPosition, isMovingForward);
            Assert.That(finalPosition.Coordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(0, 0, true, 1, 0);
            yield return new TestCaseData(2, 0, true, 3, 0);
            yield return new TestCaseData(2, 0, false, 1, 0);
        }
    }
}
