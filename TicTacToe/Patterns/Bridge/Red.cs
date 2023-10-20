using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Red : IColor
    {
        public string Fill()
        {
            return "red";
        }
    }
}
