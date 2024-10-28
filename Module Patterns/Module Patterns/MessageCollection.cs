using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Patterns
{
    public class MessageCollection : ICollection<Message>
    {
        private readonly List<Message> _messages = new List<Message>();

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public IIterator<Message> CreateIterator()
        {
            return new MessageIterator(_messages);
        }
    }
}

