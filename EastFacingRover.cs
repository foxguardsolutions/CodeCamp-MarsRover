namespace MarsRover
{
    public class EastFacingRover : RoverBase
    {
        public EastFacingRover(int x = 0, int y = 0) : base(x, y)
        {
        }

        public override IRover Forward()
        {
            return new EastFacingRover(X + 1, Y);
        }

        public override IRover Backward()
        {
            return new EastFacingRover(X - 1, Y);
        }

        public override IRover Left()
        {
            return new NorthFacingRover(X, Y);
        }

        public override IRover Right()
        {
            return new SouthFacingRover(X, Y);
        }
    }
}