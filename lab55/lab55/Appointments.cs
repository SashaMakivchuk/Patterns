using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    public class Appointment
    {
        public string Time { get; }
        public User BookedBy { get; private set; }

        public Appointment(string time)
        {
            Time = time;
        }

        public bool Book(User user)
        {
            if (BookedBy == null)
            {
                BookedBy = user;
                return true;
            }
            return false;
        }

        public bool Cancel(User user)
        {
            if (BookedBy == user)
            {
                BookedBy = null;
                return true;
            }
            return false;
        }

        public bool IsAvailable => BookedBy == null;
    }

}
