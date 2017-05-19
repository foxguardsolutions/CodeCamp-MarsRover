using MarsRover.Grids;

namespace MarsRover.Directions
{
    public static class DirectionFactory
    {
        public static IDirection GetDirection(CardinalDirection cardinalDirection, IGrid grid)
        {
            switch (cardinalDirection)
            {
                case CardinalDirection.East:
                    return new EastDirection(grid);
                case CardinalDirection.South:
                    return new SouthDirection(grid);
                case CardinalDirection.West:
                    return new WestDirection(grid);
                default:
                    return new NorthDirection(grid);
            }
        }
    }
}
