using System.Collections.Generic;
using MarsRovers.PositionsAndHeadings;

namespace MarsRovers.Instructions
{
    public interface IInstruction
    {
        IPosition GetLandingPosition();

        IList<char> GetMovingSequence();

        IHeading GetLandingHeading();
    }
}