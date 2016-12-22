using System;

namespace MarsRover
{
    public class Initializer
    {
        private const string INVALIDDIRECTION = "Could not parse direction from \"{0}\".";

        public Rover PlaceRover(int x, int y, char inputDirection, Grid grid)
        {
            var startingOrientation = ParseDirection(inputDirection);
            return new Rover(x, y, startingOrientation, grid);
        }

        private IOrientation ParseDirection(char candidate)
        {
            if (candidate == 'E')
                return new FacingEast();
            else if (candidate == 'N')
                return new FacingNorth();
            else if (candidate == 'W')
                return new FacingWest();
            else if (candidate == 'S')
                return new FacingSouth();

            return ReportInvalidDirection(candidate);
        }

        private IOrientation ReportInvalidDirection(char candidate)
        {
            var message = string.Format(INVALIDDIRECTION, candidate);
            throw new ArgumentException(message);
        }
    }
}
