using System;

namespace MarbleGame.Domain
{
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
}