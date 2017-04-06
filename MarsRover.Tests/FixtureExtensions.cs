using MarsRover.Directions;
using MarsRover.Grids;
using MarsRover.Vehicles;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    public static class FixtureExtensions
    {
        public static Rover CreateRover(this Fixture fixture, IGrid grid)
        {
            var cardinalDirection = fixture.Create<CardinalDirection>();
            return fixture.CreateRover(grid, cardinalDirection);
        }

        public static Rover CreateRover(this Fixture fixture, IGrid grid, CardinalDirection cardinalDirection)
        {
            var coordinates = fixture.Create<Coordinates>();
            return new Rover(coordinates, grid, cardinalDirection);
        }
    }
}
