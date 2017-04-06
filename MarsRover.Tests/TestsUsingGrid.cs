using MarsRover.Grids;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class TestsUsingGrid : Tests
    {
        protected IGrid Grid { get; set; }

        [SetUp]
        public new void SetUp()
        {
            Grid = new StandardGrid();
        }
    }
}
