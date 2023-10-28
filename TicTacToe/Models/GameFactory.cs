using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

public interface GameFactory
{
    public IPiece CreatePiece(Player player);
    public IObstacle CreateObstacle();

    public IComment CreateComment();
}