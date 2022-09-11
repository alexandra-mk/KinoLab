using Stage2.Models;
using Stage2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2
{
    class Program
    {
        static void Main(string[] args)
        {
            Lottery lottery = new Lottery();
            lottery.StartLottery();
           
        }
    }
}
