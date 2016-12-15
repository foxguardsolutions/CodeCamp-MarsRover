using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public Point Location { get; set; }

        public Rover(int x, int y)
        {
            Location = new Point(x, y);
        }
    }
}
