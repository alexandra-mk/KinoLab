using System;
using System.Collections.Generic;

namespace KinoLab.Services
{
    public class KinoService
    {
        public static void StartKinoGame()
        {
            List<int> playerChoice = new List<int>();
            List<int> numbers = new List<int>();

            PlayerChoice.ChooseLuckyNumbers(numbers);
            string answer = "";
            Console.WriteLine("Press X to see the lucky numbers");
            answer = Console.ReadLine().ToUpper();
            while (answer != "X")
            {
                Console.WriteLine("Press X to see the lucky numbers");
                answer = Console.ReadLine().ToUpper();
            }
            RandomService.GenerateRandomNumbers(playerChoice);

            RandomService.Winnings(playerChoice, numbers);
        }
    }
}
