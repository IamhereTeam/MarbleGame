using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarbleGame.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGame.Domain.Tests
{
    [TestClass()]
    public class MarbleGameTests
    {
        [TestMethod()]
        public void PlayTest()
        {
            Square square = new Square(2, 2, true, true, true, true);
            Square[,] _squares = new Square[2, 2];
            _squares[0, 0] = square;

            Square[,] _squares2 = (Square[,])_squares.Clone();

            _squares[1, 1] = square;

            // the size of the board (2 ≤ N ≤ 40) 
            byte N = 4;
            // the number of marbles (M > 0)
            byte M = 3;
            // the number of walls
            byte W = 1;

            // locations of the marbles
            Marble[] marbles = new Marble[] { new Marble(1, 0, 1), new Marble(2, 1, 0), new Marble(3, 1, 2) };

            // locations of the holes
            Hole[] holes = new Hole[] { new Hole(1, 2, 3), new Hole(2, 2, 1), new Hole(3, 3, 2) };

            WallLocation[] walls = new WallLocation[] { new WallLocation(new Location(1, 1), new Location(1, 2)) };

            MarbleGame game = new MarbleGame();

            var result = game.Play(N, walls, holes, marbles);

            Assert.Fail();
        }
    }
}