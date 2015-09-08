using MarsRovers.PositionsAndHeadings;

namespace MarsRovers.Terrain
{
    public class Plateau
    {
        private readonly int _southToNorthLength;
        private readonly int _westToEastLength;

        public Plateau(int westToEastLength, int southToNorthLength)
        {
            _westToEastLength = westToEastLength;
            _southToNorthLength = southToNorthLength;
        }

        public int WestToEastLength
        {
            get { return _westToEastLength; }
        }

        public int SouthToNorthLength
        {
            get { return _southToNorthLength; }
        }

        public bool IsLandingPositionOnPlateau(IPosition position)
        {
            if (position.X > WestToEastLength)
            {
                return false;
            }

            if (position.Y > SouthToNorthLength)
            {
                return false;
            }

            return true;
        }
    }
}