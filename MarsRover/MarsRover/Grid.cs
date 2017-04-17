using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        public const ushort DEFAULTSIZE = 1000;
        private ushort _xSize;
        private ushort _ySize;
        private List<Point> _obstacles;
        private IConsoleWriter _consoleWriter;

        public Grid(IConsoleWriter consoleWriter)
            : this(DEFAULTSIZE, DEFAULTSIZE, consoleWriter)
        {
        }

        public Grid(ushort xSize, ushort ySize, IConsoleWriter consoleWriter)
        {
            _xSize = (xSize == 0) ? DEFAULTSIZE : xSize;
            _ySize = (ySize == 0) ? DEFAULTSIZE : ySize;
            _obstacles = new List<Point>();
            _consoleWriter = consoleWriter;
        }

        public void AddObstacle(Point obstacleLocation)
        {
            var isValid = ValidatePoint(obstacleLocation);
            if (isValid)
                _obstacles.Add(obstacleLocation);
        }

        private bool ContainsPoint(Point point)
        {
            var x = point.X;
            var y = point.Y;
            return (x >= 0) && (x < _xSize) && (y >= 0) && (y < _ySize);
        }

        public bool HasObstacleAt(Point inspectionLocation)
        {
            return _obstacles.Any(obstacleLocation => obstacleLocation.Equals(inspectionLocation));
        }

        public ushort MaxCoordinate(int index)
        {
            var sizes = new[] { _xSize, _ySize };
            return (ushort)(sizes[index] - 1);
        }

        public bool ValidatePoint(Point point)
        {
            if (ContainsPoint(point))
                return true;

            _consoleWriter.WriteLine($"Point not on grid: {point}");
            return false;
        }
    }
}
