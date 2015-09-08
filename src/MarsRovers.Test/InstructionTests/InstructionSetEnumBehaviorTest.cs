using MarsRovers.Instructions;
using MarsRovers.PositionsAndHeadings;
using NUnit.Framework;

namespace MarsRovers.Test.InstructionTests
{
    [TestFixture]
    public class InstructionSetEnumBehaviorTest
    {
        [Test]
        public void ResetTest()
        {
            InstructionSet instructionSet = new InstructionSet();
            instructionSet.Add("5 5");
            instructionSet.Add("1 2 N");
            instructionSet.Add("L");
            instructionSet.Add("2 3 W");
            instructionSet.Add("R");

            instructionSet.MoveNext();
            Assert.AreEqual(typeof(HeadingNorth), instructionSet.Current.GetLandingHeading().GetType());

            instructionSet.MoveNext();
            Assert.AreEqual(typeof(HeadingWest), instructionSet.Current.GetLandingHeading().GetType());

            instructionSet.Reset();
            instructionSet.MoveNext();
            Assert.AreEqual(typeof(HeadingNorth), instructionSet.Current.GetLandingHeading().GetType());
        }

        [Test]
        public void MoveNextWhenNoInstructionAddedTest()
        {
            InstructionSet instructionSet = new InstructionSet();
            Assert.AreEqual(false, instructionSet.MoveNext());
        }

        [Test]
        public void MoveNextWhenHaveInstructionAddedTest()
        {
            InstructionSet instructionSet = new InstructionSet();
            instructionSet.Add("5 5");
            instructionSet.Add("1 2 N");
            instructionSet.Add("L");

            Assert.AreEqual(true, instructionSet.MoveNext());
        }
    }
}
