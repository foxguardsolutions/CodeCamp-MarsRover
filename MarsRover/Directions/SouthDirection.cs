using MarsRover.Grids;
using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public class SouthDirection : IDirection
    {
        private IGrid _grid;

        public SouthDirection(IGrid grid)
        {
            _grid = grid;
        }

        public void MoveBackward(RoverPosition position)
        {
            var newCoordinates = _grid.GetNextCoordinatesNorth(position.Coordinates);
            position.Coordinates = newCoordinates;
        }

        public void MoveForward(RoverPosition position)
        {
            var newCoordinates = _grid.GetNextCoordinatesSouth(position.Coordinates);
            position.Coordinates = newCoordinates;
        }
    }
}
