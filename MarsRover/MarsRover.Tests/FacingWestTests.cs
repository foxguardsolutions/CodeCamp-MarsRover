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
        public void Translate_ReturnsPositionWithCoordinates(int initialX, int initialY, int finalX, int finalY)
        {
            var initialPosition = new Position(initialX, initialY);
            var finalPosition = _facingWestState.Translate(initialPosition);
            Assert.That(finalPosition.Coordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(1, 1, 0, 1);
            yield return new TestCaseData(2, 0, 1, 0);
        }
    }
}
