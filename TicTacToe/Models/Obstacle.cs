namespace TicTacToe.Models
{
    public class Obstacle : Cell
    {
        public string Value { get; }

        public Obstacle(string value) : base(value)
        {
            Set(value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
