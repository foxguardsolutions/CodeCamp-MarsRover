using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public interface IDirection
    {
        void MoveBackward(RoverPosition position);
        void MoveForward(RoverPosition position);
    }
}
