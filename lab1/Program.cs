using System;


namespace GameSimulator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game DiceGame = new Game("Dice");

            GameAccount player1 = new GameAccount("Jack12345678");
            GameAccount player2 = new GameAccount("Ben123456789");

            DiceGame.PlayTheGame(player1, player2, 15);
            DiceGame.PlayTheGame(player1, player2, 10);
            DiceGame.PlayTheGame(player1, player2, 8);
            DiceGame.PlayTheGame(player1, player2, 11);
            DiceGame.PlayTheGame(player1, player2, 9);

            Console.WriteLine(player1.GetStatus());
            Console.WriteLine(player2.GetStatus());
            Console.WriteLine(DiceGame.TotalNumOfGames);
        }
    }
}
