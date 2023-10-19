namespace TicTacToe.Models
{
    public class Message
    {
        public string SendTime { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        
        public Message(string senderName, string text, string sendTime)
        {
            this.SendTime = sendTime;
            this.SenderName = senderName;
            this.Text = text;
        }
    }
}
