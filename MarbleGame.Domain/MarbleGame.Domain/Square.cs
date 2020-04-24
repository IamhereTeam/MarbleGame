using System;

namespace MarbleGame.Domain
{
    public class Square : ICloneable
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
        public Marble Marble { get; set; }
        public Hole Hole { get; set; }

        public bool NorthWall { get; set; }
        public bool EastWall { get; set; }
        public bool SouthWall { get; set; }
        public bool WesthWall { get; set; }

        public bool IsEmpty => this.Marble == null;
        public bool IsHole => this.Hole != null;
        public bool IsEmptyHole => this.Hole != null && this.Hole.IsEmpty;
        public bool MarbleAvailable => this.Marble != null;

        public object Clone()
        {
            return new Square(Location.Row, Location.Column, NorthWall, EastWall, SouthWall, WesthWall)
            {
                Marble = (Marble)Marble?.Clone(),
                Hole = (Hole)Hole?.Clone()
            };
        }
    }
}