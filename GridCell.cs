namespace MarsRover
{
    public class GridCell
    {
        public bool ContainsObstacle { get; set; }
        public int X { get; }
        public int Y { get; }

        public GridCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
