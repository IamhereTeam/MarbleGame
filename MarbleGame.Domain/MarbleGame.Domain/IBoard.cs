namespace MarbleGame.Domain
{
    public interface IBoard
    {
        Square this[byte row, byte column] { get; }
        byte Length { get; }

        IBoard AddWalls(WallLocation[] walls);
        IBoard AddHoles(Hole[] holes);
        IBoard AddMarbles(Marble[] marbles);
        IBoard MoveMarble(byte row, byte col, byte destRow, byte destCol);

        IBoardMemento Save();
        void Restore(IBoardMemento memento);
    }
}