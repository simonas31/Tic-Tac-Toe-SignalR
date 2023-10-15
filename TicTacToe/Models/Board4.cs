namespace TicTacToe.Models
{
    public class Board4 : Board
    {
        private IWinningStrategy winningStrategy;

        public Board4()
        {
            Set(4);
            winningStrategy = new FourByFourWinningStrategy();
        }

        public bool IsFourInRow
        {
            get
            {
                return winningStrategy.IsFourInRow(Pieces);
            }
        }
    }
}