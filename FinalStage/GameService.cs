using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{

    class GameService
    {
        private static Random _randomNumber = new Random();
        public static void PrintCharityMoney<T>(T a) => Console.WriteLine($"The money that goes for charity: {a} €");

        public static void PrintJackPot<T1, T2>(T1 a, T2 b) => Console.WriteLine($"The amount of money transfered to the next lottery: {a} € \n Total amount for next lottery: {b} €");

        public static void PrintNoWinnerKino<T1, T2>(T1 i, T2 a) => Console.WriteLine($"Category {i}/6+ : No winner! Jackpot = {a} €");

        public static void PrintNoWinner<T1, T2>(T1 i, T2 a) => Console.WriteLine($"Category {i}/6 : No winner! Jackpot = {a} €");

        public static void PrintWinner<T1, T2, T3>(T1 i, T2 a, T3 j) => Console.WriteLine($"For category {i}/6 winnings are : {a} € for each player ({j} player(s) won)");

        public static void PrintWinnerKino<T1, T2, T3>(T1 i, T2 a, T3 j) => Console.WriteLine($"For category {i}/6+ winnings are : {a} € for each player ({j} player(s) won)");

        public static void PrintPlayerTicket(List<IPlayer> players)
        {
            foreach(var player in players)
            {
                Console.WriteLine($"PLAYER'S {player.ID} LUCKY NUMBERS ARE");
                foreach (int playerNumber in player.LotteryTicket.Numbers)
                {
                    Console.WriteLine(playerNumber);
                }
                Console.WriteLine($"Plays KinoBonus : {player.LotteryTicket.KinoBonus}");
                Console.WriteLine("GOOD LUCK");
            }
          
        }

        public static void PrintPlayerWinnings(List<IPlayer> players)
        {
            foreach (var p in players)
            {
                Console.WriteLine($"Total winnings for player {p.ID} : {p.Winnings} €");
            }
        }

        public static void PrintErrorMessage()
        {
            Console.WriteLine("Invalid answer! Please try again.");
        }

        public static int CheckAnswer(string input)
        {

            bool isInt = int.TryParse(input, out int number);
            while (!isInt)
            {
                PrintErrorMessage();
                input = Console.ReadLine();
                isInt = int.TryParse(input, out number);
            }
            return number;
        }

        public static void GenerateRandomNumbers(Func<int> min, Func<int> max, List<int> list, Func<bool,int> a, bool b)
        {
            for (int i = 0; i < a(b); i++)
            {
                int rand = _randomNumber.Next(min(), max());
                while (list.Contains(rand))
                {
                    rand = _randomNumber.Next(min(), max());
                }
                list.Add(rand);
            }
        }
       
    }
}
