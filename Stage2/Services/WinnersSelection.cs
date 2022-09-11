using Stage2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2.Services
{
    class WinnersSelection
    {
        private List<Player> _players;

        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
        }


        private int _counterOfPlayers1;

        public int CounterOfPlayers1
        {
            get { return _counterOfPlayers1; }
            set { _counterOfPlayers1 = value; }
        }

        private int _counterOfPlayers2;

        public int CounterOfPlayers2
        {
            get { return _counterOfPlayers2; }
            set { _counterOfPlayers2 = value; }
        }


        private int _counterOfPlayers3;

        public int CounterOfPlayers3
        {
            get { return _counterOfPlayers3; }
            set { _counterOfPlayers3 = value; }
        }

        private int _counterOfPlayers4;

        public int CounterOfPlayers4
        {
            get { return _counterOfPlayers4; }
            set { _counterOfPlayers4 = value; }
        }

        private int _counterOfPlayers5;

        public int CounterOfPlayers5
        {
            get { return _counterOfPlayers5; }
            set { _counterOfPlayers5 = value; }
        }

        private int _counterOfPlayers6;

        public int CounterOfPlayers6
        {
            get { return _counterOfPlayers6; }
            set { _counterOfPlayers6 = value; }
        }

        private int _counterOfPlayers0;

        public int CounterOfPlayers0
        {
            get { return _counterOfPlayers0; }
            set { _counterOfPlayers0 = value; }
        }


        private int _counterOfPlayersKinoBonus1;

        public int CounterOfPlayersKinoBonus1
        {
            get { return _counterOfPlayersKinoBonus1; }
            set { _counterOfPlayersKinoBonus1 = value; }
        }

        private int _counterOfPlayersKinoBonus2;

        public int CounterOfPlayersKinoBonus2
        {
            get { return _counterOfPlayersKinoBonus2; }
            set { _counterOfPlayersKinoBonus2 = value; }
        }

        private int _counterOfPlayersKinoBonus3;

        public int CounterOfPlayersKinoBonus3
        {
            get { return _counterOfPlayersKinoBonus3; }
            set { _counterOfPlayersKinoBonus3 = value; }
        }


        private int _counterOfPlayersKinoBonus4;

        public int CounterOfPlayersKinoBonus4
        {
            get { return _counterOfPlayersKinoBonus4; }
            set { _counterOfPlayersKinoBonus4 = value; }
        }


        private int _counterOfPlayersKinoBonus5;

        public int CounterOfPlayersKinoBonus5
        {
            get { return _counterOfPlayersKinoBonus5; }
            set { _counterOfPlayersKinoBonus5 = value; }
        }

        private int _counterOfPlayersKinoBonus0;

        public int CounterOfPlayersKinoBonus0
        {
            get { return _counterOfPlayersKinoBonus0; }
            set { _counterOfPlayersKinoBonus0 = value; }
        }

        private float _winnings;

        public float Winnings
        {
            get { return _winnings; }
            set { _winnings = value; }
        }


        public void Draw(List<Player> players, List<int> luckyNumbers)
        {
            List<int> winningNumbers = new List<int>();
            foreach (Player player in players)
            {
                player.LotteryTicket.CounterOfNumbers = 0;
                player.LotteryTicket.CounterOfKinoBonus = 0;
                foreach (int playerNumber in player.LotteryTicket.Numbers)
                {
                    foreach (int luckyNumber in luckyNumbers)
                    {
                        if (luckyNumber != luckyNumbers.Last() && luckyNumber == playerNumber)
                        {
                            player.LotteryTicket.CounterOfNumbers++;
                            winningNumbers.Add(luckyNumber);
                        }
                        if (luckyNumber == luckyNumbers.Last() && playerNumber == luckyNumbers.Last())
                        {
                            player.LotteryTicket.CounterOfKinoBonus++;
                            winningNumbers.Add(luckyNumber);
                        }
                    }
                }
            }
        }


        public void CountPlayers(List<Player> players)
        {
            CounterOfPlayers1 = CounterOfPlayers2 = CounterOfPlayers3 = CounterOfPlayers4 = CounterOfPlayers5 =
                CounterOfPlayers6 = CounterOfPlayers0 = CounterOfPlayersKinoBonus1 = CounterOfPlayersKinoBonus2 =
                CounterOfPlayersKinoBonus3 = CounterOfPlayersKinoBonus4 = CounterOfPlayersKinoBonus5 =
                CounterOfPlayersKinoBonus0 = 0;
            foreach (Player player in players)
            {
                if (player.LotteryTicket.CounterOfKinoBonus == 0)
                {
                    if (player.LotteryTicket.CounterOfNumbers == 1)
                    {
                        CounterOfPlayers1++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 2)
                    {
                        CounterOfPlayers2++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 3)
                    {
                        CounterOfPlayers3++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 4)
                    {
                        CounterOfPlayers4++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 5)
                    {
                        CounterOfPlayers5++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 6)
                    {
                        CounterOfPlayers6++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 0)
                    {
                        CounterOfPlayers0++;
                    }
                }
                else
                {
                    if (player.LotteryTicket.CounterOfNumbers == 1)
                    {
                        CounterOfPlayersKinoBonus1++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 2)
                    {
                        CounterOfPlayersKinoBonus2++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 3)
                    {
                        CounterOfPlayersKinoBonus3++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 4)
                    {
                        CounterOfPlayersKinoBonus4++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 5)
                    {
                        CounterOfPlayersKinoBonus5++;
                    }
                    else if (player.LotteryTicket.CounterOfNumbers == 0)
                    {
                        CounterOfPlayersKinoBonus0++;
                    }
                }
            }

        }



        public void PrintWinners()
        {
            Console.OutputEncoding = Encoding.Default;
            
            float playerWinnings;
            float sumOfWinningsNotEarned;
            Console.WriteLine("**************************************************");
            Console.WriteLine($"  ******This lottery shares {Winnings} €!!!!!******");
            Console.WriteLine("**************************************************");
            if (CounterOfPlayers1 != 0)
            {
                playerWinnings = (float)(Winnings * 0.002) / CounterOfPlayers1;
                Console.WriteLine($"Category 1/6 : {CounterOfPlayers1} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.002);
                Console.WriteLine($"Category 1/6 : No winner! JackPot = {playerWinnings} €");

            }
            sumOfWinningsNotEarned = playerWinnings;
            if (CounterOfPlayers2 != 0)
            {
                playerWinnings = (float)(Winnings * 0.006) / CounterOfPlayers2;
                Console.WriteLine($"Category 2/6 : {CounterOfPlayers2} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.006);
                Console.WriteLine($"Category 2/6 : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;

            }

            if (CounterOfPlayers3 != 0)
            {
                playerWinnings = (float)(Winnings * 0.01) / CounterOfPlayers3;
                Console.WriteLine($"Category 3/6 : {CounterOfPlayers3} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.01);
                Console.WriteLine($"Category 3/6 : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayers4 != 0)
            {
                playerWinnings = (float)(Winnings * 0.03) / CounterOfPlayers4;
                Console.WriteLine($"Category 4/6 : {CounterOfPlayers4} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.03);
                Console.WriteLine($"Category 4/6 : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayers5 != 0)
            {
                playerWinnings = (float)(Winnings * 0.07) / CounterOfPlayers5;
                Console.WriteLine($"Category 5/6 : {CounterOfPlayers5} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.07);
                Console.WriteLine($"Category 5/6 : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayers6 != 0)
            {
                playerWinnings = (float)(Winnings * 0.07) / CounterOfPlayers6;
                Console.WriteLine($"Category 6/6 : {CounterOfPlayers6} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.23);
                Console.WriteLine($"Category 6/6 : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayersKinoBonus0 != 0)
            {
                playerWinnings = (float)(Winnings * 0.004) / CounterOfPlayersKinoBonus0;
                Console.WriteLine($"Category 1/6+ : {CounterOfPlayersKinoBonus0} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.004);
                Console.WriteLine($"Category 1/6+ : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayersKinoBonus1 != 0)
            {
                playerWinnings = (float)(Winnings * 0.008) / CounterOfPlayersKinoBonus1;
                Console.WriteLine($"Category 2/6+ : {CounterOfPlayersKinoBonus1} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.008);
                Console.WriteLine($"Category 2/6+ : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayersKinoBonus2 != 0)
            {
                playerWinnings = (float)(Winnings * 0.02) / CounterOfPlayersKinoBonus2;
                Console.WriteLine($"Category 3/6+ : {CounterOfPlayersKinoBonus2} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.02);
                Console.WriteLine($"Category 3/6+ : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayersKinoBonus3 != 0)
            {
                playerWinnings = (float)(Winnings * 0.05) / CounterOfPlayersKinoBonus3;
                Console.WriteLine($"Category 4/6+ : {CounterOfPlayersKinoBonus3} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.05);
                Console.WriteLine($"Category 4/6+ : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayersKinoBonus4 != 0)
            {
                playerWinnings = (float)(Winnings * 0.15) / CounterOfPlayersKinoBonus4;
                Console.WriteLine($"Category 5/6+ : {CounterOfPlayersKinoBonus4} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.15);
                Console.WriteLine($"Category 5/6+ : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }

            if (CounterOfPlayersKinoBonus5 != 0)
            {
                playerWinnings = (float)(Winnings * 0.35) / CounterOfPlayersKinoBonus5;
                Console.WriteLine($"Category 6/6+ : {CounterOfPlayersKinoBonus5} players! --> Winnings are : {playerWinnings} € for each player");
            }
            else
            {
                playerWinnings = (float)(Winnings * 0.35);
                Console.WriteLine($"Category 6/6+ : No winner! JackPot = {playerWinnings} €");
                sumOfWinningsNotEarned = playerWinnings + sumOfWinningsNotEarned;
            }
            float charityMoney = (float)(Winnings * 0.07);

            Console.WriteLine($"The money that goes for charity: {charityMoney} €");
            Console.WriteLine($"The amount of money transfered to the next lottery: {sumOfWinningsNotEarned} €");
            Winnings = sumOfWinningsNotEarned + Winnings;
            Console.WriteLine($"Total amount for next lottery: {Winnings} €");
          

        }

    }
    
}
