using System.Collections.Generic;
using MarsRovers.PositionsAndHeadings;

namespace MarsRovers.Instructions
{
    public class Instruction : IInstruction
    {
        private readonly IHeading _heading;
        private readonly IPosition _landingPosition;
        private readonly IList<char> _movingSequence;

        public Instruction(IPosition landingPosition, IHeading heading, IList<char> movingSequence)
        {
            _landingPosition = landingPosition;
            _heading = heading;
            _movingSequence = movingSequence;
        }

        #region IInstruction Members

        public IPosition GetLandingPosition()
        {
            return _landingPosition;
        }

        public IList<char> GetMovingSequence()
        {
            return _movingSequence;
        }

        public IHeading GetLandingHeading()
        {
            return _heading;
        }

        #endregion
    }
}