using System;

namespace MarsRover.Grids
{
    public static class PositionCalculator
    {
        public static uint WrapPositionIntoBounds(uint position, uint lowerBound, uint upperBound)
        {
            var lower = Math.Min(lowerBound, upperBound);
            var upper = Math.Max(lowerBound, upperBound);
            var numberOfValuesInBounds = upper - lower + 1;
            
            if (position > upper)
                position = WrapGreaterPositionIntoRange(position, numberOfValuesInBounds, lower);
            else if (position < lower)
                position = WrapLesserPositionIntoRange(position, numberOfValuesInBounds, upper);

            return position;
        }

        private static uint WrapGreaterPositionIntoRange(uint position, uint rangeLength, uint minimumValue)
        {
            var distanceFromMinValue = position - minimumValue;
            var positionInRangeLength = distanceFromMinValue % rangeLength;
            return positionInRangeLength + minimumValue;
        }

        private static uint WrapLesserPositionIntoRange(uint position, uint rangeLength, uint maximumValue)
        {
            var distanceFromMaxValue = maximumValue - position;
            var positionInRange = distanceFromMaxValue % rangeLength;
            return maximumValue - positionInRange;
        }
    }
}
