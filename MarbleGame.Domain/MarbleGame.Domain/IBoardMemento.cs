namespace MarbleGame.Domain
{
    public interface IBoardMemento
    {
        Square[,] GetSquares();
        byte GetN();
    }
}
