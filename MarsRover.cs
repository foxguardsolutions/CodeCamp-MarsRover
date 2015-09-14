using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class MarsRover
    {
        private const int MapWidth = 10;
        private const int MapHeight = 10;
        private const int SpacesPerMove = 1;
        private const char NORTH = 'N';
        private const char EAST = 'E';
        private const char SOUTH = 'S';
        private const char WEST = 'W';
        private const char FORWARD = 'f';
        private const char BACKWARD = 'b';
        private const char LEFT = 'l';
        private const char RIGHT = 'r';
        private int _x, _y;

        private List<int[]> obstacles = new List<int[]>
        {
            new int[] { 4, 4 }, new int[] { 4, 5 }, new int[] { 4, 6 },
            new int[] { 5, 4 }, new int[] { 5, 5 }, new int[] { 5, 6 },
            new int[] { 6, 4 }, new int[] { 6, 5 }, new int[] { 6, 6 },
        };

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = GetWrappedX(value);
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = GetWrappedY(value);
            }
        }

        public char Direction
        {
            get; set;
        }

        public MarsRover(int x = 0, int y = 0, char direction = 'N')
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public bool Backward()
        {
            return Move(false);
        }

        private bool CanMove(int x, int y)
        {
            return !obstacles.Any(obstacle => obstacle[0] == x && obstacle[1] == y);
        }

        public void Left()
        {
            Rotate(false);
        }

        public bool Forward()
        {
            return Move(true);
        }

        public void MakeMoves(char[] moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case FORWARD:
                        if (!Forward())
                        {
                            Console.WriteLine("Obstacle Encountered, cannot move further!");
                            return;
                        }

                        break;
                    case BACKWARD:
                        if (!Backward())
                        {
                            Console.WriteLine("Obstacle Encountered, cannot move further!");
                            return;
                        }

                        break;
                    case LEFT:
                        Left();
                        break;
                    case RIGHT:
                        Right();
                        break;
                }
            }
        }

        private bool Move(bool forward)
        {
            int newY = Y, newX = X;
            switch (Direction)
            {
                case NORTH:
                    newY = GetWrappedY(Y + (forward ? -SpacesPerMove : SpacesPerMove));
                    if (CanMove(X, newY))
                    {
                        Y = newY;
                    }

                    break;
                case WEST:
                    newX = GetWrappedX(X + (forward ? -SpacesPerMove : SpacesPerMove));
                    if (CanMove(newX, Y))
                    {
                        X = newX;
                    }

                    break;
                case SOUTH:
                    newY = GetWrappedY(Y + (forward ? SpacesPerMove : -SpacesPerMove));
                    if (CanMove(X, newY))
                    {
                        Y = newY;
                    }

                    break;
                case EAST:
                    newX = GetWrappedX(X + (forward ? SpacesPerMove : -SpacesPerMove));
                    if (CanMove(newX, Y))
                    {
                        X = newX;
                    }

                    break;
            }

            return newX == X && newY == Y;
        }

        public void Right()
        {
            Rotate(true);
        }

        private void Rotate(bool clockwise)
        {
            switch (Direction)
            {
                case NORTH:
                    Direction = clockwise ? EAST : WEST;
                    break;
                case WEST:
                    Direction = clockwise ? NORTH : SOUTH;
                    break;
                case SOUTH:
                    Direction = clockwise ? WEST : EAST;
                    break;
                case EAST:
                    Direction = clockwise ? SOUTH : NORTH;
                    break;
            }
        }

        private int GetWrappedX(int value)
        {
            return value >= MapWidth ? 0 : value < 0 ? MapWidth - 1 : value;
        }

        private int GetWrappedY(int value)
        {
            return value >= MapHeight ? 0 : value < 0 ? MapHeight - 1 : value;
        }
    }
}
