using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void GetLocation_WithoutMovement_ReturnsStartingCoordinates()
        {
            var testRover = new Rover(1, 0, N, new Grid());
            Assert.That(testRover.GetLocation(), Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void GetOrientation_WithoutMovement_ReturnsStartingOrientation()
        {
            var testRover = new Rover(1, 0, N, new Grid());
            Assert.That(testRover.GetOrientation(), Is.EqualTo(N));
        }

        [Test]
        public void GetLocation_AfterMovement_ReturnsLastPositionCoordinates()
        {
            var testRover = new Rover(0, 0, N, new Grid());
            MoveForwardTurnRightMoveForward(testRover);
            var endingCoordinates = testRover.GetLocation();
            Assert.That(endingCoordinates, Is.EqualTo(new int[] { 1, 1 }));
        }

        [Test]
        public void GetOrientation_AfterMovement_ReturnsLastPositionOrientation()
        {
            var testRover = new Rover(0, 0, N, new Grid());
            TurnAround(testRover);
            var endingOrientation = testRover.GetOrientation();
            Assert.That(endingOrientation, Is.EqualTo(S));
        }

        [Test]
        public void GetLocation_AfterSingleMovementThroughObstacle_ReturnsStartingCoordinates()
        {
            var testGrid = new Grid();
            testGrid.AddObstacle(0, 1);
            var testRover = new Rover(0, 0, N, testGrid);
            MoveForward(testRover);
            var endingCoordinates = testRover.GetLocation();
            Assert.That(endingCoordinates, Is.EqualTo(new int[] { 0, 0 }));
        }

        private void MoveForwardTurnRightMoveForward(Rover testRover)
        {
            MoveForward(testRover);
            TurnRight(testRover);
            MoveForward(testRover);
        }

        private void TurnAround(Rover testRover)
        {
            TurnRight(testRover);
            TurnRight(testRover);
        }

        private void TurnRight(Rover testRover)
        {
            var isTurningCounterclockwise = false;
            testRover.SetAction(new Rotate(isTurningCounterclockwise));
            testRover.TryMove();
        }

        private void MoveForward(Rover testRover)
        {
            var isMovingForward = true;
            testRover.SetAction(new Translate(isMovingForward));
            testRover.TryMove();
        }
    }
}
