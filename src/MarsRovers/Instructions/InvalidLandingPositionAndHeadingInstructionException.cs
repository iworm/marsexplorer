namespace MarsRovers.Instructions
{
    public class InvalidLandingPositionAndHeadingInstructionException : MarsRoversException
    {
        public InvalidLandingPositionAndHeadingInstructionException()
        {
        }

        public InvalidLandingPositionAndHeadingInstructionException(string message)
            : base(message)
        {
        }
    }
}