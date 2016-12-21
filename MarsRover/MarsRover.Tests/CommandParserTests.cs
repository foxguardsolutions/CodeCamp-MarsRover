using System;
using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class CommandParserTests
    {
        [Test]
        [TestCase("l", typeof(Rotate))]
        [TestCase("r", typeof(Rotate))]
        [TestCase("f", typeof(Translate))]
        [TestCase("b", typeof(Translate))]
        public void CreateAction_GivenValidCommandCandidate_ReturnsType(string candidate, Type expectedType)
        {
            var commandParser = new CommandParser(candidate);
            var strategy = commandParser.CreateAction();
            Assert.That(strategy.GetType(), Is.EqualTo(expectedType));
        }

        [Test]
        [TestCase("u", "Could not resolve command \"u\".")]
        [TestCase("-", "Could not resolve command \"-\".")]
        [TestCase("ff", "Could not resolve command \"ff\".")]
        public void CreateAction_GivenValidCommandCandidate_ThrowsException(string candidate, string exceptionMessage)
        {
            var commandParser = new CommandParser(candidate);
            Assert.Throws<ArgumentException>(() => { commandParser.CreateAction(); }, exceptionMessage);
        }

        [TestCaseSource(nameof(RotateTestCases))]
        public void Rotate_GivenCommandCandidate_ChangesOrientationTo(
            string candidate, CardinalDirection startFacing, CardinalDirection endFacing)
        {
            var startingPosition = new Position(0, 0, startFacing, new Grid());
            var rotateCommand = new CommandParser(candidate);
            var rotation = rotateCommand.CreateAction();
            var endingPosition = rotation.Act(startingPosition);
            Assert.That(endingPosition.Orientation, Is.EqualTo(endFacing));
        }

        private static IEnumerable<TestCaseData> RotateTestCases()
        {
            yield return new TestCaseData("l", N, W);
            yield return new TestCaseData("r", N, E);
            yield return new TestCaseData("l", W, S);
            yield return new TestCaseData("r", W, N);
            yield return new TestCaseData("l", S, E);
            yield return new TestCaseData("r", S, W);
            yield return new TestCaseData("l", E, N);
            yield return new TestCaseData("r", E, S);
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Translate_GivenCommandCandidate_ChangesPositionTo(
            string candidate, CardinalDirection startFacing, int endX, int endY)
        {
            var startingPosition = new Position(1, 0, startFacing, new Grid());
            var translateCommand = new CommandParser(candidate);
            var translation = translateCommand.CreateAction();
            var endingPosition = translation.Act(startingPosition);
            Assert.That(endingPosition.Coordinates, Is.EqualTo(new int[] { endX, endY }));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData("f", E, 2, 0);
            yield return new TestCaseData("b", E, 0, 0);
        }
    }
}
