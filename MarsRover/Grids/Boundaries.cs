namespace MarsRover.Grids
{
    public class Boundaries
    {
        public Coordinates LowerBound { get; private set; }
        public Coordinates UpperBound { get; private set; }

        public Boundaries(uint width, uint height)
        {
            LowerBound = new Coordinates(0, 0);
            UpperBound = new Coordinates(width, height);
        }
    }
}
