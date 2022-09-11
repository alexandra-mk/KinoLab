using Stage2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2.Services
{
    class PlayerChoiceService
    {
        private static Random _randomNumber = new Random();
        public static int RandomNumber { get; set; }
        public static LotteryTicket GenerateLotteryTicket(int numberOfNumbers)
        {
            
            LotteryTicket lotteryTicket = new LotteryTicket();
            for (int i = 0; i < numberOfNumbers; i++)
            {
                int rand = _randomNumber.Next(1, 81);
                while (lotteryTicket.Numbers.Contains(rand))
                {
                    rand = _randomNumber.Next(1, 81);
                }
                lotteryTicket.Numbers.Add(rand);
            }
            return lotteryTicket;
        }

        public static List<Player> GenerateTicketsBasedOnNumberOfPlayers(int numberOfPlayers, int numberOfNumbers)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = new Player();
                player.ID = i + 1;
                player.LotteryTicket = GenerateLotteryTicket(numberOfNumbers);
                players.Add(player);
            }
            return players;
        }

        public static void PrintDetails(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Player: {player.ID}");
                Console.WriteLine("*************");
                foreach (var ticket in player.LotteryTicket.Numbers)
                {
                    Console.WriteLine(ticket);
                    
                }
                Console.WriteLine("*************");
            }
        }
    }
}
