using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class FourByFourWinningStrategy : IWinningStrategy
    {
        public bool IsFourInRow(ICell[,] Pieces)
        {
            // Check all rows
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].Value) &&
                    Pieces[row, 0].Value == Pieces[row, 1].Value &&
                    Pieces[row, 1].Value == Pieces[row, 2].Value &&
                    Pieces[row, 2].Value == Pieces[row, 3].Value)
                {
                    return true;
                }
            }

            // Check all columns
            for (int col = 0; col < Pieces.GetLength(1); col++)
            {
                if (Pieces[0, col] != null && !string.IsNullOrWhiteSpace(Pieces[0, col].Value) &&
                    Pieces[0, col].Value == Pieces[1, col].Value &&
                    Pieces[1, col].Value == Pieces[2, col].Value &&
                    Pieces[2, col].Value == Pieces[3, col].Value)
                {
                    return true;
                }
            }

            // Check diagonal from upper right to lower left
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[0, 0].Value == Pieces[1, 1].Value &&
                Pieces[1, 1].Value == Pieces[2, 2].Value &&
                Pieces[2, 2].Value == Pieces[3, 3].Value)
            {
                return true;
            }

            // Check diagonal from upper left to lower right
            if (Pieces[1, 2] != null && !string.IsNullOrWhiteSpace(Pieces[1, 2].Value) &&
                Pieces[0, 3].Value == Pieces[1, 2].Value &&
                Pieces[1, 2].Value == Pieces[2, 1].Value &&
                Pieces[2, 1].Value == Pieces[3, 0].Value)
            {
                return true;
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
            return IsFourInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsThreeInRow(ICell[,] pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool IsFiveInRow(ICell[,] pieces)
        {
            return false;
        }

        public bool IsSixInRow(ICell[,] pieces)
        {

            return false;
        }
    }
}
