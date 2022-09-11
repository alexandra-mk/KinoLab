using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    class RandomPlayer : IPlayer
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

        private float _winnings;

        public float Winnings
        {
            get { return _winnings; }
            set { _winnings = value; }
        }


        private protected static Random _randomNumber = new Random();
        public static int RandomNumber { get; set; }
        public RandomPlayer()
        {
            ID = _randomNumber.Next(1000, 2001);
            LotteryTicket = new LotteryTicket();
            LotteryTicket.GenerateRandomLotteryTicket();
        }

     
    }
}
