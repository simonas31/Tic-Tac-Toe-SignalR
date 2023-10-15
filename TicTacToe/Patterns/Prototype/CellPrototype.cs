using TicTacToe.GameObjects;

namespace TicTacToe.Patterns.Prototype
{
    public abstract class CellPrototype
    {
        public abstract Cell Clone();
    }
}
