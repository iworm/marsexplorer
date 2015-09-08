using System.Collections.Generic;
using MarsRovers.PositionsAndHeadings;
using MarsRovers.Terrain;
using NUnit.Framework;

namespace MarsRovers.Test.RobotTests
{
    [TestFixture]
    public class LandingPositionAndHeadingTest
    {
        [Test]
        public void CorrectLandingPositionAndHeading()
        {
            IPosition position = new Position(1, 2);
            IHeading heading = new HeadingWest();
            IList<char> MovingInstruction = new List<char>();
            var plateau = new Plateau(5, 5);

            MovingInstruction.Add('L');

            var robot = new Robot(0, position, heading, MovingInstruction, plateau);
            Assert.AreEqual(1, robot.CurrentPosition.X);
            Assert.AreEqual(2, robot.CurrentPosition.Y);
            Assert.AreEqual(typeof (HeadingWest), robot.Heading.GetType());
        }
    }
}