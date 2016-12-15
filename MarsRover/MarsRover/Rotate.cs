using System;
using System.Linq;

namespace MarsRover
{
    public class Rotate : IAct
    {
        private bool _isTurningClockwise;

        public Rotate(bool isTurningClockwise)
        {
            _isTurningClockwise = isTurningClockwise;
        }

        public Position Act(Position lastPosition)
        {
            var nextOrientation = AdjustOrientation(lastPosition);
            return new Position(lastPosition.Coordinates[0], lastPosition.Coordinates[1], nextOrientation);
        }

        private CardinalDirection AdjustOrientation(Position lastPosition)
        {
            var directionCount = Enum.GetNames(typeof(CardinalDirection)).Count();
            var adjustmentValue = GetAdjustmentValue() + directionCount;
            return (CardinalDirection)((int)(lastPosition.Orientation + adjustmentValue) % directionCount);
        }

        private int GetAdjustmentValue()
        {
            if (_isTurningClockwise)
                return 1;
            return -1;
        }
    }
}
