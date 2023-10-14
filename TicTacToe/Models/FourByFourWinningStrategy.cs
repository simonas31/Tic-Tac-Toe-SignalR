using System;

namespace TicTacToe.Models
{
    public class FourByFourWinningStrategy : IWinningStrategy
    {
        public bool IsFourInRow(Cell[,] pieces)
        {
            // Check all rows
            for (int row = 0; row < pieces.GetLength(0); row++)
            {
                if (pieces[row, 0] != null && !string.IsNullOrWhiteSpace(pieces[row, 0].Value) &&
                    pieces[row, 0].Value == pieces[row, 1].Value &&
                    pieces[row, 1].Value == pieces[row, 2].Value &&
                    pieces[row, 2].Value == pieces[row, 3].Value)
                {
                    return true;
                }
            }

            // Check all columns
            for (int col = 0; col < pieces.GetLength(1); col++)
            {
                if (pieces[0, col] != null && !string.IsNullOrWhiteSpace(pieces[0, col].Value) &&
                    pieces[0, col].Value == pieces[1, col].Value &&
                    pieces[1, col].Value == pieces[2, col].Value &&
                    pieces[2, col].Value == pieces[3, col].Value)
                {
                    return true;
                }
            }

            // Check forward-diagonal
            if (pieces[1, 1] != null && !string.IsNullOrWhiteSpace(pieces[1, 1].Value) &&
                pieces[2, 0].Value == pieces[1, 1].Value &&
                pieces[1, 1].Value == pieces[0, 2].Value &&
                pieces[0, 2].Value == pieces[3, 3].Value)
            {
                return true;
            }

            // Check backward-diagonal
            if (pieces[1, 2] != null && !string.IsNullOrWhiteSpace(pieces[1, 2].Value) &&
                pieces[0, 3].Value == pieces[1, 2].Value &&
                pieces[1, 2].Value == pieces[2, 1].Value &&
                pieces[2, 1].Value == pieces[3, 0].Value)
            {
                return true;
            }

            return false;
        }

        public bool IsBoardFull(Cell[,] pieces)
        {
            for (int row = 0; row < pieces.GetLength(0); row++)
            {
                for (int col = 0; col < pieces.GetLength(1); col++)
                {
                    if (pieces[row, col] == null || string.IsNullOrWhiteSpace(pieces[row, col].Value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsGameOver(Cell[,] pieces)
        {
            return IsFourInRow(pieces) || IsBoardFull(pieces);
        }
        public bool IsThreeInRow(Cell[,] pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
    }
}
