using Component = TicTacToe.Interfaces.Component;

namespace TicTacToe.GameObjects
{
    public class X : Piece, Component
    {
        public X(string value) : base(value)
        {

        }

        public string operation()
        {
            return base.Value;
        }
    }
}