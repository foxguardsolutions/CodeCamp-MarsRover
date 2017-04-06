using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public interface IDirection
    {
        CardinalDirection CardinalDirection { get; }
        void MoveBackward(Rover rover);
        void MoveForward(Rover rover);
        void TurnLeft(Rover rover);
        void TurnRight(Rover rover);
    }
}
