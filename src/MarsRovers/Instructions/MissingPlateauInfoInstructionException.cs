namespace MarsRovers.Instructions
{
    public class MissingPlateauInfoInstructionException : MarsRoversException
    {
        public MissingPlateauInfoInstructionException()
        {
        }

        public MissingPlateauInfoInstructionException(string message)
            : base(message)
        {
        }
    }
}