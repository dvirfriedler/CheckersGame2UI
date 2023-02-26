using System;
using System.Collections.Generic;

namespace CheckersGame
{
    public class Player
    {
        private string m_Name;

        private string m_TeamSymbols;

        public Player m_Opponent;

        public List<Pice> m_PicesList;

        public Pice m_OneMoreTurnPice = null;

        public Player(string i_Name,string i_Symbole, List<Pice> i_Pices)
        {
            this.m_Name = i_Name;
            m_PicesList = i_Pices;
            initTeamSymbols(i_Symbole);
        }

        public string Name
        {
            get => m_Name;
        }

        public Player Opponent
        {
            get => m_Opponent;
        }

        public bool EatPice()
        {
            return m_OneMoreTurnPice != null;
        }

        public string TeamSymbols
        {
            get => m_TeamSymbols;
        }

        private void initTeamSymbols(string i_teamSymbole)
        {
            if (i_teamSymbole == "X")
            {
                m_TeamSymbols = "XK";
            }
            else
            {
                m_TeamSymbols = "OQ";
            }
        }
    }
}
