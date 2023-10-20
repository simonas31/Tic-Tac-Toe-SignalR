using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Green : IColor
    {
        public string Fill()
        {
            return "green";
        }
    }
}
