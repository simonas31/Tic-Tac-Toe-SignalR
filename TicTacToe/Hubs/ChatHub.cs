using Microsoft.AspNetCore.SignalR;
using TicTacToe.Models;
using Newtonsoft.Json;
using TicTacToe.GameObjects;

namespace TicTacToe.Hubs
{
    public class ChatHub : Hub
    {
        //create storage to check existing names and dont let user enter existing name.
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
