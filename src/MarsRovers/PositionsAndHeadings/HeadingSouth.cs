namespace MarsRovers.PositionsAndHeadings
{
    public class HeadingSouth : IHeading
    {
        #region IHeading Members

        public string Name
        {
            get { return "S"; }
        }

        public void TurnLeft(Robot robot)
        {
            robot.Heading = new HeadingEast();
        }

        public void TurnRight(Robot robot)
        {
            robot.Heading = new HeadingWest();
        }

        public void GoForward(Robot robot)
        {
            robot.CurrentPosition.DecreaseY();
        }

        #endregion
    }
}