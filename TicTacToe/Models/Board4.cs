namespace TicTacToe.Models;


public class Board4 : Board
{
    /// <summary>
    /// constructor
    /// </summary>
    public Board4()
    {
        Set(4);
    }

    /// <summary>
    /// win condition
    /// </summary>
    public bool IsThreeInRow
    {
        get
        {
            // Check all rows
            for (int row = 0; row < this.Pieces.GetLength(0)-1; row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].Value) &&
                    Pieces[row, 0].Value == Pieces[row, 1].Value &&
                    Pieces[row, 1].Value == Pieces[row, 2].Value)
                {
                    return true;
                }
            }

            for (int row = 1; row < this.Pieces.GetLength(0); row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].Value) &&
                    Pieces[row, 0].Value == Pieces[row, 1].Value &&
                    Pieces[row, 1].Value == Pieces[row, 2].Value)
                {
                    return true;
                }
            }


            // Check all columns
            for (int col = 0; col < this.Pieces.GetLength(1)-1; col++)
            {
                if (Pieces[0, col] != null && !string.IsNullOrWhiteSpace(Pieces[0, col].Value) &&
                    Pieces[0, col].Value == Pieces[1, col].Value &&
                    Pieces[1, col].Value == Pieces[2, col].Value)
                {
                    return true;
                }
            }

            for (int col = 1; col < this.Pieces.GetLength(1); col++)
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

            if (Pieces[2, 2] != null && !string.IsNullOrWhiteSpace(Pieces[2, 2].Value) &&
                Pieces[3, 1].Value == Pieces[2, 2].Value &&
                Pieces[2, 2].Value == Pieces[1, 3].Value)
            {
                return true;
            }

            if (Pieces[2, 1] != null && !string.IsNullOrWhiteSpace(Pieces[2, 1].Value) &&
                Pieces[3, 0].Value == Pieces[2, 1].Value &&
                Pieces[2, 1].Value == Pieces[1, 2].Value)
            {
                return true;
            }

            if (Pieces[1, 2] != null && !string.IsNullOrWhiteSpace(Pieces[1, 2].Value) &&
                Pieces[0, 3].Value == Pieces[1, 2].Value &&
                Pieces[1, 2].Value == Pieces[2, 1].Value)
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

            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[3, 3].Value == Pieces[1, 1].Value &&
                Pieces[1, 1].Value == Pieces[2, 2].Value)
            {
                return true;
            }

            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[0, 1].Value == Pieces[1, 2].Value &&
                Pieces[1, 2].Value == Pieces[2, 3].Value)
            {
                return true;
            }

            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[1, 0].Value == Pieces[2, 1].Value &&
                Pieces[2, 1].Value == Pieces[3, 2].Value)
            {
                return true;
            }

            return false;
        }
    }
}