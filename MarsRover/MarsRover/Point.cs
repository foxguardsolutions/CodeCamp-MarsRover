namespace MarsRover
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point Increment(int index, int maxCoordinate)
        {
            if (index == 0)
            {
                var newX = IncrementValue(X, maxCoordinate);
                return new Point(newX, Y);
            }

            var newY = IncrementValue(Y, maxCoordinate);
            return new Point(X, newY);
        }

        public Point Decrement(int index, int maxCoordinate)
        {
            if (index == 0)
            {
                var newX = DecrementValue(X, maxCoordinate);
                return new Point(newX, Y);
            }

            var newY = DecrementValue(Y, maxCoordinate);
            return new Point(X, newY);
        }

        private static int IncrementValue(int value, int maxValue)
        {
            return (value == maxValue) ? 0 : value + 1;
        }

        private static int DecrementValue(int value, int maxValue)
        {
            return (value == 0) ? maxValue : value - 1;
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}
