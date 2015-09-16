using System.Collections.Generic;

namespace MarsRover
{
    public class NorthFacingRover : RoverBase
    {
        public NorthFacingRover(int x = 0, int y = 0) : base(x, y)
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
            return new NorthFacingRover(X, Y - 1);
        }

        public new IRover Backward()
        {
            return new NorthFacingRover(X, Y + 1);
        }

        public new IRover Left()
        {
            return new WestFacingRover(X, Y);
        }

        public new IRover Right()
        {
            return new EastFacingRover(X, Y);
        }
    }
}
