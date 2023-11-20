using TicTacToe.Patterns.Template;

namespace TicTacToe.Models
{
    public class TextMessage : Message
    {
        public TextMessage(MessageData message)
        {
            this.SendTime = message.SendTime;
            this.SenderName = message.SenderName;
            this.Text = message.Text;
        }

        protected override bool hasImage()
        {
            return false;
        }
    }
}
