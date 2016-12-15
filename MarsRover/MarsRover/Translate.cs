namespace MarsRover
{
    public class Translate : IAct
    {
        private bool _isMovingForward;

        public Translate(bool isMovingForward)
        {
            _isMovingForward = isMovingForward;
        }

        public Position Act(Position lastPosition)
        {
            var nextCoordinates = AdjustCoordinates(lastPosition);
            return new Position(nextCoordinates[0], nextCoordinates[1], lastPosition.Orientation);
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
            return (int)orientation % 2;
        }

        private int GetAdjustmentValue(CardinalDirection orientation)
        {
            if (IsMovingInNegativeDirection(orientation))
                return -1;
            return 1;
        }

        private bool IsMovingInNegativeDirection(CardinalDirection orientation)
        {
            var isFacingNorthOrEast = (int)orientation / 2 == 0;
            return isFacingNorthOrEast ^ _isMovingForward;
        }
    }
}
