using MarsRover.Directions;
using MarsRover.Vehicles.Commands;
using NUnit.Framework;
using System;

namespace MarsRover.Tests.Vehicles.Commands
{
    [TestFixture]
    public class TurnLeftCommandTests : TestsUsingRover
    {
        private TurnLeftCommand _command;

        [SetUp]
        public new void SetUp()
        {
            _command = new TurnLeftCommand(Rover);
        }

        [TestCaseSource(nameof(CardinalDirectionsAndExpectedDirectionTypeLeft))]
        public void Execute_GivenRoverFacingDirection_TurnsRoverInDirectionToTheLeft(CardinalDirection cardinalDirection, Type expectedDirectionType)
        {
            GivenRoverFacingDirection(cardinalDirection);

            _command.Execute();
            
            Assert.That(Rover.Direction, Is.TypeOf(expectedDirectionType));
        }
    }
}
