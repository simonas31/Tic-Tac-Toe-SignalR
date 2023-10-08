namespace TicTacToe.Models
{
    public class Cell
    {
        public string Value { get; private set;}

        public Cell(string value)
        {
            Value = value;
        }

        public void Set(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}