using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AdaptorTests
    {
        [TestCaseSource(nameof(RotateTestCases))]
        public void RotateRover_ChangesOrientation(char initialDirection, char command, Type expectedOrientation)
        {
            var initializer = new Initializer();
            var rover = initializer.PlaceRover(0, 0, initialDirection, new Grid());
            var adaptor = new Adaptor(rover);
            adaptor.Execute(command);
            var endOrientation = rover.GetOrientation();
            Assert.That(endOrientation, Is.EqualTo(expectedOrientation));
        }

        private static IEnumerable<TestCaseData> RotateTestCases()
        {
            yield return new TestCaseData('N', 'l', typeof(FacingWest));
            yield return new TestCaseData('N', 'r', typeof(FacingEast));
            yield return new TestCaseData('N', 'f', typeof(FacingNorth));
            yield return new TestCaseData('W', 'l', typeof(FacingSouth));
        }
    }
}
