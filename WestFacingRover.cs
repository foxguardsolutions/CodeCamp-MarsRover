using System.Collections.Generic;

namespace MarsRover
{
    public class WestFacingRover : RoverBase
    {
        public WestFacingRover(int x = 0, int y = 0) : base(x, y)
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
            return new WestFacingRover(X - 1, Y);
        }

        public new IRover Backward()
        {
            return new WestFacingRover(X + 1, Y);
        }

        public new IRover Left()
        {
            return new SouthFacingRover(X, Y);
        }

        public new IRover Right()
        {
            return new NorthFacingRover(X, Y);
        }
    }
}