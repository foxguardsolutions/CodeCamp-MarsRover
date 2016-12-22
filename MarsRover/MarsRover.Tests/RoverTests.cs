using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        [TestCase(1, 0)]
        [TestCase(2, 3)]
        public void GetLocation_WithoutMovement_ReturnsInitialCoordinates(int initialX, int initialY)
        {
            var testRover = new Rover(initialX, initialY, new FacingNorth());
            var roverCoordinates = testRover.GetLocation().Coordinates;
            Assert.That(roverCoordinates, Is.EqualTo(new int[] { initialX, initialY }));
        }

        [TestCaseSource(nameof(MoveTestCases))]
        public void GetLocation_AfterForwardMove_ReturnsNewCoordinates(
            int initialX, int initialY, int finalX, int finalY)
        {
            var testRover = new Rover(initialX, initialY, new FacingNorth());
            testRover.Move();
            var roverCoordinates = testRover.GetLocation().Coordinates;
            Assert.That(roverCoordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        [TestCaseSource(nameof(MoveTestCases))]
        public void GetStartingLocation_AfterForwardMove_ReturnsStartingCoordinates(
            int initialX, int initialY, int finalX, int finalY)
        {
            var testRover = new Rover(initialX, initialY, new FacingNorth());
            testRover.Move();
            var roverStartCoordinates = testRover.GetStartingLocation().Coordinates;
            Assert.That(roverStartCoordinates, Is.EqualTo(new int[] { initialX, initialY }));
        }

        private static IEnumerable<TestCaseData> MoveTestCases()
        {
            yield return new TestCaseData(1, 0, 1, 1);
            yield return new TestCaseData(0, 2, 0, 3);
            yield return new TestCaseData(2, 0, 2, 1);
        }

        [TestCaseSource(nameof(NoRotationTestCases))]
        public void GetOrientation_WithoutRotation_ReturnsInitialOrientation(
            IOrientation initialOrientation, Type expectedOrientationType)
        {
            var testRover = new Rover(0, 0, initialOrientation);
            var finalOrientationType = testRover.GetOrientation();
            Assert.That(finalOrientationType, Is.EqualTo(expectedOrientationType));
        }

        private static IEnumerable<TestCaseData> NoRotationTestCases()
        {
            yield return new TestCaseData(new FacingNorth(), typeof(FacingNorth));
            yield return new TestCaseData(new FacingEast(), typeof(FacingEast));
        }

        [TestCaseSource(nameof(RotationTestCases))]
        public void GetOrientation_WithRotation_ReturnsNewOrientation(
            IOrientation initialOrientation, bool isTurningCounterclockwise, Type expectedOrientationType)
        {
            var testRover = new Rover(0, 0, initialOrientation);
            testRover.Rotate(isTurningCounterclockwise);
            var finalOrientationType = testRover.GetOrientation();
            Assert.That(finalOrientationType, Is.EqualTo(expectedOrientationType));
        }

        private static IEnumerable<TestCaseData> RotationTestCases()
        {
            yield return new TestCaseData(new FacingNorth(), true, typeof(FacingWest));
            yield return new TestCaseData(new FacingEast(), true, typeof(FacingNorth));
            yield return new TestCaseData(new FacingSouth(), true, typeof(FacingEast));
            yield return new TestCaseData(new FacingWest(), true, typeof(FacingSouth));
            yield return new TestCaseData(new FacingNorth(), false, typeof(FacingEast));
            yield return new TestCaseData(new FacingEast(), false, typeof(FacingSouth));
            yield return new TestCaseData(new FacingSouth(), false, typeof(FacingWest));
            yield return new TestCaseData(new FacingWest(), false, typeof(FacingNorth));
        }
    }
}