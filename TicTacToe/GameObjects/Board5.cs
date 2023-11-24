using TicTacToe.Models.Strategy;

namespace TicTacToe.GameObjects
{
    public class Board5 : Board
    {
        private IWinningStrategy winningStrategy;

        // Constructor modified to use CellFactory
        public Board5(CellFactory cellFactory) : base(cellFactory)
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

        public override bool GameEnded
        {
            get
            {
                return this.winningStrategy.IsFiveInRow(Pieces);
            }
        }
    }
}
