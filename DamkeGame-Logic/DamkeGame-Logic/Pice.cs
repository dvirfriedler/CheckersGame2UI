using System;
using System.Collections.Generic;

namespace CheckersGame
{

    public class Pice
    {
        private string m_Symbole { get; set; }

        private string m_TeamSymbols;

        private bool m_IsKing;

        public int m_Col;

        public int m_Row;

        public Pice(bool isPlayerOnePice)
        {
            m_Symbole = "O";

            m_TeamSymbols = "OQ";

            if (isPlayerOnePice)
            {
                m_Symbole = "X";

                m_TeamSymbols = "XK";
            }

            m_IsKing = false;

        }

        public void SetKing()
        {
            string newSymbole = "K";

            if (m_Symbole.Equals("O"))
            {
                newSymbole = "Q";
            }

            m_Symbole = newSymbole;
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

        public string Symbole => this.m_Symbole;

        public bool IsKing => m_IsKing;

        public bool IsAnOponnetSoldier(Pice pice) => !m_TeamSymbols.Contains(pice.m_Symbole);

        public bool CanEat()
        {
            return true;
        }

        public List<Tuple<int, int>> CanGo(int i_BoradSize)
        {
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
                for (int i = this.m_Row + 1; i < i_BoradSize; i++)
                {
                    int j = 1;
                    canGo.Add(new Tuple<int, int>(i, this.m_Col + j));
                    canGo.Add(new Tuple<int, int>(i, this.m_Col - j));
                }

                for (int i = this.m_Row - 1; i > 0; i--)
                {
                    int j = 1;
                    canGo.Add(new Tuple<int, int>(i, this.m_Col + j));
                    canGo.Add(new Tuple<int, int>(i, this.m_Col - j));
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

            return canGo;
        }
    }
}
