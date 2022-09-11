using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    public class LotteryTicket : GamesParticipant, IBuyable
    {
        private static Random _randomNumber = new Random();
        public int ID { get; set; }
       
        public bool KinoBonus { get; set; }
      
        public List<int> Results { get; set; }

        public List<int> Numbers { get; set; }

        public bool IsLottery { get; set; } = false;
        public LotteryTicket()
        {
            Results = new List<int>();
            Numbers = new List<int>();
        }


        // Random numbers & player's choice for Kinobonus
        public void GenerateLotteryTicketWithRandomNumbers()
        {
            GameService.GenerateRandomNumbers(_min, _max, Numbers, _iterations, IsLottery);
            Console.WriteLine("Do you want to play kino bonus for this random ticket? (Y/N)");
            string userAnswer = Console.ReadLine().ToUpper();
            KinoBonus = ChooseKinoBonus(userAnswer, AnswerIsNotValid);
        }

        public bool ChooseKinoBonus(string answer, Predicate<string> AnswerIsNotValid)
        {
            while (AnswerIsNotValid(answer))
            {
                GameService.PrintErrorMessage();
                answer = Console.ReadLine().ToUpper();
            }

            KinoBonus = AnswerIsYes(answer);
            return KinoBonus;
        }


        // Entirely random ticket
        public void GenerateRandomLotteryTicket()
        {
            GameService.GenerateRandomNumbers(_min, _max, Numbers, _iterations, IsLottery);
            int kinoBonus = _randomNumber.Next(1, 3);
            KinoBonus = kinoBonus == 1 ? true : false;
        }

       

        // Player chooses numbers & kinobonus
        public void ChooseNumbers()
        {
           
            Console.WriteLine("Please choose 6 unique lucky numbers from 1 to 80");
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine($"Choose number.{i} ");
                string input = Console.ReadLine();
                int number = GameService.CheckAnswer(input);
                while (!IsNumberInRange(number) || Numbers.Contains(number))
                {
                    Console.WriteLine($"Please choose number.{i} again");
                    Console.WriteLine("The numbers should be unique and have range between 1 - 80");
                    input = Console.ReadLine();
                    number = GameService.CheckAnswer(input);
                }

                Numbers.Add(number);
            }
            Console.WriteLine("Do you want to play kino bonus? (Y/N)");
            string userAnswer = Console.ReadLine().ToUpper();
            KinoBonus = ChooseKinoBonus(userAnswer, AnswerIsNotValid);
        }


    }
}
