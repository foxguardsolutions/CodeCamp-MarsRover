namespace MarsRover
{
    public class Position
    {
        public int[] Coordinates { get; set; }

        public Position(int x, int y)
        {
            Coordinates = new int[] { x, y };
        }
    }
}
