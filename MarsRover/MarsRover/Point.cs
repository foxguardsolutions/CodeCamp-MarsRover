using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Point
    {
        public int[] Coordinates { get; set; }

        public Point(int x, int y)
        {
            Coordinates = new int[] { x, y };
        }
    }
}
