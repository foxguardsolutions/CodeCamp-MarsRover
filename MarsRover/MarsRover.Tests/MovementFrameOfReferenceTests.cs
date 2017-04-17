using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    public class MovementFrameOfReferenceTests : BaseTests
    {
        protected Position InitialPosition { get; private set; }
        protected Rover ContextRover { get; private set; }

        [SetUp]
        public void SetUpRover()
        {
            InitialPosition = Fixture.Create<Position>();
            ContextRover = Fixture.Create<Rover>();
        }
    }
}
