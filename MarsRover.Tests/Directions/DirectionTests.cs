using MarsRover.Grids;
using MarsRover.Vehicles;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class DirectionTests : Tests
    {
        protected IGrid Grid { get; set; }
        protected RoverPosition Position { get; set; }

        [SetUp]
        public new void SetUp()
        {
            Grid = new StandardGrid();
            Position = Fixture.Create<RoverPosition>();
        }
    }
}
