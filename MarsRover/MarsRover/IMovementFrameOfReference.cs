namespace MarsRover
{
    public interface IMovementFrameOfReference
    {
        Position MoveForward(Position lastPosition);
        Position MoveBackward(Position lastPosition);

        void RotateCounterclockwise(Rover rover);
        void RotateClockwise(Rover rover);
    }
}
