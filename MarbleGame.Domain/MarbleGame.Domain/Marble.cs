namespace MarbleGame.Domain
{
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
}
