namespace MarbleGame.Domain
{
    public interface IBoard
    {
        Square this[byte row, byte column] { get; }

        IBoard AddWalls(WallLocation[] walls);
        IBoard AddHoles(Hole[] holes);
        IBoard AddMarbles(Marble[] marbles);
    }
}
