using NUnit.Framework;

namespace MarsRover.Tests
{
    public class MovementWhenFacingEastTests : MovementFrameOfReferenceTests
    {
        private IMovementFrameOfReference _movement;

        [SetUp]
        public void SetState()
        {
            _movement = new MovementWhenFacingEast();
        }

        [Test]
        public void MoveForward_ReturnsPositionWithIncrementedXCoordinate()
        {
            var expectedFinalPosition = InitialPosition.IncrementCoordinate(0);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _movement.MoveForward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void MoveBackward_ReturnsPositionWithDecrementedXCoordinate()
        {
            var expectedFinalPosition = InitialPosition.DecrementCoordinate(0);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _movement.MoveBackward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void RotateCounterclockwise_SetsRoverFrameOfReferenceNorth()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingNorth);

            _movement.RotateCounterclockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }

        [Test]
        public void RotateClockwise_SetsRoverFrameOfReferenceSouth()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingSouth);

            _movement.RotateClockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }
    }
}
