using System;


namespace GameSimulator
{
    class GameStats
    {
        public string OpponentName { get; set; }
        public string Result { get; set; }
        public int Rating { get; set; }


        public GameStats(string opponentName, string result, int rating)
        {
            OpponentName = opponentName;
            Result = result;
            Rating = rating;
        }
    }
}
