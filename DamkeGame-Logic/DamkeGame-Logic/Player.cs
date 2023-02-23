using System;
using System.Collections.Generic;

namespace CheckersGame
{
    public class Player
    {
        private string m_Name;

        private string m_Symbols;

        public Player m_Opponent;

        public List<Pice> m_PicesList;

        public Pice m_OneMoreTurnPice = null;

        public Player(string i_Name,string m_Symbole, List<Pice> i_Pices)
        {
            this.m_Name = i_Name;
            m_PicesList = i_Pices;
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
    }
}
