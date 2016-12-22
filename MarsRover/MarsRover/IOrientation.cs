namespace MarsRover
{
    public interface IOrientation
    {
        Position Translate(Position position);
        void Rotate(Rover rover);
    }
}