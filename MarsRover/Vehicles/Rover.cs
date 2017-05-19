using MarsRover.Directions;
using MarsRover.Grids;
using System.Linq;

namespace MarsRover.Vehicles
{
    public class Rover
    {
        internal const string OBSTACLE_STATUS_FORMAT = "Obstacle encountered at {0}";
        internal const string STANDARD_STATUS_FORMAT = "Rover is currently at {0}";

        public Coordinates Coordinates { get; private set; }
        public Coordinates? ObstacleEncountered { get; private set; }
        public IDirection Direction { get; set; }

        private Plane _plane;

        public Rover(Coordinates coordiantes, Plane plane, CardinalDirection cardinalDirection)
        {
            Coordinates = coordiantes;
            Direction = DirectionFactory.GetDirection(cardinalDirection, plane.Grid);
            _plane = plane;
        }

        public string GetStatus()
        {
            if (ObstacleEncountered != null)
                return string.Format(OBSTACLE_STATUS_FORMAT, ObstacleEncountered);
            else
                return string.Format(STANDARD_STATUS_FORMAT, Coordinates);
        }

        public void MoveBackward() => Direction.MoveBackward(this);

        public void MoveForward() => Direction.MoveForward(this);

        public void MoveTo(Coordinates coordinates)
        {
            if (CheckForObstacle(coordinates))
                SetCoordinatesForObstacleFound(coordinates);
            else
                Coordinates = coordinates;
        }

        public void TurnLeft() => Direction.TurnLeft(this);
        
        public void TurnRight() => Direction.TurnRight(this);

        private bool CheckForObstacle(Coordinates coordinates)
        {
            return _plane.Obstacles.Any(o => o.Equals(coordinates));
        }

        private void SetCoordinatesForObstacleFound(Coordinates coordinates)
        {
            ObstacleEncountered = coordinates;
        }
    }
}
