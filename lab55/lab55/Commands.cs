using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    public interface ICommand
    {
        void Execute();
    }
    public class BookAppointmentCommand : ICommand
    {
        private readonly string _appointmentDetails;

        public BookAppointmentCommand(string appointmentDetails)
        {
            _appointmentDetails = appointmentDetails;
        }

        public void Execute()
        {
            Console.WriteLine($"Booking: {_appointmentDetails}");
        }
    }

    public class CancelAppointmentCommand : ICommand
    {
        private readonly string _appointmentDetails;

        public CancelAppointmentCommand(string appointmentDetails)
        {
            _appointmentDetails = appointmentDetails;
        }

        public void Execute()
        {
            Console.WriteLine($"Cancelling: {_appointmentDetails}");
        }
    }
    public class CommandInvoker
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
            _commands.Clear();
        }
    }


}
