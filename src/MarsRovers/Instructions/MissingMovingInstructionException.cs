namespace MarsRovers.Instructions
{
    public class MissingMovingInstructionException : MarsRoversException
    {
        public MissingMovingInstructionException()
        {
        }

        public MissingMovingInstructionException(string message)
            : base(message)
        {
        }
    }
}