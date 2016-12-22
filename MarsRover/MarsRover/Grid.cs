using System;

namespace MarsRover
{
    public class Grid
    {
        private const ushort DEFAULTSIZE = 1000;
        private const string INVALIDPOINT = "Point not on grid: {0}, {1}";
        private ushort _xSize;
        private ushort _ySize;

        public Grid()
            : this(DEFAULTSIZE, DEFAULTSIZE)
        {
        }

        public Grid(ushort xSize, ushort ySize)
        {
            _xSize = (xSize == 0) ? DEFAULTSIZE : xSize;
            _ySize = (ySize == 0) ? DEFAULTSIZE : ySize;
        }

        public ushort MaxCoordinate(int index)
        {
            var sizes = new ushort[] { _xSize, _ySize };
            return (ushort)(sizes[index] - 1);
        }

        internal void ValidatePoint(int x, int y)
        {
            if (!ContainsPoint(x, y))
            {
                var message = string.Format(INVALIDPOINT, x, y);
                throw new ArgumentException(message);
            }
        }

        internal bool ContainsPoint(int x, int y)
        {
            return (x >= 0) && (x < _xSize) && (y >= 0) && (y < _ySize);
        }
    }
}
