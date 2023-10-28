using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class FiveByFiveWinningStrategy : IWinningStrategy
    {
        public bool IsFiveInRow(Cell[,] Pieces)
        {
            // Check all rows
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].Value) &&
                    Pieces[row, 0].Value == Pieces[row, 1].Value &&
                    Pieces[row, 1].Value == Pieces[row, 2].Value &&
                    Pieces[row, 2].Value == Pieces[row, 3].Value &&
                    Pieces[row, 3].Value == Pieces[row, 4].Value)
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
                    Pieces[2, col].Value == Pieces[3, col].Value &&
                    Pieces[3, col].Value == Pieces[4, col].Value)
                {
                    return true;
                }
            }

            // Check forward-diagonal
            if (Pieces[3, 0] != null && !string.IsNullOrWhiteSpace(Pieces[3, 0].Value) &&
                Pieces[4, 0].Value == Pieces[3, 1].Value &&
                Pieces[3, 1].Value == Pieces[2, 2].Value &&
                Pieces[2, 2].Value == Pieces[1, 3].Value &&
                Pieces[1, 3].Value == Pieces[4, 0].Value)
            {
                return true;
            }

            // Check backward-diagonal
            if (Pieces[0, 0] != null && !string.IsNullOrWhiteSpace(Pieces[0, 0].Value) &&
                Pieces[0, 0].Value == Pieces[1, 1].Value &&
                Pieces[1, 1].Value == Pieces[2, 2].Value &&
                Pieces[2, 2].Value == Pieces[3, 3].Value &&
                Pieces[3, 3].Value == Pieces[4, 4].Value)
            {
                return true;
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
            return IsFourInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsThreeInRow(Cell[,] pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }

        public bool IsFourInRow(Cell[,] Pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }

        public bool IsSixInRow(Cell[,] pieces)
        {

            return false;
        }
    }
}
