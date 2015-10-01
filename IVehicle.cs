namespace MarsRover
{
    public interface IVehicle
    {
        Grid World { get; set; }
        GridCell CurrentLocation { get; set; }
        char Orientation { get; set; }

        bool Move(char movement);
    }
}
