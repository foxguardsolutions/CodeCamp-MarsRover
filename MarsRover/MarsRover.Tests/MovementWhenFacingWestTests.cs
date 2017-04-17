using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MovementWhenFacingWestTests : MovementFrameOfReferenceTests
    {
        private IMovementFrameOfReference _state;

        [SetUp]
        public void SetState()
        {
            _state = new MovementWhenFacingWest();
        }

        [Test]
        public void MoveForward_ReturnsPositionWithDecrementedXCoordinate()
        {
            var expectedFinalPosition = InitialPosition.DecrementCoordinate(0);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _state.MoveForward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void MoveBackward_ReturnsPositionWithIncrementedXCoordinate()
        {
            var expectedFinalPosition = InitialPosition.IncrementCoordinate(0);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _state.MoveBackward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void RotateCounterclockwise_SetsRoverFrameOfReferenceSouth()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingSouth);

            _state.RotateCounterclockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }

        [Test]
        public void RotateClockwise_SetsRoverFrameOfReferenceNorth()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingNorth);

            _state.RotateClockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }
    }
}
