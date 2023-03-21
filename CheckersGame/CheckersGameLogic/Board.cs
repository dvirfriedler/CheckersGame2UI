using System;

namespace CheckersLogic
{
    public class Board
    {
        private Pice[,] m_Borad;

        private readonly int m_Size;

        private readonly Player m_Player1 = null;

        private readonly Player m_Player2 = null;

        private string m_LastMove = "This is the first move";

        private int m_TotalNumberOfPices;

        public Board(int i_boradSize ,Player i_player1, Player i_player2)
        {
            this.m_Borad = new Pice[i_boradSize, i_boradSize];

            this.m_Size = i_boradSize;

            this.m_Player1 = i_player1;
            this.m_Player2 = i_player2;

            this.m_TotalNumberOfPices = m_Player1.Pices.Count + m_Player2.Pices.Count;

            this.initilaize();
        }

        public Pice[,] Borad => m_Borad;

        public int Size => this.m_Size;

        public Player Player1 => this.m_Player1;

        public Player Player2 => this.m_Player2;

        public string LastMove => this.m_LastMove;

        public int TotalNumberOfPices => this.m_TotalNumberOfPices;

        public bool HasPiceOrOutOfBoard(int row, int col)
        {
            bool hasPice = true;

            if (row < 0 || row >= m_Size || col < 0 || col >= m_Size)
            {
                hasPice = false;
            }
            else
            {
                hasPice = this.m_Borad[row, col] != null;
            }

            return hasPice;
        }

        public void DoMove(int sRow, int sCol, int destRow, int destCol)
        {
            List<Pice> soldiesrsInTheWay = this.ListSoldiersInWay(sRow, sCol, destRow, destCol);

            Pice piceToMove = this.m_Borad[sRow, sCol];

            if (soldiesrsInTheWay.Count == 1)
            {
                removePice(soldiesrsInTheWay[0]);
            }

            //// CanGoTeast

           //// Pice[,] tempBoard = this.m_Borad;
           //// Pice[,] testAvilableMoves = piceToMove.CanGoTest(m_Size);
           //// this.m_Borad = testAvilableMoves;
           //// Console.WriteLine(this.ToString());
           //// this.m_Borad = tempBoard;

            ////

            piceToMove.Row = destRow;
            piceToMove.Col = destCol;

            this.m_Borad[destRow, destCol] = this.m_Borad[sRow, sCol];
            this.m_Borad[sRow, sCol] = null;
        }

        public bool OutOfBoard(int row, int col)
        {
            bool outOfBoard = false;

            if (row < 0 || row >= this.m_Size || col < 0 || col >= this.m_Size)
            {
                outOfBoard = true;
            }

            return outOfBoard;
        }

        public List<Pice> ListSoldiersInWay(int sRow, int sCol, int destRow, int destCol)
        {
            List<Pice> soldiesrsInTheWay = new List<Pice>();

            int currentRow = sRow;
            int currentCol = sCol;

            if (sRow == destRow)
            {
                for (currentCol = sCol + UpOrDown(sCol, destCol); currentCol < destCol; currentCol += UpOrDown(sCol, destCol))
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

            return boradString;
        }

        private void initilaize()
        {
            int piceNumber = 0;

            for (int i = 0; i < (this.m_Size / 2) - 1; i++)
            {
                for (int j = (i + 1) % 2; j < this.m_Size; j = j + 2)
                {
                    this.Player1.Pices[piceNumber].Row = i;
                    this.Player1.Pices[piceNumber].Col = j;

                    this.m_Borad[i, j] = this.m_Player1.Pices[piceNumber++];
                }
            }

            piceNumber = 0;

            for (int i = (this.m_Size / 2) + 1; i < this.m_Size; i++)
            {
                for (int j = (i + 1) % 2; j <= this.m_Size - 1; j = j + 2)
                {
                    this.Player2.Pices[piceNumber].Row = i;
                    this.Player2.Pices[piceNumber].Col = j;

                    this.m_Borad[i, j] = this.Player2.Pices[piceNumber++];
                }
            }
        }

        private void removePice(Pice pice)
        {
            this.m_Borad[pice.Row, pice.Col] = null;

            this.m_TotalNumberOfPices--;

            if (this.Player1.TeamSymbols.Equals(pice.TeamSymbols))
            {
                this.Player1.Pices.Remove(pice);
            }
            else
            {
                this.Player2.Pices.Remove(pice);
            }
        }
    }
}
