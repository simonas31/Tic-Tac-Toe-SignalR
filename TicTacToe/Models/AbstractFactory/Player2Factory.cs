
using TicTacToe.Interfaces;
using TicTacToe.Controllers;
using TicTacToe.GameObjects;
using TicTacToe.Models.DecoratorPattern;
using TicTacToe.Models.Flyweight;

namespace TicTacToe.Models
{
    public class Player2Factory : GameFactory
    {
        public override Obstacle CreateObstacle()
        {
            return new Obstacle("B");
        }

        public override Piece CreatePiece(Player player)
        {
            return PieceFactory.GetPiece("O");
        }

        public override IComment CreateComment()
        {
            return new Comment("#");
        }
    }
}
