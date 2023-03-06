using System;
using System.Collections.Generic;

namespace CheckersGame
{
    public class Player
    {
        private readonly string m_Name;

        private string m_TeamSymbols;

        private Player m_Opponent;

        private List<Pice> m_PicesList;

        public Player(string i_Name,string i_Symbole, List<Pice> i_Pices)
        {
            this.m_Name = i_Name;
            this.m_PicesList = i_Pices;
            this.InitTeamSymbols(i_Symbole);
        }

        public string Name => this.m_Name;

        public string TeamSymbols => this.m_TeamSymbols;

        public Player Opponent
        {
            get => this.m_Opponent;
            set => this.m_Opponent = value;
        }

        public List<Pice> Pices
        {
            get => this.m_PicesList;
            set => this.m_PicesList = value;
        }

        private void InitTeamSymbols(string i_teamSymbole)
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
