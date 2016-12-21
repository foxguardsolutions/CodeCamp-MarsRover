using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        private const ushort DEFAULTSIZE = 1000;
        private ushort _xSize;
        private ushort _ySize;
        private List<int[]> _obstacles;

        public Grid()
            : this(DEFAULTSIZE, DEFAULTSIZE)
        {
        }

        public Grid(ushort xSize, ushort ySize)
        {
            _xSize = ValidateSize(xSize);
            _ySize = ValidateSize(ySize);
            _obstacles = new List<int[]>();
        }

        public ushort[] Size()
        {
            return new ushort[] { _xSize, _ySize };
        }

        private ushort ValidateSize(ushort input)
        {
            if (input < 1)
                return DEFAULTSIZE;
            return input;
        }

        public void AddObstacle(int x, int y)
        {
            if (ContainsPoint(x, y))
                _obstacles.Add(new int[] { x, y });
        }

        internal bool ContainsPoint(int x, int y)
        {
            return (x >= 0) && (x < _xSize) && (y >= 0) && (y < _ySize);
        }

        public bool IsClearOfObstacles(int x, int y)
        {
            return !HasObstacle(x, y);
        }

        private bool HasObstacle(int x, int y)
        {
            var checkLocation = new int[] { x, y };
            return _obstacles.Any(obstacle => Enumerable.SequenceEqual(obstacle, checkLocation));
        }
    }
}
