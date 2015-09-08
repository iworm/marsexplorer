using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarsRovers.PositionsAndHeadings;
using MarsRovers.Terrain;

namespace MarsRovers.Instructions
{
    public class InstructionSet : IEnumerator<IInstruction>, IEnumerable<IInstruction>
    {
        private const int DefaultIndex = -1;
        private const int EachComplateInstructionLineCount = 2;
        private const string InstructionDelimiter = " ";

        private readonly IList<string> _instructions = new List<string>();
        private int _currentIndex = DefaultIndex;

        #region IEnumerable<IInstruction> Members

        public IEnumerator<IInstruction> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region IEnumerator<IInstruction> Members

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _currentIndex += EachComplateInstructionLineCount;

            if (_currentIndex >= _instructions.Count)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            _currentIndex = DefaultIndex;
        }

        public IInstruction Current
        {
            get
            {
                if (_currentIndex >= _instructions.Count)
                {
                    throw new MissingLandingPositionAndHeadingInstructionException(
                        "Landing position and heading should be provided.");
                }

                LandingPositionAndHeading landingPositionAndHeading = GetLangingPositionAndHeading();

                IList<char> movingInstructions = GetMovingInstructions();

                IInstruction instruction = new Instruction(
                    landingPositionAndHeading.Position
                    , landingPositionAndHeading.Heading
                    , movingInstructions);

                return instruction;
            }
        }

        private IList<char> GetMovingInstructions()
        {
            if (_currentIndex + 1 >= _instructions.Count)
            {
                throw new MissingMovingInstructionException("Move sequence Instruction should be provided.");
            }

            return _instructions[_currentIndex + 1].ToCharArray().ToList();
        }

        private LandingPositionAndHeading GetLangingPositionAndHeading()
        {
            string[] landingInfo = _instructions[_currentIndex].Split(new[] {InstructionDelimiter}, StringSplitOptions.RemoveEmptyEntries);

            if (landingInfo.Length != 3)
            {
                throw new InvalidLandingPositionAndHeadingInstructionException(
                    "Landing position and heading should be provided");
            }

            int positionX, positionY;

            if (!int.TryParse(landingInfo[0], out positionX))
            {
                throw new InvalidLandingPositionAndHeadingInstructionException(
                    "Landing position X coordinate should be a number");
            }

            if (!int.TryParse(landingInfo[1], out positionY))
            {
                throw new InvalidLandingPositionAndHeadingInstructionException(
                    "Landing position Y coordinate should be a number");
            }

            if (positionX < 0 || positionY < 0)
            {
                throw new InvalidLandingPositionAndHeadingInstructionException(
                    "Landing position is on the outside of the plateau.");
            }

            LandingPositionAndHeading landingPositionAndHeading = new LandingPositionAndHeading();
            landingPositionAndHeading.Position = new Position(positionX, positionY);

            if (!GetPlateau().IsLandingPositionOnPlateau(landingPositionAndHeading.Position))
            {
                throw new InvalidLandingPositionAndHeadingInstructionException(
                    "Landing position is on the outside of the plateau.");
            }

            IHeading heading = CreateHeading(landingInfo[2]);
            landingPositionAndHeading.Heading = heading;

            return landingPositionAndHeading;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        #endregion

        public void Add(string instruction)
        {
            _instructions.Add(instruction);
        }

        public Plateau GetPlateau()
        {
            if (_instructions.Count == 0)
            {
                throw new MissingPlateauInfoInstructionException("Plateau size should be provided");
            }

            string[] plateauSize = _instructions[0].Split(new[] {InstructionDelimiter},
                                                        StringSplitOptions.RemoveEmptyEntries);

            if (plateauSize.Length != 2)
            {
                throw new InvalidPlateauInfoInstructionException("Plateau size is formed by \"West to East Length\" and \"South to North Length\"");
            }

            int westToEastLength, southToNorthLength;

            if (!int.TryParse(plateauSize[0], out westToEastLength))
            {
                throw new InvalidPlateauInfoInstructionException("Plateau west to east length must be a number");
            }

            if (!int.TryParse(plateauSize[1], out southToNorthLength))
            {
                throw new InvalidPlateauInfoInstructionException("Plateau south to north length must be a number");
            }

            if (westToEastLength < 0 || southToNorthLength < 0)
            {
                throw new InvalidPlateauInfoInstructionException("Plateau length of each side must great than or equal to 0");
            }

            var plateau = new Plateau(westToEastLength, southToNorthLength);

            return plateau;
        }

        private static IHeading CreateHeading(string headingText)
        {
            IHeading heading;

            switch (headingText)
            {
                case "W":
                    heading = new HeadingWest();
                    break;
                case "E":
                    heading = new HeadingEast();
                    break;
                case "S":
                    heading = new HeadingSouth();
                    break;
                case "N":
                    heading = new HeadingNorth();
                    break;
                default:
                    throw new UnknownHeadingInstructionException("Unknown heading Instruction " + headingText);
            }

            return heading;
        }
    }
}