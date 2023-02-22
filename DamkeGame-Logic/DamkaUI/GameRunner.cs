using System;
using CheckersGame;

namespace DamkaUI
{
    public static class GameRunner
    {
        public static void Start()
        {
            string firstPlayerName = "Player1";
            string secondPlayerName = "PC";
            int bordSize = 8;
            bool pcOpponnent = false;
            bool qwit = false;
            bool gameStart = false;
            Game game = null;
            string currentMove = string.Empty;
            

            while (!qwit)
            {
                if (!gameStart)
                {
                  //  CheckersInterface.ShowInrtudction();
                  //
                  //  CheckersInterface.ShowInstractions();
                  //
                  //  pcOpponnent = CheckersInterface.GatGameMode() == 1;
                  //  firstPlayerName = CheckersInterface.GetPlayerName(1);
                  //
                  //  if (!pcOpponnent)
                  //  {
                  //      secondPlayerName = CheckersInterface.GetPlayerName(2);
                  //  }
                  //
                  //  bordSize = CheckersInterface.GetBoardSize();
                  //
                    game = new Game(firstPlayerName, secondPlayerName, bordSize);
                    gameStart = true;
                }

                CheckersInterface.ShowBorad(game);

                currentMove = CheckersInterface.AskForNextMove(game);
                //currentMove = "Ab>Ac"; //test

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
