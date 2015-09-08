namespace MarsRovers.Terrain
{
    public class BeyondPlateauEdgeException : MarsRoversException
    {
        public BeyondPlateauEdgeException()
        {
        }

        public BeyondPlateauEdgeException(string message)
            : base(message)
        {
        }
    }
}