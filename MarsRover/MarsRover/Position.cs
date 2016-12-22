using System;

namespace MarsRover
{
    public class Position
    {
        public int[] Coordinates { get; set; }
        private Grid _grid;

        public Position(int x, int y, Grid grid)
        {
            grid.ValidatePoint(x, y);
            Coordinates = new int[] { x, y };
            _grid = grid;
        }

        public Position Clone()
        {
            return new Position(Coordinates[0], Coordinates[1], _grid);
        }

        public void IncrementCoordinate(int index)
        {
            var maxCoordinate = _grid.MaxCoordinate(index);
            if (Coordinates[index] == maxCoordinate)
                Coordinates[index] = 0;
            else
                Coordinates[index]++;
        }

        public void DecrementCoordinate(int index)
        {
            var maxCoordinate = _grid.MaxCoordinate(index);
            if (Coordinates[index] == 0)
                Coordinates[index] = maxCoordinate;
            else
                Coordinates[index]--;
        }
    }
}
