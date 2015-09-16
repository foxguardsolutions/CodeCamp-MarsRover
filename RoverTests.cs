using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover
{
    [TestFixture]
    public class RoverTests
    {
        private Map mars;
        private Rover marsRover;

        [SetUp]
        public void SetUp()
        {
            List<int[]> obstacles = new List<int[]>()
            {
                new int[] { 4, 4 }, new int[] { 4, 5 }, new int[] { 4, 6 },
                new int[] { 5, 4 }, new int[] { 5, 5 }, new int[] { 5, 6 },
                new int[] { 6, 4 }, new int[] { 6, 5 }, new int[] { 6, 6 },
            };
            mars = new Map(10, 10);
            mars.Obstacles = obstacles;
            marsRover = new Rover(new NorthFacingRover(), mars);
        }

        [TestCase("F", Result = new int[] { 0, 9 })]
        [TestCase("LLFFLFF", Result = new int[] { 2, 2 })]
        public int[] RoverMoveTests(string moves)
        {
            foreach (var action in moves)
            {
                marsRover.MoveRover(action);
            }

            return new int[] { marsRover.X, marsRover.Y };
        }

        [TestCase("F", Result = true)]
        [TestCase("LLFFLFF", Result = true)]
        [TestCase("RFFFFRFFF", Result = true)]
        [TestCase("RFFFFRFFFF", Result = false)]
        public bool RoverMoveReturnsFalseWhenAnObstacleIsEncountered(string moves)
        {
            bool canMove = true;
            foreach (var action in moves)
            {
                canMove &= marsRover.MoveRover(action);
            }

            return canMove;
        }
    }
}
