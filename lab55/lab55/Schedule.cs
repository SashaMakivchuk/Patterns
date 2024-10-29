using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
public class ScheduleManager
{
    private static ScheduleManager _instance;
    private static readonly object _lock = new object();

    private ScheduleManager() { }

    public static ScheduleManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ScheduleManager();
                }
                return _instance;
            }
        }
    }

    public void DisplaySchedule()
    {
        Console.WriteLine("Schedule");
    }
}

}
