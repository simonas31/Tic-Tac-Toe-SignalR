using TicTacToe.Interfaces;


namespace TicTacToe.Patterns.Bridge
{
    public class Square : IShape
    {
        private IColor color;

        public Square(IColor color)
        {
            this.color = color;
        }

        public string Draw()
        {
            return $"a {color.Fill()} square";
        }
    }
}
