using MarsRover.Directions;
using MarsRover.Vehicles.Commands;
using NUnit.Framework;
using System;

namespace MarsRover.Tests.Vehicles.Commands
{
    [TestFixture]
    public class TurnRightCommandTests : TestsUsingRover
    {
        private TurnRightCommand _command;

        [SetUp]
        public new void SetUp()
        {
            _command = new TurnRightCommand(Rover);
        }

        [TestCaseSource(nameof(CardinalDirectionsAndExpectedDirectionTypeRight))]
        public void Execute_GivenRoverFacingDirection_TurnsRoverInDirectionToTheRight(CardinalDirection cardinalDirection, Type expectedDirectionType)
        {
            GivenRoverFacingDirection(cardinalDirection);

            _command.Execute();
            
            Assert.That(Rover.Direction, Is.TypeOf(expectedDirectionType));
        }
    }
}
