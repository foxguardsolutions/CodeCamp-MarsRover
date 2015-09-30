using System;

namespace MarsRover
{
    public class Rover
    {
        private IRover InternalRover { get; set; }

        public Map Planet { get; set; }

        public int X
        {
            get
            {
                return InternalRover.X;
            }
            set
            {
                InternalRover.X = value;
            }
        }

        public int Y
        {
            get
            {
                return InternalRover.Y;
            }
            set
            {
                InternalRover.Y = value;
            }
        }

        public Rover(IRover rover, Map map)
        {
            InternalRover = rover;
            Planet = map;
        }

        public bool MoveRover(char action)
        {
            var newRover = MapCoordinates(InternalRover.Move(action));
            if (Planet.CanMoveTo(newRover.X, newRover.Y))
            {
                InternalRover = newRover;
                return true;
            }

            Console.WriteLine("Cannot perform move, obstacle in the way!");
            return false;
        }

        private IRover MapCoordinates(IRover rover)
        {
            Type roverType = rover.GetType();
            return (IRover)Activator.CreateInstance(
                roverType,
                Planet.ConvertXCoordinate(rover.X),
                Planet.ConvertYCoordinate(rover.Y));
        }
    }
}
