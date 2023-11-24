using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;
using System;
using System.Collections.Generic;

namespace TicTacToe.GameObjects
{
    /// <summary>
    /// Represents a Tic-Tac-Toe board and where players have placed their pieces.
    /// </summary>
    public class Board : ITicTacToeBoard
    {
        private CellFactory cellFactory;

        /// <summary>
        /// The number of pieces that have been placed on the board.
        /// </summary>
        private int totalPiecesPlaced { get; set; }

        /// <summary>
        /// Size of the board 3, 4, 5
        /// </summary>
        public int BoardSize { get; set; }

        /// <summary>
        /// Checks if the game has ended
        /// </summary>
        public virtual bool GameEnded => false;

        public Board(CellFactory cellFactory)
        {
            // TODO: Make the dimensions of the board constants
            this.cellFactory = cellFactory;
            Pieces = new ICell[BoardSize, BoardSize];

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Pieces[i, j] = cellFactory.GetCell(i, j);
                }
            }
        }

        /// <summary>
        /// Represents the pieces on the board.
        /// Must be publicly accessible to allow serialization.
        /// </summary>
        public ICell[,] Pieces { get; private set; }

        protected void Set(int n)
        {
            BoardSize = n;
            Pieces = new ICell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Pieces[i, j] = cellFactory.GetCell(i, j);
                }
            }
        }

        /// <summary>
        /// Returns whether there are any positions left on the board.
        /// </summary>
        public bool AreSpacesLeft
        {
            get
            {
                return totalPiecesPlaced < Pieces.GetLength(0) * Pieces.GetLength(0);
            }
        }

        /// <summary>
        /// Update a cell with wanted value.
        /// </summary>
        /// <param name="row">Coordinate 1</param>
        /// <param name="col">Coordinate 2</param>
        /// <param name="pieceToPlace">Value to be placed</param>
        public void PlacePiece(int row, int col, Decorator pieceToPlace)
        {
            // Use the CellFactory to get the cell instance
            ICell cell = cellFactory.GetCell(row, col);

            // Set the value of the cell using the pieceToPlace
            cell.Set(pieceToPlace.operation());

            totalPiecesPlaced++;
        }

        public void PlacePiece(int row, int col, string pieceToPlace)
        {
            // Use the CellFactory to get the cell instance
            ICell cell = cellFactory.GetCell(row, col);

            // Set the value of the cell using the pieceToPlace
            cell.Set(pieceToPlace);

            totalPiecesPlaced++;
        }

        /// <summary>
        /// Get all Cell values as a single string.
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
