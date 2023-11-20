using TicTacToe.Models;

namespace TicTacToe.Patterns.Template
{
    public abstract class Message : MessageTemplate
    {
        public string SendTime { get; set; }
        public string SenderName { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public override sealed Message BuildMessage(MessageData message)
        {
            if (hasImage())
            {
                return new GifMessage(message);
            }
            else
            {
                return new TextMessage(message);
            }
        }

        protected abstract bool hasImage();
    }
}
