using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class RoverBase : IRover
    {
        public Dictionary<Movements, DoAction> MyActions
        {
            get; set;
        }

        public int X
        {
            get; set;
        }

        public int Y
        {
            get; set;
        }

        public RoverBase(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public IRover Backward()
        {
            throw new NotImplementedException();
        }

        public IRover Forward()
        {
            throw new NotImplementedException();
        }

        public IRover Left()
        {
            throw new NotImplementedException();
        }

        public IRover Move(char action)
        {
            return MyActions[(Movements)action]();
        }

        public IRover Right()
        {
            throw new NotImplementedException();
        }
    }
}
