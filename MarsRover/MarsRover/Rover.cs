using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        private List<Position> _path;

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
            var nextCoordinates = GetLastPosition().Coordinates;
            nextCoordinates[0]++;
            var nextPosition = new Position(nextCoordinates[0], nextCoordinates[1], CardinalDirection.North);
            _path.Add(nextPosition);
        }

        private Position GetLastPosition()
        {
            return _path[_path.Count - 1];
        }
    }
}
