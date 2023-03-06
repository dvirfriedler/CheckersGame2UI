namespace DamkaUI
{
    using System;
    using DamkaLogic;

    public static class CheckersInterface
    {
        public static void ShowInstractions()
        {
            Console.WriteLine("Instructions:");
            Console.WriteLine("In each itration each player will need to deside between 3 options:");
            Console.WriteLine("1. Play a game move => **>**");
            Console.WriteLine("2. Play a rendom move => R");
            Console.WriteLine("3. Finish the game => Q");
            Console.WriteLine("For example if you want to move your piece from Af to Ae, write Af>Ae and then press enter");
            Console.WriteLine("When you ready to play press enter");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ShowInrtudction()
        {
            Console.WriteLine("Hello:");
            Console.WriteLine("This is Chackers Console applaction:");
            Console.WriteLine("Are You ready to play?");
            Console.ReadLine();
            Console.Clear();
        }

        public static void NotAValidMove()
        {
            Console.WriteLine("Please Enter a valid move!!!");
        }

        public static string AskForNextMove(Game i_game)
        {
            Console.WriteLine($"{i_game.Player1.Name} score: {i_game.GetScore(i_game.Player1)} ");
            Console.WriteLine($"{i_game.Player2.Name} score: {i_game.GetScore(i_game.Player2)} ");

            if (i_game.EatInLastMove)
            {
                Console.WriteLine($"Congratulations {i_game.PlayerTurn.Name} ! You have another turn.");
                Console.WriteLine();
                Console.WriteLine($"{i_game.PlayerTurn.Name} your last move was: {i_game.LastMove}");
            }
            else
            {
                Console.WriteLine($"{i_game.PlayerTurn.Opponent.Name} was : {i_game.LastMove}");
            }

            Console.WriteLine($"{i_game.PlayerTurn.Name} please enter your next Move");

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
            Console.WriteLine($"{i_game.Player1.Name} Scoure {firstPlayerScore} : " +
              $"{i_game.Player2.Name} Scoure {secondPlayerScore} ");
        }

        public static bool NewGame()
        {
            Console.WriteLine("Do you want to start a new Game?");
            Console.WriteLine("Y | N");

            string answer = Console.ReadLine();

            while (!"YN".Contains(answer))
            {
                Console.WriteLine("Please choose a valid input");
                Console.WriteLine("Y | N");
                answer = Console.ReadLine();
            }

            return answer.Equals("Y");
        }

        public static void ShowBorad(Game o_game)
        {
            Console.WriteLine(o_game.Board.ToString());
        }

        public static void ShowLastMove(Game i_game)
        {
            Console.WriteLine($"{i_game.PlayerTurn.Opponent.Name} was : {i_game.LastMove}");
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
            Console.WriteLine($"Hello {i_playerOne.Name} you play against {i_playerTow.Name} .");
            Console.WriteLine($"Your board size is: {i_boradSize}.");
        }

        public static int GatGameMode()
        {
            Console.WriteLine("Selcet Game Mode:");
            Console.WriteLine("Press 1 for playing against PC.");
            Console.WriteLine("Press 2 for playing against a friend");
            string gameMode = Console.ReadLine();
            Console.Clear();

            while (gameMode.Length != 1 || !"12".Contains(gameMode))
            {
                Console.WriteLine("Please enter valid input.");
                Console.WriteLine("(For computer press 1.)");
                Console.WriteLine("(For friend press 2.)");
                Console.Clear();

                gameMode = Console.ReadLine();
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
            Console.WriteLine($"Please enter the {playerNumber} name.");

            string io_PlayerName = Console.ReadLine();

            Console.Clear();

            while (io_PlayerName.Equals(""))
            {
                Console.WriteLine("Your name cannot be empty");
                Console.WriteLine("Please enter a valid name and press enter.");

                io_PlayerName = Console.ReadLine();
            }

            Console.Clear();
            return io_PlayerName;
        }

        public static int GetBoardSize()
        {
            Console.WriteLine("Please choose the the size of your bord: 6, 8, 10 and press enter.");
            string bordSize = Console.ReadLine();

            while (!"6810".Contains(bordSize))
            {
                Console.WriteLine("Please enter valid bord size (6, 8 10) and press enter.");
                bordSize = Console.ReadLine();
            }

            return int.Parse(bordSize);
        }
    }
}
