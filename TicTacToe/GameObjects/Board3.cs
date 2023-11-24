using TicTacToe.Models;

namespace TicTacToe.GameObjects;


public class Board3 : Board
{
    private IWinningStrategy winningStrategy;

    public Board3(CellFactory cellFactory) : base(cellFactory)
    {
        Set(3);
        winningStrategy = new ThreeByThreeWinningStrategy();
    }

    public bool IsThreeInRow
    {
        get
        {
            return winningStrategy.IsThreeInRow(Pieces);
        }
    }

    public override bool GameEnded => this.IsThreeInRow;
}