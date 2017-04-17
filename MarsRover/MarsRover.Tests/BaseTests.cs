using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class BaseTests
    {
        protected Fixture Fixture { get; private set; }

        [SetUp]
        public void SetUpFixture()
        {
            Fixture = new Fixture();
            Fixture.Register<IConsoleWriter>(() => new ConsoleWriter());
            Fixture.Register<IMovementFrameOfReference>(() => new MovementWhenFacingNorth());
        }
    }
}
