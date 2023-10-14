using TicTacToe.Models;

public interface IWinningStrategy
{
    bool IsThreeInRow(Cell[,] pieces); // For 3x3 board
    bool IsFourInRow(Cell[,] pieces);  // For 4x4 board
}
