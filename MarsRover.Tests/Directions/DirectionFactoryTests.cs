using MarsRover.Directions;
using MarsRover.Grids;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class DirectionFactoryTests
    {
        private IGrid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new StandardGrid();
        }

        [TestCaseSource(nameof(Directions))]
        public void GetDirection_GivenCardinalDirection_ReturnsExpectedDirection(CardinalDirection cardinalDirection, Type directionType)
        {
            var actual = DirectionFactory.GetDirection(cardinalDirection, _grid);

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
