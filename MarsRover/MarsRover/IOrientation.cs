namespace MarsRover
{
    public interface IOrientation
    {
        Position Translate(Position position, bool isMovingForward);
        void Rotate(Rover rover, bool isTurningCounterclockwise);
    }
}