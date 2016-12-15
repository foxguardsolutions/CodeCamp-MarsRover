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

        public void Move(bool isMovingForward)
        {
            var lastPosition = GetLastPosition();
            var nextCoordinates = AdjustCoordinates(lastPosition, isMovingForward);
            var nextPosition = new Position(nextCoordinates[0], nextCoordinates[1], lastPosition.Orientation);
            _path.Add(nextPosition);
        }

        private Position GetLastPosition()
        {
            return _path[_path.Count - 1];
        }

        private int[] AdjustCoordinates(Position lastPosition, bool isMovingForward)
        {
            var nextCoordinates = lastPosition.Coordinates;
            var axisOfMovement = GetAxisOfMovement(lastPosition.Orientation);
            var adjustmentValue = GetAdjustmentValue(lastPosition.Orientation, isMovingForward);
            nextCoordinates[axisOfMovement] += adjustmentValue;
            return nextCoordinates;
        }

        private int GetAxisOfMovement(CardinalDirection orientation)
        {
            return (int)orientation / 2;
        }

        private int GetAdjustmentValue(CardinalDirection orientation, bool isMovingForward)
        {
            if (IsMovingInNegativeDirection(orientation, isMovingForward))
            {
                return -1;
            }

            return 1;
        }

        private static bool IsMovingInNegativeDirection(CardinalDirection orientation, bool isMovingForward)
        {
            var isFacingNorthOrEast = (int)orientation % 2 == 0;
            return isFacingNorthOrEast ^ isMovingForward;
        }
    }
}
