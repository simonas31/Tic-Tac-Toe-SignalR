<<<<<<< HEAD:TicTacToe/Models/AbstractFactory/GameFactory.cs
﻿using TicTacToe.GameObjects;
using TicTacToe.Controllers;

public abstract class GameFactory
{
    public abstract Decorator CreatePiece(Player player);
    public abstract Obstacle CreateObstacle();
=======
﻿using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

public interface GameFactory
{
    public IPiece CreatePiece(Player player);
    public IObstacle CreateObstacle();

    public IComment CreateComment();
>>>>>>> main:TicTacToe/Models/GameFactory.cs
}