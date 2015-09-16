using System.Collections.Generic;

namespace MarsRover
{
    public delegate IRover DoAction();

    public enum Movements
    {
        FORWARD = 'F',
        BACKWARD = 'B',
        LEFT = 'L',
        RIGHT = 'R',
    }

    public interface IRover
    {
        int X
        {
            get; set;
        }

        int Y
        {
            get; set;
        }

        Dictionary<Movements, DoAction> MyActions
        {
            get; set;
        }

        IRover Backward();
        IRover Forward();
        IRover Left();
        IRover Move(char action);
        IRover Right();
    }
}
