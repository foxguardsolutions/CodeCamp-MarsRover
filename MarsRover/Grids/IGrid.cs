namespace MarsRover.Grids
{
    public interface IGrid
    {
        Boundaries Boundaries { get; }

        Coordinates GetNextCoordinatesEast(Coordinates coordinates);
        Coordinates GetNextCoordinatesNorth(Coordinates coordinates);
        Coordinates GetNextCoordinatesSouth(Coordinates coordinates);
        Coordinates GetNextCoordinatesWest(Coordinates coordinates);
    }
}
