using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Patterns
{ // iterator forr messages
    public class MessageIterator : IIterator<Message>
    {
        private readonly List<Message> _messages;
        private int _position = -1;

        public MessageIterator(List<Message> messages)
        {
            _messages = messages.OrderBy(m => m.Sender).ThenBy(m => m.Date).ToList();
        }

        public Message Current => _messages[_position];

        public bool MoveNext()
        {
            _position++;
            return _position < _messages.Count;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
