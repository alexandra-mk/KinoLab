using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    public class Selection : IService
    {

        public int ID { get; set; }

        public int[] PlayersCount { get; set; }

        public int[] PlayersCountKino { get; set; }

        public Lottery Lottery { get; set; }

        public List<IPlayer> Players { get; set; }

        public float JackPot { get; set; }

        public Selection()
        {

        }

        
        

        public Selection(int id, Lottery lottery, List<IPlayer> players)
        {
            ID = id;
            Lottery = lottery;
            Players = players;
        }


        // Start selection, find lucky numbers for each player
        public void Start()
        {
            foreach (var player in Players)
            {
                player.LotteryTicket.Results.Clear();
                foreach (int playerNumber in player.LotteryTicket.Numbers)
                {
                    foreach (int luckyNumber in Lottery.LuckyNumbers)
                    {
                        if (luckyNumber == playerNumber)
                        {
                            player.LotteryTicket.Results.Add(luckyNumber);
                           
                        }
                    }
                }
                
                Console.WriteLine($"Player {player.ID} got {player.LotteryTicket.Results.Count}/6: ");
                foreach(int num in player.LotteryTicket.Results)
                {
                    Console.WriteLine(num);
                }
                if (player.LotteryTicket.KinoBonus && player.LotteryTicket.Numbers.Contains(Lottery.LuckyNumbers.Last()))
                {
                    Console.WriteLine("With Kino Bonus!");
                }
                else
                {
                    Console.WriteLine("Without Kino Bonus!");
                }
            }
        }

        // Count how many players won in each category
        public void CountPlayers()
        {

            PlayersCount = new int[7];
            PlayersCountKino = new int[6];
            for (int i = 0; i <= 6; i++)
            {
                Console.WriteLine($"Category {i}/6:");
                foreach (var player in Players)
                {
                    if (player.LotteryTicket.Results.Count == i && (!player.LotteryTicket.Numbers.Contains(Lottery.LuckyNumbers.Last()) || player.LotteryTicket.KinoBonus == false))
                    {
                        PlayersCount[i]++;
                        
                    }
                }
                Console.WriteLine(PlayersCount[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Category {i + 1}/6+:");
                foreach (var player in Players)
                {
                    if (player.LotteryTicket.KinoBonus == true)
                    {
                        if (player.LotteryTicket.Results.Count == i + 1 && player.LotteryTicket.Numbers.Contains(Lottery.LuckyNumbers.Last()))
                        {
                            PlayersCountKino[i]++;
                           
                        }
                    }
                   
                }
                Console.WriteLine(PlayersCountKino[i]);
            }
         


        }

        // Calculate winnings for each player
        public void CalculateWinnings()
        {
            
            Console.OutputEncoding = Encoding.Default;
            float moneyTransfered = 0;
            float playerWinnings = 0;
            float sumOfWinningsNotEarned = 0;
            float[] multiply = new float[] { 0.002f, 0.006f, 0.01f, 0.03f, 0.07f, 0.23f };
            float[] multiplyKino = new float[] { 0.004f, 0.008f, 0.02f, 0.05f, 0.15f, 0.35f };
            
            
                for (int i = 0; i <= 5; i++)
                {
                    if (PlayersCount[i + 1] != 0)
                    {
                        
                        playerWinnings = (float)(Lottery.StartingMoney * multiply[i]) / PlayersCount[i + 1];
                        foreach(var p in Players)
                        {
                           
                           if (p.LotteryTicket.Results.Count == i + 1 && (!p.LotteryTicket.Numbers.Contains(Lottery.LuckyNumbers.Last()) || p.LotteryTicket.KinoBonus == false))
                           {
                               p.Winnings += playerWinnings;
                           }
                        }
                        GameService.PrintWinner(i + 1, playerWinnings, PlayersCount[i + 1]);
                    }
                    else
                    {
                        moneyTransfered = (float)(Lottery.StartingMoney * multiply[i]);
                        GameService.PrintNoWinner(i + 1, moneyTransfered);
                        sumOfWinningsNotEarned = moneyTransfered + sumOfWinningsNotEarned;
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    if (PlayersCountKino[i] != 0)
                    {
                        playerWinnings = (float)(Lottery.StartingMoney * multiplyKino[i]) / PlayersCountKino[i];
                        foreach(var p in Players)
                        {
                            if (p.LotteryTicket.KinoBonus == true && p.LotteryTicket.Results.Count == i && p.LotteryTicket.Numbers.Contains(Lottery.LuckyNumbers.Last()))
                            {
                                p.Winnings += playerWinnings;
                            }
                        }
                        
                        GameService.PrintWinnerKino(i + 1, playerWinnings, PlayersCountKino[i]);
                    }
                    else
                    {
                        moneyTransfered = (float)(Lottery.StartingMoney * multiplyKino[i]);
                        GameService.PrintNoWinnerKino(i + 1, moneyTransfered);
                        sumOfWinningsNotEarned = moneyTransfered + sumOfWinningsNotEarned;
                    }
                }

           
            Lottery.CharityMoney = (float)(Lottery.StartingMoney * 0.07);
            JackPot = sumOfWinningsNotEarned + Lottery.StartingMoney;
            GameService.PrintCharityMoney(Lottery.CharityMoney);
            GameService.PrintJackPot(sumOfWinningsNotEarned, JackPot);
        }

    }
}
