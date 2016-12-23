using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private IMovementFrameOfReference _movement;
        private List<Position> _path;
        private bool _isObstructed;
        private IConsoleWriter _consoleWriter;

        public Rover(Point coordinates, IMovementFrameOfReference startingFrameOfReference, Grid referenceGrid, IConsoleWriter consoleWriter)
        {
            SetFrameOfReference(startingFrameOfReference);
            InitializePath(coordinates, referenceGrid);
            _consoleWriter = consoleWriter;
        }

        public void SetFrameOfReference(IMovementFrameOfReference newMovementFrameOfReference)
        {
            _movement = newMovementFrameOfReference;
        }

        private void InitializePath(Point coordinates, Grid referenceGrid)
        {
            _path = new List<Position>();
            var startPosition = new Position(coordinates, referenceGrid);
            _path.Add(startPosition);
        }

        public void RotateCounterclockwise()
        {
            _movement.RotateCounterclockwise(this);
        }

        public void RotateClockwise()
        {
            _movement.RotateClockwise(this);
        }

        public IMovementFrameOfReference GetMovementFrameOfReference()
        {
            return _movement;
        }

        public void MoveForward()
        {
            var lastPosition = GetLocation();
            var nextPosition = _movement.MoveForward(lastPosition);
            MoveTo(nextPosition);
        }

        public void MoveBackward()
        {
            var lastPosition = GetLocation();
            var nextPosition = _movement.MoveBackward(lastPosition);
            MoveTo(nextPosition);
        }

        private void MoveTo(Position position)
        {
            var canMove = position.IsClearOfObstacles();
            if (canMove)
            {
                _path.Add(position);
            }
            else
            {
                _isObstructed = true;
                new ObstacleReport(position, _consoleWriter);
            }
        }

        public Point GetCoordinates()
        {
            return GetLocation().GetCoordinates();
        }

        private Position GetLocation()
        {
            return _path[_path.Count - 1];
        }

        public bool IsObstructed()
        {
            return _isObstructed;
        }
    }
}
