using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Triangle : IShape
    {
        private IColor color;

        public Triangle(IColor color)
        {
            this.color = color;
        }

        public string Draw()
        {
            return $"a {color.Fill()} triangle";
        }
    }
}
