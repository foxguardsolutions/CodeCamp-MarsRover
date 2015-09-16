using System.Collections.Generic;

namespace MarsRover
{
    public class EastFacingRover : RoverBase
    {
        public EastFacingRover(int x = 0, int y = 0) : base(x, y)
        {
            MyActions = new Dictionary<Movements, DoAction>()
            {
                { Movements.FORWARD, new DoAction(Forward) },
                { Movements.BACKWARD, new DoAction(Backward) },
                { Movements.LEFT, new DoAction(Left) },
                { Movements.RIGHT, new DoAction(Right) },
            };
        }

        public new IRover Forward()
        {
            return new EastFacingRover(X + 1, Y);
        }

        public new IRover Backward()
        {
            return new EastFacingRover(X - 1, Y);
        }

        public new IRover Left()
        {
            return new NorthFacingRover(X, Y);
        }

        public new IRover Right()
        {
            return new SouthFacingRover(X, Y);
        }
    }
}