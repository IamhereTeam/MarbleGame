using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MarbleGame.Domain
{
    public class MarbleGame
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">the size of the board (2 ≤ N ≤ 40)</param>
        /// <param name="walls">locations of the walls</param>
        /// <param name="holes">locations of the holes</param>
        /// <param name="marbles">locations of the marbles</param>
        /// <returns>She minimal number of moves to win the game</returns>
        public string Play(byte n, WallLocation[] walls, Hole[] holes, Marble[] marbles)
        {
            IBoard board = new Board(n);

            Debug.WriteLine(board.ToString());

            board.AddWalls(walls)
                .AddHoles(holes)
                .AddMarbles(marbles);

            Debug.WriteLine(board.ToString());

            ILiftableBoard liftableBoard = new LiftableBoard(board);
            Caretaker caretaker = new Caretaker(liftableBoard);

            var result = Do(liftableBoard, caretaker, "");

            Debug.WriteLine(result);

            return result;
        }

        private string Do(ILiftableBoard board, Caretaker caretaker, string s)
        {
            Debug.WriteLine(board.ToString());
            caretaker.Backup();

            var movedMarbles = board.LiftNorthSide();
            Debug.WriteLine(board.ToString());

            if (movedMarbles > 0)
            {
                var gameState = board.GetGameState();

                if (gameState == GameState.Won)
                {
                    s += "N_Won" + Environment.NewLine;
                    caretaker.Undo();
                    return s;
                }
                else if (gameState == GameState.Lost)
                {
                    //s += "N_Lost" + Environment.NewLine;
                    //caretaker.Undo();
                    //return s;
                }
                else if (gameState == GameState.None)
                {
                    s += "N" + Do(board, caretaker, s);
                }
            }
            Debug.WriteLine(board.ToString());

            caretaker.Undo();
            caretaker.Backup();
            Debug.WriteLine(board.ToString());

            if (board.LiftEastSide() > 0)
            {
                Debug.WriteLine(board.ToString());
                var gameState = board.GetGameState();

                if (gameState == GameState.Won)
                {
                    s += "E_Won" + Environment.NewLine;
                    caretaker.Undo();
                    return s;
                }
                else if (gameState == GameState.Lost)
                {
                    //s += "E_Lost" + Environment.NewLine;
                    //caretaker.Undo();
                    //return s;
                }
                else if (gameState == GameState.None)
                {
                    s += "E" + Do(board, caretaker, s);
                }
            }

            Debug.WriteLine(board.ToString());

            caretaker.Undo();
            caretaker.Backup();
            Debug.WriteLine(board.ToString());

            if (board.LiftSouthSide() > 0)
            {
                Debug.WriteLine(board.ToString());
                var gameState = board.GetGameState();

                if (gameState == GameState.Won)
                {
                    s += "S_Won" + Environment.NewLine;
                    caretaker.Undo();
                    return s;
                }
                else if (gameState == GameState.Lost)
                {
                    //s += "S_Lost" + Environment.NewLine;
                    //caretaker.Undo();
                    //return s;
                }
                else if (gameState == GameState.None)
                {
                    s += "S" + Do(board, caretaker, s);
                }
            }
            Debug.WriteLine(board.ToString());

            caretaker.Undo();
            caretaker.Backup();
            Debug.WriteLine(board.ToString());

            if (board.LiftWestSide() > 0)
            {
                Debug.WriteLine(board.ToString());
                var gameState = board.GetGameState();

                if (gameState == GameState.Won)
                {
                    s += "W_Won" + Environment.NewLine;
                    caretaker.Undo();
                    return s;
                }
                else if (gameState == GameState.Lost)
                {
                    //s += "W_Lost" + Environment.NewLine;
                    //caretaker.Undo();
                    //return s;
                }
                else if (gameState == GameState.None)
                {
                    s += "W" + Do(board, caretaker, s);
                }
            }
            Debug.WriteLine(board.ToString());

            caretaker.Undo();
            Debug.WriteLine(board.ToString());

            return " -- 0 -- ";
        }
    }
}