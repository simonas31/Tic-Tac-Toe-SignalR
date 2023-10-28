<<<<<<< HEAD:TicTacToe/Models/AbstractFactory/Player1Factory.cs
﻿using TicTacToe.Controllers;
using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class Player1Factory : GameFactory
    {
        public override Obstacle CreateObstacle()
        {
            return new Obstacle("W");
        }

        public override Decorator CreatePiece(Player player)
        {
            return new ConcreteDecoratorX(new X("X"));
        }
    }
}
=======
﻿using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class Player1Factory : GameFactory
    {
        public IObstacle CreateObstacle()
        {
            return new Obstacle("W");
        }

        public IPiece CreatePiece(Player player)
        {
            return new Piece("X");
        }

        public IComment CreateComment()
        {
            return new Comment("#");
        }
    }
}
>>>>>>> main:TicTacToe/Models/Player1Factory.cs
