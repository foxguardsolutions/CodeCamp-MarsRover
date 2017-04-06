using MarsRover.Directions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class DirectionFactoryTests : TestsUsingGrid
    {
        [TestCaseSource(nameof(Directions))]
        public void GetDirection_GivenCardinalDirection_ReturnsExpectedDirection(CardinalDirection cardinalDirection, Type directionType)
        {
            var actual = DirectionFactory.GetDirection(cardinalDirection, Grid);

            Assert.That(actual, Is.TypeOf(directionType));
        }
        
        private static IEnumerable<TestCaseData> Directions()
        {
            yield return new TestCaseData(CardinalDirection.East, typeof(EastDirection));
            yield return new TestCaseData(CardinalDirection.North, typeof(NorthDirection));
            yield return new TestCaseData(CardinalDirection.South, typeof(SouthDirection));
            yield return new TestCaseData(CardinalDirection.West, typeof(WestDirection));
        }
    }
}
