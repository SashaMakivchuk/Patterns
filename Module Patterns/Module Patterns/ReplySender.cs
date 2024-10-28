using Module_Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Module_Patterns
{ // for sending replies
    public class ReplySender
    {
        private readonly MessageCollection _messageCollection;

        public ReplySender(MessageCollection messageCollection)
        {
            _messageCollection = messageCollection;
        }

        public void SendReplyToAll(string targetText, string replyText)
        {
            var iterator = _messageCollection.CreateIterator();

            while (iterator.MoveNext())
            {
                var message = iterator.Current;
                if (message.Text.Contains(targetText))
                {
                    Console.WriteLine($"Reply {message.Sender} ({message.Date}): {replyText}");
                }
            }
        }
    }
}
