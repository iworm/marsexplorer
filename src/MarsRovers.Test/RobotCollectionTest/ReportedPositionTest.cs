using System.Collections.Generic;
using MarsRovers.PositionsAndHeadings;
using MarsRovers.Terrain;
using NUnit.Framework;

namespace MarsRovers.Test.RobotCollectionTest
{
    [TestFixture]
    public class ReportedPositionTest
    {
        [Test]
        [ExpectedException(typeof(SuccessException))]
        public void ListenReportedPosition()
        {
            RobotCollection robots = new RobotCollection();
            robots.ReportedPosition += (id, position, heading) => Assert.Pass();
            robots.Add(new Robot(0, new Position(1, 1), new HeadingEast(), new List<char>() { 'M' }, new Plateau(5, 5)));
            robots.StartExplore();
        }

        [Test]
        public void NotListenReportedPosition()
        {
            RobotCollection robots = new RobotCollection();
            robots.Add(new Robot(0, new Position(1, 1), new HeadingEast(), new List<char>() { 'M' }, new Plateau(5, 5)));
            robots.StartExplore();
        }
    }
}
