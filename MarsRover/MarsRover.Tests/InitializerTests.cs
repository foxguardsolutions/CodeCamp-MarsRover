using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class InitializerTests
    {
        [Test]
        public void PlaceRover_GivenValidPlacement_ReturnsRoverWithInitialValues()
        {
            var initializer = new Initializer();
            var rover = initializer.PlaceRover(0, 0, 'N', new Grid());
            var coordinates = rover.GetLocation().Coordinates;
            Assert.That(coordinates, Is.EqualTo(new int[] { 0, 0 }));
        }
    }
}
