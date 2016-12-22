using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PositionTests
    {
        private Position _position;

        [SetUp]
        public void SetUp()
        {
            _position = new Position(1, 0, new Grid());
        }

        [Test]
        public void CoordinatesGetter_ReturnsInitialCoordinates()
        {
            var coordinates = _position.Coordinates;
            Assert.That(coordinates, Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void Clone_WithoutChangingClonedPosition_ReturnsInitialCoordinates()
        {
            var newPosition = _position.Clone();
            var newCoordinates = newPosition.Coordinates;
            Assert.That(newCoordinates, Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void Clone_WithChangeToClonedPosition_DoesNotChangeInitialCoordinates()
        {
            var newPosition = _position.Clone();
            newPosition.Coordinates[0]++;
            var oldCoordinates = _position.Coordinates;
            Assert.That(oldCoordinates, Is.EqualTo(new int[] { 1, 0 }));
        }

        [TestCase(0, 1000, "Point not on grid: 0, 1000")]
        public void NewPosition_GivenInvalidCoordinates_ThrowsException(
           int initialX, int initialY, string exceptionMessage)
        {
            Assert.Throws<ArgumentException>(() => { new Position(initialX, initialY, new Grid()); }, exceptionMessage);
        }

        [TestCaseSource(nameof(IncrementTestCases))]
        public void IncrementCoordinate_IncreasesCoordinateValue(int initialX, int initialY, int coordinateIndex, int finalX, int finalY)
        {
            var position = new Position(initialX, initialY, new Grid());
            position.IncrementCoordinate(coordinateIndex);
            var newCoordinates = position.Coordinates;
            Assert.That(newCoordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> IncrementTestCases()
        {
            yield return new TestCaseData(1, 0, 0, 2, 0);
            yield return new TestCaseData(1, 0, 1, 1, 1);
            yield return new TestCaseData(1, 999, 1, 1, 0);
        }

        [TestCaseSource(nameof(DecrementTestCases))]
        public void DecrementCoordinate_DecreasesCoordinateValue(int initialX, int initialY, int coordinateIndex, int finalX, int finalY)
        {
            var position = new Position(initialX, initialY, new Grid());
            position.DecrementCoordinate(coordinateIndex);
            var newCoordinates = position.Coordinates;
            Assert.That(newCoordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> DecrementTestCases()
        {
            yield return new TestCaseData(1, 0, 0, 0, 0);
            yield return new TestCaseData(2, 0, 0, 1, 0);
            yield return new TestCaseData(0, 2, 1, 0, 1);
            yield return new TestCaseData(0, 2, 0, 999, 2);
        }
    }
}
