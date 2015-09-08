using System.Collections.Generic;
using MarsRovers.PositionsAndHeadings;

namespace MarsRovers
{
    public class RobotCollection
    {
        private readonly IList<Robot> _robots = new List<Robot>();

        public int Count
        {
            get { return _robots.Count; }
        }

        public event ReportPositionHandler ReportedPosition;

        public void Add(Robot robot)
        {
            robot.ReportedPosition += RobotReportedPosition;
            _robots.Add(robot);
        }

        public void StartExplore()
        {
            foreach (Robot robot in _robots)
            {
                robot.Move();
            }
        }

        private void RobotReportedPosition(int robotId, IPosition position, IHeading heading)
        {
            if (ReportedPosition != null)
            {
                ReportedPosition(robotId, position, heading);
            }
        }
    }
}