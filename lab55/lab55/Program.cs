using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppointmentManager appointmentManager = new AppointmentManager();
            NotificationService notificationService = new NotificationService();

            while (true)
            {
                Console.Write(" Admin or a Client? ('Admin', 'Client', or 'Exit' to quit): ");
                string role = Console.ReadLine();

                if (role.ToLower() == "exit")
                {
                    Console.WriteLine("Exit");
                    break;
                }
                else if (role.ToLower() == "admin")
                {
                    Administrator administrator = new Administrator(appointmentManager);
                    

                    while (true)
                    {
                        Console.WriteLine("\nAvailable Appointments:");
                        var availableAppointments = appointmentManager.GetAvailableAppointments();
                        foreach (var appointment in availableAppointments)
                        {
                            Console.WriteLine($"- {appointment.Time}");
                        }
                        Console.WriteLine("\nAdmin Options:");
                        Console.WriteLine("1. Add an appointment (Format: 'hh:mm AM/PM')");
                        Console.WriteLine("2. Delete an appointment");
                        Console.WriteLine("3. Back");
                        Console.Write("Choose: ");
                        string choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            Console.Write("Enter the time of the new appointment (Format: 'hh:mm AM/PM'): ");
                            string timeToAdd = Console.ReadLine();

                            if (administrator.AddAppointment(timeToAdd))
                            {
                                Console.WriteLine($"Appointment at {timeToAdd} is added.");
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Enter the time of the appointment you want to delete: ");
                            string timeToDelete = Console.ReadLine();

                            if (administrator.DeleteAppointment(timeToDelete))
                            {
                                Console.WriteLine($"Appointment at {timeToDelete} is deleted.");
                            }
                            else
                            {
                                Console.WriteLine($"Couldn't delete appointment at {timeToDelete} (it may be booked or doesn't exist).");
                            }
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Return");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option");
                        }
                    }
                }
                else if (role.ToLower() == "client")
                {
                    Console.Write("Enter your name: ");
                    string userName = Console.ReadLine();

                    Console.Write("Do you want email notifications? (yes/no): ");
                    bool wantsEmail = Console.ReadLine().ToLower() == "yes";

                    Console.Write("Do you want SMS notifications? (yes/no): ");
                    bool wantsSMS = Console.ReadLine().ToLower() == "yes";

                    User user = new User(userName, wantsEmail, wantsSMS);
                    Client client = new Client(user);
                    notificationService.RegisterObserver(client);

                    while (true)
                    {
                        Console.WriteLine("\nAvailable Appointments:");
                        var availableAppointments = appointmentManager.GetAvailableAppointments();
                        foreach (var appointment in availableAppointments)
                        {
                            Console.WriteLine($"- {appointment.Time}");
                        }

                        Console.WriteLine("\nClient Options:");
                        Console.WriteLine("1. Book an appointment");
                        Console.WriteLine("2. Cancel an appointment");
                        Console.WriteLine("3. View booked appointments");
                        Console.WriteLine("4. Back");
                        Console.Write("Choose an option: ");
                        string choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            Console.Write("Enter the appointment : ");
                            string timeToBook = Console.ReadLine();

                            if (appointmentManager.BookAppointment(timeToBook, user))
                            {
                                Console.WriteLine($"{user.Name} booked an appointment at {timeToBook}.");
                                notificationService.NotifyObservers($"Your appointment at {timeToBook} is confirmed.", user);
                            }
                            else
                            {
                                Console.WriteLine($"Couldn't book appointment at {timeToBook}.");
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Enter the appointment you want to cancel: ");
                            string timeToCancel = Console.ReadLine();

                            if (appointmentManager.CancelAppointment(timeToCancel, user))
                            {
                                Console.WriteLine($"{user.Name} canceled the appointment at {timeToCancel}.");
                                notificationService.NotifyObservers($"Your appointment at {timeToCancel} has been canceled.", user);
                            }
                            else
                            {
                                Console.WriteLine($"Could not cancel appointment at {timeToCancel}.");
                            }
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("\nYour Booked Appointments:");
                            var bookedAppointments = appointmentManager.GetBookedAppointments(user);
                            if (bookedAppointments.Count > 0)
                            {
                                foreach (var appointment in bookedAppointments)
                                {
                                    Console.WriteLine($"- {appointment.Time}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No appointments booked.");
                            }
                        }
                        else if (choice == "4")
                        {
                            Console.WriteLine("Return");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid role selection");
                }
            }
        }
    }
}
