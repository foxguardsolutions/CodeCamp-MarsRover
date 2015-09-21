using System;
using System.Collections.Generic;

namespace MarsRover
{
    public abstract class RoverBase : IRover
    {
        public Dictionary<Movements, Func<IRover>> MyActions { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public abstract IRover Backward();
        public abstract IRover Forward();
        public abstract IRover Left();
        public abstract IRover Right();

        public RoverBase(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
            MyActions = new Dictionary<Movements, Func<IRover>>()
            {
                { Movements.FORWARD, Forward },
                { Movements.BACKWARD, Backward },
                { Movements.LEFT, Left },
                { Movements.RIGHT, Right },
            };
        }

        public IRover Move(char action)
        {
            return MyActions[(Movements)action]();
        }
    }
}
