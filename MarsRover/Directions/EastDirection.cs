using MarsRover.Grids;
using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public class EastDirection : IDirection
    {
        private IGrid _grid;

        public EastDirection(IGrid grid)
        {
            _grid = grid;
        }

        public void MoveBackward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesWest(rover.Coordinates);
            rover.MoveTo(newCoordinates);
        }

        public void MoveForward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesEast(rover.Coordinates);
            rover.MoveTo(newCoordinates);
        }
    }
}
