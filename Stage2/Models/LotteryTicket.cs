using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2.Models
{
    class LotteryTicket
    {
        private List<int> _numbers;

        public List<int> Numbers
        {
            get { return _numbers; }
            set { _numbers = value; }
        }

        private int _numberOfNumbers;

        public int NumberOfNumbers
        {
            get { return _numberOfNumbers; }
            set { _numberOfNumbers = value; }
        }

        //private int _kinoBonus;

        //public int KinoBonus
        //{
        //    get { return _kinoBonus; }
        //    set { _kinoBonus = value; }
        //}

        public LotteryTicket()
        {
            Numbers = new List<int>();
        }

        private int _counterOfNumbers;

        public int CounterOfNumbers
        {
            get { return _counterOfNumbers; }
            set { _counterOfNumbers = value; }
        }


        private int _counterOfKinoBonus;

        public int CounterOfKinoBonus
        {
            get { return _counterOfKinoBonus; }
            set { _counterOfKinoBonus = value; }
        }

    }
}
