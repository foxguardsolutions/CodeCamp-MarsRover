namespace MarsRover
{
    public class NorthFacingRover : RoverBase
    {
        public NorthFacingRover(int x = 0, int y = 0) : base(x, y)
        {
        }

        public override IRover Forward()
        {
            return new NorthFacingRover(X, Y - 1);
        }

        public override IRover Backward()
        {
            return new NorthFacingRover(X, Y + 1);
        }

        public override IRover Left()
        {
            return new WestFacingRover(X, Y);
        }

        public override IRover Right()
        {
            return new EastFacingRover(X, Y);
        }
    }
}
