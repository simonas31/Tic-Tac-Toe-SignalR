using TicTacToe.GameObjects;
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
