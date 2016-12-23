using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class ObstacleReportTests : BaseTests
    {
        [Test]
        public void ObstacleReport_WritesMessageToConsole()
        {
            var mockConsoleWriter = new Mock<IConsoleWriter>();
            var obstaclePosition = Fixture.Create<Position>();
            var obstacleCoordinates = obstaclePosition.GetCoordinates();
            var expectedMessage = $"Obstacle encountered at position ({obstacleCoordinates}). Movement terminated.";
            new ObstacleReport(obstaclePosition, mockConsoleWriter.Object);
            mockConsoleWriter.Verify(x => x.WriteLine(expectedMessage), Times.Once());
        }
    }
}
