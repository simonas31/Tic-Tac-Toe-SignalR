using TicTacToe.Interfaces;

namespace TicTacToe.Controllers
{
    public abstract class Decorator: Component
    {
        protected Component wrappee {get; set;}
        public Decorator(Component c)
        {
            wrappee = c;
        }

        public abstract string operation();
        public abstract string specificOperation();
    }
}