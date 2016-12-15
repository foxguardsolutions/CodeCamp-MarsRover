using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position
    {
        public int[] Coordinates { get; set; }

        public CardinalDirection Orientation { get; set; }

        public Position(int x, int y, CardinalDirection directionFacing)
        {
            Coordinates = new int[] { x, y };
            Orientation = directionFacing;
        }
    }
}
