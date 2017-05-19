using MarsRover.Grids;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;

namespace MarsRover.Tests.Grids
{
    [TestFixture]
    public class PositionCalculatorTests : Tests
    {
        private uint _lowerBound;
        private uint _position;
        private uint _rangeLength;
        private uint _upperBound;

        [SetUp]
        public new void SetUp()
        {
            var bounds = Fixture.CreateMany<uint>(count: 2).OrderBy(i => i).ToArray();
            _lowerBound = bounds[0];
            _upperBound = bounds[1];
            _position = Fixture.CreateUIntInRange(_lowerBound, _upperBound);
            _rangeLength = _upperBound - _lowerBound + 1;
        }

        [Test]
        public void WrapPositionIntoBounds_GivenPositionInBounds_ReturnsPositionPovided()
        {
            var expected = _position;

            var actual = PositionCalculator.WrapPositionIntoBounds(_position, _lowerBound, _upperBound);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WrapPositionIntoBounds_GivenPositionGreaterThanUpperBound_ReturnsPositionBetweenBounds()
        {
            var positionOutOfRange = _position + _rangeLength;
            var expected = _position;

            var actual = PositionCalculator.WrapPositionIntoBounds(positionOutOfRange, _lowerBound, _upperBound);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WrapPositionIntoBounds_GivenPositionLessThanLowerBound_ReturnsPositionBetweenBounds()
        {
            var positionOutOfRange = _lowerBound - 1;
            var expected = _upperBound;

            var actual = PositionCalculator.WrapPositionIntoBounds(positionOutOfRange, _lowerBound, _upperBound);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
