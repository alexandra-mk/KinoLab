using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    
    public class Game : GamesParticipant, IGame
    {
        public int ID { get; set; }
      
        public List<IPlayer> Players { get; set; }
        private List<Lottery> _lotteries;

        public List<Lottery> Lotteries
        {
            get { return _lotteries; }
            set { _lotteries = value; }
        }


        public Game()
        {
            Players = new List<IPlayer>();
            Lotteries = new List<Lottery>();
        }




        // General method to start entire game
        public void Start()
        {
            int number = 0; 
            do
            {
                Console.WriteLine("Choose way of adding players to the game:\n" +
                  "\t1.User input\n \t2.Random players");

                string input = Console.ReadLine();
                number = GameService.CheckAnswer(input);
              
            } while (number != 1 && number != 2);
            switch (number)
            {
                case 1:
                    UserPlayers();
                    break;
                case 2:
                    RandomPlayers();
                    break;
                default:
                    Console.WriteLine("Type 1 or 2");
                    break;
            }
            StartGame();
            PrintLotteries();
            GameService.PrintPlayerWinnings(Players);
            HowManyTimesANumberInLotteries();
        }

       
        // Start game/lotteries
        public void StartGame()
        {
            Console.OutputEncoding = Encoding.Default;
            bool keepRunning = true;
            int i = 1;
            float start = 100000;
            do
            {
                Lottery lottery = new Lottery(i);
                Lotteries.Add(lottery);
                lottery.Start();
                Selection selection = new Selection(i, lottery, Players);
                lottery.StartingMoney = start;

                Console.WriteLine($"This lottery's Jackpot is : {start} € ! ! ! !");
                selection.Start();
                selection.CountPlayers();
                selection.CalculateWinnings();
                foreach (var player in selection.Players)
                {
                    Console.WriteLine($"player {player.ID} got {player.Winnings}");
                }
                i++;
                start = selection.JackPot;
                Console.WriteLine("Continue to the next lottery? (Press Y to continue)");
                string userAnswer = Console.ReadLine().ToUpper();
                if (!AnswerIsYes(userAnswer))
                {
                    keepRunning = false;
      
                }

            } while (keepRunning);
        }

        // Create random players for the game
        public void RandomPlayers()
        {
            Console.WriteLine("How many players will play Kino?");
           
            string input = Console.ReadLine();
            int number = GameService.CheckAnswer(input);
            for (int i = 0; i < number; i++)
            {
                RandomPlayer p = new RandomPlayer();
                Players.Add(p);
            }
            GameService.PrintPlayerTicket(Players);
        }

        // Add players by user choices
        public void UserPlayers()
        {
            List<int> usedIds = new List<int>();
            bool keepRunning = true;
            do
            {
                Console.WriteLine("Add new player\n \tGive player's id");

                string input = Console.ReadLine();
                int number = GameService.CheckAnswer(input);
                while (usedIds.Contains(number))
                {
                    GameService.PrintErrorMessage();
                    input = Console.ReadLine();
                    number = GameService.CheckAnswer(input);
                }
                usedIds.Add(number);
                LotteryTicket ticket = new LotteryTicket();
                Player player = new Player(number, ticket);
                player.ChooseTicket();
                Players.Add(player);
                Console.WriteLine("Do you want to add another player? (Press Y to continue)");
                string userAnswer = Console.ReadLine().ToUpper();
                if (!AnswerIsYes(userAnswer))
                {
                    keepRunning = false;

                }
            } while (keepRunning);
          
        }

        // Print lotteries' lucky numbers
        public void PrintLotteries()
        {
            foreach (Lottery lottery in Lotteries)
            {
                Console.WriteLine($"Lottery ID {lottery.ID}");
                foreach (var num in lottery.LuckyNumbers)
                {
                    Console.WriteLine(num);
                }
            }
        }


        // Find how many times a number appeared in lotteries
        public void HowManyTimesANumberInLotteries()
        {
            
            bool keepRunning = true;
            do
            {
                Console.WriteLine("Choose a number to check if it was a lucky number and how many times:");
                string input = Console.ReadLine();
                int number = GameService.CheckAnswer(input);
                while (!IsNumberInRange(number))
                {
                    Console.WriteLine("The numbers have range between 1 - 80");
                    input = Console.ReadLine();
                    number = GameService.CheckAnswer(input);
                }
                List<int> found = new List<int>();
                foreach (var l in Lotteries)
                {
                    if (l.LuckyNumbers.Contains(number))
                    {
                        found.Add(number);
                    }
                }
                Console.WriteLine($"The number {number} appeared in lotteries {found.Count} time(s).");
                Console.WriteLine("Do you want to check for another one? (Press Y to continue)");
                string userAnswer = Console.ReadLine().ToUpper();
                if (!AnswerIsYes(userAnswer))
                {
                    keepRunning = false;
                    Console.WriteLine("GOODBYE!!!");
                }
            } while (keepRunning);
         
        }
    }
}
