using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Patterns
{
    public class MessageCollection : IEnumerable<Message>
    {
        private List<Message> _messages = new List<Message>();

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public IEnumerator<Message> GetEnumerator()
        {
            var sortedMessages = _messages
                .OrderBy(m => m.Sender)
                .ThenBy(m => m.Date)
                .ToList();

            foreach (var message in sortedMessages)
            {
                yield return message;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
