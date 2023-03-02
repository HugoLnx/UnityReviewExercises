using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Math4GamedevBitOperations;

public class BitboardTests
{
    public IBitBoard BuildBitBoard(int width, int height = 1, int bitsPerCell=1, ulong board = 0L)
    {
        //return new BitBoard(width, height, bitsPerCell, board);
        return new BitBoardSolution(width, height, bitsPerCell, board);
    }

    [Category("1D Bitboard")]
    [Test]
    public void Test_Board1D_OnOff()
    {
        IBitBoard board = BuildBitBoard(5);
        int inx = 4;

        Assert.IsTrue(board.IsOff(inx));
        board.TurnOn(inx);
        Assert.IsTrue(board.IsOn(inx));
        board.TurnOff(inx);
        Assert.IsTrue(board.IsOff(inx));
    }

    [Category("1D Bitboard")]
    [Test]
    public void Test_Board1D_Toggle()
    {
        IBitBoard board = BuildBitBoard(5);
        int inx = 4;

        Assert.IsTrue(board.IsOff(inx));
        board.Toggle(inx);
        Assert.IsTrue(board.IsOn(inx));
        board.Toggle(inx);
        Assert.IsTrue(board.IsOff(inx));
    }

    [Category("1D Bitboard")]
    [Test]
    public void Test_Board1D_CountOnBits()
    {
        IBitBoard board = BuildBitBoard(5);

        board.TurnOn(0);
        board.TurnOn(3);
        board.TurnOn(4);

        Assert.AreEqual(3, board.CountBitsOn());
    }

    [Category("2D Bitboard")]
    [Test]
    public void Test_Board2D_OnOff()
    {
        IBitBoard board = BuildBitBoard(4, 4);

        var x = 1;
        var y = 3;

        Assert.IsTrue(board.IsOff(x, y));
        board.TurnOn(x, y);
        Assert.IsTrue(board.IsOn(x, y));
        board.TurnOff(x, y);
        Assert.IsTrue(board.IsOff(x, y));
    }

    [Category("2D Bitboard")]
    [Test]
    public void Test_Board2D_Toggle()
    {
        IBitBoard board = BuildBitBoard(4, 4);

        var x = 1;
        var y = 3;

        Assert.IsTrue(board.IsOff(x, y));
        board.Toggle(x, y);
        Assert.IsTrue(board.IsOn(x, y));
        board.Toggle(x, y);
        Assert.IsTrue(board.IsOff(x, y));
    }

    [Category("2D Bitboard")]
    [Test]
    public void Test_Board2D_CountOnBits()
    {
        IBitBoard board = BuildBitBoard(4, 4);

        board.TurnOn(0, 2);
        board.TurnOn(3, 1);
        board.TurnOn(1, 2);
        board.TurnOn(2, 3);
        board.TurnOn(3, 3);

        Assert.AreEqual(5, board.CountBitsOn());
    }

    [Category("3D Bitboard")]
    [Test]
    public void Test_Board3D_OnOff()
    {
        IBitBoard board = BuildBitBoard(4, 7, 9);

        var x = 1;
        var y = 6;
        var z = 7;

        Assert.IsTrue(board.IsOff(x, y, z));
        board.TurnOn(x, y, z);
        Assert.IsTrue(board.IsOn(x, y, z));
        board.TurnOff(x, y, z);
        Assert.IsTrue(board.IsOff(x, y, z));
    }

    [Category("3D Bitboard")]
    [Test]
    public void Test_Board3D_Toggle()
    {
        IBitBoard board = BuildBitBoard(7, 9, 4);

        var x = 6;
        var y = 7;
        var z = 3;

        Assert.IsTrue(board.IsOff(x, y, z));
        board.Toggle(x, y, z);
        Assert.IsTrue(board.IsOn(x, y, z));
        board.Toggle(x, y, z);
        Assert.IsTrue(board.IsOff(x, y, z));
    }

    [Category("3D Bitboard")]
    [Test]
    public void Test_Board3D_CountOnBits()
    {
        IBitBoard board = BuildBitBoard(9, 4, 7);

        board.TurnOn(0, 3, 6);
        board.TurnOn(2, 1, 4);
        board.TurnOn(4, 2, 0);
        board.TurnOn(6, 0, 1);
        board.TurnOn(8, 5, 2);
        board.TurnOn(3, 3, 3);

        Assert.AreEqual(6, board.CountBitsOn());
    }
}