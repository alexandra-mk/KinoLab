using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    public interface IPlayer
    {
        int ID { get; set; }
        LotteryTicket LotteryTicket { get; set; }
        float Winnings { get; set; }
        
    }
}
