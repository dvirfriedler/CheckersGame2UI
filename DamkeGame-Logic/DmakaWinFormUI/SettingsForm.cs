using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DamkaLogic;


namespace DmakaWinFormUI
{
    public partial class SettingsForm : Form
    {
        private string m_Player1Name ="";

        private string m_Player2Name = "PC";

        private int m_BoardSize = 0;


       


        public SettingsForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            m_Player1Name = this.FirstNameTextBox.Text;

            if(m_Player1Name.Length > 1 && m_BoardSize != 0)
            {
                StartGameButton.Enabled = true;
            }
            else
            {
                StartGameButton.Enabled = false;
            }
        }

        private void TowPlayersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TowPlayersCheckBox.Checked)
            {
                SecondNameTextBox.Enabled = true;
            }
            else
            {
                SecondNameTextBox.Enabled = false;
                if(m_BoardSize != 0 && FirstNameTextBox.Text.Length > 0)
                {
                    StartGameButton.Enabled = true;
                }
            }
        }

        private void BoradSizeGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Size6CheckBox.Checked)
            {
                m_BoardSize = 6;

                Size8CheckBox.Enabled = false;
                Size10CheckBox.Enabled = false;
                if(m_Player1Name.Length > 1)
                {
                    StartGameButton.Enabled = true;
                }
            }
            else
            {
                Size8CheckBox.Enabled = true;
                Size10CheckBox.Enabled = true;
            }
        }

        private void Size8CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Size8CheckBox.Checked)
            {
                m_BoardSize = 8;

                Size6CheckBox.Enabled = false;
                Size10CheckBox.Enabled = false;
            }
            else
            {
                Size6CheckBox.Enabled = true;
                Size10CheckBox.Enabled = true;
            }
        }

        private void Size10CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Size10CheckBox.Checked)
            {
                m_BoardSize = 10;

                Size6CheckBox.Enabled = false;
                Size8CheckBox.Enabled = false;
            }
            else
            {
                Size6CheckBox.Enabled = true;
                Size8CheckBox.Enabled = true;
            }
        }

        private void SecondNameTextBox_TextChanged(object sender, EventArgs e)
        {
            m_Player2Name = this.SecondNameTextBox.Text;

            if (m_Player2Name.Length > 1 && m_BoardSize != 0)
            {
                StartGameButton.Enabled = true;
            }
            else
            {
                StartGameButton.Enabled = false;
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            int test = 2;
            Game game = new Game(m_Player1Name,m_Player2Name,m_BoardSize);

            //GameForm gameForm = new GameForm(game);

           // gameForm.Show();

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
