using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    class Player : IPlayer
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


        public Player()
        {

        }

        public Player(int id, LotteryTicket lotteryTicket)
        {
            ID = id;
            LotteryTicket = lotteryTicket;
        }

        // Player's choice for ticket
        public void ChooseTicket()
        {
            Console.WriteLine("Choose action:\n \t1.Choose ticket numbers \n \t2.Fill tickets randomly");
            bool isInt;
            int number;
            string input = Console.ReadLine();
            isInt = int.TryParse(input, out number);
            while (!isInt || (number != 1 && number != 2))
            {
                GameService.PrintErrorMessage();
                input = Console.ReadLine();
                isInt = int.TryParse(input, out number);
            }


            switch (number)
            {
                case 1:
                    LotteryTicket.ChooseNumbers();
                    break;
                case 2:
                    LotteryTicket.GenerateLotteryTicketWithRandomNumbers();
                    break;
                default:
                    Console.WriteLine("Type 1 or 2");
                    break;
            }


        }

      
    }
}
