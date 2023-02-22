using System;
using CheckersGame;

namespace DamkaUI
{
    public static class CheckersInterface
    {

        public static void ShowInstractions()
        {
           


            System.Console.WriteLine("Instructions:");
            System.Console.WriteLine("In each itration each player will need to deside between 2 options:");
            System.Console.WriteLine("1. Play a game move.");
            System.Console.WriteLine("2. Finish the game.");
            System.Console.WriteLine("If you want to finsh the game please write Q and then press Enter");
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
            System.Console.WriteLine($"{i_game.m_PlayerTurn.m_Opponent.Name} was : {i_game.m_LastMove}");
            System.Console.WriteLine($"{i_game.m_PlayerTurn.Name} please enter your next Move");
            string move = System.Console.ReadLine();
            return move;
        }

        public static void ShowGameSummary(Game game)
        {

        }

        public static bool NewGame()
        {
            return true;
        }

        public static void ShowBorad(Game o_game)
        {
            System.Console.WriteLine(o_game.m_Board.ToString());
        }

        public static void ShowLastMove(string LastMove) 
        {
            System.Console.WriteLine(LastMove);
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
            System.Console.WriteLine("Hello welcome to the Checkers.");
            System.Console.WriteLine($"Please enter the {i_PlayerNumber} name.");
            string io_PlayerName = System.Console.ReadLine();
            Console.Clear();

            while (io_PlayerName.Equals(""))
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
            string o_BordSize = System.Console.ReadLine();

            while(!"6810".Contains(o_BordSize))
            {
                System.Console.WriteLine("Please enter valid bord size (6, 8 10) and press enter.");
                o_BordSize = System.Console.ReadLine();
            }
             return int.Parse(o_BordSize);
        }
    }
}
