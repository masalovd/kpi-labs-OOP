using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulator2
{
    abstract class Game
    {
        public int GameRating { get; set; }
        public string GameName { get; set; }
        public Game(string gameName)
        {
            GameName = gameName;
        }

        public abstract void PlayTheGame(GameAccount player1, GameAccount player2, int rating);
    }

    class StandartGame : Game
    {
        public StandartGame(string gameName) : base(gameName) { }

        public override void PlayTheGame(GameAccount player1, GameAccount player2, int rating)
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
                Console.WriteLine($"{player1.UserName} won the rating game!");
                player1.WinGame(player2.UserName, rating, "standart");
                player2.LoseGame(player1.UserName, rating, "standart");
            }
            // second player wins
            else
            {
                Console.WriteLine($"{player2.UserName} won the rating game!");
                player2.WinGame(player1.UserName, rating, "standart");
                player1.LoseGame(player2.UserName, rating, "standart");
            }
        }
    }

    class OneWayGame : Game
    {
        public OneWayGame(string gameName) : base(gameName) { }

        public override void PlayTheGame(GameAccount player1, GameAccount player11, int rating)
        {
            // check for correct rating
            if (rating <= 0)
            {
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be greater then zero");
            }

            // game simulation
            Random rand = new Random();
            int res = rand.Next(1, 3);

            // player wins
            if (res == 1)
            {
            Console.WriteLine($"{player1.UserName} won the oneway game!");
            player1.WinGame(player1.UserName, rating, "oneway");
            }
            // player lose
            else
            {
                Console.WriteLine($"{player1.UserName} lose the oneway game!");
                player1.LoseGame(player1.UserName, rating, "oneway");
            }
        }
    }

    class TrainingGame : Game
    {
        public TrainingGame(string gameName) : base(gameName) { }

        public override void PlayTheGame(GameAccount player1, GameAccount player2, int rating)
        {

            rating = 0;

            Random rand = new Random();
            int res = rand.Next(1, 3);

            // first player wins
            if (res == 1)
            {
                Console.WriteLine($"{player1.UserName} won the training game!");
                player1.WinGame(player2.UserName, rating, "training");
                player2.LoseGame(player1.UserName, rating, "training");
            }
            // second player wins
            else
            {
                Console.WriteLine($"{player2.UserName} won the training game!");
                player2.WinGame(player1.UserName, rating, "training");
                player1.LoseGame(player2.UserName, rating, "training");
            }
        }
    }

}
