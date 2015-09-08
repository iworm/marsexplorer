using System.Collections.Generic;
using MarsRovers.Instructions;
using NUnit.Framework;

namespace MarsRovers.Test.InstructionTests
{
    [TestFixture]
    public class MovingInstructionTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _instructionSet = new InstructionSet();
            _instructionSet.Add("5 5");
            _instructionSet.Add("1 2 N");
        }

        #endregion

        private InstructionSet _instructionSet;

        [Test]
        public void CombineCorrectMovingInstruction()
        {
            _instructionSet.Add("LRMRLM");

            _instructionSet.MoveNext();
            IList<char> MovingInstruction = _instructionSet.Current.GetMovingSequence();

            Assert.AreEqual('L', MovingInstruction[0]);
            Assert.AreEqual('R', MovingInstruction[1]);
            Assert.AreEqual('M', MovingInstruction[2]);
            Assert.AreEqual('R', MovingInstruction[3]);
            Assert.AreEqual('L', MovingInstruction[4]);
            Assert.AreEqual('M', MovingInstruction[5]);
        }

        [Test]
        public void EmptyMovingInstruction()
        {
            _instructionSet.Add(string.Empty);

            _instructionSet.MoveNext();
            IList<char> MovingInstruction = _instructionSet.Current.GetMovingSequence();

            Assert.AreEqual(0, MovingInstruction.Count);
        }

        [Test]
        [ExpectedException(typeof (MissingMovingInstructionException))]
        public void NoMovingInstructionShouldThrowException()
        {
            _instructionSet.MoveNext();
            IInstruction instruction = _instructionSet.Current;
        }

        [Test]
        public void OnlyOneCorrectMovingInstruction()
        {
            _instructionSet.Add("L");

            _instructionSet.MoveNext();
            IList<char> MovingInstruction = _instructionSet.Current.GetMovingSequence();

            Assert.AreEqual('L', MovingInstruction[0]);
        }
    }
}