using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public interface IState //interface for state
    {
        void UseInter(Account account, int mbUsed);
        void MakeCall(Account account, int minutes, string number);
    }
}
