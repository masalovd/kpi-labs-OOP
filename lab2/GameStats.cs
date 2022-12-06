using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulator2
{
    class GameStats
    {
        public string OpponentName { get; set; }
        public string Result { get; set; }
        public int Rating { get; set; }

        public string GameType { get; set; }


        public GameStats(string opponentName, string gameType, string result, int rating)
        {
            OpponentName = opponentName;
            GameType = gameType;
            Result = result;
            Rating = rating;
        }
    }
}
