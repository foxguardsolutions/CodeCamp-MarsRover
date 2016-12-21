using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private List<Position> _path;

        public Rover(int x, int y)
        {
            _path = new List<Position>();
            var startPosition = new Position(x, y);
            _path.Add(startPosition);
        }

        public Position GetLocation()
        {
            return _path[_path.Count - 1];
        }

        public Position GetStartingLocation()
        {
            return _path[0];
        }

        public void Move()
        {
            var lastPosition = GetLocation();
            var nextPosition = Translate(lastPosition);
            _path.Add(nextPosition);
        }

        private Position Translate(Position position)
        {
            var nextPosition = position.Clone();
            nextPosition.Coordinates[1]++;
            return nextPosition;
        }
    }
}
