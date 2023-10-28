using TicTacToe.GameObjects;
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
