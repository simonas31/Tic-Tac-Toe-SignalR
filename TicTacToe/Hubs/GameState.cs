﻿using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.ComponentModel;
using TicTacToe.Models;

namespace TicTacToe.Hubs
{
    public class GameState
    {
        // GameState Singleton
        private readonly static Lazy<GameState> instance =
            new Lazy<GameState>(() => new GameState());

        private readonly ConcurrentDictionary<string, Player> players =
            new ConcurrentDictionary<string, Player>(StringComparer.OrdinalIgnoreCase);

        private readonly ConcurrentDictionary<string, Game> games =
            new ConcurrentDictionary<string, Game>(StringComparer.OrdinalIgnoreCase);

        private readonly ConcurrentQueue<Player> waitingPlayers =
            new ConcurrentQueue<Player>();

        public GameState()
        {
        }

        public static GameState Instance
        {
            get { return instance.Value; }
        }

        public Player CreatePlayer(string username, string roomName, string connectionId)
        {
            var player = new Player(username, roomName, connectionId);
            this.players[connectionId] = player;

            return player;
        }

        public Player GetPlayer(string playerId)
        {
            Player foundPlayer;
            if (!this.players.TryGetValue(playerId, out foundPlayer))
            {
                return null;
            }

            return foundPlayer;
        }

        public Game GetGame(Player player, string roomName)
        {
            Game foundGame = games.Values.FirstOrDefault(g => g.GameRoomName == player.PlayingRoomName);

            if (foundGame == null)
            {
                return null;
            }

            return foundGame;
        }

        public Game GetGame(Player player, out Player opponent)
        {
            opponent = null;
            Game foundGame = games.Values.FirstOrDefault(g => g.GameRoomName == player.PlayingRoomName);

            if (foundGame == null)
            {
                return null;
            }

            opponent = (player.Id == foundGame.Player1.Id) ? foundGame.Player2 : foundGame.Player1;

            return foundGame;
        }

        public Player GetWaitingOpponent(string roomName)
        {
            Player foundPlayer;
            if (!this.waitingPlayers.TryDequeue(out foundPlayer))
            {
                return null;
            }

            return foundPlayer;
        }

        public void RemoveGame(string gameId)
        {
            Game foundGame;
            if (!this.games.TryRemove(gameId, out foundGame))
            {
                throw new InvalidOperationException("Game not found.");
            }

            Player foundPlayer;
            this.players.TryRemove(foundGame.Player1.Id, out foundPlayer);
            this.players.TryRemove(foundGame.Player2.Id, out foundPlayer);
        }

        public void AddToWaitingPool(Player player)
        {
            this.waitingPlayers.Enqueue(player);
        }

        public bool IsUsernameTaken(string username)
        {
            return this.players.Values.FirstOrDefault(player => player.Name.Equals(username, StringComparison.InvariantCultureIgnoreCase)) != null;
        }

        public bool IsRoomNameTaken(string roomName)
        {
            return this.games.Values.FirstOrDefault(game => game.GameRoomName.Equals(roomName, StringComparison.InvariantCultureIgnoreCase)) != null;
        }

        public bool CanEnterRoom(string roomName)
        {
            return this.games.Values.FirstOrDefault(game => game.GameRoomName.Equals(roomName) && game.Player1 != null && game.Player2 == null) != null;
        }

        public async Task<Game> CreateGame(Player firstPlayer, Player secondPlayer, IGroupManager groupManager, string roomName)
        {
            Game game = new Game(firstPlayer, secondPlayer, roomName);
            this.games[game.GameRoomName] = game;

            if (groupManager != null)
            {
                await groupManager.AddToGroupAsync(firstPlayer.Id, groupName: game.GameRoomName);
                await groupManager.AddToGroupAsync(secondPlayer.Id, groupName: game.GameRoomName);
            }

            return game;
        }
    }
}
