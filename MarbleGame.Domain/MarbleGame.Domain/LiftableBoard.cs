namespace MarbleGame.Domain
{
    public class LiftableBoard : ILiftableBoard
    {
        private readonly IBoard _board;

        public LiftableBoard(IBoard board) : base()
        {
            this._board = board;
        }

        public Square this[byte row, byte column] => _board[row, column];
        public byte Length => _board.Length;

        public IBoard AddHoles(Hole[] holes) => _board.AddHoles(holes);
        public IBoard AddMarbles(Marble[] marbles) => _board.AddMarbles(marbles);
        public IBoard AddWalls(WallLocation[] walls) => _board.AddWalls(walls);
        public IBoard MoveMarble(byte row, byte col, byte destRow, byte destCol) => _board.MoveMarble(row, col, destRow, destCol);
        public IBoardMemento Save() => _board.Save();
        public void Restore(IBoardMemento memento) => _board.Restore(memento);

        public byte LiftNorthSide()
        {
            byte movedMarbles = 0;
            byte last = (byte)(Length - 1);

            for (int i = 0; i < Length - 1; i++)
            {
                for (byte row = last; row > 0; row--)
                {
                    for (byte col = 0; col < Length; col++)
                    {
                        byte upperRow = (byte)(row - 1);
                        if (this[upperRow, col].MarbleAvailable && this[row, col].IsEmpty && !this[upperRow, col].SouthWall)
                        {
                            _board.MoveMarble(upperRow, col, row, col);
                            movedMarbles++;
                        }
                    }
                }
            }

            return movedMarbles;
        }
        public byte LiftEastSide()
        {
            byte movedMarbles = 0;

            for (int i = 0; i < Length - 1; i++)
            {
                for (byte col = 0; col < Length - 1; col++)
                {
                    for (byte row = 0; row < Length; row++)
                    {
                        byte upperCol = (byte)(col + 1);
                        if (this[row, upperCol].MarbleAvailable && this[row, col].IsEmpty && !this[row, upperCol].WesthWall)
                        {
                            _board.MoveMarble(row, upperCol, row, col);
                            movedMarbles++;
                        }
                    }
                }
            }

            return movedMarbles;
        }
        public byte LiftSouthSide()
        {
            byte movedMarbles = 0;

            for (int i = 0; i < Length - 1; i++)
            {
                for (byte row = 0; row < Length - 1; row++)
                {
                    for (byte col = 0; col < Length; col++)
                    {
                        byte upperRow = (byte)(row + 1);
                        if (this[upperRow, col].MarbleAvailable && this[row, col].IsEmpty && !this[upperRow, col].NorthWall)
                        {
                            _board.MoveMarble(upperRow, col, row, col);
                            movedMarbles++;
                        }
                    }
                }
            }

            return movedMarbles;
        }
        public byte LiftWestSide()
        {
            byte movedMarbles = 0;
            byte last = (byte)(Length - 1);

            for (int i = 0; i < Length - 1; i++)
            {
                for (byte col = last; col > 0; col--)
                {
                    for (byte row = 0; row < Length; row++)
                    {
                        byte upperCol = (byte)(col - 1);
                        if (this[upperCol, col].MarbleAvailable && this[row, col].IsEmpty && !this[upperCol, col].SouthWall)
                        {
                            _board.MoveMarble(upperCol, col, row, col);
                            movedMarbles++;
                        }
                    }
                }
            }

            return movedMarbles;
        }

        public GameState GetGameState()
        {
            byte matchCount = 0;
            byte holeCount = 0;

            for (byte row = 0; row < Length; row++)
            {
                for (byte col = 0; col < Length; col++)
                {
                    if (this[row, col].IsHole)
                    {
                        holeCount++;
                        if (!this[row, col].IsEmptyHole)
                        {
                            if (this[row, col].Hole.Id != this[row, col].Hole.Marble.Id)
                            {
                                return GameState.Lost;
                            }
                            else
                            {
                                matchCount++;
                            }
                        }
                    }
                }
            }

            return matchCount == holeCount ? GameState.Won : GameState.None;
        }

        public override string ToString() => _board.ToString();
    }

    public enum GameState : byte
    {
        None,
        Won,
        Lost
    }
}