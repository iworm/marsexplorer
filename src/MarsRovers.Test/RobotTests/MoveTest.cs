using System.Collections.Generic;
using MarsRovers.Instructions;
using MarsRovers.PositionsAndHeadings;
using MarsRovers.Terrain;
using NUnit.Framework;

namespace MarsRovers.Test.RobotTests
{
    [TestFixture]
    public class MoveTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _targetPlateau = new Plateau(5, 5);
        }

        #endregion

        private Plateau _targetPlateau;

        [Test]
        public void GoForwardToWest()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingWest();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();

            Assert.AreEqual(0, robot.CurrentPosition.X);
            Assert.AreEqual(2, robot.CurrentPosition.Y);
            Assert.AreEqual(typeof (HeadingWest), robot.Heading.GetType());
        }

        [Test]
        public void GoForwardToNorth()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingNorth();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();

            Assert.AreEqual(1, robot.CurrentPosition.X);
            Assert.AreEqual(3, robot.CurrentPosition.Y);
            Assert.AreEqual(typeof(HeadingNorth), robot.Heading.GetType());
        }

        [Test]
        public void GoForwardToEast()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingEast();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();

            Assert.AreEqual(2, robot.CurrentPosition.X);
            Assert.AreEqual(2, robot.CurrentPosition.Y);
            Assert.AreEqual(typeof(HeadingEast), robot.Heading.GetType());
        }

        [Test]
        public void GoForwardToSouth()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingSouth();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();

            Assert.AreEqual(1, robot.CurrentPosition.X);
            Assert.AreEqual(1, robot.CurrentPosition.Y);
            Assert.AreEqual(typeof(HeadingSouth), robot.Heading.GetType());
        }

        [Test]
        [ExpectedException(typeof (BeyondPlateauEdgeException))]
        public void GoForwardButNowIsHeadingEastEdgeShouldThrowException()
        {
            IPosition position = new Position(5, 5);
            IHeading heading = new HeadingEast();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();
        }

        [Test]
        [ExpectedException(typeof (BeyondPlateauEdgeException))]
        public void GoForwardButNowIsHeadingNorthEdgeShouldThrowException()
        {
            IPosition position = new Position(0, 5);
            IHeading heading = new HeadingNorth();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();
        }

        [Test]
        [ExpectedException(typeof (BeyondPlateauEdgeException))]
        public void GoForwardButNowIsHeadingSouthEdgeShouldThrowException()
        {
            IPosition position = new Position(0, 0);
            IHeading heading = new HeadingSouth();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();
        }

        [Test]
        [ExpectedException(typeof (BeyondPlateauEdgeException))]
        public void GoForwardButNowIsHeadingWestEdgeShouldThrowException()
        {
            IPosition position = new Position(0, 0);
            IHeading heading = new HeadingWest();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('M');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();
        }

        [Test]
        public void TurnLeft()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingWest();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('L');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();

            Assert.AreEqual(1, robot.CurrentPosition.X);
            Assert.AreEqual(2, robot.CurrentPosition.Y);
            Assert.AreEqual(typeof (HeadingSouth), robot.Heading.GetType());
        }

        [Test]
        public void TurnRight()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingWest();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('R');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();

            Assert.AreEqual(1, robot.CurrentPosition.X);
            Assert.AreEqual(2, robot.CurrentPosition.Y);
            Assert.AreEqual(typeof (HeadingNorth), robot.Heading.GetType());
        }

        [Test]
        [ExpectedException(typeof(UnknownMovingInstructionException))]
        public void InvalidMoveInstructionShouldThrowException()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingWest();
            IList<char> MovingInstruction = new List<char>();
            MovingInstruction.Add('T');

            var robot = new Robot(0, position, heading, MovingInstruction, _targetPlateau);
            robot.Move();
        }
    }
}