using System;

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
        public MoveDirection[] Play(byte n, WallLocation[] walls, Hole[] holes, Marble[] marbles)
        {
            IBoard board = new Board(n);

            board.AddWalls(walls)
                .AddHoles(holes)
                .AddMarbles(marbles);

            ILiftableBoard liftableBoard = new LiftableBoard(board);

            //liftableBoard.LiftNorthSide().LiftSouthSide()


            byte movesCount = 4;
            for (byte i = 0; i < movesCount; i++)
            {
                MoveDirection moveDirection = (MoveDirection)i;

                // Lift South Side
                var d = MoveNorth(n, walls, holes, marbles);
            }

            return null;
        }

        private bool MoveNorth(byte n, WallLocation[] walls, Hole[] holes, Marble[] marbles)
        {
            foreach (var marbel in marbles)
            {
                //marbel.Location.


            }

            for (int row = n - 1; row >= 0; row--)
            {

            }

            return false;
        }
    }
}