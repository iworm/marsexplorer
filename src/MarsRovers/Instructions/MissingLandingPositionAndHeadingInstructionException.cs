namespace MarsRovers.Instructions
{
    public class MissingLandingPositionAndHeadingInstructionException : MarsRoversException
    {
        public MissingLandingPositionAndHeadingInstructionException()
        {
        }

        public MissingLandingPositionAndHeadingInstructionException(string message)
            : base(message)
        {
        }
    }
}