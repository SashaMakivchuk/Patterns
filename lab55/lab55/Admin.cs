using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab55
{
    public class Administrator
    {
        private AppointmentManager _appointmentManager;

        public Administrator(AppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        public bool AddAppointment(string time)
        {
            // Regular expression 10:00 AM or 02:30 PM
            var timePattern = new Regex(@"^(0[1-9]|1[0-2]):[0-5][0-9] (AM|PM)$");

            if (!timePattern.IsMatch(time))
            {
                Console.WriteLine("Invalid time format. Right: 'hh:mm AM/PM'.");
                return false;
            }

            return _appointmentManager.AddAppointment(time);
        }

        public bool DeleteAppointment(string time)
        {
            return _appointmentManager.DeleteAppointment(time);
        }
    }
}
