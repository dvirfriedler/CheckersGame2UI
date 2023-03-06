using System;
using CheckersGame;

namespace DamkaUI
{
    public static class GameRunner
    {
        public static void Start(bool test = false)
        {
            string player1Name = "Player1";
            string player2Name = "PC";
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
                        //CheckersInterface.ShowInrtudction();
                        //CheckersInterface.ShowInstractions();

                        pcOpponnent = CheckersInterface.GatGameMode() == 1;
                        player1Name = CheckersInterface.GetPlayerName(1);

                        if (!pcOpponnent)
                        {
                            player2Name = CheckersInterface.GetPlayerName(2);
                        }

                        bordSize = CheckersInterface.GetBoardSize();

                    }//// TEST

                    game = new Game(player1Name, player2Name, bordSize);
                    gameStart = true;
                }

                CheckersInterface.ShowBorad(game);

                playerTrun = game.PlayerTurn;

                if (test)
                {
                    game.PlayRandomMove();
                }
                else
                {
                    if (game.PlayerTurn.Name.Equals("PC"))
                    {
                         game.PlayRandomMove();
                    }

                    else
                    {
                        currentMove = CheckersInterface.AskForNextMove(game);

                        switch (currentMove)
                        {
                            case "R":

                                game.PlayRandomMove();
                                break;

                            case "Q":
                                qwit = true;
                                break;

                            default:

                                while (!game.PlayMove(currentMove))
                                {
                                    CheckersInterface.NotAValidMove();
                                    currentMove = CheckersInterface.AskForNextMove(game);
                                }

                                break;
                        }
                    }
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
