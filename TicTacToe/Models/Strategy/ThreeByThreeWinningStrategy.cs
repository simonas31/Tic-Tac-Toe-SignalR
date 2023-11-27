using System;
using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class ThreeByThreeWinningStrategy : IWinningStrategy
    {
        public bool IsThreeInRow(Proxy[,] Pieces)
        {
            // Check all rows
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].requestValue()) &&
                    Pieces[row, 0].requestValue() == Pieces[row, 1].requestValue() &&
                    Pieces[row, 1].requestValue() == Pieces[row, 2].requestValue())
                {
                    return true;
                }
            }

            // Check all columns
            for (int col = 0; col < Pieces.GetLength(1); col++)
            {
                if (Pieces[0, col] != null && !string.IsNullOrWhiteSpace(Pieces[0, col].requestValue()) &&
                    Pieces[0, col].requestValue() == Pieces[1, col].requestValue() &&
                    Pieces[1, col].requestValue() == Pieces[2, col].requestValue())
                {
                    return true;
                }
            }

            // Check forward-diagonal
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].requestValue()) &&
                Pieces[2, 0].requestValue() == Pieces[1, 1].requestValue() &&
                Pieces[1, 1].requestValue() == Pieces[0, 2].requestValue())
            {
                return true;
            }

            // Check backward-diagonal
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].requestValue()) &&
                Pieces[0, 0].requestValue() == Pieces[1, 1].requestValue() &&
                Pieces[1, 1].requestValue() == Pieces[2, 2].requestValue())
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
            return IsThreeInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsFourInRow(Proxy[,] Pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool IsFiveInRow(Proxy[,] Pieces)
        {

            return false;
        }
        public bool IsSixInRow(Proxy[,] Pieces)
        {

            return false;
        }
    }
}

