using System;
using System.Collections.Generic;

namespace CheckersGame
{
    public class Pice
    {
        private string m_Symbole { get; set; }

        private string m_TeamSymbols;


        private bool m_IsKing;

        private bool m_FirstMove;

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

            m_FirstMove = true;
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

        public string Symbole  => m_Symbole;

        public bool IsKing => m_IsKing;

        public bool IsFirstMove => m_FirstMove;

        public bool IsAnOponnetSoldier(Pice pice) => !m_TeamSymbols.Contains(pice.m_Symbole);
    }
}
