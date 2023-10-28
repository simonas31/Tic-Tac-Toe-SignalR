﻿using TicTacToe.Models.DecoratorPattern;
using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

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

        public override IComment CreateComment()
        {
            return new Comment("#");
        }
    }
}