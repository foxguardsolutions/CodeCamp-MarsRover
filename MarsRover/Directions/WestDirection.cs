using MarsRover.Grids;
using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public class WestDirection : IDirection
    {
        private IGrid _grid;

        public WestDirection(IGrid grid)
        {
            _grid = grid;
        }

        public void MoveBackward(RoverPosition position)
        {
            var newCoordinates = _grid.GetNextCoordinatesEast(position.Coordinates);
            position.Coordinates = newCoordinates;
        }

        public void MoveForward(RoverPosition position)
        {
            var newCoordinates = _grid.GetNextCoordinatesWest(position.Coordinates);
            position.Coordinates = newCoordinates;
        }
    }
}
