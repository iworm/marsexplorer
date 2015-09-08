namespace MarsRovers.PositionsAndHeadings
{
    public interface IHeading
    {
        string Name { get; }
        void TurnLeft(Robot robot);
        void TurnRight(Robot robot);
        void GoForward(Robot robot);
    }
}