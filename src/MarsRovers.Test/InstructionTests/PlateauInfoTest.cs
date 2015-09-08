using MarsRovers.Instructions;
using MarsRovers.Terrain;
using NUnit.Framework;

namespace MarsRovers.Test.InstructionTests
{
    [TestFixture]
    public class PlateauInfoTest
    {
        [Test]
        public void CorrectPlateauSizeTest()
        {
            var instructionSet = new InstructionSet();
            instructionSet.Add("5 3");

            Plateau plateau = instructionSet.GetPlateau();

            Assert.AreEqual(5, plateau.WestToEastLength);
            Assert.AreEqual(3, plateau.SouthToNorthLength);
        }

        [Test]
        [ExpectedException(typeof (InvalidPlateauInfoInstructionException))]
        public void InvalidPlateauWestToEastLengthShouldThrowException()
        {
            var instructionSet = new InstructionSet();
            instructionSet.Add("A 55");

            instructionSet.GetPlateau();
        }

        [Test]
        [ExpectedException(typeof(InvalidPlateauInfoInstructionException))]
        public void InvalidPlateauSouthToNorthLengthShouldThrowException()
        {
            var instructionSet = new InstructionSet();
            instructionSet.Add("55 A");

            instructionSet.GetPlateau();
        }

        [Test]
        [ExpectedException(typeof (MissingPlateauInfoInstructionException))]
        public void NoPlateauInfoShouldThrowException()
        {
            var instructionSet = new InstructionSet();
            instructionSet.GetPlateau();
        }

        [Test]
        [ExpectedException(typeof (InvalidPlateauInfoInstructionException))]
        public void PlateauSizeMissWidthOrLengthShouldThrowException()
        {
            var instructionSet = new InstructionSet();
            instructionSet.Add("55");

            instructionSet.GetPlateau();
        }

        [Test]
        [ExpectedException(typeof (InvalidPlateauInfoInstructionException))]
        public void PlateauWidthOrLengthIsNegativeShouldThrowException()
        {
            var instructionSet = new InstructionSet();
            instructionSet.Add("5 -1");

            instructionSet.GetPlateau();
        }
    }
}