using MarsRovers.PositionsAndHeadings;
using NUnit.Framework;

namespace MarsRovers.Test.Heading
{
    [TestFixture]
    public class TurnTest
    {
        [Test]
        public void HeadingNorthTurnLeftShouldHeadingWest()
        {
            Robot robot = new Robot(0, null, new HeadingNorth(), null, null);
            robot.Heading.TurnLeft(robot);
            Assert.AreEqual(typeof(HeadingWest), robot.Heading.GetType());
        }

        [Test]
        public void HeadingNorthTurnRightShouldHeadingEast()
        {
            Robot robot = new Robot(0, null, new HeadingNorth(), null, null);
            robot.Heading.TurnRight(robot);
            Assert.AreEqual(typeof(HeadingEast), robot.Heading.GetType());
        }

        [Test]
        public void HeadingEastTurnLeftShouldHeadingNorth()
        {
            Robot robot = new Robot(0, null, new HeadingEast(), null, null);
            robot.Heading.TurnLeft(robot);
            Assert.AreEqual(typeof(HeadingNorth), robot.Heading.GetType());
        }

        [Test]
        public void HeadingEastTurnRightShouldHeadingSouth()
        {
            Robot robot = new Robot(0, null, new HeadingEast(), null, null);
            robot.Heading.TurnRight(robot);
            Assert.AreEqual(typeof(HeadingSouth), robot.Heading.GetType());
        }

        [Test]
        public void HeadingSouthTurnLeftShouldHeadingEast()
        {
            Robot robot = new Robot(0, null, new HeadingSouth(), null, null);
            robot.Heading.TurnLeft(robot);
            Assert.AreEqual(typeof(HeadingEast), robot.Heading.GetType());
        }

        [Test]
        public void HeadingSouthTurnRightShouldHeadingWest()
        {
            Robot robot = new Robot(0, null, new HeadingSouth(), null, null);
            robot.Heading.TurnRight(robot);
            Assert.AreEqual(typeof(HeadingWest), robot.Heading.GetType());
        }

        [Test]
        public void HeadingWestTurnLeftShouldHeadingSouth()
        {
            Robot robot = new Robot(0, null, new HeadingWest(), null, null);
            robot.Heading.TurnLeft(robot);
            Assert.AreEqual(typeof(HeadingSouth), robot.Heading.GetType());
        }

        [Test]
        public void HeadingWestTurnRightShouldHeadingNorth()
        {
            Robot robot = new Robot(0, null, new HeadingWest(), null, null);
            robot.Heading.TurnRight(robot);
            Assert.AreEqual(typeof(HeadingNorth), robot.Heading.GetType());
        }
    }
}
