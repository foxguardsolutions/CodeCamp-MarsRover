namespace MarsRover
{
    public class SouthFacingRover : RoverBase
    {
        public SouthFacingRover(int x = 0, int y = 0) : base(x, y)
        {
        }

        public override IRover Forward()
        {
            return new SouthFacingRover(X, Y + 1);
        }

        public override IRover Backward()
        {
            return new SouthFacingRover(X, Y - 1);
        }

        public override IRover Left()
        {
            return new EastFacingRover(X, Y);
        }

        public override IRover Right()
        {
            return new WestFacingRover(X, Y);
        }
    }
}