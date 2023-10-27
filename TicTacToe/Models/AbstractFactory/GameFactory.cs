using TicTacToe.GameObjects;
using TicTacToe.Controllers;

public abstract class GameFactory
{
    public abstract Decorator CreatePiece(Player player);
    public abstract Obstacle CreateObstacle();
}