using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MovementWhenFacingSouthTests : MovementFrameOfReferenceTests
    {
        private IMovementFrameOfReference _state;

        [SetUp]
        public void SetState()
        {
            _state = new MovementWhenFacingSouth();
        }

        [Test]
        public void MoveForward_ReturnsPositionWithDecrementedYCoordinate()
        {
            var expectedFinalPosition = InitialPosition.DecrementCoordinate(1);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _state.MoveForward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void MoveBackward_ReturnsPositionWithIncrementedYCoordinate()
        {
            var expectedFinalPosition = InitialPosition.IncrementCoordinate(1);
            var expectedFinalCoordinates = expectedFinalPosition.GetCoordinates();

            var finalPosition = _state.MoveBackward(InitialPosition);
            var finalCoordinates = finalPosition.GetCoordinates();

            Assert.That(finalCoordinates, Is.EqualTo(expectedFinalCoordinates));
        }

        [Test]
        public void RotateCounterclockwise_SetsRoverFrameOfReferenceEast()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingEast);

            _state.RotateCounterclockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }

        [Test]
        public void RotateClockwise_SetsRoverFrameOfReferenceWest()
        {
            var expectedFrameOfReference = typeof(MovementWhenFacingWest);

            _state.RotateClockwise(ContextRover);
            var finalFrameOfReference = ContextRover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }
    }
}
