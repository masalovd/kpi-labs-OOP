using GameSimulator2;
using System;


namespace GameSimulator
{
    class Program
    {
        public static void Main(string[] args)
        {
            StandartGame game1 = new StandartGame("Dice");
            TrainingGame game2 = new TrainingGame("Cards");
            OneWayGame game3 = new OneWayGame("2048");

            GameAccount player1 = new GameAccount("Jack12345678", "base");
            GameAccount player2 = new GameAccount("Ben123456789", "gold");

            game1.PlayTheGame(player1, player2, 15);
            game1.PlayTheGame(player1, player2, 10);
            game1.PlayTheGame(player1, player2, 8);
            game1.PlayTheGame(player1, player2, 5);
            game2.PlayTheGame(player1, player2, 0);
            game3.PlayTheGame(player1, player1, 2);
            game3.PlayTheGame(player1, player1, 5);

            Console.WriteLine("");
            Console.WriteLine(player1.GetStatus());
            Console.WriteLine("");
            Console.WriteLine(player2.GetStatus());
        }
    }
}

