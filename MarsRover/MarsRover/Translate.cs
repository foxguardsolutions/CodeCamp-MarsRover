namespace MarsRover
{
    public class Translate : Action
    {
        public Translate(bool isMovingForward)
            : base(isMovingForward)
        {
        }

        public override Position Act(Position lastPosition)
        {
            var nextCoordinates = AdjustCoordinates(lastPosition);
            return new Position(nextCoordinates[0], nextCoordinates[1], lastPosition.Orientation, lastPosition.ReferenceGrid);
        }

        private int[] AdjustCoordinates(Position lastPosition)
        {
            var adjustmentValue = GetAdjustmentValue(IncreasesCoordinateValue(lastPosition.Orientation));
            var axisOfMovement = GetAxisOfMovement(lastPosition.Orientation);
            var relevantGridDimension = lastPosition.ReferenceGrid.Size()[axisOfMovement];
            var nextCoordinates = (int[])lastPosition.Coordinates.Clone();
            nextCoordinates[axisOfMovement] = AdjustModulo(nextCoordinates[axisOfMovement], adjustmentValue, relevantGridDimension);
            return nextCoordinates;
        }

        private int GetAxisOfMovement(CardinalDirection orientation)
        {
            return (int)orientation % 2;
        }

        private bool IncreasesCoordinateValue(CardinalDirection orientation)
        {
            var isFacingNorthOrEast = (int)orientation / 2 == 0;
            return !(isFacingNorthOrEast ^ HasPositiveDirectionOfMovement);
        }
    }
}
