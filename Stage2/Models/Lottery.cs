using Stage2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2.Models
{
    class Lottery
    {
        public void StartLottery()
        {
            bool isInt;
            int number;
            do
            {
                Console.WriteLine("Choose number of players");
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out number);
            } while (!isInt || number < 1);
         
            List<Player> players = PlayerChoiceService.GenerateTicketsBasedOnNumberOfPlayers(number, 6);

            PlayerChoiceService.PrintDetails(players);
            WinnersSelection winnersSelection = new WinnersSelection();
           
            winnersSelection.Winnings = 100000;
            for (int i = 0; i < 5; i++)
            {
            
                winnersSelection.Draw(players, LotterySelectionService.GenerateLotteryNumbers());
                winnersSelection.CountPlayers(players);
                winnersSelection.PrintWinners();
                
            }


        }
    }
}
