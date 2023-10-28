using TicTacToe.GameObjects;

namespace TicTacToe.Models.Strategy
{
    public class FiveByFiveWinningStrategy : IWinningStrategy
    {
        public bool IsFiveInRow(Cell[,] Pieces)
        {
            int rows = Pieces.GetLength(0);
            int cols = Pieces.GetLength(1);

            // Check all rows
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= cols - 5; col++)
                {
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].Value) &&
                        Pieces[row, col].Value == Pieces[row, col + 1].Value &&
                        Pieces[row, col + 1].Value == Pieces[row, col + 2].Value &&
                        Pieces[row, col + 2].Value == Pieces[row, col + 3].Value &&
                        Pieces[row, col + 3].Value == Pieces[row, col + 4].Value)
                    {
                        return true;
                    }
                }
            }

            // Check all columns
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row <= rows - 5; row++)
                {
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].Value) &&
                        Pieces[row, col].Value == Pieces[row + 1, col].Value &&
                        Pieces[row + 1, col].Value == Pieces[row + 2, col].Value &&
                        Pieces[row + 2, col].Value == Pieces[row + 3, col].Value &&
                        Pieces[row + 3, col].Value == Pieces[row + 4, col].Value)
                    {
                        return true;
                    }
                }
            }

            // Check diagonals
            for (int row = 0; row <= rows - 5; row++)
            {
                for (int col = 0; col <= cols - 5; col++)
                {
                    // Check diagonal from upper left to lower right
                    if (Pieces[row, col] != null && !string.IsNullOrWhiteSpace(Pieces[row, col].Value) &&
                        Pieces[row, col].Value == Pieces[row + 1, col + 1].Value &&
                        Pieces[row + 1, col + 1].Value == Pieces[row + 2, col + 2].Value &&
                        Pieces[row + 2, col + 2].Value == Pieces[row + 3, col + 3].Value &&
                        Pieces[row + 3, col + 3].Value == Pieces[row + 4, col + 4].Value)
                    {
                        return true;
                    }

                    // Check diagonal from upper right to lower left
                    if (Pieces[row, col + 4] != null && !string.IsNullOrWhiteSpace(Pieces[row, col + 4].Value) &&
                        Pieces[row, col + 4].Value == Pieces[row + 1, col + 3].Value &&
                        Pieces[row + 1, col + 3].Value == Pieces[row + 2, col + 2].Value &&
                        Pieces[row + 2, col + 2].Value == Pieces[row + 3, col + 1].Value &&
                        Pieces[row + 3, col + 1].Value == Pieces[row + 4, col].Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public bool IsBoardFull(Cell[,] Pieces)
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

        public bool IsGameOver(Cell[,] Pieces)
        {
            return IsFiveInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsThreeInRow(Cell[,] pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool IsFourInRow(Cell[,] pieces)
        {

            return false;
        }
        public bool IsSixInRow(Cell[,] pieces)
        {

            return false;
        }
    }

}
