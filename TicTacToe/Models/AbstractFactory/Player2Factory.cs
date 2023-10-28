using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;

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

        public override IComment CreateComment()
        {
            return new Comment("#");
        }
    }
}
