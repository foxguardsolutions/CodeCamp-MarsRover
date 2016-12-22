using System;

namespace MarsRover
{
    public class Grid
    {
        private const ushort DEFAULTSIZE = 1000;
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

        public ushort[] Size()
        {
            return new ushort[] { _xSize, _ySize };
        }
    }
}
