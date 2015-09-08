using MarsRovers.PositionsAndHeadings;

namespace MarsRovers
{
    public delegate void ReportPositionHandler(int robotId, IPosition position, IHeading heading);
}