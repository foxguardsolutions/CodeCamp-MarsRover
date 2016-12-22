using System;

namespace MarsRover
{
    public class Initializer
    {
        public Rover PlaceRover(int x, int y, char initialDirection, Grid grid)
        {
            var startingOrientation = new FacingNorth();
            return new Rover(x, y, startingOrientation, grid);
        }
    }
}
