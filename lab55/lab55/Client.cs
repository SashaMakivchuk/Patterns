using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    public class Client : IObserver
    {
        private User _user;

        public Client(User user)
        {
            _user = user;
        }

        public void Update(string message, User user)
        {
            if (user.WantsEmailNotifications)
            {
                Console.WriteLine($"[Email] {user.Name} notification: {message}");
            }
            if (user.WantsSMSNotifications)
            {
                Console.WriteLine($"[SMS] {user.Name} notification: {message}");
            }
        }
    }
}
