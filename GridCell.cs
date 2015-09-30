namespace MarsRover
{
    public class GridCell
    {
        public bool ContainsObstacle { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public GridCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
