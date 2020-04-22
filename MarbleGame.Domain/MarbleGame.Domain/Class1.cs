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
            Board board = new Board(n);
            board.AddWalls(walls);
            board.AddHoles(holes);
            board.AddMarbles(marbles);

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

    public class Board
    {
        private readonly byte _n;
        private Square[,] _squares;

        public Board(byte n)
        {
            this._n = n;
            InitSquares();
        }
        public Square this[byte row, byte column] => _squares[row, column];

        public void AddWalls(WallLocation[] walls)
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
        }

        internal void AddHoles(Hole[] holes)
        {
            foreach (var hole in holes)
            {
                _squares[hole.Location.Row, hole.Location.Column].Hole = hole;
            }
        }

        internal void AddMarbles(Marble[] marbles)
        {
            foreach (var marble in marbles)
            {
                _squares[marble.Location.Row, marble.Location.Column].Marble = marble;
            }
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
    }

    public struct Square
    {
        public Square(byte row, byte column, bool northWall, bool eastWall, bool southWall, bool westhWall)
        {
            Location = new Location(row, column);
            NorthWall = northWall;
            EastWall = eastWall;
            SouthWall = southWall;
            WesthWall = westhWall;
            Marble = null;
            Hole = null;
        }

        public Location Location { get; set; }
        public Marble? Marble { get; set; }
        public Hole? Hole { get; set; }

        public bool NorthWall { get; set; }
        public bool EastWall { get; set; }
        public bool SouthWall { get; set; }
        public bool WesthWall { get; set; }
    }

    public struct Marble
    {
        public Marble(byte id, byte row, byte column)
        {
            Id = id;
            Location = new Location(row, column);
        }
        public byte Id { get; set; }
        public Location Location { get; set; }
    }

    public struct Hole
    {
        public Hole(byte id, byte row, byte column)
        {
            Id = id;
            Location = new Location(row, column);
        }
        public byte Id { get; set; }
        public Location Location { get; set; }
    }

    public struct Location
    {
        public Location(byte row, byte column)
        {
            Row = row;
            Column = column;
        }

        public byte Row { get; set; }
        public byte Column { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return obj is Location location && Row == location.Row && Column == location.Column;
            }
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Location left, Location right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }
    }

    public struct WallLocation
    {
        public WallLocation(Location square1, Location square2)
        {
            if (!IsValidWall(square1, square2))
            {
                throw new ArgumentOutOfRangeException("Wrong wall location");
            }

            Square1 = square1;
            Square2 = square2;
        }

        public Location Square1 { get; set; }
        public Location Square2 { get; set; }

        private static bool IsValidWall(Location square1, Location square2)
        {
            bool isValidWall = false;

            if (square1.Row == square2.Row)
            {
                isValidWall = Math.Abs(square1.Column - square2.Column) == 1;
            }
            else if (square1.Column == square2.Column)
            {
                isValidWall = Math.Abs(square1.Row - square2.Row) == 1;
            }

            return isValidWall;
        }
    }

    public enum MoveDirection : byte
    {
        North,
        East,
        South,
        West
    }
}
