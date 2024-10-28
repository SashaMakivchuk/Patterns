using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Patterns
{ // to save messages
    public class Message
    {
        public DateTime Date { get; }
        public string Sender { get; }
        public string Receiver { get; }
        public string Text { get; }

        public Message(DateTime date, string sender, string receiver, string text)
        {
            Date = date;
            Sender = sender;
            Receiver = receiver;
            Text = text;
        }
    }
}
