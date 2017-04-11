using MarsRover.Grids;

namespace MarsRover.Vehicles
{
    public class RoverPosition
    {
        public Coordinates Coordinates { get; set; }
        
        public RoverPosition(Coordinates coordinates)
            => Coordinates = coordinates;
    }
}
