namespace MarsRovers.PositionsAndHeadings
{
    public class HeadingNorth : IHeading
    {
        #region IHeading Members

        public string Name
        {
            get { return "N"; }
        }

        public void TurnLeft(Robot robot)
        {
            robot.Heading = new HeadingWest();
        }

        public void TurnRight(Robot robot)
        {
            robot.Heading = new HeadingEast();
        }

        public void GoForward(Robot robot)
        {
            robot.CurrentPosition.IncreaseY(robot.TargetPlateau.SouthToNorthLength);
        }

        #endregion
    }
}