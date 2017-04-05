namespace MarsRover.Grids
{
    public class StandardGrid : IGrid
    {
        public Coordinates GetNextCoordinatesEast(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X + 1, coordinates.Y);
        }

        public Coordinates GetNextCoordinatesNorth(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X, coordinates.Y + 1);
        }

        public Coordinates GetNextCoordinatesSouth(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X, coordinates.Y - 1);
        }

        public Coordinates GetNextCoordinatesWest(Coordinates coordinates)
        {
            return new Coordinates(coordinates.X - 1, coordinates.Y);
        }
    }
}
