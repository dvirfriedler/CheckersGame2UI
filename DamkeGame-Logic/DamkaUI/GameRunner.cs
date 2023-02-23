using System;
using CheckersGame;

namespace DamkaUI
{
    public static class GameRunner
    {
        public static void Start(bool test = true)
        {
            List<string> testMoves = new List<string>(); ////TEST
            int testStep = 0; ////TEST

            if (test) ////TEST
            {
                testMoves.Add("Bc>Ad");   //// TEST
                testMoves.Add("Cf>Be");   //// TEST
                testMoves.Add("Ad>Cf");   //// TEST
                testMoves.Add("Bg>De");   //// TEST
                testMoves.Add("Fc>Ed");   //// TEST
                testMoves.Add("Gh>Hg");   //// TEST

            }

            string firstPlayerName = "Player1";
            string secondPlayerName = "PC";
            int bordSize = 8;
            bool pcOpponnent = false;
            bool qwit = false;
            bool gameStart = false;
            Game game = null;
            Player playerTrun = null;
            string currentMove = string.Empty;

            while (!qwit)
            {
                if (!gameStart)
                {
                    if (!test) //// TEST
                    {
                        CheckersInterface.ShowInrtudction();
                        CheckersInterface.ShowInstractions();

                        pcOpponnent = CheckersInterface.GatGameMode() == 1;
                        firstPlayerName = CheckersInterface.GetPlayerName(1);

                        if (!pcOpponnent)
                        {
                            secondPlayerName = CheckersInterface.GetPlayerName(2);
                        }

                        bordSize = CheckersInterface.GetBoardSize();

                    }  //// TEST

                    game = new Game(firstPlayerName, secondPlayerName, bordSize);
                    gameStart = true;
                }

                CheckersInterface.ShowBorad(game);

                playerTrun = game.PlayerTurn;

                if (test)
                {
                    currentMove = testMoves[testStep];
                    testStep++;
                }
                else
                {
                    currentMove = CheckersInterface.AskForNextMove(game);
                }

                while (!game.PlayMove(currentMove))
                {
                    CheckersInterface.NotAValidMove();
                    currentMove = CheckersInterface.AskForNextMove(game);
                }

                if (game.GameIsOver())
                {
                    CheckersInterface.ShowGameSummary(game);

                    if (!CheckersInterface.NewGame())
                    {
                        qwit = true;
                    }
                }
            }

            Console.WriteLine("The game is over, press Enter to Exit");
            Console.ReadLine();
        }
    }
}
