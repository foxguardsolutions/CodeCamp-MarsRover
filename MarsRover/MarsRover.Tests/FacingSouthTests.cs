using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class FacingSouthTests
    {
        private IOrientation _facingSouthState;

        [SetUp]
        public void SetUp()
        {
            _facingSouthState = new FacingSouth();
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_ReturnsPositionWithCoordinates(int initialX, int initialY, bool isMovingForward, int finalX, int finalY)
        {
            var initialPosition = new Position(initialX, initialY, new Grid());
            var finalPosition = _facingSouthState.Translate(initialPosition, isMovingForward);
            Assert.That(finalPosition.Coordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(1, 1, true, 1, 0);
            yield return new TestCaseData(0, 2, true, 0, 1);
            yield return new TestCaseData(0, 2, false, 0, 3);
        }
    }
}
