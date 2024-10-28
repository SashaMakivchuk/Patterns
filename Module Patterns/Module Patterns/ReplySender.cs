using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Patterns
{
    public class ReplySender
    {
        private MessageCollection _messageCollection;

        public ReplySender(MessageCollection messageCollection)
        {
            _messageCollection = messageCollection;
        }

        public void SendReplyToAll(string targetText, string replyText)
        {
            foreach (var message in _messageCollection)
            {
                if (message.Text.Contains(targetText))
                {
                    Console.WriteLine($"Send reply {message.Sender} ({message.Date}): {replyText}");
                }
            }
        }
    }
}
