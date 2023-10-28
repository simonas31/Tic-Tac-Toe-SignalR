using TicTacToe.Interfaces;

namespace TicTacToe.GameObjects
{
    public class Piece : Cell, IPiece
    {

        public Piece(string value) : base(value)
        {
            Set(value);
        }

        public override string ToString()
        {
            return Value;
        }

        public string getStatus()
        {
            return "piece";
        }

        public string Move()
        {
            return "I Move";
        }
    }
}
