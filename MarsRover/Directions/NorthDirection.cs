using MarsRover.Grids;
using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public class NorthDirection : IDirection
    {
        private IGrid _grid;

        public NorthDirection(IGrid grid)
        {
            _grid = grid;
        }

        public void MoveBackward(RoverPosition position)
        {
            var newCoordinates = _grid.GetNextCoordinatesSouth(position.Coordinates);
            position.Coordinates = newCoordinates;
        }

        public void MoveForward(RoverPosition position)
        {
            var newCoordinates = _grid.GetNextCoordinatesNorth(position.Coordinates);
            position.Coordinates = newCoordinates;
        }
    }
}
