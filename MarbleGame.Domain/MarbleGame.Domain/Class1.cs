using System.Collections.Generic;

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

            board.AddWalls(walls)
                .AddHoles(holes)
                .AddMarbles(marbles);

            ILiftableBoard liftableBoard = new LiftableBoard(board);

            var s = Do(liftableBoard);

            return s;
        }

        private string Do(ILiftableBoard liftableBoard)
        {
            var liftNorthResult = liftableBoard.LiftNorthSide();

            if (liftNorthResult.GameState == GameState.Moved)
            {
                return "N" + Do(liftNorthResult);
            }
            else if (liftNorthResult.GameState == GameState.Won)
            {
                return "N";
            }
            // if None or Lost lift another side

            var liftEastResult = liftableBoard.LiftEastSide();

            if (liftEastResult.GameState == GameState.Moved)
            {
                return "E" + Do(liftEastResult);
            }
            else if (liftEastResult.GameState == GameState.Won)
            {
                return "E";
            }

            var liftSouthResult = liftableBoard.LiftSouthSide();

            if (liftSouthResult.GameState == GameState.Moved)
            {
                return "S" + Do(liftSouthResult);
            }
            else if (liftSouthResult.GameState == GameState.Won)
            {
                return "S";
            }

            var liftWestResult = liftableBoard.LiftWestSide();

            if (liftWestResult.GameState == GameState.Moved)
            {
                return "W" + Do(liftWestResult);
            }
            else if (liftWestResult.GameState == GameState.Won)
            {
                return "W";
            }

            return "0";
        }
    }
}