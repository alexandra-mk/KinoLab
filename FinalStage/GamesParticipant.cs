using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStage
{
    public class GamesParticipant
    {
        internal Func<int> _min = MinNumber;
        protected Func<int> _max = MaxNumber;
        protected Func<bool, int> _iterations = Iterations;
        protected Predicate<string> AnswerIsNotValid = answer => answer != "Y" && answer != "N";
        protected Predicate<int> IsNumberInRange = n => n <= 80 && n >= 1;
        protected Predicate<string> AnswerIsYes = answer => answer == "Y";
        public static int MinNumber()
        {
            bool isKino = true;
            if (isKino)
            {
                return 1;
            }
            return 0;
        }

        public static int MaxNumber()
        {
            bool isKino = true;
            if (isKino)
            {
                return 81;
            }
            return 0;
        }

        public static int Iterations(bool foo)
        {
            if (foo)
            {
                return 20;
            }
            return 6;
        }
    }
}
