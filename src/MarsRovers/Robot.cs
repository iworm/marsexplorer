using System.Collections.Generic;
using MarsRovers.Instructions;
using MarsRovers.PositionsAndHeadings;
using MarsRovers.Terrain;

namespace MarsRovers
{
    public class Robot
    {
        public readonly IPosition CurrentPosition;
        public readonly Plateau TargetPlateau;

        private readonly IList<char> _movingInstructions;
        private readonly int _robotId;

        public Robot(int robotId, IPosition langdingPosition, IHeading heading, IList<char> movingInstructions,
                     Plateau targetPlateau)
        {
            _robotId = robotId;
            CurrentPosition = langdingPosition;
            Heading = heading;
            _movingInstructions = movingInstructions;
            TargetPlateau = targetPlateau;
        }

        public IHeading Heading { get; set; }
        public event ReportPositionHandler ReportedPosition;

        public void Move()
        {
            foreach (char instruction in _movingInstructions)
            {
                ExecuteInstruction(instruction);
            }

            ReportCurrentPosition();
        }

        private void ExecuteInstruction(char instruction)
        {
            switch (instruction)
            {
                case 'L':
                    Heading.TurnLeft(this);
                    break;
                case 'R':
                    Heading.TurnRight(this);
                    break;
                case 'M':
                    Heading.GoForward(this);
                    break;
                default:
                    throw new UnknownMovingInstructionException("Unknown move instruction " + instruction);
            }
        }

        private void ReportCurrentPosition()
        {
            if (ReportedPosition != null)
            {
                ReportedPosition(_robotId, CurrentPosition, Heading);
            }
        }
    }
}