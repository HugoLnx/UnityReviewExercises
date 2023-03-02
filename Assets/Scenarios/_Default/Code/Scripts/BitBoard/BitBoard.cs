using System;

namespace Math4GamedevBitOperations
{
    public class BitBoard : IBitBoard
    {
        public int Width { get; }
        public int Height { get; }
        public int BitsPerCell { get; }
        public ulong Board => _board;

        private ulong _board;

        public BitBoard(int width, int height = 1, int bitsPerCell=1, ulong board = 0L)
        {
            this.Width = width;
            this.Height = height;
            this.BitsPerCell = bitsPerCell;
            _board = board;
        }

        public void TurnOn(int x, int y = 0, int bitInx = 0)
        {
        }

        public void TurnOff(int x, int y = 0, int bitInx = 0)
        {
        }

        public void Toggle(int x, int y = 0, int bitInx = 0) {
        }

        public bool IsOn(int x, int y = 0, int bitInx = 0) {
            return false;
        }

        public bool IsOff(int x, int y = 0, int bitInx = 0) {
            return false;
        }
        public int CountBitsOn() {
            return 0;
        }
    }
}