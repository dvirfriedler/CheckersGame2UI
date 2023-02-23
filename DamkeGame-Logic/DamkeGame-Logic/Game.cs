using System;
using System.Collections.Generic;

namespace CheckersGame
{
    public class Game
    {
        public Board m_Board { get; set; }

        private Player m_Player1 { get; set; }

        private Player m_Player2 { get; set; }

        public Player m_PlayerTurn { get; set; }

        public string m_LastMove { get; set; }

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
        }

        public bool PlayMove(string i_Move)
        {
            bool didMove = true;

            // List<int> positions = this.CharToLocation(i_Move);
            //
            // int sCol = positions[0];
            // int sRow = positions[1];
            // int destCol = positions[2];
            // int destRow = positions[3];
            //
            // if (!this.MoveTemplateIsValid(i_Move)) // Check that the move string is "**>**"
            // {
            //     didMove = false;
            // }
            // else if (!this.MoveLocationsIsValid(i_Move)) // check that the location inside the board
            // {
            //     didMove = false;
            // }
            // else if (!m_Board.HasPice(sCol, sRow) || m_Board.HasPice(destCol, destRow)) // check that the source has soldier and the destnation dont
            // {
            //     didMove = false;
            // }
            // else if (!this.MoveIsVaild(sCol, sRow, destCol, destRow)) // check the the move is vaild according to checkars rules
            // {
            //     didMove = false;
            // }
            // else
            // {
            //     this.m_Board.PlayMove(positions[0], positions[1], positions[2], positions[3]); //If everything was ok it will do the move
            // }

            // test end

            List<Tuple<int, int>> sorceAndDest = this.moveToTuppleLocationsList(i_Move);

            int sCol = sorceAndDest[0].Item2;
            int sRow = sorceAndDest[0].Item1;
            int destCol = sorceAndDest[1].Item2;
            int destRow = sorceAndDest[1].Item1;

            Pice sourcePice = this.m_Board.m_Borad[sRow, sCol];

            if (sourcePice == null)
            {
                didMove = false;
            }
            else if (m_Board.HasPice(destRow, destCol))
            {
                didMove = false;
            }
            else if (!moveIsVaild2(sRow, sCol, destRow, destCol))
            {
                didMove = false;
            }
            else
            {
                this.m_Board.PlayMove(sRow, sCol, destRow, destCol); ////If everything was ok it will do the move
            }

            return didMove;
        }

        private bool moveIsVaild2(int sRow, int sCol, int destRow, int destCol)
        {
            bool moveIsVaild = true;

            List<Pice> soldiersInTheWayList = this.ListSoldiersInWay(sCol, sRow, destCol, destRow);

            Pice sourcePice = this.m_Board.m_Borad[sRow, sCol];

            Tuple<int, int> dest = new Tuple<int, int>(destRow, destCol);

            if (!sourcePice.CanGo(this.m_Board.m_Size).Contains(dest))
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

            return moveIsVaild;
        }

        private bool MoveIsVaild(int sCol, int sRow, int destCol, int destRow)
        {
            bool moveIsVaild = true;

            List<Pice> soldiersInTheWayList = this.ListSoldiersInWay(sCol, sRow, destCol, destRow);

            Pice sourcePice = this.m_Board.m_Borad[sRow, sCol];

            if (soldiersInTheWayList.Count > 1) /// There is more than one soldier in the way
            {
                moveIsVaild = false;
            }
            else if (sourcePice.IsKing) // Pice is a King
            {
                if (soldiersInTheWayList.Count == 1)
                {
                    if (!soldiersInTheWayList[0].IsAnOponnetSoldier(sourcePice)) // the soldier in the way is from the same team
                    {
                        moveIsVaild = false;
                    }
                }
            }
            else if (soldiersInTheWayList.Count == 1) // Pice is not a king and have one soldier in the way
            {
                if (!soldiersInTheWayList[0].IsAnOponnetSoldier(sourcePice)) //The pice in the way is not an Oponnent
                {
                    moveIsVaild = false;
                }
                else if (this.distance(sCol, sRow, destCol, destRow) != 2) // distance is to big for a regular soldier
                {
                    moveIsVaild = false;
                }
            }
            else if (soldiersInTheWayList.Count == 0) // pice not a king and no soldiers in the way
            {
                if (this.distance(sCol, sRow, destCol, destRow) != 1) // REGULAR PICE AND TRY DO TO MORE THAN ONE STPES NOT IN THE FIRST MOVE;
                {
                    moveIsVaild = false;
                }
            }

            return moveIsVaild;
        }

        private List<Pice> ListSoldiersInWay(int sCol, int sRow, int destCol, int destRow)
        {
            List<Pice> soldiesrsInTheWay = new List<Pice>();

            int currentRow = sRow;
            int currentCol = sCol;
            while (currentRow != destRow + 1 && currentCol != destCol + 1)
            {
                currentCol = sCol;
                while (currentCol != destCol + 1)
                {
                    if (this.m_Board.m_Borad[currentRow, currentCol] != null)
                    {
                        soldiesrsInTheWay.Add(this.m_Board.m_Borad[currentRow, currentCol]);
                    }

                    currentCol = 1 * UpOrDown(sCol, destCol);
                }

                currentRow += 1 * UpOrDown(sRow, destRow);
            }

          //  for (int currentRow = sRow; currentRow != destRow + 1; currentRow += 1*UpOrDown(sRow, destRow))
          //  {
          //      for (int currentCol = sCol; currentCol != destCol + 1; currentCol += 1 * UpOrDown(sCol, destCol))
          //      {
          //          if (this.m_Board.m_Borad[currentRow, currentCol] != null)
          //          {
          //              soldiesrsInTheWay.Add(this.m_Board.m_Borad[currentRow, currentCol]);
          //          }
          //      }
          //  }
          //
          //  soldiesrsInTheWay.Remove(soldiesrsInTheWay[0]); // remove the pice that in borad[sCol,sRow]

            return soldiesrsInTheWay;
        }

        private int UpOrDown(int sorce, int dest)
        {
            int upOrDown = 1;

            if (dest - sorce < 0)
            {
                upOrDown = -1;
            }

            return upOrDown;
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

            if(i_Move.Length != 5)
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

        private bool MoveLocationsIsValid(String i_Move)
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
            return true;
        }

        public string GetScore()
        {
            return "";
        }

        public Player PlayerTurn
        {
            get => this.m_PlayerTurn;
        }
    }
}
