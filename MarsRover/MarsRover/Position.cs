using System;

namespace MarsRover
{
    public class Position
    {
        public int[] Coordinates { get; set; }

        public Position(int x, int y)
        {
            Coordinates = new int[] { x, y };
        }

        public Position Clone()
        {
            return new Position(Coordinates[0], Coordinates[1]);
        }
    }
}
