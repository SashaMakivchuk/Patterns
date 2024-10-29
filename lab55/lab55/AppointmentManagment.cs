using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    public class AppointmentManager
    {
        private readonly List<Appointment> _appointments = new List<Appointment>();
        public AppointmentManager()
        {
            _appointments.Add(new Appointment("10:00 AM"));
            _appointments.Add(new Appointment("11:00 AM"));
            _appointments.Add(new Appointment("02:00 PM"));
        }

        public bool AddAppointment(string time)
        {
            if (_appointments.Any(a => a.Time == time))
            {
                Console.WriteLine("This appointment already exists.");
                return false;
            }
            _appointments.Add(new Appointment(time));
            return true;
        }

        public bool DeleteAppointment(string time)
        {
            var appointment = _appointments.FirstOrDefault(a => a.Time == time && a.IsAvailable);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
                return true;
            }
            return false;
        }

        public bool BookAppointment(string time, User user)
        {
            var appointment = _appointments.FirstOrDefault(a => a.Time == time && a.IsAvailable);
            return appointment?.Book(user) ?? false;
        }

        public bool CancelAppointment(string time, User user)
        {
            var appointment = _appointments.FirstOrDefault(a => a.Time == time && a.BookedBy == user);
            return appointment?.Cancel(user) ?? false;
        }

        public List<Appointment> GetAvailableAppointments()
        {
            return _appointments
                .Where(a => a.IsAvailable)
                .OrderBy(a => DateTime.Parse(a.Time).ToString("tt"))
                .ThenBy(a => DateTime.Parse(a.Time).TimeOfDay)      
                .ToList();
        }
        public List<Appointment> GetBookedAppointments(User user)
        {
            return _appointments
                .Where(a => a.BookedBy == user)
                .OrderBy(a => DateTime.Parse(a.Time))
                .ToList();
        }
    }
}
