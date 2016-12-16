namespace MarsRover
{
    public class Grid
    {
        private const int DEFAULTSIZE = 1000;
        private int _xSize;
        private int _ySize;

        public Grid()
        {
            _xSize = DEFAULTSIZE;
            _ySize = DEFAULTSIZE;
        }

        public Grid(int xSize, int ySize)
        {
            _xSize = Validate(xSize);
            _ySize = Validate(ySize);
        }

        public int[] Size()
        {
            return new int[] { _xSize, _ySize };
        }

        private int Validate(int input)
        {
            if (input < 1)
                return DEFAULTSIZE;
            return input;
        }
    }
}
