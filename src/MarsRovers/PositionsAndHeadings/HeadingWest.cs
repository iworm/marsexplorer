namespace MarsRovers.PositionsAndHeadings
{
    public class HeadingWest : IHeading
    {
        #region IHeading Members

        public string Name
        {
            get { return "W"; }
        }

        public void TurnLeft(Robot robot)
        {
            robot.Heading = new HeadingSouth();
        }

        public void TurnRight(Robot robot)
        {
            robot.Heading = new HeadingNorth();
        }

        public void GoForward(Robot robot)
        {
            robot.CurrentPosition.DecreaseX();
        }

        #endregion
    }
}