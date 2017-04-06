using MarsRover.Grids;
using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public class NorthDirection : IDirection
    {
        private IGrid _grid;

        public CardinalDirection CardinalDirection => CardinalDirection.North;

        public NorthDirection(IGrid grid)
        {
            _grid = grid;
        }

        public void MoveBackward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesSouth(rover.Coordinates);
            rover.MoveTo(newCoordinates);
        }

        public void MoveForward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesNorth(rover.Coordinates);
            rover.MoveTo(newCoordinates);
        }

        public void TurnLeft(Rover rover)
        {
            rover.Direction = DirectionFactory.GetDirection(CardinalDirection.GetDirectionToTheLeft(), _grid);
        }

        public void TurnRight(Rover rover)
        {
            rover.Direction = DirectionFactory.GetDirection(CardinalDirection.GetDirectionToTheRight(), _grid);
        }
    }
}
