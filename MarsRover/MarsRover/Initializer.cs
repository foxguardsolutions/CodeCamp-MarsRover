namespace MarsRover
{
    public class Initializer
    {
        public Rover PlaceRover(int x, int y, CardinalDirection inputDirection, Grid grid, IConsoleWriter consoleWriter)
        {
            var startingFrameOfReference = ParseDirection(inputDirection);
            var startingCoordinates = new Point(x, y);
            return new Rover(startingCoordinates, startingFrameOfReference, grid, consoleWriter);
        }

        private static IMovementFrameOfReference ParseDirection(CardinalDirection direction)
        {
            if (direction == CardinalDirection.EAST)
                return new MovementWhenFacingEast();
            if (direction == CardinalDirection.WEST)
                return new MovementWhenFacingWest();
            if (direction == CardinalDirection.SOUTH)
                return new MovementWhenFacingSouth();
            return new MovementWhenFacingNorth();
        }
    }
}
