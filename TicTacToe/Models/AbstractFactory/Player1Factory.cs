
using TicTacToe.Controllers;
using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;

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

