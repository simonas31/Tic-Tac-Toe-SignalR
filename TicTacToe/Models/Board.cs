namespace TicTacToe.Models
{
	/// <summary>
	/// Represents a Tic-Tac-Toe board and where players have placed their pieces.
	/// </summary>
	public class Board
	{
		/// <summary>
		/// The number of pieces that have been placed on the board.
		/// </summary>
		private int totalPiecesPlaced;

		public Board()
		{
			// TODO: Make the dimensions of the board constants
			this.Pieces = new Cell[3, 3];
			for(int i = 0; i < 3; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					Pieces[i, j] = new Cell();
				}
			}
		}

		/// <summary>
		/// Represents the pieces on the board.
		/// Must be publicly accessible to allow serialization.
		/// </summary>
		public Cell[,] Pieces { get; private set; }

		protected void Set(int n)
		{
			this.Pieces = new Cell[n, n];
			for(int i = 0; i < n; i++)
			{
				for(int j = 0; j < n; j++)
				{
					Pieces[i, j] = new Cell();
				}
			}
		}
		/// <summary>
		/// Determines whether there are three pieces in a row that match.
		/// Possible configurations are either horizontal, vertical, or the diagonals.
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

		/// <summary>
		/// Returns whether there are any positions left on the board.
		/// </summary>
		public bool AreSpacesLeft
		{
			get
			{
				return this.totalPiecesPlaced < Pieces.GetLength(0)*Pieces.GetLength(0);
			}
		}

		/// <summary>
		/// update a cell with wanted value
		/// </summary>
		/// <param name="row">cordinate 1</param>
		/// <param name="col">cordinate 2</param>
		/// <param name="pieceToPlace">value to be placed</param>
		public void PlacePiece(int row, int col, string pieceToPlace)
		{
			this.Pieces[row, col].Set(pieceToPlace);
			this.totalPiecesPlaced++;
		}

		/// <summary>
		/// get all Cell values as a single string
		/// </summary>
		/// <returns>Cell values as a single string</returns>
		public override string ToString()
		{
            List<string> piecesList = new List<string>();

            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    piecesList.Add(Pieces[i, j].Value);
                }
            }

            return string.Join(", ", piecesList);
        }
	}
}