using System;

namespace MarbleGame.Domain
{
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
}