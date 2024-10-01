using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class LowBalance : IState //if not enough for month but enough for daily
    {
        public void UseInter(Account account, int mbUsed)
        {
            if (account.Balance >= 7)
            {
                account.Balance -= 7;
                account.Mb = 200;
                Console.WriteLine($"Daily package active: 200 MB for 7 UAH\n Remaining balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Not enough for daily package");
            }
        }

        public void MakeCall(Account account, int minutes, string number)
        {
            double callCost = minutes * 0.60;
            if (account.Balance >= callCost)
            {
                account.Balance -= callCost;
                Console.WriteLine($"Call to {number} for {minutes} min\n Cost: {callCost} UAH\n Remaining balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Not enough for the call");
            }
        }
    }
}
