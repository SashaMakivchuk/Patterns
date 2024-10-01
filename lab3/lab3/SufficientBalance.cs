using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class SufficientBalance : IState //if enough money for month
    {
        public void UseInter(Account account, int mbUsed)
        {
            if (account.Mb >= mbUsed)
            {
                account.Mb -= mbUsed;
                Console.WriteLine($"Used {mbUsed} MB\n Remaining MB: {account.Mb}");
            }
            else
            {
                Console.WriteLine("Not enough MB");
            }
        }

        public void MakeCall(Account account, int minutes, string number)
        {
            if (account.Minutes >= minutes)
            {
                account.Minutes -= minutes;
                Console.WriteLine($"Call to {number} for {minutes} min\n Remaining minutes: {account.Minutes}");
            }
            else
            {
                Console.WriteLine("Not enough minutes for the call");
            }
        }
    }
}
