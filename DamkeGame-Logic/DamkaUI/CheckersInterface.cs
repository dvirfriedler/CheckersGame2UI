using System;
using CheckersGame;

namespace DamkaUI
{
    public static class CheckersInterface
    {

        public static void ShowInstractions()
        {
            System.Console.WriteLine("Instructions:");
            System.Console.WriteLine("In each itration each player will need to deside between 3 options:");
            System.Console.WriteLine("1. Play a game move => **>**");
            System.Console.WriteLine("2. Play a rendom move => R");
            System.Console.WriteLine("3. Finish the game => Q");
            System.Console.WriteLine("For example if you want to move your piece from Af to Ae, write Af>Ae and then press enter");
            System.Console.WriteLine("When you ready to play press enter");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ShowInrtudction()
        {
            System.Console.WriteLine("Hello:");
            System.Console.WriteLine("This is Chackers Console applaction:");
            System.Console.WriteLine("Are You ready to play?");
            Console.ReadLine();
            Console.Clear();
        }

        public static void NotAValidMove()
        {
            System.Console.WriteLine("Please Enter a valid move!!!");
        }

        public static string AskForNextMove(Game i_game)
        {
            System.Console.WriteLine($"{i_game.Player1.Name} score: {i_game.GetScore(i_game.Player1)} ");
            System.Console.WriteLine($"{i_game.Player2.Name} score: {i_game.GetScore(i_game.Player2)} ");

            if (i_game.EatInLastMove)
            {
                System.Console.WriteLine($"Congratulations {i_game.PlayerTurn.Name} ! You have another turn.");
                System.Console.WriteLine();
                System.Console.WriteLine($"{i_game.PlayerTurn.Name} your last move was: {i_game.LastMove}");
            }
            else
            {
                System.Console.WriteLine($"{i_game.PlayerTurn.Opponent.Name} was : {i_game.LastMove}");
            }

            System.Console.WriteLine($"{i_game.PlayerTurn.Name} please enter your next Move");

            string move = Console.ReadLine();

            return move;
        }

        public static void ShowGameSummary(Game game)
        {

        }

        public static void ShowScore(Game i_game)
        {
            string firstPlayerScore = i_game.GetScore(i_game.Player1).ToString("0.###");
            string secondPlayerScore = i_game.GetScore(i_game.Player2).ToString("0.###");
            System.Console.WriteLine($"{i_game.Player1.Name} Scoure {firstPlayerScore} : " +
              $"{i_game.Player2.Name} Scoure {secondPlayerScore} ");
        }

        public static bool NewGame()
        {
            return true;
        }

        public static void ShowBorad(Game o_game)
        {
            Console.WriteLine(o_game.Board.ToString());
        }

        public static void ShowLastMove(Game i_game)
        {
            System.Console.WriteLine($"{i_game.PlayerTurn.Opponent.Name} was : {i_game.LastMove}");
        }

        internal static void ShowLastMove(Player playerTurn, Board o_gameBorad, int turnCounter)
        {
            if (turnCounter == 0)
            {
                Console.WriteLine("ShowLastMove");
            }
            else
            {
                Console.WriteLine("ShowLastMove");
                Console.WriteLine("ShowLastMove");
            }
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ShowGameDetails(Player i_playerOne, Player i_playerTow, int i_boradSize)
        {
            System.Console.WriteLine($"Hello {i_playerOne.Name} you play against {i_playerTow.Name} .");
            System.Console.WriteLine($"Your board size is: {i_boradSize}.");
        }

        public static int GatGameMode()
        {
            System.Console.WriteLine("Selcet Game Mode:");
            System.Console.WriteLine("Press 1 for playing against PC.");
            System.Console.WriteLine("Press 2 for playing against a friend");
            string gameMode = System.Console.ReadLine();
            Console.Clear();

            while (gameMode.Length != 1 || !("12".Contains(gameMode)))
            {
                System.Console.WriteLine("Please enter valid input.");
                System.Console.WriteLine("(For computer press 1.)");
                System.Console.WriteLine("(For friend press 2.)");
                Console.Clear();

                gameMode = System.Console.ReadLine();
            }

            Console.Clear();

            return int.Parse(gameMode);
        }

        public static string GetPlayerName(int i_PlayerNumber)
        {
            string playerNumber = "first player";

            if (i_PlayerNumber == 2)
            {
                playerNumber = "second player";
            }

            Console.WriteLine("Hello welcome to the Checkers.");
            System.Console.WriteLine($"Please enter the {playerNumber} name.");

            string io_PlayerName = Console.ReadLine();

            Console.Clear();

            while ( io_PlayerName.Equals("") )
            {
                System.Console.WriteLine("Your name cannot be empty");
                System.Console.WriteLine("Please enter a valid name and press enter.");

                io_PlayerName = System.Console.ReadLine();
            }

            Console.Clear();
            return io_PlayerName;
        }

        public static int GetBoardSize()
        {
            System.Console.WriteLine("Please choose the the size of your bord: 6, 8, 10 and press enter.");
            string bordSize = System.Console.ReadLine();

            while (!"6810".Contains(bordSize))
            {
              System.Console.WriteLine("Please enter valid bord size (6, 8 10) and press enter.");
              bordSize = System.Console.ReadLine();
            }

            return int.Parse(bordSize);
        }
    }
}
