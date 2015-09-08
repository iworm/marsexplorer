using MarsRovers.Instructions;
using MarsRovers.PositionsAndHeadings;
using NUnit.Framework;

namespace MarsRovers.Test.InstructionTests
{
    [TestFixture]
    public class LandingPositionAndHeadingTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _instructionSet = new InstructionSet();
            _instructionSet.Add("5 5");
        }

        #endregion

        private InstructionSet _instructionSet;

        [Test]
        public void CorrectLandingPositionAndHeading()
        {
            _instructionSet.Add("1 2 W");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;

            IPosition landingPosition = instruction.GetLandingPosition();
            Assert.AreEqual(1, landingPosition.X);
            Assert.AreEqual(2, landingPosition.Y);
            Assert.AreEqual(typeof (HeadingWest), instruction.GetLandingHeading().GetType());
        }

        [Test]
        public void CorrectLandingPositionAndHeadingToEast()
        {
            _instructionSet.Add("1 2 E");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;

            IPosition landingPosition = instruction.GetLandingPosition();
            Assert.AreEqual(1, landingPosition.X);
            Assert.AreEqual(2, landingPosition.Y);
            Assert.AreEqual(typeof(HeadingEast), instruction.GetLandingHeading().GetType());
        }

        [Test]
        public void CorrectLandingPositionAndHeadingToSouth()
        {
            _instructionSet.Add("1 2 S");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;

            IPosition landingPosition = instruction.GetLandingPosition();
            Assert.AreEqual(1, landingPosition.X);
            Assert.AreEqual(2, landingPosition.Y);
            Assert.AreEqual(typeof(HeadingSouth), instruction.GetLandingHeading().GetType());
        }

        [Test]
        [ExpectedException(typeof (InvalidLandingPositionAndHeadingInstructionException))]
        public void HaveLandingHeadingButMissLandingPositionShouldThrowException()
        {
            _instructionSet.Add("W");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof (InvalidLandingPositionAndHeadingInstructionException))]
        public void HaveLandingPositionButMissLandingHeadingShouldThrowException()
        {
            _instructionSet.Add("1 2");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof (InvalidLandingPositionAndHeadingInstructionException))]
        public void LandingPositionIsNegativeShouldThrowException()
        {
            _instructionSet.Add("-1 -2 W");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof(InvalidLandingPositionAndHeadingInstructionException))]
        public void LandingPositionIsLargerThanPlateauEastEdgeShouldThrowException()
        {
            _instructionSet.Add("10 5 W");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof(InvalidLandingPositionAndHeadingInstructionException))]
        public void LandingPositionIsLargerThanPlateauNorthEdgeShouldThrowException()
        {
            _instructionSet.Add("5 10 W");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof (UnknownHeadingInstructionException))]
        public void InvalidHeadingShouldThrowException()
        {
            _instructionSet.Add("1 2 A");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof(InvalidLandingPositionAndHeadingInstructionException))]
        public void LandingPositionXCoordinateIsNotNumberShouldThrowException()
        {
            _instructionSet.Add("A 2 W");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof(InvalidLandingPositionAndHeadingInstructionException))]
        public void LandingPositionYCoordinateIsNotNumberShouldThrowException()
        {
            _instructionSet.Add("2 B W");
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        [ExpectedException(typeof (MissingLandingPositionAndHeadingInstructionException))]
        public void NotHaveLandingPositionShouldThrowException()
        {
            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }
    }
}