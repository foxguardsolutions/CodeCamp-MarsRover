using System.Collections.Generic;

namespace MarsRover
{
    public enum Movement
    {
        FORWARD, BACKWARD, LEFT, RIGHT
    }

    public interface IVehicle
    {
        Grid World { get; set; }
        GridCell CurrentLocation { get; set; }
        Grid.Direction Orientation { get; set; }

        bool Move(Movement movement);
    }
}
