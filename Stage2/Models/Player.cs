using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2.Models
{
    class Player
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private LotteryTicket _lotteryTicket;

        public LotteryTicket LotteryTicket
        {
            get { return _lotteryTicket; }
            set { _lotteryTicket = value; }
        }
    }
}
