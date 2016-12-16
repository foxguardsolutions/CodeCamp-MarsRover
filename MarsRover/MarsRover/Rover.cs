using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private List<Position> _path;
        private IAct _strategy;

        public Rover(int x, int y, CardinalDirection directionFacing)
        {
            var startingPosition = new Position(x, y, directionFacing);
            _path = new List<Position>() { startingPosition };
        }

        public int[] GetLocation()
        {
            var lastPosition = GetLastPosition();
            return lastPosition.Coordinates;
        }

        public CardinalDirection GetOrientation()
        {
            var lastPosition = GetLastPosition();
            return lastPosition.Orientation;
        }

        public void Move()
        {
            var lastPosition = GetLastPosition();
            var nextPosition = Act(lastPosition);
            _path.Add(nextPosition);
        }

        private Position GetLastPosition()
        {
            return _path[_path.Count - 1];
        }

        private Position Act(Position lastPosition)
        {
            return _strategy.Act(lastPosition);
        }

        public void SetAction(IAct strategy)
        {
            _strategy = strategy;
        }
    }
}
