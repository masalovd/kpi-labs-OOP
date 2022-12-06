using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulator2
{
    class GameAccount
    {
        private string userName;
        private string accountType;
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

        public string AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                if (value is "base")
                {
                    accountType = value;
                }
                else if (value is "gold")
                {
                    accountType = value;
                }
                else if (value is "diamond")
                {
                    accountType = value;
                }
            }
        }

        public GameAccount(string userName, string accountType)
        {
            UserName = userName;
            CurrentRating = 0;
            GamesCount = 0;
            AccountType = accountType;
        }

        public void WinGame(string opponentName, int rating, string gameType)
        {
            if (gameType != "training")
            {
                // rating increase depending on the type of account
                if (accountType == "base" || accountType == "diamond")
                { 
                    CurrentRating += rating;
                }
                else if (accountType == "gold")
                {
                    CurrentRating += 2 * rating;
                }

                if (gameType == "standart")
                {
                    // enter personal statistics in the list
                    var gameResult = new GameStats(opponentName, gameType, "Win", rating);
                    allGames.Add(gameResult);
                }
                else if (gameType == "oneway")
                {
                    var gameResult = new GameStats("Computer bot", gameType, "Win", rating);
                    allGames.Add(gameResult);
                }
            }
            GamesCount++;
        }

        public void LoseGame(string opponentName, int rating, string gameType)
        {
            if (gameType != "training")
            {
                // checking that the rating doesn't become less than 1 
                if (CurrentRating - rating <= 1)
                {
                    CurrentRating = 1;
                }
                // decrease in rating depending on the type of account
                else if (accountType == "base" || accountType == "gold")
                {
                    CurrentRating -= rating;
                }
                else if (accountType == "diamond")
                {
                    CurrentRating -= 1;
                }

                // enter personal statistics in the list
                if (gameType == "standart")
                {
                    var gameResult = new GameStats(opponentName, gameType, "Lose", rating);
                    allGames.Add(gameResult);
                }
                else if (gameType == "oneway")
                {
                    var gameResult = new GameStats("Computer bot", gameType, "Lose", rating);
                    allGames.Add(gameResult);
                }
            }
            GamesCount++;
        }

        public string GetStatus()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine($"Username: {UserName}");
            report.AppendLine($"Account type: {accountType}");
            report.AppendLine("Opponent\t\tGame type\tResult\tRating");
            foreach (var item in allGames)
            {
                if(item.GameType == "oneway")
                    report.AppendLine($"{item.OpponentName}\t\t{item.GameType}\t\t{item.Result}\t{item.Rating}");
                else
                    report.AppendLine($"{item.OpponentName}\t\t{item.GameType}\t{item.Result}\t{item.Rating}");
            }
            report.AppendLine("\nCurrent rating\tGames count");
            report.AppendLine($"{CurrentRating}\t\t{GamesCount}");

            return report.ToString();
        }
    }
}
