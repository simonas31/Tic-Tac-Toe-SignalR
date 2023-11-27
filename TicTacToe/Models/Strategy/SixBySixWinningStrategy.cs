using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class SixBySixWinningStrategy : IWinningStrategy
    {
        public bool IsSixInRow(Proxy[,] Pieces)
        {
            int rows = Pieces.GetLength(0);
            int cols = Pieces.GetLength(1);

            // Check all rows
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= cols - 6; col++)
                {
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].requestValue()) &&
                        Pieces[row, col + 1].requestValue() == Pieces[row, col + 2].requestValue() &&
                        Pieces[row, col + 2].requestValue() == Pieces[row, col + 3].requestValue() &&
                        Pieces[row, col + 3].requestValue() == Pieces[row, col + 4].requestValue() &&
                        Pieces[row, col + 4].requestValue() == Pieces[row, col + 5].requestValue())
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
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].requestValue()) &&
                        Pieces[row, col].requestValue() == Pieces[row + 1, col].requestValue() &&
                        Pieces[row + 1, col].requestValue() == Pieces[row + 2, col].requestValue() &&
                        Pieces[row + 2, col].requestValue() == Pieces[row + 3, col].requestValue() &&
                        Pieces[row + 3, col].requestValue() == Pieces[row + 4, col].requestValue() &&
                        Pieces[row + 4, col].requestValue() == Pieces[row + 5, col].requestValue())
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
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].requestValue()) &&
                        Pieces[row, col].requestValue() == Pieces[row + 1, col + 1].requestValue() &&
                        Pieces[row + 1, col + 1].requestValue() == Pieces[row + 2, col + 2].requestValue() &&
                        Pieces[row + 2, col + 2].requestValue() == Pieces[row + 3, col + 3].requestValue() &&
                        Pieces[row + 3, col + 3].requestValue() == Pieces[row + 4, col + 4].requestValue() &&
                        Pieces[row + 4, col + 4].requestValue() == Pieces[row + 5, col + 5].requestValue())
                    {
                        return true;
                    }

                    // Check diagonal from upper right to lower left
                    if (Pieces[row, col + 5] != null && !string.IsNullOrWhiteSpace(Pieces[row, col + 5].requestValue()) &&
                        Pieces[row, col + 5].requestValue() == Pieces[row + 1, col + 4].requestValue() &&
                        Pieces[row + 1, col + 4].requestValue() == Pieces[row + 2, col + 3].requestValue() &&
                        Pieces[row + 2, col + 3].requestValue() == Pieces[row + 3, col + 2].requestValue() &&
                        Pieces[row + 3, col + 2].requestValue() == Pieces[row + 4, col + 1].requestValue() &&
                        Pieces[row + 4, col + 1].requestValue() == Pieces[row + 5, col].requestValue())
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public bool IsBoardFull(Proxy[,] Pieces)
        {
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                for (int col = 0; col < Pieces.GetLength(1); col++)
                {
                    if (Pieces[row, col] == null || string.IsNullOrWhiteSpace(Pieces[row, col].requestValue()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsGameOver(Proxy[,] Pieces)
        {
            return IsSixInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsFourInRow(Proxy[,] Pieces)
        {
  
            return false;
        }
        public bool IsFiveInRow(Proxy[,] Pieces)
        {

            return false;
        }
        public bool IsThreeInRow(Proxy[,] Pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
    }
}
