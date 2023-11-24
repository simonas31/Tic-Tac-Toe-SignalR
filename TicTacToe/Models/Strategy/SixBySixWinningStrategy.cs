using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class SixBySixWinningStrategy : IWinningStrategy
    {
        public bool IsSixInRow(ICell[,] Pieces)
        {
            int rows = Pieces.GetLength(0);
            int cols = Pieces.GetLength(1);

            // Check all rows
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= cols - 6; col++)
                {
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].Value) &&
                        Pieces[row, col].Value == Pieces[row, col + 1].Value &&
                        Pieces[row, col + 1].Value == Pieces[row, col + 2].Value &&
                        Pieces[row, col + 2].Value == Pieces[row, col + 3].Value &&
                        Pieces[row, col + 3].Value == Pieces[row, col + 4].Value &&
                        Pieces[row, col + 4].Value == Pieces[row, col + 5].Value)
                    {
                        return true;
                    }
                }
            }

            // Check all columns
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row <= rows - 6; row++)
                {
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].Value) &&
                        Pieces[row, col].Value == Pieces[row + 1, col].Value &&
                        Pieces[row + 1, col].Value == Pieces[row + 2, col].Value &&
                        Pieces[row + 2, col].Value == Pieces[row + 3, col].Value &&
                        Pieces[row + 3, col].Value == Pieces[row + 4, col].Value &&
                        Pieces[row + 4, col].Value == Pieces[row + 5, col].Value)
                    {
                        return true;
                    }
                }
            }

            // Check diagonals
            for (int row = 0; row <= rows - 6; row++)
            {
                for (int col = 0; col <= cols - 6; col++)
                {
                    // Check diagonal from upper left to lower right
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].Value) &&
                        Pieces[row, col].Value == Pieces[row + 1, col + 1].Value &&
                        Pieces[row + 1, col + 1].Value == Pieces[row + 2, col + 2].Value &&
                        Pieces[row + 2, col + 2].Value == Pieces[row + 3, col + 3].Value &&
                        Pieces[row + 3, col + 3].Value == Pieces[row + 4, col + 4].Value &&
                        Pieces[row + 4, col + 4].Value == Pieces[row + 5, col + 5].Value)
                    {
                        return true;
                    }

                    // Check diagonal from upper right to lower left
                    if (Pieces[row, col + 5] != null && !string.IsNullOrWhiteSpace(Pieces[row, col + 5].Value) &&
                        Pieces[row, col + 5].Value == Pieces[row + 1, col + 4].Value &&
                        Pieces[row + 1, col + 4].Value == Pieces[row + 2, col + 3].Value &&
                        Pieces[row + 2, col + 3].Value == Pieces[row + 3, col + 2].Value &&
                        Pieces[row + 3, col + 2].Value == Pieces[row + 4, col + 1].Value &&
                        Pieces[row + 4, col + 1].Value == Pieces[row + 5, col].Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public bool IsBoardFull(ICell[,] Pieces)
        {
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                for (int col = 0; col < Pieces.GetLength(1); col++)
                {
                    if (Pieces[row, col] == null || string.IsNullOrWhiteSpace(Pieces[row, col].Value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsGameOver(ICell[,] Pieces)
        {
            return IsSixInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsFourInRow(ICell[,] Pieces)
        {
  
            return false;
        }
        public bool IsFiveInRow(ICell[,] Pieces)
        {

            return false;
        }
        public bool IsThreeInRow(ICell[,] Pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
    }
}
