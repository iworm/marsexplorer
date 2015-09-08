namespace MarsRovers.PositionsAndHeadings
{
    public class HeadingEast : IHeading
    {
        #region IHeading Members

        public string Name
        {
            get { return "E"; }
        }

        public void TurnLeft(Robot robot)
        {
            robot.Heading = new HeadingNorth();
        }

        public void TurnRight(Robot robot)
        {
            robot.Heading = new HeadingSouth();
        }

        public void GoForward(Robot robot)
        {
            robot.CurrentPosition.IncreaseX(robot.TargetPlateau.WestToEastLength);
        }

        #endregion
    }
}