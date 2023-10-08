namespace TicTacToe.Models;


public class Board3 : Board
{
    /// <summary>
    /// constructor
    /// </summary>
    public Board3()
    {
        Set(3);
    }

    /// <summary>
    /// win condition
    /// </summary>
    public bool IsThreeInRow
    {
        get
        {
            // Check all rows
            for (int row = 0; row < this.Pieces.GetLength(0); row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].Value) &&
                    Pieces[row, 0].Value == Pieces[row, 1].Value &&
                    Pieces[row, 1].Value == Pieces[row, 2].Value)
                {
                    return true;
                }
            }

            // Check all columns
            for (int col = 0; col < this.Pieces.GetLength(1); col++)
            {
                if (Pieces[0, col] != null && !string.IsNullOrWhiteSpace(Pieces[0, col].Value) &&
                    Pieces[0, col].Value == Pieces[1, col].Value &&
                    Pieces[1, col].Value == Pieces[2, col].Value)
                {
                    return true;
                }
            }

            // Check forward-diagonal
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[2, 0].Value == Pieces[1, 1].Value &&
                Pieces[1, 1].Value == Pieces[0, 2].Value)
            {
                return true;
            }

            // Check backward-diagonal
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[0, 0].Value == Pieces[1, 1].Value &&
                Pieces[1, 1].Value == Pieces[2, 2].Value)
            {
                return true;
            }

            return false;
        }
    }
}