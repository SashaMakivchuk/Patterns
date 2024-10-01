using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Account // class for acc
    {
        public double Balance { get; set; }
        public int Mb { get; set; }
        public int Minutes { get; set; }
        private IState state;

        public Account(double balance, int mb, int minutes)
        {
            Balance = balance;
            Mb = mb;
            Minutes = minutes;
            state = new SufficientBalance(); //new state
        }

        public void SetState(IState newState)
        {
            state = newState;
        }

        public void UseInter(int mbUsed)
        {
            state.UseInter(this, mbUsed);
        }

        public void MakeCall(int minutes, string number)
        {
            state.MakeCall(this, minutes, number);
        }
    }
}
