using System;
using System.Collections.Generic;

namespace MarsRover
{
    public enum Movements
    {
        FORWARD = 'F',
        BACKWARD = 'B',
        LEFT = 'L',
        RIGHT = 'R',
    }

    public interface IRover
    {
        int X { get; set; }

        int Y { get; set; }

        Dictionary<Movements, Func<IRover>> MyActions { get; set; }

        IRover Backward();
        IRover Forward();
        IRover Left();
        IRover Move(char action);
        IRover Right();
    }
}
