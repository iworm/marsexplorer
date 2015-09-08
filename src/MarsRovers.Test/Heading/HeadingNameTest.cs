using MarsRovers.PositionsAndHeadings;
using NUnit.Framework;

namespace MarsRovers.Test.Heading
{
    [TestFixture]
    public class HeadingNameTest
    {
        [Test]
        public void GetHeadingNorthName()
        {
            Assert.AreEqual("N", new HeadingNorth().Name);
        }

        [Test]
        public void GetHeadingEastName()
        {
            Assert.AreEqual("E", new HeadingEast().Name);
        }

        [Test]
        public void GetHeadingSouthName()
        {
            Assert.AreEqual("S", new HeadingSouth().Name);
        }

        [Test]
        public void GetHeadingWestName()
        {
            Assert.AreEqual("W", new HeadingWest().Name);
        }
    }
}
