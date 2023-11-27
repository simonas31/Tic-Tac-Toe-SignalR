using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class FourByFourWinningStrategy : IWinningStrategy
    {
        public bool IsFourInRow(Proxy[,] Pieces)
        {
            // Check all rows
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].requestValue()) &&
                    Pieces[row, 0].requestValue() == Pieces[row, 1].requestValue() &&
                    Pieces[row, 1].requestValue() == Pieces[row, 2].requestValue() &&
                    Pieces[row, 2].requestValue() == Pieces[row, 3].requestValue())
                {
                    return true;
                }
            }

            // Check all columns
            for (int col = 0; col < Pieces.GetLength(1); col++)
            {
                if (Pieces[0, col] != null && !string.IsNullOrWhiteSpace(Pieces[0, col].requestValue()) &&
                    Pieces[0, col].requestValue() == Pieces[1, col].requestValue() &&
                    Pieces[1, col].requestValue() == Pieces[2, col].requestValue() &&
                    Pieces[2, col].requestValue() == Pieces[3, col].requestValue())
                {
                    return true;
                }
            }

            // Check diagonal from upper right to lower left
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].requestValue()) &&
                Pieces[0, 0].requestValue() == Pieces[1, 1].requestValue() &&
                Pieces[1, 1].requestValue() == Pieces[2, 2].requestValue() &&
                Pieces[2, 2].requestValue() == Pieces[3, 3].requestValue())
            {
                return true;
            }

            // Check diagonal from upper left to lower right
            if (Pieces[1, 2] != null && !string.IsNullOrWhiteSpace(Pieces[1, 2].requestValue()) &&
                Pieces[0, 3].requestValue() == Pieces[1, 2].requestValue() &&
                Pieces[1, 2].requestValue() == Pieces[2, 1].requestValue() &&
                Pieces[2, 1].requestValue() == Pieces[3, 0].requestValue())
            {
                return true;
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
            return IsFourInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsThreeInRow(Proxy[,] pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool IsFiveInRow(Proxy[,] pieces)
        {
            return false;
        }

        public bool IsSixInRow(Proxy[,] pieces)
        {

            return false;
        }
    }
}
