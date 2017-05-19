using System;

namespace MarsRover
{
    public static class UIntExtensions
    {
        public static bool IsBetween(this uint number, uint value1, uint value2,
            bool inclusive = true)
        {
            var lower = Math.Min(value1, value2);
            var upper = Math.Max(value1, value2);

            return inclusive ? lower <= number && number <= upper
                             : lower < number && number < upper;
        }
    }
}
