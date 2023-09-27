namespace TicTacToe.Models
{
    public class Obstacle
    {
        public string Value { get; }

        public Obstacle(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
