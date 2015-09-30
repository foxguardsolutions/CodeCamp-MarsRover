using System;
using System.Drawing.Drawing2D;

namespace MarsRover
{
    public class Rover : IVehicle
    {
        private const int RIGHT_ANGLE = 90;

        private Matrix translationMatrix = new Matrix();

        public Grid World { get;  set; }
        public GridCell CurrentLocation { get; set; }
        public Grid.Direction Orientation { get; set; }

        public Rover(int x, int y, Grid.Direction dir)
        {
            Orientation = dir;

            CurrentLocation = new GridCell(x, y);

            translationMatrix.Translate(x, y);

            switch (dir)
            {
                case Grid.Direction.NORTH:
                    translationMatrix.Rotate(-RIGHT_ANGLE);
                    break;
                case Grid.Direction.SOUTH:
                    translationMatrix.Rotate(RIGHT_ANGLE);
                    break;
                case Grid.Direction.WEST:
                    translationMatrix.Rotate(2 * RIGHT_ANGLE);
                    break;
                case Grid.Direction.EAST:
                    break;
            }
        }

        public bool Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.FORWARD:
                    translationMatrix.Translate(1, 0);
                    break;
                case Movement.BACKWARD:
                    translationMatrix.Translate(-1, 0);
                    break;
                case Movement.LEFT:
                    translationMatrix.Rotate(-RIGHT_ANGLE);
                    break;
                case Movement.RIGHT:
                    translationMatrix.Rotate(RIGHT_ANGLE);
                    break;
            }

            return IsValidMove();
        }

        private bool IsValidMove()
        {
            int x = Convert.ToInt32(translationMatrix.OffsetX);
            int y = Convert.ToInt32(translationMatrix.OffsetY);

            if (!World.GridCellAt(x, y).ContainsObstacle)
            {
                CurrentLocation = World.GridCellAt(x, y);

                return true;
            }

            Console.WriteLine("Encounter Obstacle!");

            return false;
        }
    }
}
