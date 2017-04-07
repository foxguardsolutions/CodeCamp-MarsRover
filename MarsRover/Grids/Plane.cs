using System.Collections.Generic;

namespace MarsRover.Grids
{
    public class Plane
    {
        public IGrid Grid { get; set; }
        public IEnumerable<Coordinates> Obstacles { get; set; }

        public Plane(IGrid grid, IEnumerable<Coordinates> obstacles)
        {
            Grid = grid;
            Obstacles = obstacles;
        }
    }
}
