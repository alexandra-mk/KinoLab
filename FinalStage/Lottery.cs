using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    public class Lottery : GamesParticipant, IService
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private List<int> _luckyNumbers;

        public List<int> LuckyNumbers
        {
            get { return _luckyNumbers; }
            set { _luckyNumbers = value; }
        }

        private float _startingMoney;

        public float StartingMoney
        {
            get { return _startingMoney; }
            set { _startingMoney = value; }
        }

        private float _charityMoney;

        public float CharityMoney
        {
            get { return _charityMoney; }
            set { _charityMoney = value; }
        }

        public bool IsLottery { get; set; } = true;

        public Lottery(int id)
        {
            ID = id;
            
            LuckyNumbers = new List<int>();
        }

        // Start lottery
        public void Start()
        {

            Console.WriteLine("===== THE LUCKY NUMBERS ARE =====");
            GameService.GenerateRandomNumbers(_min, _max, LuckyNumbers, _iterations, IsLottery);
            int kinoBonus = LuckyNumbers.Last();

            foreach (int number in LuckyNumbers)
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
    }
}
