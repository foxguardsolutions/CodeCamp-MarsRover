using System;
using System.Linq;

namespace MarsRover
{
    public class Rotate : Action
    {
        public Rotate(bool isTurningCounterclockwise)
            : base(isTurningCounterclockwise)
        {
        }

        public override Position Act(Position lastPosition)
        {
            var nextOrientation = AdjustOrientation(lastPosition);
            return new Position(lastPosition.Coordinates[0], lastPosition.Coordinates[1], nextOrientation, lastPosition.ReferenceGrid);
        }

        private CardinalDirection AdjustOrientation(Position lastPosition)
        {
            var adjustmentValue = GetAdjustmentValue(HasPositiveDirectionOfMovement);
            var directionCount = Enum.GetNames(typeof(CardinalDirection)).Count();
            var nextOrientation = AdjustModulo((int)lastPosition.Orientation, adjustmentValue, directionCount);
            return (CardinalDirection)nextOrientation;
        }
    }
}
