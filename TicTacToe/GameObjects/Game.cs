﻿using TicTacToe.Models;

namespace TicTacToe.GameObjects
{
    public class Game
    {
        private bool isFirstPlayersTurn;

        /// <summary>
        /// Creates a new game object.
        /// </summary>
        /// <param name="player1">The first player to join the game.</param>
        /// <param name="player2">The second player to join the game.</param>
        public Game(Player1Factory player1Factory, Player player1, string roomName)
        {
            Player1 = player1;
            GameRoomName = roomName;
            Board = BoardCreator.factoryMethod(3);

            isFirstPlayersTurn = true;

            // Link the players to the game as well
            Player1.PlayingRoomName = GameRoomName;
            Player1.Piece = player1Factory.CreatePiece(player1).ToString();
        }

        /// <summary>
        /// Creates a new game object.
        /// </summary>
        /// <param name="player1">The first player to join the game.</param>
        /// <param name="player2">The second player to join the game.</param>
        public Game(GameFactory player1Factory, GameFactory player2Factory, Player player1, Player player2, string roomName)
        {
            Player1 = player1;
            Player2 = player2;
            GameRoomName = roomName;
            Board = BoardCreator.factoryMethod(3);

            isFirstPlayersTurn = true;

            // Link the players to the game as well
            Player1.PlayingRoomName = GameRoomName;
            Player1.Piece = player1Factory.CreatePiece(player1).ToString();

            if (Player2 != null)
            {
                Player2.PlayingRoomName = GameRoomName;
                Player2.Piece = player2Factory.CreatePiece(player1).ToString(); ;
            }
        }

        ///// <summary>
        ///// A unique identifier for this game.
        ///// </summary>
        //public string Id { get; set; }

        /// <summary>
        /// Game room name identifier.
        /// </summary>
        public string GameRoomName { get; set; }

        /// <summary>
        /// One of two partipants of the game.
        /// </summary>
        public Player Player1 { get; set; }

        /// <summary>
        /// One of two participants of the game.
        /// </summary>
        public Player? Player2 { get; set; }

        /// <summary>
        /// The board that represents the tic-tac-toe game.
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// Returns which player is currently allowed to place a piece down.
        /// </summary>
        public Player WhoseTurn
        {
            get
            {
                return isFirstPlayersTurn ?
                    Player1 :
                    Player2;
            }
        }

        /// <summary>
        /// Returns whether the game is ongoing or has completed.
        /// Over states include either a tie or a player has won.
        /// </summary>
        public bool IsOver
        {
            get
            {
                return IsTie || Board.IsThreeInRow;
            }
        }

        /// <summary>
        /// Returns whether the game is a tie.
        /// </summary>
        public bool IsTie
        {
            get
            {
                return !Board.AreSpacesLeft;
            }
        }

        /// <summary>
        /// Places a piece on the board. The game knows whose turn it is so no need
        /// to identify the player. Will also update whose turn it is.
        /// </summary>
        /// <param name="row">The row where the piece will be placed.</param>
        /// <param name="col">The column where the piece will be placed.</param>
        public void PlacePiece(int row, int col)
        {
            string pieceToPlace = isFirstPlayersTurn ?
                Player1.Piece :
                Player2.Piece;
            Board.PlacePiece(row, col, pieceToPlace);

            isFirstPlayersTurn = !isFirstPlayersTurn;
        }

        /// <summary>
        /// Returns whether or not the specified move is valid.
        /// A move is invalid if there is already a piece placed in the location or
        /// the move is off the board.
        /// </summary>
        /// <param name="row">The row position of the move.</param>
        /// <param name="col">The column position of the move.</param>
        /// <returns>true if the move is valid; otherwise false.</returns>
        public bool IsValidMove(int row, int col)
        {
            // TODO: Make the board dimensions public properties
            bool cond1 = row < Board.Pieces.GetLength(0);
            bool cond2 = row < Board.Pieces.GetLength(1);
            bool cond3 = string.IsNullOrWhiteSpace(Board.Pieces[row, col].Value);


            return
                cond1 &&
                cond2 &&
                cond3;
        }

        public override string ToString()
        {
            return string.Format("(Id={0}, Player1={1}, Player2={2}, Board={3})",
                GameRoomName, Player1, Player2, Board);
        }
    }
}