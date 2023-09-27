namespace TicTacToe.Models
{
    public class Piece
    {
        public string Value { get; }

        public Piece(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
