using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace MarsRover
{
    public class Rover : IVehicle
    {
        private const int RIGHT_ANGLE = 90;

        private Matrix translationMatrix = new Matrix();
        private Dictionary<Grid.Direction, Action> directionActions = new Dictionary<Grid.Direction, Action>();
        private Dictionary<Movement, Action> movementActions = new Dictionary<Movement, Action>();
        private Dictionary<Movement, char> movementDictionary;

        public Grid World { get;  set; }
        public GridCell CurrentLocation { get; set; }
        public Grid.Direction Orientation { get; set; }

        public Rover(int x, int y, Grid.Direction dir)
        {
            Orientation = dir;

            CurrentLocation = new GridCell(x, y);

            translationMatrix.Translate(x, y);

            GenerateDirectionActions();
            GenerateMovementActions();

            directionActions[dir].Invoke();
        }

        private void GenerateDirectionActions()
        {
            directionActions.Add(Grid.Direction.NORTH, TurnNorth);
            directionActions.Add(Grid.Direction.EAST, TurnEast);
            directionActions.Add(Grid.Direction.SOUTH, TurnSouth);
            directionActions.Add(Grid.Direction.WEST, TurnWest);
        }

        private void GenerateMovementActions()
        {
            movementActions.Add(Movement.FORWARD, MoveForward);
            movementActions.Add(Movement.BACKWARD, MoveBackward);
            movementActions.Add(Movement.LEFT, TurnNorth);
            movementActions.Add(Movement.RIGHT, TurnSouth);
        }

        private void TurnNorth()
        {
            translationMatrix.Rotate(-RIGHT_ANGLE);
        }

        private void TurnSouth()
        {
            translationMatrix.Rotate(RIGHT_ANGLE);
        }

        private void TurnEast()
        {
            translationMatrix.Rotate(0);
        }

        private void TurnWest()
        {
            translationMatrix.Rotate(2 * RIGHT_ANGLE);
        }

        private void MoveForward()
        {
            translationMatrix.Translate(1, 0);
        }

        private void MoveBackward()
        {
            translationMatrix.Translate(-1, 0);
        }

        public bool Move(Movement movement)
        {
            Console.WriteLine(movement);

            movementActions[movement].Invoke();

            return IsValidMove();
        }

        private bool IsValidMove()
        {
            int x = (int)Math.Round(translationMatrix.OffsetX);
            int y = (int)Math.Round(translationMatrix.OffsetY);

            if (!World.GridCellAt(x, y).ContainsObstacle)
            {
                CurrentLocation = World.GridCellAt(x, y);

                return true;
            }

            Console.WriteLine("Encountered Obstacle!");

            return false;
        }
    }
}
