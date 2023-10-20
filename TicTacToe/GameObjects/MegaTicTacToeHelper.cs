using TicTacToe.GameObjects;
using TicTacToe.Models;

public class MegaTicTacToeHelper
{
    private readonly ThreeByThreeWinningStrategy _strategy;
    private readonly Cell[,] _megaBoard;

    public Cell[,] BoardState => _megaBoard;

    public MegaTicTacToeHelper(Cell[,] megaBoard)
    {
        if (megaBoard.GetLength(0) != 9 || megaBoard.GetLength(1) != 9)
            throw new ArgumentException("The board must be 9x9.");

        _strategy = new ThreeByThreeWinningStrategy();
        _megaBoard = megaBoard;
    }

    private Cell[,] ExtractSubBoard(int rowOffset, int colOffset)
    {
        Cell[,] subBoard = new Cell[3, 3];
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                subBoard[row, col] = _megaBoard[row + rowOffset, col + colOffset];
            }
        }
        return subBoard;
    }

    public bool IsGameOver()
    {
        Cell[,] megaResultBoard = new Cell[3, 3];

        // Check each 3x3 board and set the result in megaResultBoard
        for (int megaRow = 0; megaRow < 3; megaRow++)
        {
            for (int megaCol = 0; megaCol < 3; megaCol++)
            {
                Cell[,] subBoard = ExtractSubBoard(megaRow * 3, megaCol * 3);
                if (_strategy.IsGameOver(subBoard))
                {
                    Cell winner = new Cell();
                    winner.Value = _strategy.IsThreeInRow(subBoard) ? subBoard[1, 1].Value : "";
                    megaResultBoard[megaRow, megaCol] = winner;
                }
                else
                {
                    megaResultBoard[megaRow, megaCol] = new Cell(); // empty cell
                }
            }
        }

        // Now, use the ThreeByThreeWinningStrategy to check the megaResultBoard
        return _strategy.IsGameOver(megaResultBoard);
    }

    public bool MakeMove(int row, int col, string player)
    {
        if (string.IsNullOrWhiteSpace(player) || (player != "X" && player != "O"))
            throw new ArgumentException("Invalid player. Only 'X' or 'O' allowed.");

        if (_megaBoard[row, col] == null || string.IsNullOrWhiteSpace(_megaBoard[row, col].Value))
        {
            _megaBoard[row, col] = new Cell { Value = player };
            return true; // Move was successful
        }
        return false; // Cell already occupied
    }
}
