namespace MarbleGame.Domain
{
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
}