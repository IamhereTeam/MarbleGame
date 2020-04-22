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

        public IBoard AddHoles(Hole[] holes) => _board.AddHoles(holes);
        public IBoard AddMarbles(Marble[] marbles) => _board.AddMarbles(marbles);
        public IBoard AddWalls(WallLocation[] walls) => _board.AddWalls(walls);

        public ILiftableBoard LiftNorthSide()
        {
            return this;
        }
        public ILiftableBoard LiftEastSide()
        {
            return this;
        }
        public ILiftableBoard LiftSouthSide()
        {
            return this;
        }
        public ILiftableBoard LiftWestSide()
        {
            return this;
        }
    }
}