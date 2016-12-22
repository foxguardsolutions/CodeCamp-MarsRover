using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AdaptorTests
    {
        private Initializer _initializer;
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _initializer = new Initializer();
            _grid = new Grid();
        }

        [TestCaseSource(nameof(ExecuteTestCases))]
        public void RotateRover_ChangesOrientation(
            int initialX, int initialY, char initialDirection, int finalX, int finalY, Type expectedOrientation, char[] command)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var adaptor = new Adaptor(rover);
            adaptor.Execute(command);
            var endOrientation = rover.GetOrientation();
            Assert.That(endOrientation, Is.EqualTo(expectedOrientation));
        }

        [TestCaseSource(nameof(ExecuteTestCases))]
        public void MoveRover_ChangesLocation(
            int initialX, int initialY, char initialDirection, int finalX, int finalY, Type expectedOrientation, char[] command)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var adaptor = new Adaptor(rover);
            adaptor.Execute(command);
            var endCoordinates = rover.GetLocation().Coordinates;
            Assert.That(endCoordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> ExecuteTestCases()
        {
            yield return new TestCaseData(0, 0, 'N', 0, 0, typeof(FacingWest), new char[] { 'l' });
            yield return new TestCaseData(0, 0, 'N', 0, 0, typeof(FacingEast), new char[] { 'r' });
            yield return new TestCaseData(0, 0, 'W', 0, 0, typeof(FacingSouth), new char[] { 'l' });
            yield return new TestCaseData(0, 0, 'N', 0, 1, typeof(FacingNorth), new char[] { 'f' });
            yield return new TestCaseData(0, 1, 'N', 0, 0, typeof(FacingNorth), new char[] { 'b' });
        }

        [TestCase('x', "Could not parse command from \"x\".")]
        [TestCase('!', "Could not parse command from \"!\".")]
        public void PlaceRover_GivenInvalidParameters_ThrowsException(char command, string exceptionMessage)
        {
            var rover = _initializer.PlaceRover(0, 0, 'N', _grid);
            var adaptor = new Adaptor(rover);
            Assert.Throws<ArgumentException>(() => { adaptor.Execute(command); }, exceptionMessage);
        }
    }
}
