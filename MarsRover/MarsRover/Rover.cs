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
            var lastPosition = _path[_path.Count - 1];
            return lastPosition.Coordinates;
        }

        public CardinalDirection GetOrientation()
        {
            var lastPosition = _path[_path.Count - 1];
            return lastPosition.Orientation;
        }
    }
}
