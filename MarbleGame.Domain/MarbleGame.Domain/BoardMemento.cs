namespace MarbleGame.Domain
{
    internal class BoardMemento : IBoardMemento
    {
        private readonly byte _n;
        private Square[,] _squares;

        public BoardMemento(Square[,] state, byte n)
        {
            this._n = n;
            this._squares = state;
        }

        public Square[,] GetSquares()
        {
            return this._squares;
        }
        public byte GetN()
        {
            return this._n;
        }
    }
}