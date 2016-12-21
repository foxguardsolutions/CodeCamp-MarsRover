using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        // public Position Location { get; set; }
        private List<Position> _path;

        public Rover(int x, int y)
        {
            _path = new List<Position>();
            var startPosition = new Position(x, y);
            _path.Add(startPosition);
        }

        public int[] GetLocation()
        {
            return _path[_path.Count - 1].Coordinates;
        }
    }
}
