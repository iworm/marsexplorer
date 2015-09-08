using MarsRovers.Instructions;
using MarsRovers.Terrain;

namespace MarsRovers
{
    public static class Shuttle
    {
        public static RobotCollection LandingRobots(InstructionSet instructionSet)
        {
            var robotCollection = new RobotCollection();

            Plateau plateau = instructionSet.GetPlateau();

            foreach (IInstruction instruction in instructionSet)
            {
                var robot = new Robot(robotCollection.Count
                                      , instruction.GetLandingPosition()
                                      , instruction.GetLandingHeading()
                                      , instruction.GetMovingSequence()
                                      , plateau);

                robotCollection.Add(robot);
            }

            return robotCollection;
        }
    }
}