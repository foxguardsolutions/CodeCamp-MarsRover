namespace MarsRover
{
    public class WestFacingRover : RoverBase
    {
        public WestFacingRover(int x = 0, int y = 0) : base(x, y)
        {
        }

        public override IRover Forward()
        {
            return new WestFacingRover(X - 1, Y);
        }

        public override IRover Backward()
        {
            return new WestFacingRover(X + 1, Y);
        }

        public override IRover Left()
        {
            return new SouthFacingRover(X, Y);
        }

        public override IRover Right()
        {
            return new NorthFacingRover(X, Y);
        }
    }
}