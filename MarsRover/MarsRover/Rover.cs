using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private IOrientation _state;
        private List<Position> _path;

        public Rover(int x, int y, IOrientation startingOrientation)
        {
            SetOrientation(startingOrientation);
            InitializePath(x, y);
        }

        public void SetOrientation(IOrientation newOrientation)
        {
            _state = newOrientation;
        }

        private void InitializePath(int x, int y)
        {
            _path = new List<Position>();
            var startPosition = new Position(x, y);
            _path.Add(startPosition);
        }

        public void Move()
        {
            var lastPosition = GetLocation();
            var nextPosition = Translate(lastPosition);
            _path.Add(nextPosition);
        }

        private Position Translate(Position position)
        {
            return _state.Translate(position);
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

        public void Rotate(bool isTurningCounterclockwise)
        {
            _state.Rotate(this, isTurningCounterclockwise);
        }
    }
}
