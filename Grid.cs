namespace MarsRover
{
    public class Grid
    {
        private GridCell[,] grid;

        public enum Direction
        {
            NORTH = 0, EAST = 90, SOUTH = 180, WEST = 270
        }

        public Grid(int width, int height)
        {
            grid = new GridCell[width, height];

            for (int w = 0; w < grid.GetLength(0); w++)
            {
                for (int h = 0; h < grid.GetLength(1); h++)
                {
                    grid[w, h] = new GridCell(w, h);
                }
            }
        }

        public GridCell GridCellAt(int x, int y)
        {
            int modX = ((x % grid.GetLength(0)) + grid.GetLength(0)) % grid.GetLength(0);
            int modY = ((y % grid.GetLength(1)) + grid.GetLength(1)) % grid.GetLength(1);

            return grid[modX, modY];
        }
    }
}
