using TicTacToe.Controllers;
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
