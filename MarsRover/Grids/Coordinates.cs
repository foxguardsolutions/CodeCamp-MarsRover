namespace MarsRover.Grids
{
    public struct Coordinates
    {
        public uint X { get; private set; }
        public uint Y { get; private set; }

        public Coordinates(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}, {Y})";
    }
}
