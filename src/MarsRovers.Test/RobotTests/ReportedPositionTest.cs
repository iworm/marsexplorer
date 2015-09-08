using System.Collections.Generic;
using MarsRovers.PositionsAndHeadings;
using MarsRovers.Terrain;
using NUnit.Framework;

namespace MarsRovers.Test.RobotTests
{
    [TestFixture]
    public class ReportedPositionTest
    {
        [Test]
        [ExpectedException(typeof(SuccessException))]
        public void ListenReportedPosition()
        {
            Robot robot = new Robot(0, new Position(1, 1), new HeadingEast(), new List<char>() { 'M' }, new Plateau(5, 5));
            robot.ReportedPosition += (id, position, heading) => Assert.Pass();
            robot.Move();
        }

        [Test]
        public void NotListenReportedPosition()
        {
            Robot robot = new Robot(0, new Position(1, 1), new HeadingEast(), new List<char>() { 'M' }, new Plateau(5, 5));
            robot.Move();
        }
    }
}
