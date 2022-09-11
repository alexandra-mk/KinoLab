using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    public interface IGame : IService
    {
        
        List<IPlayer> Players { get; set; }
        List<Lottery> Lotteries { get; set; }

        
        void UserPlayers();
        void RandomPlayers();
        void StartGame();
        void PrintLotteries();
    }
}
