using System.Reflection.Metadata;
using TicTacToe.Patterns.Template;

namespace TicTacToe.Models
{
    public class GifMessage : Message
    {
        public GifMessage(MessageData message) 
        {
            this.SendTime = message.SendTime;
            this.SenderName = message.SenderName;
            this.Image = message.Image;
        }

        protected override bool hasImage()
        {
            return true;
        }
    }
}
