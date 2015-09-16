using System.Collections.Generic;

namespace MarsRover
{
    public class SouthFacingRover : RoverBase
    {
        public SouthFacingRover(int x = 0, int y = 0) : base(x, y)
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
            return new SouthFacingRover(X, Y + 1);
        }

        public new IRover Backward()
        {
            return new SouthFacingRover(X, Y - 1);
        }

        public new IRover Left()
        {
            return new EastFacingRover(X, Y);
        }

        public new IRover Right()
        {
            return new WestFacingRover(X, Y);
        }
    }
}