using MarsRover.Directions;
using MarsRover.Grids;

namespace MarsRover.Vehicles
{
    public class Rover
    {
        public Coordinates Coordinates { get; private set; }
        public IDirection Direction { get; set; }
        
        public Rover(Coordinates coordiantes, IGrid grid, CardinalDirection cardinalDirection)
        {
            Coordinates = coordiantes;
            Direction = DirectionFactory.GetDirection(cardinalDirection, grid);
        }

        public void MoveBackward() => Direction.MoveBackward(this);

        public void MoveForward() => Direction.MoveForward(this);

        public void MoveTo(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
