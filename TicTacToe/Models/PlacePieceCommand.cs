using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;

namespace TicTacToe.Models
{
    public class PlacePieceCommand : IBoardCommand
    {
        private int row;
        private int col;
        private ICell piece;

        private ICell previousPiece;

        public PlacePieceCommand(int row, int col, Cell piece)
        {
            this.row = row;
            this.col = col;
            this.piece = piece;
        }

        public void Execute(Board4 board)
        {
            previousPiece = board.Pieces[row, col];
            board.PlacePiece(row, col, piece.Value); // Use piece.Value here
        }

        public void Undo(Board4 board)
        {
            board.PlacePiece(row, col, previousPiece.Value); // Use previousPiece.Value here
        }

    }

}