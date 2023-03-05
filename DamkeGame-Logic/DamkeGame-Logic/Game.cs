using System;
using System.Collections.Generic;

namespace CheckersGame
{
    public class Game
    {
        public Board m_Board { get; set; }

        private Player m_Player1 { get; }

        private Player m_Player2 { get; }

        public Player m_PlayerTurn { get; set; }

        public string m_LastMove { get; set; }

        private int m_BoardSize { get; }

        public Game(string io_Player1Name = "firstPlater", string io_Plyaer2Name = "player2", int io_BoradSize = 6)
        {
            Pice player1Pice = new Pice(true);
            Pice player2Pice = new Pice(false);

            List<Pice> player1Pices = player1Pice.GetList((io_BoradSize / 2) * ((io_BoradSize / 2) -1));
            List<Pice> player2Pices = player2Pice.GetList((io_BoradSize / 2) * ((io_BoradSize / 2) - 1));

            this.m_Player1 = new Player(io_Player1Name, "X", player1Pices);
            this.m_Player2 = new Player(io_Plyaer2Name, "O", player2Pices);

            this.m_Player1.m_Opponent = this.m_Player2;
            this.m_Player2.m_Opponent = this.m_Player1;

            this.m_PlayerTurn = this.m_Player1;

            this.m_Board = new Board(io_BoradSize, this.m_Player1, this.m_Player2);

            this.m_LastMove = "This is the first move.";

            m_BoardSize = io_BoradSize;
        }

        public Player Player1 => this.m_Player1;

        public Player Player2 => this.m_Player2;

        public bool PlayMove(string i_Move)
        {
            bool didMove = true;

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

                if (!this.m_PlayerTurn.EatPice())
                {
                    this.m_PlayerTurn = this.PlayerTurn.Opponent;
                }
            }

            return didMove;
        }

        /// <summary>
        /// This methode chaeck that the move is vaild according to 3 rules.
        /// 1.Check that the move template is according to "**>**"
        /// 2.Check that the source isn't empty and that the detstnation is empty
        /// 3.Check that the source pice is belongs to the current player turn.
        /// 4.Check that the destnation location is included in the set of the avilabile location of the sorcepice.
        /// 5.Check if its avilable to eat soldiers in the way from sorce to destnation.
        /// </summary>
        /// <param name="sRow"></param>
        /// <param name="sCol"></param>
        /// <param name="destRow"></param>
        /// <param name="destCol"></param>
        /// <returns>return True if the move is can be done.</returns>
        private bool moveIsVaild(string i_Move)
        {
            bool moveIsVaild = true;

            List<Tuple<int, int>> sorceAndDest = this.moveToTuppleLocationsList(i_Move);

            int sCol = sorceAndDest[0].Item2;
            int sRow = sorceAndDest[0].Item1;
            int destCol = sorceAndDest[1].Item2;
            int destRow = sorceAndDest[1].Item1;

            List<Pice> soldiersInTheWayList = this.m_Board.ListSoldiersInWay(sRow, sCol, destRow, destCol);

            Pice sourcePice = this.m_Board.m_Borad[sRow, sCol];

            Tuple<int, int> dest = new Tuple<int, int>(destRow, destCol);

            if (!this.MoveTemplateIsValid(i_Move)) //// Check that the move string is "**>**"
            {
                moveIsVaild = false;
            }
            else if (this.m_Board.m_Borad[sRow, sCol] == null || this.m_Board.HasPice(destRow, destCol)) //// Check that the source has Pice and the dest dont.
            {
                moveIsVaild = false;
            }
            else if (!this.PlayerTurn.TeamSymbols.Equals(sourcePice.TeamSymbols))
            {
                moveIsVaild = false;
            }
            else if (!sourcePice.CanGo(this.m_Board.m_Size).Contains(dest))
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
                if (!sourcePice.IsKing) ////The pice isnt a king 
                {
                    if (this.distance(sCol, sRow, destCol, destRow) != 1)
                    {
                        moveIsVaild = false;
                    }
                }
            }

            if (CurrentPlayerCanEat())
            {
                if (soldiersInTheWayList.Count == 0)
                {
                    moveIsVaild = false;
                }
            }

            return moveIsVaild;
        }

        private int distance(int sCol, int sRow, int DestCol, int DestRow)
        {
            int colDistance = Math.Abs(sCol - DestCol);
            int rowDistance = Math.Abs(sRow - DestRow);

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

            List<int> locations = CharToLocation(i_Move);

            foreach (int location in locations)
            {
                if (location >= m_Board.m_Size)
                {
                    valid = false;
                }
            }

            return valid;
        }

        private List<int> CharToLocation(string i_Move)
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
            List<int> positions = CharToLocation(i_Move);

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

            if(m_Player1.m_PicesList.Count == 0 || m_Player2.m_PicesList.Count == 0)
            {
                gameIsOver = true;
            }

            return gameIsOver;
        }

        public double GetScore(Player i_Player)
        {
            double totalPicesCount = m_Player1.m_PicesList.Count + m_Player2.m_PicesList.Count;
            double score = 0.5 + (double)(i_Player.m_PicesList.Count) / totalPicesCount;

            return score;
        }

        public Player PlayerTurn
        {
            get => this.m_PlayerTurn;
        }

        private string moveTupleToStringMove(List<Tuple<int, int>> i_MoveTupple)
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
            return this.m_Board.m_Borad[row, col];
        }

        private List<Pice> closeEnamyList(Pice i_pice)
        {
            List<Pice> closeEnamyList = new List<Pice>();

            Pice downLeftPice = m_Board.m_Borad[Math.Min(i_pice.Row + 1, m_BoardSize - 1), Math.Max(i_pice.Col - 1, 0)];
            Pice downRightPice = m_Board.m_Borad[Math.Min(i_pice.Row + 1, m_BoardSize - 1), Math.Min(i_pice.Col + 1, m_BoardSize - 1)];
            Pice upLeftPice = m_Board.m_Borad[Math.Max(i_pice.Row - 1, 0), Math.Max(i_pice.Col - 1, 0)];
            Pice upRightPice = m_Board.m_Borad[Math.Max(i_pice.Row - 1, 0), Math.Min(i_pice.Col + 1, m_BoardSize - 1)];

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
                    upLeftPice = m_Board.m_Borad[Math.Max(currnetRow, 0), Math.Min(currentCol - 1, 0)];

                    if (i_pice.IsOpponent(upLeftPice))
                    {
                        closeEnamyList.Add(upLeftPice);
                        break;
                    }

                    currentCol -= 1;
                }

                currentCol = i_pice.Col;

                for (currnetRow = i_pice.Row + 1; currnetRow < m_BoardSize; currnetRow++) //// down Left
                {
                    downLeftPice = m_Board.m_Borad[Math.Min(currnetRow, m_BoardSize - 1), Math.Max(currentCol - 1, 0)];

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
                    upRightPice = m_Board.m_Borad[Math.Min(currnetRow, 0), Math.Min(currentCol - 1, m_BoardSize - 1)];

                    if (i_pice.IsOpponent(upRightPice))
                    {
                        closeEnamyList.Add(upRightPice);
                        break;
                    }

                    currentCol += 1;
                }

                currentCol = i_pice.Col;

                for (currnetRow = i_pice.Row + 1; currnetRow < m_BoardSize; currnetRow++) //// down Right
                {
                    downRightPice = m_Board.m_Borad[Math.Min(currnetRow, m_BoardSize - 1), Math.Min(currentCol + 1, m_BoardSize - 1)];

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
            bool canEat = true;

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

                    if (m_Board.HasPice(afterJumpRow, afterJumpCol))
                    {
                        canEat = true;
                    }
                }
            }

            return canEat;
        }

        private bool CurrentPlayerCanEat()
        {

            bool playerCanEat = false;

            foreach (Pice currentPice in this.m_PlayerTurn.m_PicesList)
            {
                if (PiceCanEat(currentPice))
                {
                    playerCanEat = true;
                    break;
                }
            }

            return playerCanEat;
        }

        public bool PlayRandomMove()
        {
            List<Pice> currentPlayerPices = m_PlayerTurn.m_PicesList;

            List<string> playerAvilableMoves = new List<string>();

            Random rnd = new Random();

            bool vaildMove = false;

            for (int i = 0; i < currentPlayerPices.Count; i++)
            {
                Pice currentPice = currentPlayerPices[i];

                List<Tuple<int, int>> canGoList = currentPice.CanGo(this.m_Board.m_Size);

                foreach (Tuple<int, int> destMove in canGoList)
                {
                    Tuple<int, int> source = currentPice.GetLocationTuple();
                    List<Tuple<int, int>> fullmove = new List<Tuple<int, int>> { source, destMove };

                    playerAvilableMoves.Add(moveTupleToStringMove(fullmove));
                }
            }

            while (!vaildMove)
            {
                string currentMove = playerAvilableMoves[rnd.Next(playerAvilableMoves.Count)];
                if (!moveIsVaild(currentMove))
                {
                    playerAvilableMoves.Remove(currentMove);
                }
                else
                {
                    PlayMove(currentMove);
                    break;
                }
            }

            return true;
        }
    }
}
