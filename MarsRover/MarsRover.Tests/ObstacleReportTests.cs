using System;
using System.IO;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class ObstacleReportTests
    {
        [Test]
        [TestCase(0, 1, "Obstacle encountered at point 0, 1. Movement terminated.")]
        [TestCase(1, 1, "Obstacle encountered at point 1, 1. Movement terminated.")]
        public void ObstacleReport_WritesToConsole(int x, int y, string message)
        {
            var obstacleLocation = new Position(x, y, CardinalDirection.N, new Grid());
            var expectedReport = message + Environment.NewLine;
            var actualReport = ReportConsoleOutputToString(obstacleLocation);
            Assert.That(actualReport, Is.EqualTo(expectedReport));
        }

        private string ReportConsoleOutputToString(Position inputPosition)
        {
            using (StringWriter consoleWriter = new StringWriter())
            {
                new ObstacleReport(inputPosition, consoleWriter);
                return consoleWriter.ToString();
            }
        }
    }
}
