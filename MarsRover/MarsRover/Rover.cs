using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MarsRover
{
    public class Rover
    {
        private List<Position> _path;
        private IAct _strategy;

        public Rover(int x, int y, CardinalDirection directionFacing, Grid referenceGrid)
        {
            var startingPosition = new Position(x, y, directionFacing, referenceGrid);
            _path = new List<Position>() { startingPosition };
        }

        public int[] GetLocation()
        {
            var lastPosition = GetLastPosition();
            return lastPosition.Coordinates;
        }

        public CardinalDirection GetOrientation()
        {
            var lastPosition = GetLastPosition();
            return lastPosition.Orientation;
        }

        public bool TryMove()
        {
            var lastPosition = GetLastPosition();
            var nextPosition = Act(lastPosition);
            var isValidMovement = CanMoveTo(nextPosition);
            if (isValidMovement)
                _path.Add(nextPosition);
            return isValidMovement;
        }

        private bool CanMoveTo(Position nextPosition)
        {
            return nextPosition.ReferenceGrid.IsClearOfObstacles(nextPosition.Coordinates[0], nextPosition.Coordinates[1]);
        }

        private Position GetLastPosition()
        {
            return _path[_path.Count - 1];
        }

        private Position Act(Position lastPosition)
        {
            return _strategy.Act(lastPosition);
        }

        public void SetAction(IAct strategy)
        {
            _strategy = strategy;
        }
    }
}
