using System;

namespace MarbleGame.Domain
{
    public class Hole : ICloneable
    {
        public Hole(byte id, byte row, byte column)
        {
            Id = id;
            Location = new Location(row, column);
            Marble = null;
        }
        public byte Id { get; set; }
        public Location Location { get; set; }

        public Marble Marble { get; set; }

        public void AddMarble(Marble marble)
        {
            this.Marble = marble;
        }

        public object Clone()
        {
            return new Hole(Id, Location.Row, Location.Column)
            {
                Marble = (Marble)Marble?.Clone()
            };
        }

        public bool IsEmpty => this.Marble == null;
    }
}