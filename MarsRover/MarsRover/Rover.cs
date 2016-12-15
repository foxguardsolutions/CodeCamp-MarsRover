using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        private List<Position> _path;

        public Rover(int x, int y, CardinalDirection directionFacing)
        {
            var startingPosition = new Position(x, y, directionFacing);
            _path = new List<Position>() { startingPosition };
        }

        public int[] GetLocation()
        {
            var lastPosition = GetLastPosition();
            return lastPosition.Coordinates;
        }

        public CardinalDirection GetOrientation()
        {
            var lastPosition = GetLastPosition();
            return lastPosition.Orientation;
        }

        public void Move()
        {
            var lastPosition = GetLastPosition();
            var nextCoordinates = AdjustCoordinates(lastPosition);
            var nextPosition = new Position(nextCoordinates[0], nextCoordinates[1], lastPosition.Orientation);
            _path.Add(nextPosition);
        }

        private Position GetLastPosition()
        {
            return _path[_path.Count - 1];
        }

        private int[] AdjustCoordinates(Position lastPosition)
        {
            var nextCoordinates = lastPosition.Coordinates;
            var axisOfMovement = GetAxisOfMovement(lastPosition.Orientation);
            var adjustmentValue = GetAdjustmentValue(lastPosition.Orientation);
            nextCoordinates[axisOfMovement] += adjustmentValue;
            return nextCoordinates;
        }

        private int GetAxisOfMovement(CardinalDirection orientation)
        {
            return (int)orientation / 2;
        }

        private int GetAdjustmentValue(CardinalDirection orientation)
        {
            var movingInPositiveDirection = (int)orientation % 2 == 0;
            if (movingInPositiveDirection)
            {
                return 1;
            }

            return -1;
        }
    }
}
