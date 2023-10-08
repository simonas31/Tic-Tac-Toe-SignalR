namespace TicTacToe.Models;


public class Board3 : Board
{
    public Board3()
    {
        Set(3);
    }

    public bool IsThreeInRow
    {
        get
        {
            // Check all rows
            for (int row = 0; row < this.Pieces.GetLength(0); row++)
            {
                if (!string.IsNullOrWhiteSpace(Pieces[row, 0]) &&
                    Pieces[row, 0] == Pieces[row, 1] &&
                    Pieces[row, 1] == Pieces[row, 2])
                {
                    return true;
                }
            }

            // Check all columns
            for (int col = 0; col < this.Pieces.GetLength(1); col++)
            {
                if (!string.IsNullOrWhiteSpace(Pieces[0, col]) &&
                    Pieces[0, col] == Pieces[1, col] &&
                    Pieces[1, col] == Pieces[2, col])
                {
                    return true;
                }
            }

            // Check forward-diagonal
            if (!string.IsNullOrWhiteSpace(Pieces[1, 1]) &&
                Pieces[2, 0] == Pieces[1, 1] &&
                Pieces[1, 1] == Pieces[0, 2])
            {
                return true;
            }

            // Check backward-diagonal
            if (!string.IsNullOrWhiteSpace(Pieces[1, 1]) &&
                Pieces[0, 0] == Pieces[1, 1] &&
                Pieces[1, 1] == Pieces[2, 2])
            {
                return true;
            }

            return false;
        }
    }
}