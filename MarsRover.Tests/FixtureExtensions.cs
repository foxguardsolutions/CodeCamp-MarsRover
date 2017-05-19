using MarsRover.Directions;
using MarsRover.Grids;
using MarsRover.Vehicles;
using Ploeh.AutoFixture;
using System;

namespace MarsRover.Tests
{
    public static class FixtureExtensions
    {
        public static Rover CreateRover(this Fixture fixture, Plane plane)
        {
            var coordinates = fixture.Create<Coordinates>();
            var cardinalDirection = fixture.Create<CardinalDirection>();
            return new Rover(coordinates, plane, cardinalDirection);
        }

        public static uint CreateUIntInRange(this Fixture fixture, uint value1, uint value2)
        {
            var number = fixture.Create<uint>();
            var upper = Math.Max(value1, value2);
            var lower = Math.Min(value1, value2);
            var rangeLength = upper - lower + 1;
            var numberInRangeLength = number % rangeLength;
            return numberInRangeLength + lower;
        }
    }
}
