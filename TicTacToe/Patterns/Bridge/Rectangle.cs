using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Rectangle : IShape
    {
        private IColor color;

        public Rectangle(IColor color)
        {
            this.color = color;
        }

        public string Draw()
        {
            return $"a {color.Fill()} rectangle";
        }
    }
}
