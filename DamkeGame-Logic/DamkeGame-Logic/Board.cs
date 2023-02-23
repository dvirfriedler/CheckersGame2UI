using System;

namespace CheckersGame
{
    public class Board
    {
        public Pice[,] m_Borad;

        public int m_Size;

        internal Player m_Player1 = null;

        internal Player m_Player2 = null;

        public Board(int boradSize ,Player i_player1, Player i_player2)
        {
            this.m_Borad = new Pice[boradSize, boradSize];
            this.m_Size = boradSize;
            this.m_Player1 = i_player1;
            this.m_Player2 = i_player2;
            this.initilaize();
        }

        public bool HasPice(int row, int col)
        {
            bool hasPice = this.m_Borad[row, col] != null;
            return hasPice;
        }

        public void DoMove(int sRow, int sCol, int destRow, int destCol)
        {
            List<Pice> soldiesrsInTheWay = ListSoldiersInWay(sRow, sCol, destRow, destCol);

            if (soldiesrsInTheWay.Count == 1)
            {
                removePice(soldiesrsInTheWay[0]);
            }

            this.m_Borad[sRow, sCol].m_Row = destRow;
            this.m_Borad[sRow, sCol].m_Col = destCol;

            this.m_Borad[destRow, destCol] = this.m_Borad[sRow, sCol];
            this.m_Borad[sRow, sCol] = null;

        }

        public List<Pice> ListSoldiersInWay(int sRow, int sCol, int destRow, int destCol)
        {
            List<Pice> soldiesrsInTheWay = new List<Pice>();

            int currentRow = sRow;
            int currentCol = sCol;

            if (sRow == destRow)
            {
                for (currentCol = sCol + UpOrDown(sCol,destCol); currentCol < destCol; currentCol += UpOrDown(sCol, destCol))
                {
                    soldiesrsInTheWay.Add(this.m_Borad[currentRow, currentCol]);
                }
            }
            else if (sCol == destCol)
            {
                for (currentRow = sRow + UpOrDown(sRow, destRow); currentRow < destRow; currentRow += UpOrDown(sRow, destRow))
                {
                    soldiesrsInTheWay.Add(this.m_Borad[currentRow, currentCol]);
                }
            }
            else
            {
                while (currentRow != destRow && currentCol != destCol)
                {
                    currentCol += UpOrDown(sCol, destCol);
                    currentRow += UpOrDown(sRow, destRow);
                    soldiesrsInTheWay.Add(this.m_Borad[currentRow, currentCol]);
                }
            }

            soldiesrsInTheWay.RemoveAll(item => item == null);
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

        public override string ToString()
        {
            string boradString = "   ";

            for (int i = 0; i < this.m_Size + 1; i++)
            {
                for (int j = 0; j < this.m_Size + 1; j++)
                {
                    if ( i == 0)
                    {
                        if (j != 8)
                        {
                            boradString += "  ";
                            boradString += (char)((int)'A' + j);
                            boradString += " ";
                        }
                    }
                    else if ( j == 0)
                    {
                        boradString += " ";
                        boradString += (char)((int)'a' - 1 + i);
                        boradString += " |";
                    }
                    else
                    {
                        if (this.m_Borad[i - 1, j - 1] == null)
                        {
                            boradString += " ";
                            boradString += " ";
                            boradString += " |";
                        }
                        else
                        {
                            boradString += " ";
                            boradString += this.m_Borad[i - 1, j - 1].ToString();
                            boradString += " |";
                        }
                    }
                }

                boradString += "\n    ";

                for (int j = 0; j < this.m_Size; j++)
                {
                    boradString += "----";
                }

                boradString += "\n";
            }

            Console.WriteLine(boradString); // test
            return boradString;
        }

        private void initilaize()
        {
            int piceNumber = 0;

            for (int i = 0; i < (this.m_Size / 2) - 1; i++)
            {
                for (int j = (i + 1) % 2; j < this.m_Size; j = j + 2)
                {
                    this.m_Player1.m_PicesList[piceNumber].m_Row = i;
                    this.m_Player1.m_PicesList[piceNumber].m_Col = j;

                    this.m_Borad[i, j] = this.m_Player1.m_PicesList[piceNumber++];
                }
            }

            piceNumber = 0;

            for (int i = (this.m_Size / 2) + 1; i < this.m_Size; i++)
            {
                for (int j = (i + 1) % 2; j <= this.m_Size - 1; j = j + 2)
                {
                    this.m_Player2.m_PicesList[piceNumber].m_Row = i;
                    this.m_Player2.m_PicesList[piceNumber].m_Col = j;

                    this.m_Borad[i, j] = this.m_Player2.m_PicesList[piceNumber++];
                }
            }
        }

        private void removePice(Pice pice)
        {
            this.m_Borad[pice.m_Row, pice.m_Col] = null;
        }
    }
}
