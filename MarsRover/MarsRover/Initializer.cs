using System;
using System.Collections.Generic;
using static MarsRover.CardinalDirection;

namespace MarsRover
{
    public class Initializer
    {
        private const string INVALIDPLACEMENT = "Placement point not on grid: {0}, {1}";

        public Rover PlaceRover(int x, int y, string startingDirection, Grid referenceGrid)
        {
            ValidatePlacement(x, y, referenceGrid);

            var startingOrientation = (CardinalDirection)Enum.Parse(typeof(CardinalDirection), startingDirection, true);

            return new Rover(x, y, startingOrientation, referenceGrid);
        }

        private void ValidatePlacement(int x, int y, Grid referenceGrid)
        {
            if (!referenceGrid.ContainsPoint(x, y))
            {
                ReportInvalidPlacement(x, y);
            }
        }

        private void ReportInvalidPlacement(int x, int y)
        {
            var message = string.Format(INVALIDPLACEMENT, x, y);
            throw new ArgumentException(message);
        }
    }
}
