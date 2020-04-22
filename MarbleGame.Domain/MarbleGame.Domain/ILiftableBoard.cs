namespace MarbleGame.Domain
{
    public interface ILiftableBoard : IBoard
    {
        ILiftableBoard LiftNorthSide();
        ILiftableBoard LiftEastSide();
        ILiftableBoard LiftSouthSide();
        ILiftableBoard LiftWestSide();
    }
}
