using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Map
    {
        public int MapWidth
        {
            get; set;
        }

        public int MapHeight
        {
            get; set;
        }

        public List<int[]> Obstacles
        {
            get; set;
        }

        public Map(int width = 10, int height = 10)
        {
            MapWidth = width;
            MapHeight = height;
        }

        public bool CanMoveTo(int x, int y)
        {
            return !Obstacles.Any(p => p[0] == x && p[1] == y);
        }

        public int ConvertXCoordinate(int x)
        {
            return (x >= MapWidth) ? x % MapWidth : (x < 0) ? MapWidth + x : x;
        }

        public int ConvertYCoordinate(int y)
        {
            return (y >= MapHeight) ? y % MapHeight : (y < 0) ? MapHeight + y : y;
        }
    }
}
