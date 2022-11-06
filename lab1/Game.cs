using System;


namespace GameSimulator
{
    class Game
    {
        private string gameName;
        private int totalNumOfGames = 0;

        public string GameName {
            get
            {
                return gameName;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The length of the game name must be grater then 0");
                }
                gameName = value;
            } 
        }

        public string TotalNumOfGames 
        {
            get { return $"Total num of games: {totalNumOfGames}"; }
        }

        public Game(string gameName)
        {
            GameName = gameName;
        }

        public void PlayTheGame(GameAccount player1, GameAccount player2, int rating)
        {
            // check for correct rating
            if (rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be greater then zero");
            }

            // game simulation
            Random rand = new Random();
            int res = rand.Next(1, 3);

            // first player wins
            if (res == 1)
            {
                //Console.WriteLine($"{player1.UserName} won the game!");
                player1.WinGame(player2.UserName, rating);
                player2.LoseGame(player1.UserName, rating);
            }
            // second player wins
            else
            {
                //Console.WriteLine($"{player2.UserName} won the game!");
                player2.WinGame(player1.UserName, rating);
                player1.LoseGame(player2.UserName, rating);
            }
            totalNumOfGames++;
        }
    }
}
