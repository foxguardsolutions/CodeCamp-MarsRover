using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private IOrientation _state;
        private List<Position> _path;
        private bool _isObstructed;

        public Rover(int x, int y, IOrientation startingOrientation, Grid referenceGrid)
        {
            SetOrientation(startingOrientation);
            InitializePath(x, y, referenceGrid);
        }

        public void SetOrientation(IOrientation newOrientation)
        {
            _state = newOrientation;
        }

        private void InitializePath(int x, int y, Grid referenceGrid)
        {
            _path = new List<Position>();
            var startPosition = new Position(x, y, referenceGrid);
            _path.Add(startPosition);
        }

        public void Rotate(bool isTurningCounterclockwise)
        {
            _state.Rotate(this, isTurningCounterclockwise);
        }

        public void Move(bool isMovingForward)
        {
            var lastPosition = GetLocation();
            var nextPosition = Translate(lastPosition, isMovingForward);
            var canMove = nextPosition.IsClearOfObstacles();
            if (canMove)
                _path.Add(nextPosition);
            else
                _isObstructed = true;
        }

        private Position Translate(Position position, bool isMovingForward)
        {
            return _state.Translate(position, isMovingForward);
        }

        public Position GetLocation()
        {
            return _path[_path.Count - 1];
        }

        public Position GetStartingLocation()
        {
            return _path[0];
        }

        public Type GetOrientation()
        {
            return _state.GetType();
        }

        public bool IsObstructed()
        {
            return _isObstructed;
        }
    }
}
