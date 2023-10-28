using TicTacToe.Models;

namespace TicTacToe.GameObjects
{
    public class Board5 : Board
    {
        private IWinningStrategy winningStrategy;

        public Board5()
        {
            Set(5);
            winningStrategy = new FiveByFiveWinningStrategy();
        }

        public bool IsFiveInRow
        {
            get
            {
                return winningStrategy.IsFiveInRow(Pieces);
            }
        }

        public override bool GameEnded => this.IsFiveInRow;
    }
}
