using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DmakaWinFormUI
{
    public partial class GameForm : Form
    {
        private string m_Move = null;

        private List<Button> m_ButtonSlots = new List<Button>();
        public GameForm(Game i_Game)
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            
        }

        public static void NotAValidMove()
        {
            Form errorForm = new Form();
            errorForm.Text = "Please Enter a valid move!!!";
        }

        public static string AskForNextMove(Game i_game)
        {
            
        }

    }
}
