﻿using TicTacToe.Interfaces;

namespace TicTacToe.GameObjects
{
    public class MegaBoardAdapter : ITicTacToeBoard
    {
        private MegaTicTacToeHelper _adapter;

        public MegaBoardAdapter(Cell[,] megaBoard)
        {
            _adapter = new MegaTicTacToeHelper(megaBoard);
        }

        public bool GameEnded => _adapter.IsGameOver();
        public Cell[,] Pieces
        {
            get
            {
                // Assuming MegaTicTacToeHelper has a method to retrieve the board
                return _adapter.BoardState;
            }
        }

        public bool AreSpacesLeft
        {
            get
            {
                // Iterating through each cell to see if any cell is empty
                for (int i = 0; i < BoardSize; i++)
                {
                    for (int j = 0; j < BoardSize; j++)
                    {
                        if (string.IsNullOrWhiteSpace(Pieces[i, j].Value))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public int BoardSize
        {
            get
            {
                // Assuming the board is square
                return Pieces.GetLength(0);
            }
        }

        public void PlacePiece(int row, int col, string pieceToPlace)
        {
            _adapter.MakeMove(row, col, pieceToPlace);
        }
    }
}