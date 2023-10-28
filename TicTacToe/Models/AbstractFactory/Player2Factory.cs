<<<<<<< HEAD:TicTacToe/Models/AbstractFactory/Player2Factory.cs
﻿using TicTacToe.Controllers;
using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class Player2Factory : GameFactory
    {
        public override Obstacle CreateObstacle()
        {
            return new Obstacle("B");
        }

        public override Decorator CreatePiece(Player player)
        {
            return new ConcreteDecoratorO(new O("O"));
        }
    }
}
=======
﻿using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class Player2Factory : GameFactory
    {
        public IObstacle CreateObstacle()
        {
            return new Obstacle("B");
        }

        public IPiece CreatePiece(Player player)
        {
            return new Piece("O");
        }

        public IComment CreateComment()
        {
            return new Comment("#");
        }
    }
}
>>>>>>> main:TicTacToe/Models/Player2Factory.cs
