namespace MarbleGame.Domain
{
    public interface ILiftableBoard : IBoard
    {
        byte LiftNorthSide();
        byte LiftEastSide();
        byte LiftSouthSide();
        byte LiftWestSide();

        GameState GetGameState();
    }
}
