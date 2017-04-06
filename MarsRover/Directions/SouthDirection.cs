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

        public void MoveBackward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesNorth(rover.Coordinates);
            rover.MoveTo(newCoordinates);
        }

        public void MoveForward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesSouth(rover.Coordinates);
            rover.MoveTo(newCoordinates);
        }
    }
}
