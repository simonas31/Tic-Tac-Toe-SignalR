using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Blue : IColor
    {
        public string Fill()
        {
            return "blue";
        }
    }
}
