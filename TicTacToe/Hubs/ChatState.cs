using TicTacToe.Patterns.Iterator;
using TicTacToe.Patterns.Template;

namespace TicTacToe.Hubs
{
    public class ChatState
    {
        private static ChatState? _instance;
        private static readonly object mLock = new object();
        private static readonly object messageLock = new object();

        private readonly MessagesCollection _messages = new MessagesCollection();

        private ChatState() { }
        public static ChatState? Instance
        {
            get
            {
                lock (mLock)
                {
                    if (_instance == null)
                        _instance = new ChatState();
                }

                return _instance;
            }
        }

        public void AddMessage(Message msg)
        {
            lock(messageLock)
            {
                _messages.AddItem(msg);
            }
        }

        public object GetMessage()
        {
            lock (messageLock)
            {
                return _messages.GetEnumerator().Current;
            }
        }

        public MessagesCollection GetMessages()
        {
            lock (messageLock)
            {
                return _messages;
            }
        }
    }
}
