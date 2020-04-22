namespace MarbleGame.Domain
{
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
}