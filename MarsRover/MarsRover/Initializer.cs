using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.CardinalDirection;

namespace MarsRover
{
    public class Initializer
    {
        private const string INVALIDPLACEMENT = "Placement point not on grid: {0}, {1}";
        private static Dictionary<char, CardinalDirection> _validDirections = new Dictionary<char, CardinalDirection>()
        {
            { 'E', East },
            { 'N', North },
            { 'W', West },
            { 'S', South },
        };

        public Rover PlaceRover(int x, int y, char direction, Grid referenceGrid)
        {
            if (!referenceGrid.ContainsPoint(x, y))
            {
                ReportInvalidPlacement(x, y);
            }

            var startingOrientation = _validDirections[direction];

            return new Rover(x, y, startingOrientation, referenceGrid);
        }

        private void ReportInvalidPlacement(int x, int y)
        {
            var message = string.Format(INVALIDPLACEMENT, x, y);
            throw new ArgumentException(message);
        }
    }
}
