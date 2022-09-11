using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoLab.Services
{
    public static class PlayerChoice
    {
        private static Random _randomNumber = new Random();
        public static int RandomNumber { get; set; }

        public static void ChooseLuckyNumbers(List<int> playerChoice)
        {
            string userAnswer = "";
            int number = 0;
            Console.WriteLine("Please choose 6 unique lucky numbers from 1 to 80");
            for (int i = 1; i <= 6; i++)
            {

                Console.WriteLine($"Choose number.{i} ");
                number = int.Parse(Console.ReadLine());
                while (number > 80 || number < 1 || playerChoice.Contains(number))
                {
                    Console.WriteLine($"Please choose number.{i} again");
                    Console.WriteLine("The numbers should be unique and have range between 1 - 80");
                    number = int.Parse(Console.ReadLine());
                }
                playerChoice.Add(number);
            }
            Console.WriteLine("Do you want to play kino bonus? (Y/N)");
            userAnswer = Console.ReadLine().ToUpper();
            while (userAnswer != "Y" && userAnswer != "N")
            {
                Console.WriteLine("Your answer was not correct, please try again! Do you want to play kino bonus? (Y/N)");
                userAnswer = Console.ReadLine().ToUpper();
            }


            Console.WriteLine("PLAYER'S LUCKY NUMBERS ARE");
            foreach (int playerNumber in playerChoice)
            {
                Console.WriteLine(playerNumber);
            }
            Console.WriteLine("GOOD LUCK");
        }

        public static void GenerateRandomUsersChoices(List<int> numbers, int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int rand = _randomNumber.Next(1, 81);
                    while (numbers.Contains(rand))
                    {
                        rand = _randomNumber.Next(1, 81);
                    }
                    numbers.Add(rand);
                }
            }
        }
    }
}
