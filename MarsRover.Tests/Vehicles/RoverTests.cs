using MarsRover.Directions;
using MarsRover.Grids;
using MarsRover.Vehicles;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;

namespace MarsRover.Tests.Vehicles
{
    [TestFixture]
    public class RoverTests : TestsUsingRover
    {
        private string _obstacleStatusFormat;
        private string _standardStatusFormat;

        [SetUp]
        public new void SetUp()
        {
            _obstacleStatusFormat = Rover.OBSTACLE_STATUS_FORMAT;
            _standardStatusFormat = Rover.STANDARD_STATUS_FORMAT;
        }

        [Test]
        public void GetStatus_GivenMovedRover_ReturnsStringDetailingNewRoverPosition()
        {
            Rover.MoveForward();
            var expected = string.Format(_standardStatusFormat, Rover.Coordinates);

            var actual = Rover.GetStatus();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetStatus_GivenNewRover_ReturnsStringDetailingRoverPosition()
        {
            var expected = string.Format(_standardStatusFormat, Rover.Coordinates);

            var actual = Rover.GetStatus();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetStatus_GivenRoverEncounteredObstacle_ReturnsStringWithPositionOfObstacle()
        {
            GivenRoverFacingDirectionWithObstacleInFrontOfRover(CardinalDirection.North);
            Rover.MoveForward();
            var obstacle = Grid.GetNextCoordinatesNorth(Rover.Coordinates);
            var expected = string.Format(_obstacleStatusFormat, obstacle);

            var actual = Rover.GetStatus();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(CardinalDirection))]
        public void MoveBackward_GivenObstacleBehindRover_DoesNotMoveRoverAndSetsObstacleEncountered(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirectionWithObstacleBehindRover(cardinalDirection);
            var expectedRoverCoordinates = Rover.Coordinates;
            var expectedObstacleCoordinates = GetNextCoordinatesInOppositeDirection(Grid, Rover.Coordinates, cardinalDirection);

            Rover.MoveBackward();

            Assert.That(Rover.Coordinates, Is.EqualTo(expectedRoverCoordinates));
            Assert.That(Rover.ObstacleEncountered, Is.EqualTo(expectedObstacleCoordinates));
        }

        [TestCaseSource(nameof(CardinalDirections))]
        public void MoveBackward_GivenRoverFacingDirection_MovesRoverInOppositeDirectionOnGrid(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var expected = GetNextCoordinatesInOppositeDirection(Grid, Rover.Coordinates, cardinalDirection);

            Rover.MoveBackward();
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(CardinalDirection))]
        public void MoveForward_GivenObstacleInFrontOfRover_DoesNotMoveRoverAndSetsObstacleEncountered(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirectionWithObstacleInFrontOfRover(cardinalDirection);
            var expectedRoverCoordinates = Rover.Coordinates;
            var expectedObstacleCoordinates = GetNextCoordinatesInDirection(Grid, Rover.Coordinates, cardinalDirection);

            Rover.MoveForward();

            Assert.That(Rover.Coordinates, Is.EqualTo(expectedRoverCoordinates));
            Assert.That(Rover.ObstacleEncountered, Is.EqualTo(expectedObstacleCoordinates));
        }

        [TestCaseSource(nameof(CardinalDirections))]
        public void MoveForward_GivenRoverFacingDirection_MovesRoverInDirectionFacedOnGrid(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var expected = GetNextCoordinatesInDirection(Grid, Rover.Coordinates, cardinalDirection);

            Rover.MoveForward();
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [Test]
        public void MoveTo_GivenCoordinates_ChangesMoverCoordinatesToNewCoordinates()
        {
            var expected = Fixture.Create<Coordinates>();
            
            Rover.MoveTo(expected);
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(CardinalDirection))]
        public void MoveTo_GivenObstacleAtCoordinates_DoesNotMoveRoverAndSetsObstacleEncountered(CardinalDirection cardinalDirection)
        {
            var expectedRoverCoordinates = Rover.Coordinates;
            var expectedObstacleCoordinates = Fixture.Create<Coordinates>();
            Obstacles.Add(expectedObstacleCoordinates);

            Rover.MoveTo(expectedObstacleCoordinates);

            Assert.That(Rover.Coordinates, Is.EqualTo(expectedRoverCoordinates));
            Assert.That(Rover.ObstacleEncountered, Is.EqualTo(expectedObstacleCoordinates));
        }

        [TestCaseSource(nameof(CardinalDirectionsAndExpectedDirectionTypeLeft))]
        public void TurnLeft_GivenRoverFacingDirection_FacesRoverInDirectionToTheLeft(CardinalDirection cardinalDirection, Type expectedDirectionType)
        {
            GivenRoverFacingDirection(cardinalDirection);

            Rover.TurnLeft();
            
            Assert.That(Rover.Direction, Is.TypeOf(expectedDirectionType));
        }

        [TestCaseSource(nameof(CardinalDirectionsAndExpectedDirectionTypeRight))]
        public void TurnRight_GivenRoverFacingDirection_FacesRoverInDirectionToTheRight(CardinalDirection cardinalDirection, Type expectedDirectionType)
        {
            GivenRoverFacingDirection(cardinalDirection);

            Rover.TurnRight();
            
            Assert.That(Rover.Direction, Is.TypeOf(expectedDirectionType));
        }

        private void GivenRoverFacingDirectionWithObstacleInFrontOfRover(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var obstacle = GetNextCoordinatesInDirection(Grid, Rover.Coordinates, cardinalDirection);
            Obstacles.Add(obstacle);

        }

        private void GivenRoverFacingDirectionWithObstacleBehindRover(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var obstacle = GetNextCoordinatesInOppositeDirection(Grid, Rover.Coordinates, cardinalDirection);
            Obstacles.Add(obstacle);
        }
    }
}
