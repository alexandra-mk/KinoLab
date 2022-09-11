using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoLab
{
    public class RandomService
    {
        private static Random _randomNumber = new Random();
        public static int RandomNumber { get; set; }

        public static void GenerateRandomNumbers(List<int> numbers)
        {
            Console.WriteLine("===== THE LUCKY NUMBERS ARE =====");
            int rand = 0;
            int kinoBonus = 0;

            for (int i = 0; i < 20; i++)
            {
                rand = _randomNumber.Next(1, 81);
                while (numbers.Contains(rand))
                {
                    rand = _randomNumber.Next(1, 81);
                }
                numbers.Add(rand);
            }
            kinoBonus = numbers.Last();

            foreach (int number in numbers)
            {
                if (number != kinoBonus)
                {
                    Console.WriteLine($"* {number} * ");
                }
                else if (number == kinoBonus)
                {
                    Console.WriteLine("***KINO BONUS IS***");
                    Console.WriteLine($"* {kinoBonus} * ");
                }
            }
        }

        public static void Winnings(List<int> luckyNumbers, List<int> playerChoice)
        {
            
            int counterOfNumbers = 0;
            int counterOfKinoBonus = 0;
            List<int> winningNumbers = new List<int>();
            foreach (int luckyNumber in luckyNumbers)
            {
                foreach (int playerNumber in playerChoice)
                {
                    if (luckyNumber != luckyNumbers.Last() && luckyNumber == playerNumber)
                    {
                        counterOfNumbers++;
                        winningNumbers.Add(luckyNumber);
                    }
                    if (luckyNumber == luckyNumbers.Last() && playerNumber == luckyNumbers.Last())
                    {
                        counterOfKinoBonus++;
                        winningNumbers.Add(luckyNumber);
                    }
                }
            }

            if (counterOfNumbers == 0 && counterOfKinoBonus == 0)
            {
                Console.WriteLine("You are a black cat don't chase your luck");
                Console.WriteLine("You didn't find Kino bonus!");
            }
            else if (counterOfNumbers != 0 && counterOfKinoBonus == 0)
            {
                Console.WriteLine("*****GONGRATULATIONS YOU WON******");
                Console.WriteLine($"You found {counterOfNumbers}/6 lucky numbers");
                Console.WriteLine("You didn't find Kino bonus!");
            }
            else if (counterOfNumbers != 0 && counterOfKinoBonus == 1)
            {
                Console.WriteLine("*****GONGRATULATIONS YOU WON******");
                Console.WriteLine($"You found {counterOfNumbers}/6 lucky numbers and KINO BONUS");
            }
            else if (counterOfNumbers == 0 && counterOfKinoBonus == 1)
            {
                Console.WriteLine("*****GONGRATULATIONS YOU WON******");
                Console.WriteLine($"You found 1/6 lucky numbers and that is the KINO BONUS");
            }
            Console.WriteLine("Your winning numbers are: ");
            foreach (int winningNumber in winningNumbers)
            {
                Console.WriteLine($"* {winningNumber} *");
            }
        }
    }
}



