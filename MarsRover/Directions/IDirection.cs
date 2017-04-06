using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public interface IDirection
    {
        void MoveBackward(Rover rover);
        void MoveForward(Rover rover);
    }
}
