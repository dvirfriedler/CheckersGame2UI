using System;
using System.Collections.Generic;

namespace CheckersGame
{
    public class Pice
    {
        private string m_Symbole;

        private string m_TeamSymbols;

        private bool m_IsKing;

        private int m_Col;

        private int m_Row;

        private int m_BoardSize;

        private int m_Rank;

        public Pice(bool isPlayerOnePice)
        {
           this.m_Symbole = "O";

           m_TeamSymbols = "OQ";

           if (isPlayerOnePice)
           {
                this.m_Symbole = "X";

                this.m_TeamSymbols = "XK";
           }

           this.m_IsKing = false;

           this.m_Rank = 1;
        }

        private void SetKing()
        {
            string newSymbole = "K";

            if (m_Symbole.Equals("O"))
            {
                newSymbole = "Q";
            }

            this.m_Rank = 10;

            this.m_Symbole = newSymbole;
        }

        public List<Pice> GetList(int i_ListSize)
        {
            List<Pice> pices = new List<Pice>();

            for (int i = 0; i < i_ListSize; i++)
            {
                Pice newPice = new Pice(this.m_Symbole.Equals("X"));
                pices.Add(newPice);
            }

            return pices;
        }

        public override string ToString() => m_Symbole.ToString();

        public string Symbole
        {
            get => this.m_Symbole;
            set => this.m_Symbole = value;
        }

        public int Rank => this.m_Rank;

        public bool IsKing => m_IsKing;

        public bool IsAnOponnetSoldier(Pice pice) => !m_TeamSymbols.Contains(pice.m_Symbole);

        public string TeamSymbols => m_TeamSymbols;

        public int Col
        {
            get => this.m_Col;
            set => this.m_Col = value;
        }

        public int Row
        {
            get => this.m_Row;
            set
            {
                this.m_Row = value;
                {
                    if (this.m_Row == this.m_BoardSize - 1 && this.m_Symbole == "X")
                    {
                       this.SetKing();
                    }
                    else if (this.m_Row == 0 && this.m_Symbole == "O")
                    {
                       this.SetKing();
                    }
                }
            }
        }

        public Tuple<int,int> GetLocationTuple()
        {
            Tuple<int, int> locationTuple = new Tuple<int, int>(this.Row, this.Col);

            return locationTuple;
        }

        public bool IsOpponent(Pice i_Pice)
        {
            bool isOponnent = true;

            if (i_Pice == null)
            {
                isOponnent = false;
            }
            else
            {
                isOponnent = (!this.m_TeamSymbols.Contains(i_Pice.m_Symbole));
            }

            return isOponnent;
        }

        public Pice[,] CanGoTest(int i_BoradSize)
        {
            Pice[,] availableMoves = new Pice[i_BoradSize, i_BoradSize];

            availableMoves[this.Row, this.Col] = this;

            List<Tuple<int, int>> canGoList = CanGo(i_BoradSize);

            foreach (Tuple<int, int> tuple in canGoList)
            {
                Pice testPice = new Pice(true);
                testPice.Symbole = "T";
                availableMoves[tuple.Item1, tuple.Item2] = testPice;
            }

            return availableMoves;
        }

        public List<Tuple<int, int>> CanGo(int i_BoradSize)
        {
            this.m_BoardSize = i_BoradSize;

            List<Tuple<int, int>> canGo = new List<Tuple<int, int>>();

            if (this.m_Symbole == "X")
            {
                canGo.Add(new Tuple<int, int>(this.m_Row + 1, this.m_Col - 1));
                canGo.Add(new Tuple<int, int>(this.m_Row + 1, this.m_Col + 1));
                canGo.Add(new Tuple<int, int>(this.m_Row + 2, this.m_Col - 2));
                canGo.Add(new Tuple<int, int>(this.m_Row + 2, this.m_Col + 2));
            }
            else if (this.m_Symbole == "O")
            {
                canGo.Add(new Tuple<int, int>(this.m_Row - 1, this.m_Col - 1));
                canGo.Add(new Tuple<int, int>(this.m_Row - 1, this.m_Col + 1));
                canGo.Add(new Tuple<int, int>(this.m_Row - 2, this.m_Col - 2));
                canGo.Add(new Tuple<int, int>(this.m_Row - 2, this.m_Col + 2));
            }
            else
            {
                int addOrSubToCol = 0;

                for (int currentRow = this.m_Row + 1; currentRow < i_BoradSize; currentRow++)
                {
                    addOrSubToCol++;

                    canGo.Add(new Tuple<int, int>(currentRow, this.m_Col + addOrSubToCol));
                    canGo.Add(new Tuple<int, int>(currentRow, this.m_Col - addOrSubToCol));
                }

                addOrSubToCol = 0;

                for (int i = this.m_Row - 1; i >= 0; i--)
                {
                    addOrSubToCol++;

                    canGo.Add(new Tuple<int, int>(i, this.m_Col + addOrSubToCol));
                    canGo.Add(new Tuple<int, int>(i, this.m_Col - addOrSubToCol));
                }
            }

            List<Tuple<int, int>> itemsToRemove = new List<Tuple<int, int>>();

            foreach (Tuple<int, int> item in canGo)
            {
                if (item.Item1 >= i_BoradSize || item.Item2 >= i_BoradSize || item.Item1 < 0 || item.Item2 < 0)
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (Tuple<int, int> item in itemsToRemove)
            {
                canGo.Remove(item);
            }

            canGo.Sort((x, y) => Math.Abs(x.Item1 - this.Row).CompareTo(Math.Abs(y.Item1 - this.Row))); //// Sort the list from close move to far move

            return canGo;
        }
    }
}
