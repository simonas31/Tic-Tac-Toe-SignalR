using TicTacToe.GameObjects;

public interface IWinningStrategy
{
    bool IsThreeInRow(ICell[,] Pieces); // For 3x3 board
    bool IsFourInRow(ICell[,] Pieces);  // For 4x4 board
    bool IsFiveInRow(ICell[,] Pieces);  // For 5x5 board
    bool IsSixInRow(ICell[,] Pieces);  // For 6x6 board
}
