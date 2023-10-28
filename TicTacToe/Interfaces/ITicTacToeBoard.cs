using TicTacToe.GameObjects;

namespace TicTacToe.Interfaces
{
    public interface ITicTacToeBoard
    {
        bool GameEnded { get; }
        void PlacePiece(int row, int col, string pieceToPlace);
        Cell[,] Pieces { get; }
        bool AreSpacesLeft { get; }
        int BoardSize {  get; }
    }
}
