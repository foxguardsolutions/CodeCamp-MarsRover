namespace MarsRover
{
    public class Position
    {
        private Point _coordinates;
        private Grid _grid;

        public Position(Point coordinates, Grid grid)
        {
            grid.ValidatePoint(coordinates);
            _coordinates = coordinates;
            _grid = grid;
        }

        public Point GetCoordinates()
        {
            return _coordinates;
        }

        public Position IncrementCoordinate(int index)
        {
            var maxCoordinate = _grid.MaxCoordinate(index);
            var nextCoordinates = _coordinates.Increment(index, maxCoordinate);
            return new Position(nextCoordinates, _grid);
        }

        public Position DecrementCoordinate(int index)
        {
            var maxCoordinate = _grid.MaxCoordinate(index);
            var nextCoordinates = _coordinates.Decrement(index, maxCoordinate);
            return new Position(nextCoordinates, _grid);
        }

        public bool IsClearOfObstacles()
        {
            return !_grid.HasObstacleAt(_coordinates);
        }
    }
}
