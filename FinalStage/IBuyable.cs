using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    public interface IBuyable
    {
        int ID { get; set; }
        List<int> Results { get; set; }

        List<int> Numbers { get; set; }

        void ChooseNumbers();
        void GenerateLotteryTicketWithRandomNumbers();
        void GenerateRandomLotteryTicket();
    }
}
