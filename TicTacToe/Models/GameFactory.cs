using System.IO.Pipelines;
using TicTacToe.Models;

public abstract class GameFactory
{
    public abstract Piece CreatePiece(Player player);
    public abstract Obstacle CreateObstacle();
}