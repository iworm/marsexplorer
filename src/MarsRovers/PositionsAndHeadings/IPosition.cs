namespace MarsRovers.PositionsAndHeadings
{
    public interface IPosition
    {
        int X { get; }
        int Y { get; }

        void IncreaseX(int max);
        void DecreaseX();
        void IncreaseY(int max);
        void DecreaseY();
    }
}