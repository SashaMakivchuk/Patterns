using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    public class User
    {
        public string Name { get; private set; }
        public bool WantsEmailNotifications { get; private set; }
        public bool WantsSMSNotifications { get; private set; }

        public User(string name, bool wantsEmail, bool wantsSMS)
        {
            Name = name;
            WantsEmailNotifications = wantsEmail;
            WantsSMSNotifications = wantsSMS;
        }

        public void SetNotificationPreferences(bool wantsEmail, bool wantsSMS)
        {
            WantsEmailNotifications = wantsEmail;
            WantsSMSNotifications = wantsSMS;
        }
    }
}
