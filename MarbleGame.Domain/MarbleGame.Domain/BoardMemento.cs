namespace MarbleGame.Domain
{
    internal class BoardMemento : IBoardMemento
    {
        private readonly byte _n;
        private Square[,] _squares;

        public BoardMemento(Square[,] state, byte n)
        {
            this._n = n;
            this._squares = new Square[n, n];//(Square[,])state.Clone();

            for (int row = 0; row < _n; row++)
            {
                for (int col = 0; col < _n; col++)
                {

                    this._squares[row, col] = (Square)state[row, col].Clone();
                }
            }
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