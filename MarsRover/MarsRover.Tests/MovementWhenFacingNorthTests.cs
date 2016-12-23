using NUnit.Framework;

namespace MarsRover.Tests
{
    public class MovementWhenFacingNorthTests : MovementFrameOfReferenceTests
    {
        private IMovementFrameOfReference _movement;

        [SetUp]
        public void SetState()
        {
            _movement = new MovementWhenFacingNorth();
        }

        [Test]
        public void MoveForward_ReturnsPositionWithIncrementedYCoordinate()
        {
            var expectedFinalPosition = InitialPosition.IncrementCoordinate(1);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _movement.MoveForward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void MoveBackward_ReturnsPositionWithDecrementedYCoordinate()
        {
            var expectedFinalPosition = InitialPosition.DecrementCoordinate(1);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _movement.MoveBackward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void RotateCounterclockwise_SetsRoverFrameOfReferenceWest()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingWest);

            _movement.RotateCounterclockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }

        [Test]
        public void RotateClockwise_SetsRoverFrameOfReferenceEast()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingEast);

            _movement.RotateClockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }
    }
}
