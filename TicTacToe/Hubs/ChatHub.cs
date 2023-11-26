using Microsoft.AspNetCore.SignalR;
using TicTacToe.Models;
using System.Text.Json;
using TicTacToe.GameObjects;
using TicTacToe.Patterns.Template;
using TicTacToe.Patterns.Iterator;

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

            var builtMessage = msg.BuildMessage(msgData);

            ChatState.Instance.AddMessage(builtMessage);

            //uncomment for showing iterator pattern
            //foreach(var messg in ChatState.Instance.GetMessages())
            //{
            //    Console.WriteLine(messg.ToString());
            //}

            await Clients.All.SendAsync("ReceiveMessage", builtMessage);
        }
    }
}
