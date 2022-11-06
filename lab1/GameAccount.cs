using System;


namespace GameSimulator
{
    class GameAccount
    {
        private string userName; 
        private int CurrentRating;
        private int GamesCount;

        // list with personal game statistics
        List<GameStats> allGames = new List<GameStats>();

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                // check for correct username
                if (value.Length > 12)
                {
                    throw new ArgumentException("Your nickname must be no longer than 12 characters");
                }
                userName = value;
            }
        }

        public GameAccount(string userName)
        {
            UserName = userName;
            CurrentRating = 1;
            GamesCount = 0;
        }

        public void WinGame(string opponentName, int rating) 
        {
            // enter personal statistics in the list
            var res = new GameStats(opponentName, "Win", rating);
            allGames.Add(res);
            CurrentRating += rating;
            GamesCount++;
        }
            
        public void LoseGame(string opponentName, int rating)
        {
            // checking that the rating doesn't become less than 1 
            if (CurrentRating - rating <= 1)
            {
                CurrentRating = 1;
            }
            else 
            { 
                CurrentRating -= rating; 
            }
            // enter personal statistics in the list
            var res = new GameStats(opponentName, "Lose", rating);
            allGames.Add(res);
            GamesCount++;
        }

        public string GetStatus() 
        {
            var report = new System.Text.StringBuilder();
            
            report.AppendLine($"Username: {UserName}");
            report.AppendLine("Opponent\t\tResult\tRating");
            foreach(var item in allGames)
            {
                report.AppendLine($"{item.OpponentName}\t\t{item.Result}\t  {item.Rating}");
            }
            report.AppendLine("\nCurrent rating\tGames count");
            report.AppendLine($"{CurrentRating}\t\t{GamesCount}");

            return report.ToString();
        }
    }
}
