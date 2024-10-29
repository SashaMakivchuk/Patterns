using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    public class NotificationService : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string message, User user)
        {
            foreach (var observer in _observers)
            {
                if (observer is Client client)
                {
                    client.Update(message, user);
                }
            }
        }
    }

}
