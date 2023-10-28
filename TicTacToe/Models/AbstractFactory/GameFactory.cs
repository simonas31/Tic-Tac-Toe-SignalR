
using TicTacToe.GameObjects;
using TicTacToe.Controllers;
using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;


public abstract class GameFactory
{
    public abstract Decorator CreatePiece(Player player);
    public abstract Obstacle CreateObstacle();
    public abstract IComment CreateComment();
}