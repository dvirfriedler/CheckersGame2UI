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

        public bool HasPice(int i,int j)
        {
            bool hasPice = this.m_Borad[j, i] != null;
            return hasPice;
        }

        public void PlayMove(int sCol, int sRow, int destCol, int destRow)
        {
            this.m_Borad[destRow, destCol] = this.m_Borad[sRow, sCol];

            this.m_Borad[sRow, sCol] = null;
        }

        public override string ToString()
        {
            string boradString = "   ";

            for (int i = 0; i < this.m_Size + 1 ; i++)
            {
                for (int j = 0; j < this.m_Size +1; j++)
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
                for (int j = (i+1) % 2 ; j <this.m_Size; j = j + 2)
                {
                    this.m_Borad[i, j] = this.m_Player1.m_PicesList[piceNumber++];
                }
            }

            piceNumber = 0;

            for (int i = (this.m_Size / 2) + 1; i < this.m_Size; i++)
            {
                for (int j = (i + 1) % 2; j <= this.m_Size - 1; j = j + 2)
                {
                    this.m_Borad[i, j] = this.m_Player2.m_PicesList[piceNumber++];
                }
            }
        }
    }
}
