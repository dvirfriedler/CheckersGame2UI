namespace DamkaLogic
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        private Board m_Board { get; set; }

        private Player m_Player1 { get; }

        private Player m_Player2 { get; }

        private Player m_PlayerTurn { get; set; }

        private string m_LastMove { get; set; }

        private int m_BoardSize { get; }

        private Pice m_LastMovePice;

        private bool m_EatInLastMove;

        public Game(string io_Player1Name = "firstPlater", string io_Plyaer2Name = "player2", int io_BoradSize = 6)
        {
            Pice player1Pice = new Pice(true);
            Pice player2Pice = new Pice(false);

            List<Pice> player1Pices = player1Pice.GetList((io_BoradSize / 2) * ((io_BoradSize / 2) -1));
            List<Pice> player2Pices = player2Pice.GetList((io_BoradSize / 2) * ((io_BoradSize / 2) - 1));

            this.m_Player1 = new Player(io_Player1Name, "X", player1Pices);
            this.m_Player2 = new Player(io_Plyaer2Name, "O", player2Pices);

            this.m_Player1.Opponent = this.m_Player2;
            this.m_Player2.Opponent = this.m_Player1;

            this.m_PlayerTurn = this.m_Player1;

            this.m_Board = new Board(io_BoradSize, this.m_Player1, this.m_Player2);

            this.m_LastMove = "This is the first move.";

            this.m_BoardSize = io_BoradSize;

            this.m_LastMovePice = null;

            this.m_EatInLastMove = false;
        }

        public Board Board => this.m_Board;

        public Player PlayerTurn => this.m_PlayerTurn;

        public Player Player1 => this.m_Player1;

        public Player Player2 => this.m_Player2;

        public string LastMove => this.m_LastMove;

        public bool EatInLastMove => this.m_EatInLastMove;

        public int BoardSize => this.m_BoardSize;

        public bool PlayMove(string i_Move)
        {
            bool didMove = true;

            int startNumberOfPices = this.m_Board.TotalNumberOfPices;

            if (!this.moveIsVaild(i_Move))
            {
                didMove = false;
            }
            else
            {
                List<Tuple<int, int>> sorceAndDest = this.moveToTuppleLocationsList(i_Move);

                int sCol = sorceAndDest[0].Item2;
                int sRow = sorceAndDest[0].Item1;
                int destCol = sorceAndDest[1].Item2;
                int destRow = sorceAndDest[1].Item1;

                this.m_Board.DoMove(sRow, sCol, destRow, destCol);
                this.m_LastMove = i_Move;

                Pice currentPice = this.m_Board.Borad[destRow, destCol];

                if (this.piceWasEatenInthistMove(startNumberOfPices) && this.PiceCanEat(currentPice))
                {
                    this.m_LastMovePice = currentPice;
                    this.m_EatInLastMove = true;
                }
                else
                {
                    this.m_LastMovePice = null;
                    this.m_EatInLastMove = false;
                    this.m_PlayerTurn = this.PlayerTurn.Opponent;
                }
            }

            if (this.PlayerTurn.Name.Equals("PC"))
            {
                this.PlayRandomMove();
            }

            return didMove;
        }

        private bool piceWasEatenInthistMove(int i_numberOfPicesInTheStartOfTheTurn)
        {
            return this.m_Board.TotalNumberOfPices != i_numberOfPicesInTheStartOfTheTurn;
        }

        private bool moveIsVaild(string i_Move)
        {
            bool moveIsVaild = true;
            bool eatWitheCorrectPice = true;

            List<Tuple<int, int>> sorceAndDest = this.moveToTuppleLocationsList(i_Move);

            int sCol = sorceAndDest[0].Item2;
            int sRow = sorceAndDest[0].Item1;
            int destCol = sorceAndDest[1].Item2;
            int destRow = sorceAndDest[1].Item1;

            List<Pice> soldiersInTheWayList = this.m_Board.ListSoldiersInWay(sRow, sCol, destRow, destCol);

            Pice sourcePice = this.m_Board.Borad[sRow, sCol];

            Tuple<int, int> dest = new Tuple<int, int>(destRow, destCol);

            if (!this.MoveTemplateIsValid(i_Move)) //// Check that the move string is "**>**"
            {
                moveIsVaild = false;
            }
            else if (this.m_Board.Borad[sRow, sCol] == null || this.m_Board.HasPiceOrOutOfBoard(destRow, destCol)) //// Check that the source has Pice and the dest dont.
            {
                moveIsVaild = false;
            }
            else if (!this.PlayerTurn.TeamSymbols.Equals(sourcePice.TeamSymbols))
            {
                moveIsVaild = false;
            }
            else if (!sourcePice.CanGo(this.m_Board.Size).Contains(dest)) 
            {
                moveIsVaild = false;
            }
            else if (soldiersInTheWayList.Count > 1) //// There is more than one soldier in the way
            {
                moveIsVaild = false;
            }
            else if (soldiersInTheWayList.Count == 1) //// There is one soldier in the way
            {
               if (!soldiersInTheWayList[0].IsAnOponnetSoldier(sourcePice)) //// the soldier in the way is from the same team
               {
                   moveIsVaild = false;
               }
            }
            else //// no soldier in the way
            {
                if (!sourcePice.IsKing) ////The pice isnt a king.
                {
                    if (this.distance(sCol, sRow, destCol, destRow) != 1)
                    {
                        moveIsVaild = false;
                    }
                }
            }

            if (this.CurrentPlayerCanEat())
            {
                if (soldiersInTheWayList.Count == 0)
                {
                    moveIsVaild = false;
                }
            }

            if (this.EatInLastMove)
            {
                if (sRow != this.m_LastMovePice.Row || sCol != this.m_LastMovePice.Col)
                {
                    eatWitheCorrectPice = false;
                }
            }

            return moveIsVaild && eatWitheCorrectPice;
        }

        private int distance(int i_sCol, int i_sRow, int i_destCol, int i_destRow)
        {
            int colDistance = Math.Abs(i_sCol - i_destCol);
            int rowDistance = Math.Abs(i_sRow - i_destRow);

            return Math.Max(colDistance, rowDistance);
        }

        private bool MoveTemplateIsValid(string i_Move)
        {
            bool vaild = true;

            if (i_Move.Length != 5)
            {
                vaild = false;
            }
            else
            {
                char[] moveCharArray = i_Move.ToCharArray();

                if (!Char.IsUpper(moveCharArray[0]))
                {
                    vaild = false;
                }
                else if (!char.IsLower(moveCharArray[1]))
                {
                    vaild = false;
                }
                else if (!moveCharArray[2].Equals('>'))
                {
                    vaild = false;
                }
                else if (!char.IsUpper(moveCharArray[3]))
                {
                    vaild = false;
                }
                else if (!char.IsLower(moveCharArray[4]))
                {
                    vaild = false;
                }
            }

            return vaild;

        }

        private bool MoveLocationsIsValid(string i_Move)
        {
            bool valid = true;

            List<int> locations = this.CharToLocation(i_Move);

            foreach (int location in locations)
            {
                if (location >= this.Board.Size)
                {
                    valid = false;
                }
            }

            return valid;
        }

        public List<int> CharToLocation(string i_Move)
        {
            List<int> positions = new List<int>() { 0, 0, 0, 0 };

            if (i_Move.Length == 5)
            {
                char[] moveCahrArray = i_Move.ToCharArray();
                positions[0] = moveCahrArray[0] - (int)'A';
                positions[1] = moveCahrArray[1] - (int)'a';
                positions[2] = moveCahrArray[3] - (int)'A';
                positions[3] = moveCahrArray[4] - (int)'a';
            }

            return positions;
        }

        private List<Tuple<int, int>> moveToTuppleLocationsList(string i_Move)
        {
            List<int> positions = this.CharToLocation(i_Move);

            Tuple<int, int> sourceTuple = new Tuple<int, int>(positions[1], positions[0]);
            Tuple<int, int> destTuple = new Tuple<int, int>(positions[3], positions[2]);

            List<Tuple<int, int>> tuplesPositions = new List<Tuple<int, int>>();

            tuplesPositions.Add(sourceTuple);
            tuplesPositions.Add(destTuple);

            return tuplesPositions;
        }

        public bool GameIsOver()
        {
            bool gameIsOver = false;

            if (this.Player1.Pices.Count == 0 || this.Player2.Pices.Count == 0)
            {
                gameIsOver = true;
            }

            return gameIsOver;
        }

        public int GetScore(Player i_Player)
        {
            double totalPicesRank = this.Player1.GetPlayerRank() + this.Player2.GetPlayerRank();
            double currentPlayerRank = i_Player.GetPlayerRank();

            int score = (int)(Math.Pow((double)currentPlayerRank / (double)totalPicesRank, 0.4) * 100);

            return score;
        }

        public string moveTupleToStringMove(List<Tuple<int, int>> i_MoveTupple)
        {
            string move = string.Empty;

            move += (char)(i_MoveTupple[0].Item2 + (int)'A');
            move += (char)(i_MoveTupple[0].Item1 + (int)'a');
            move += ">";
            move += (char)(i_MoveTupple[1].Item2 + (int)'A');
            move += (char)(i_MoveTupple[1].Item1 + (int)'a');

            return move;
        }

        private Pice getPice(int row, int col)
        {
            return this.m_Board.Borad[row, col];
        }

        private List<Pice> closeEnamyList(Pice i_pice)
        {
            List<Pice> closeEnamyList = new List<Pice>();

            Pice downLeftPice = this.Board.Borad[Math.Min(i_pice.Row + 1, this.m_BoardSize - 1), Math.Max(i_pice.Col - 1, 0)];
            Pice downRightPice = this.Board.Borad[Math.Min(i_pice.Row + 1, this.m_BoardSize - 1), Math.Min(i_pice.Col + 1, this.m_BoardSize - 1)];
            Pice upLeftPice = this.Board.Borad[Math.Max(i_pice.Row - 1, 0), Math.Max(i_pice.Col - 1, 0)];
            Pice upRightPice = this.Board.Borad[Math.Max(i_pice.Row - 1, 0), Math.Min(i_pice.Col + 1, this.m_BoardSize - 1)];

            if (i_pice.Symbole.Equals("X"))
            {
                if (i_pice.IsOpponent(downLeftPice))
                {
                    closeEnamyList.Add(downLeftPice);
                }

                if (i_pice.IsOpponent(downRightPice))
                {
                    closeEnamyList.Add(downRightPice);
                }
            }
            else if (i_pice.Symbole.Equals("O"))
            {
                if (i_pice.IsOpponent(upLeftPice))
                {
                    closeEnamyList.Add(upLeftPice);
                }

                if (i_pice.IsOpponent(upRightPice))
                {
                    closeEnamyList.Add(upRightPice);
                }
            }
            else
            {
                int currnetRow = i_pice.Row;
                int currentCol = i_pice.Col;

                for (currnetRow = i_pice.Row - 1; currnetRow >= 0; currnetRow--) //// Up Left
                {
                    upLeftPice = this.Board.Borad[Math.Max(currnetRow, 0), Math.Max(currentCol - 1, 0)];

                    if (i_pice.IsOpponent(upLeftPice))
                    {
                        closeEnamyList.Add(upLeftPice);
                        break;
                    }

                    currentCol -= 1;
                }

                currentCol = i_pice.Col;

                for (currnetRow = i_pice.Row + 1; currnetRow < this.m_BoardSize; currnetRow++) //// down Left
                {
                    downLeftPice = this.Board.Borad[Math.Min(currnetRow, this.m_BoardSize - 1), Math.Max(currentCol - 1, 0)];

                    if (i_pice.IsOpponent(downLeftPice))
                    {
                        closeEnamyList.Add(downLeftPice);
                        break;
                    }

                    currentCol -= 1;
                }

                currentCol = i_pice.Col;

                for (currnetRow = i_pice.Row - 1; currnetRow >= 0; currnetRow--) //// Up Right
                {
                    upRightPice = this.Board.Borad[Math.Max(currnetRow, 0), Math.Min(currentCol + 1, this.m_BoardSize - 1)];

                    if (i_pice.IsOpponent(upRightPice))
                    {
                        closeEnamyList.Add(upRightPice);
                        break;
                    }

                    currentCol += 1;
                }

                currentCol = i_pice.Col;

                for (currnetRow = i_pice.Row + 1; currnetRow < this.m_BoardSize; currnetRow++) //// down Right
                {
                    downRightPice = this.Board.Borad[Math.Min(currnetRow, this.m_BoardSize - 1), Math.Min(currentCol + 1, this.m_BoardSize - 1)];

                    if (i_pice.IsOpponent(upRightPice))
                    {
                        closeEnamyList.Add(upRightPice);
                        break;
                    }

                    currentCol += 1;
                }
            }

            return closeEnamyList;
        }

        private bool PiceCanEat(Pice i_pice)
        {
            bool canEat = false;

            List<Pice> closeEnamyList = this.closeEnamyList(i_pice);

            if (closeEnamyList.Count == 0)
            {
                canEat = false;
            }
            else
            {
                foreach (Pice enemyPice in closeEnamyList)
                {
                    int afterJumpRow = enemyPice.Row + (enemyPice.Row - i_pice.Row);
                    int afterJumpCol = enemyPice.Col + (enemyPice.Col - i_pice.Col);

                    if (!this.Board.HasPiceOrOutOfBoard(afterJumpRow, afterJumpCol))
                    {
                        if (!this.Board.OutOfBoard(afterJumpRow, afterJumpCol))
                        {
                            canEat = true;
                            break;
                        }
                    }
                }
            }

            return canEat;
        }

        private bool CurrentPlayerCanEat()
        {
            bool playerCanEat = false;

            foreach (Pice currentPice in this.m_PlayerTurn.Pices)
            {
                if (this.PiceCanEat(currentPice))
                {
                    playerCanEat = true;
                    break;
                }
            }

            return playerCanEat;
        }

        public bool PlayRandomMove()
        {
            List<Pice> currentPlayerPices = this.PlayerTurn.Pices;

            List<string> playerAvilableMoves = new List<string>();

            Random rnd = new Random();

            bool vaildMove = false;


            for (int i = 0; i < currentPlayerPices.Count; i++)
            {
                Pice currentPice = currentPlayerPices[i];

                List<Tuple<int, int>> canGoList = currentPice.CanGo(this.m_Board.Size);

                foreach (Tuple<int, int> destMove in canGoList)
                {
                    Tuple<int, int> source = currentPice.GetLocationTuple();
                    List<Tuple<int, int>> fullmove = new List<Tuple<int, int>> { source, destMove };

                    playerAvilableMoves.Add(this.moveTupleToStringMove(fullmove));
                }
            }

            while (!vaildMove)
            {
                if(playerAvilableMoves.Count == 0)
                {
                    break;
                }
                string currentMove = playerAvilableMoves[rnd.Next(playerAvilableMoves.Count)];
                if (!this.moveIsVaild(currentMove))
                {
                    playerAvilableMoves.Remove(currentMove);
                }
                else
                {
                    this.PlayMove(currentMove);
                    break;
                }
            }

            return true;
        }
    }
}
