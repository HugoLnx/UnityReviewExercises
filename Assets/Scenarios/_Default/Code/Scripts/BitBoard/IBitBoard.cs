
namespace Math4GamedevBitOperations
{
    public interface IBitBoard
    {
        int Width { get; }
        int Height { get; }
        int BitsPerCell { get; }
        void TurnOn(int x, int y = 0, int bitInx = 0);
        void TurnOff(int x, int y = 0, int bitInx = 0);
        void Toggle(int x, int y = 0, int bitInx = 0);
        bool IsOn(int x, int y = 0, int bitInx = 0);
        bool IsOff(int x, int y = 0, int bitInx = 0);
        int CountBitsOn();
    }
}