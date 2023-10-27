using TicTacToe.Controllers;
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
