using System;

namespace MarbleGame.Domain
{
    public class Marble : ICloneable
    {
        public Marble(byte id, byte row, byte column)
        {
            Id = id;
            Location = new Location(row, column);
        }

        public byte Id { get; set; }
        public Location Location { get; set; }

        public object Clone()
        {
            return new Marble(Id, Location.Row, Location.Column);
        }
    }
}
