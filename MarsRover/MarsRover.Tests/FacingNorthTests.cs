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
            _facingNorthState = new NorthFacing();
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_ReturnsPositionWithCoordinates(int initialX, int initialY, int finalX, int finalY)
        {
            var initialPosition = new Position(initialX, initialY);
            var finalPosition = _facingNorthState.Translate(initialPosition);
            Assert.That(finalPosition.Coordinates, Is.EqualTo(new int[] { initialX, finalY }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(0, 1, 0, 2);
            yield return new TestCaseData(0, 2, 0, 3);
        }
    }
}
