namespace MarsRover.Grids
{
    public class PlanetaryGrid : IGrid
    {
        public Boundaries Boundaries { get; private set; }

        public PlanetaryGrid(Boundaries boundaries)
        {
            Boundaries = boundaries;
        }

        public Coordinates GetNextCoordinatesEast(Coordinates coordinates)
        {
            var coordinatesInBounds = GetCoordinatesInBounds(coordinates);
            var nextX = coordinatesInBounds.X == Boundaries.UpperBound.X ?
                        Boundaries.LowerBound.X :
                        coordinatesInBounds.X + 1;
            return new Coordinates(nextX, coordinatesInBounds.Y);
        }

        public Coordinates GetNextCoordinatesNorth(Coordinates coordinates)
        {
            var coordinatesInBounds = GetCoordinatesInBounds(coordinates);
            var nextY = coordinatesInBounds.Y == Boundaries.UpperBound.Y ?
                        Boundaries.LowerBound.Y :
                        coordinatesInBounds.Y + 1;
            return new Coordinates(coordinatesInBounds.X, nextY);
        }

        public Coordinates GetNextCoordinatesSouth(Coordinates coordinates)
        {
            var coordinatesInBounds = GetCoordinatesInBounds(coordinates);
            var nextY = coordinatesInBounds.Y == Boundaries.LowerBound.Y ?
                        Boundaries.UpperBound.Y :
                        coordinatesInBounds.Y - 1;
            return new Coordinates(coordinatesInBounds.X, nextY);
        }

        public Coordinates GetNextCoordinatesWest(Coordinates coordinates)
        {
            var coordinatesInBounds = GetCoordinatesInBounds(coordinates);
            var nextX = coordinatesInBounds.X == Boundaries.LowerBound.X ?
                        Boundaries.UpperBound.X :
                        coordinatesInBounds.X - 1;
            return new Coordinates(nextX, coordinatesInBounds.Y);
        }
        
        private Coordinates GetCoordinatesInBounds(Coordinates coordinates)
        {
            if (AreCoordinatesInBounds(coordinates.X, coordinates.Y))
                return coordinates;

            var xInBounds = PositionCalculator.WrapPositionIntoBounds(
                coordinates.X, Boundaries.LowerBound.X, Boundaries.UpperBound.X);
            var yInBounds = PositionCalculator.WrapPositionIntoBounds(
                coordinates.Y, Boundaries.LowerBound.Y, Boundaries.UpperBound.Y);

            return new Coordinates(xInBounds, yInBounds);
        }

        private bool AreCoordinatesInBounds(uint x, uint y)
        {
            return x.IsBetween(Boundaries.LowerBound.X, Boundaries.UpperBound.X)
                && y.IsBetween(Boundaries.LowerBound.Y, Boundaries.UpperBound.Y);
        }
    }
}
