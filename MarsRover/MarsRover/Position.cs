using System;

namespace MarsRover
{
    public class Position
    {
        public int[] Coordinates { get; set; }
        public CardinalDirection Orientation { get; set; }
        public Grid ReferenceGrid { get; set; }

        public Position(int x, int y, CardinalDirection directionFacing, Grid referenceGrid)
        {
            Coordinates = new int[] { x, y };
            Orientation = directionFacing;
            ReferenceGrid = referenceGrid;
        }
    }
}
