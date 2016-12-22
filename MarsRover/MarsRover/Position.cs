using System;

namespace MarsRover
{
    public class Position
    {
        public int[] Coordinates { get; set; }
        private Grid _grid;

        public Position(int x, int y, Grid grid)
        {
            Coordinates = new int[] { x, y };
            _grid = grid;
        }

        public Position Clone()
        {
            return new Position(Coordinates[0], Coordinates[1], _grid);
        }
    }
}
