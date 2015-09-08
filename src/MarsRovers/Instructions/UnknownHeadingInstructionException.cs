namespace MarsRovers.Instructions
{
    public class UnknownHeadingInstructionException : MarsRoversException
    {
        public UnknownHeadingInstructionException()
        {
        }

        public UnknownHeadingInstructionException(string message)
            : base(message)
        {
        }
    }
}