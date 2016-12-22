namespace MarsRover
{
    public class FacingWest : IOrientation
    {
        public Position Translate(Position position)
        {
            var nextPosition = position.Clone();
            nextPosition.Coordinates[0]--;
            return nextPosition;
        }

        public void Rotate(Rover context)
        {
            context.SetOrientation(new FacingSouth());
        }
    }
}
