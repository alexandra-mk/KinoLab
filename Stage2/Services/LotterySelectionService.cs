using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2.Services
{
    class LotterySelectionService
    {
        private static Random _randomNumber = new Random();
        public static int RandomNumber { get; set; }

        public static List<int> GenerateLotteryNumbers()
        {
            Console.WriteLine("===== THE LUCKY NUMBERS ARE =====");
            List<int> numbers = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                int rand = _randomNumber.Next(1, 81);
                while (numbers.Contains(rand))
                {
                    rand = _randomNumber.Next(1, 81);
                }
                numbers.Add(rand);
            }
            int kinoBonus = numbers.Last();

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
            return numbers;
        }
    }   
}
