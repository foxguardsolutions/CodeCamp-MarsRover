using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace MarsRover
{
    public class Rover : IVehicle
    {
        private const int RIGHT_ANGLE = 90;

        private Matrix translationMatrix = new Matrix();
        private Dictionary<char, Action> directionActions = new Dictionary<char, Action>();
        private Dictionary<char, Action> movementActions = new Dictionary<char, Action>();

        public Grid World { get;  set; }
        public GridCell CurrentLocation { get; set; }
        public char Orientation { get; set; }

        public Rover(int x, int y, char dir)
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
            directionActions.Add('N', TurnNorth);
            directionActions.Add('E', TurnEast);
            directionActions.Add('S', TurnSouth);
            directionActions.Add('W', TurnWest);
        }

        private void GenerateMovementActions()
        {
            movementActions.Add('F', MoveForward);
            movementActions.Add('B', MoveBackward);
            movementActions.Add('L', TurnNorth);
            movementActions.Add('R', TurnSouth);
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

        public bool Move(char movement)
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
