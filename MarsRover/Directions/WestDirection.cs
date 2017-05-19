using MarsRover.Grids;
using MarsRover.Vehicles;

namespace MarsRover.Directions
{
    public class WestDirection : IDirection
    {
        private IGrid _grid;

        public CardinalDirection CardinalDirection => CardinalDirection.West;

        public WestDirection(IGrid grid)
        {
            _grid = grid;
        }

        public void MoveBackward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesEast(rover.Coordinates);
            rover.MoveTo(newCoordinates);
        }

        public void MoveForward(Rover rover)
        {
            var newCoordinates = _grid.GetNextCoordinatesWest(rover.Coordinates);
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
