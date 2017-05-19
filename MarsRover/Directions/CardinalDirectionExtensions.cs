using System;
using System.Collections.Generic;

namespace MarsRover.Directions
{
    public static class CardinalDirectionExtensions
    {
        private static LinkedList<CardinalDirection> _cardinalDirections =
            new LinkedList<CardinalDirection>((IEnumerable<CardinalDirection>)Enum.GetValues(typeof(CardinalDirection)));

        public static CardinalDirection GetDirectionToTheLeft(this CardinalDirection cardinalDirection)
        {
            var node = _cardinalDirections.Find(cardinalDirection);
            var leftDirection = node.Previous ?? _cardinalDirections.Last;
            return leftDirection.Value;
        }

        public static CardinalDirection GetDirectionToTheRight(this CardinalDirection cardinalDirection)
        {
            var node = _cardinalDirections.Find(cardinalDirection);
            var rightDirection = node.Next ?? _cardinalDirections.First;
            return rightDirection.Value;
        }
    }
}
