using NUnit.Framework;

namespace MarsRovers.Test.RobotCollectionTest
{
    [TestFixture]
    public class CountTest
    {
        [Test]
        public void TestRobotCount()
        {
            RobotCollection robots = new RobotCollection();
            robots.Add(new Robot(0, null, null, null, null));

            Assert.AreEqual(1, robots.Count);
        }
    }
}
