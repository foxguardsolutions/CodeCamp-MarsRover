namespace MarsRover
{
    public enum Movement
    {
        FORWARD = 'F', BACKWARD = 'B', LEFT = 'L', RIGHT = 'R'
    }

    public interface IVehicle
    {
        Grid World { get; set; }
        GridCell CurrentLocation { get; set; }
        Grid.Direction Orientation { get; set; }

        bool Move(Movement movement);
    }
}
