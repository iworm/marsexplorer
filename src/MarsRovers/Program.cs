using System;
using MarsRovers.Instructions;
using MarsRovers.PositionsAndHeadings;

namespace MarsRovers
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                InstructionSet instructionSet = ReceiveInstructions();

                RobotCollection robotCollection = Shuttle.LandingRobots(instructionSet);
                robotCollection.ReportedPosition += RobotsReportedPosition;
                robotCollection.StartExplore();
            }
            catch (MarsRoversException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadKey();
        }

        private static void RobotsReportedPosition(int robotId, IPosition position, IHeading heading)
        {
            Console.WriteLine(string.Format("{0} {1} {2}"
                                            , position.X, position.Y, heading.Name));
        }

        private static InstructionSet ReceiveInstructions()
        {
            var instructionSet = new InstructionSet();

            string instruction;

            while ((instruction = Console.ReadLine()) != string.Empty)
            {
                instructionSet.Add(instruction);
            }

            //instructionSet.Add("5 5");
            //instructionSet.Add("1 2 N");
            //instructionSet.Add("LMLMLMLMM");
            //instructionSet.Add("3 3 E");
            //instructionSet.Add("MMRMMRMRRM");
            //instructionSet.Add("3 3 E");
            //instructionSet.Add("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM");

            return instructionSet;
        }
    }
}