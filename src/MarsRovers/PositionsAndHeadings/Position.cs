using MarsRovers.Terrain;

namespace MarsRovers.PositionsAndHeadings
{
    public class Position : IPosition
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        #region IPosition Members

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public void IncreaseX(int max)
        {
            if (_x == max)
            {
                throw new BeyondPlateauEdgeException(
                    "You are at the east edge of the plateau, and can not move forward to beyond the edge.");
            }

            _x++;
        }

        public void DecreaseX()
        {
            if (_x == 0)
            {
                throw new BeyondPlateauEdgeException(
                    "You are at the west edge of the plateau, and can not move forward to beyond the edge.");
            }

            _x--;
        }

        public void IncreaseY(int max)
        {
            if (_y == max)
            {
                throw new BeyondPlateauEdgeException("You are at the east edge of the plateau, and can not move forward to beyond the edge.");
            }

            _y++;
        }

        public void DecreaseY()
        {
            if (_y == 0)
            {
                throw new BeyondPlateauEdgeException(
                    "You are at the south edge of the plateau, and can not move forward to beyond the edge.");
            }

            _y--;
        }

        #endregion
    }
}