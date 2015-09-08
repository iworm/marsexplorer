namespace MarsRovers.Instructions
{
    public class InvalidPlateauInfoInstructionException : MarsRoversException
    {
        public InvalidPlateauInfoInstructionException()
        {
        }

        public InvalidPlateauInfoInstructionException(string message)
            : base(message)
        {
        }
    }
}