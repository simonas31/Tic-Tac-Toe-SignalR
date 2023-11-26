using Microsoft.AspNetCore.SignalR;
using TicTacToe.Models;
using System.Text.Json;
using TicTacToe.GameObjects;
using TicTacToe.Patterns.Template;

namespace TicTacToe.Hubs
{
    public class ChatHub : Hub
    {

        //create storage to check existing names and dont let user enter existing name.
        public async Task SendMessage(string message)
        {
            MessageData msgData = JsonSerializer.Deserialize<MessageData>(message);
            Message msg;
            if(msgData?.Image != null)
            {
                msg = new GifMessage();
            }
            else
            {
                msg = new TextMessage();
            }
            await Clients.All.SendAsync("ReceiveMessage", msg.BuildMessage(msgData));
        }
    }
}
