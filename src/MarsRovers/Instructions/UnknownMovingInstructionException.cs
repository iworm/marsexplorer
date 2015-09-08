namespace MarsRovers.Instructions
{
    public class UnknownMovingInstructionException : MarsRoversException
    {
        public UnknownMovingInstructionException()
        {
        }

        public UnknownMovingInstructionException(string message)
            : base(message)
        {
        }
    }
}