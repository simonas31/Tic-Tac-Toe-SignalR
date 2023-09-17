﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
	/// <summary>
	/// Represents a user playing the game.
	/// </summary>
	public class Player
	{
		public Player(string name, string roomName, string id)
		{
			this.Name = name;
			this.PlayingRoomName = roomName;
			this.Id = id;
		}

		/// <summary>
		/// A user defined username to display as a friendly name.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// A unique ID to identify a player. Use the SignalR connection ID.
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// The unique name to identify the game a player is playing; otherwise null.
		/// The game will decide the game ID.
		/// </summary>
		public string PlayingRoomName { get; set; }

		/// <summary>
		/// Defines the piece that will be placed on the board to represent this user.
		/// The game will decide the game piece.
		/// </summary>
		public string Piece { get; set; }

		public override string ToString()
		{
			return String.Format("(Id={0}, Name={1}, GameId={2}, Piece={3})",
				this.Id, this.Name, this.PlayingRoomName, this.Piece);
		}

		public override bool Equals(object obj)
		{
			Player other = obj as Player;

			if (other == null)
			{
				return false;
			}

			return this.Id.Equals(other.Id) && this.Name.Equals(other.Name);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode() * this.Name.GetHashCode();
		}
	}
}
