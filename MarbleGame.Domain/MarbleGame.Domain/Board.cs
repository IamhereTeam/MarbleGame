using System;

namespace MarbleGame.Domain
{
    public class Board : IBoard
    {
        private byte _n;
        private Square[,] _squares;

        public byte Length => _n;

        public Board(byte n)
        {
            this._n = n;
            InitSquares();
        }

        public Square this[byte row, byte column] => _squares[row, column];

        public IBoard AddWalls(WallLocation[] walls)
        {
            foreach (var wall in walls)
            {
                if (wall.Square1.Row == wall.Square2.Row)
                {
                    if (wall.Square1.Column < wall.Square2.Column)
                    {
                        _squares[wall.Square1.Row, wall.Square1.Column].EastWall = true;
                        _squares[wall.Square2.Row, wall.Square2.Column].WesthWall = true;
                    }
                    else
                    {
                        _squares[wall.Square1.Row, wall.Square1.Column].WesthWall = true;
                        _squares[wall.Square2.Row, wall.Square2.Column].EastWall = true;
                    }
                }
                else if (wall.Square1.Column == wall.Square2.Column)
                {
                    if (wall.Square1.Row < wall.Square2.Row)
                    {
                        _squares[wall.Square1.Row, wall.Square1.Column].SouthWall = true;
                        _squares[wall.Square2.Row, wall.Square2.Column].NorthWall = true;
                    }
                    else
                    {
                        _squares[wall.Square1.Row, wall.Square1.Column].NorthWall = true;
                        _squares[wall.Square2.Row, wall.Square2.Column].SouthWall = true;
                    }
                }
            }
            return this;
        }

        public IBoard AddHoles(Hole[] holes)
        {
            foreach (var hole in holes)
            {
                _squares[hole.Location.Row, hole.Location.Column].Hole = hole;
            }
            return this;
        }

        public IBoard AddMarbles(Marble[] marbles)
        {
            foreach (var marble in marbles)
            {
                _squares[marble.Location.Row, marble.Location.Column].Marble = marble;
            }
            return this;
        }

        private void InitSquares()
        {
            this._squares = new Square[_n, _n];
            for (byte row = 0; row < _n; row++)
            {
                for (byte col = 0; col < _n; col++)
                {
                    _squares[row, col] = new Square(row, col, row == 0, col == _n - 1, row == _n - 1, col == 0);
                }
            }
        }

        public IBoard MoveMarble(byte row, byte col, byte destRow, byte destCol)
        {
            if (_squares[destRow, destCol].IsHole)
            {
                _squares[destRow, destCol].Hole.Value.AddMarble(_squares[row, col].Marble.Value);
            }
            else
            {
                _squares[destRow, destCol].Marble = _squares[row, col].Marble;
            }
            _squares[row, col].Marble = null;

            return this;
        }


        public IBoardMemento Save()
        {
            return new BoardMemento(this._squares, this._n);
        }

        public void Restore(IBoardMemento memento)
        {
            if (!(memento is BoardMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this._squares = memento.GetSquares();
            this._n = memento.GetN();
        }
    }
}