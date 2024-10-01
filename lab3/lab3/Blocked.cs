using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Blocked : IState //if not enough money for anything
    {
        public void UseInter(Account account, int mbUsed)
        {
            Console.WriteLine("Account is blocked\n Internet access is unavailable");
        }

        public void MakeCall(Account account, int minutes, string number)
        {
            Console.WriteLine("Account is blocked\n Calls are unavailable");
        }
    }
}
