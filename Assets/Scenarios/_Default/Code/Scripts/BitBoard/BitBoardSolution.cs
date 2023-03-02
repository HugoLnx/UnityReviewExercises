using System;

namespace Math4GamedevBitOperations
{
    public class BitBoardSolution : IBitBoard
    {
        public int Width { get; }
        public int Height { get; }
        public int BitsPerCell { get; }

        private ulong _board;

        public BitBoardSolution(int width, int height = 1, int bitsPerCell=1, ulong board = 0L)
        {
            this.Width = width;
            this.Height = height;
            this.BitsPerCell = bitsPerCell;
            _board = board;
        }

        public void TurnOn(int x, int y = 0, int bitInx = 0)
        {
            _board |= BitMaskFor(x, y, bitInx);
        }

        public void TurnOff(int x, int y = 0, int bitInx = 0)
        {
            _board &= ~ BitMaskFor(x, y, bitInx);
        }

        public void Toggle(int x, int y = 0, int bitInx = 0) {
            _board ^= BitMaskFor(x, y, bitInx);
        }

        public bool IsOn(int x, int y = 0, int bitInx = 0) {
            return (_board & BitMaskFor(x, y, bitInx)) != 0;
        }

        public bool IsOff(int x, int y = 0, int bitInx = 0) {
            return ! IsOn(x, y, bitInx);
        }
        public int CountBitsOn() {
            ulong b = _board;
            int count = 0;
            while (b != 0) {
                b &= b - 1UL;
                count++;
            }
            return count;
        }

        private ulong BitMaskFor(int x, int y, int bitInx)
        {
            int cellInx = GetCellInx(x, y);
            return 1UL << (cellInx * BitsPerCell + bitInx);
        }

        private int GetCellInx(int x, int y)
        {
            return (y * Width) + x;
        }

        // public static BitBoard operator &(BitBoard b1, BitBoard b2)
        // {
        //     return NewMixBoard(b1, b2, b1._board & b2._board);
        // }
        // public static BitBoard operator |(BitBoard b1, BitBoard b2)
        // {
        //     return NewMixBoard(b1, b2, b1._board | b2._board);
        // }
        // public static BitBoard operator ^(BitBoard b1, BitBoard b2)
        // {
        //     return NewMixBoard(b1, b2, b1._board ^ b2._board);
        // }
        // public static BitBoard operator ~(BitBoard b)
        // {
        //     return new BitBoard(b.Width, b.Height, b.BitsPerCell, ~b._board);
        // }

        // private static BitBoard NewMixBoard(BitBoard b1, BitBoard b2, ulong board)
        // {
        //     int width = Math.Max(b1.Width, b2.Width);
        //     int height = Math.Max(b1.Height, b2.Height);
        //     int bitsPerCell = Math.Max(b1.BitsPerCell, b2.BitsPerCell);
        //     return new BitBoard(width, height, bitsPerCell, board);
        // }
    }
}