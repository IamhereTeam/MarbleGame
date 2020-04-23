namespace MarbleGame.Domain
{
    public struct Hole
    {
        public Hole(byte id, byte row, byte column)
        {
            Id = id;
            Location = new Location(row, column);
            Marble = null;
        }
        public byte Id { get; set; }
        public Location Location { get; set; }

        public Marble? Marble { get; set; }

        public void AddMarble(Marble marble)
        {
            this.Marble = marble;
        }
        public bool IsEmpty=> !this.Marble.HasValue;
    }
}