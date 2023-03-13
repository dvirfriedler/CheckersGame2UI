using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DamkaLogic;

namespace DmakaWinFormUITest
{
    public partial class GameForm : Form
    {
        private Game m_Game;

        private List<Button> m_ButtonSlots = new List<Button>();

        private TableLayoutPanel m_board = null;


        public GameForm(Game i_Game)
        {
            InitializeComponent();

            this.m_Game = i_Game;

            this.m_board = this.BoardPanel;

            initBoard(); 
        }


        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void initBoard()
        {
            this.m_board.RowCount = m_Game.Board.Size;

            this.m_board.ColumnCount = m_Game.Board.Size;

           m_board.Dock = DockStyle.Fill;

            m_board.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            this.m_board.Height = this.m_board.Width = this.Width = 600;

            int squereSize = m_board.Size.Width / m_Game.Board.Size;

            for (int row = 0; row < m_Game.Board.Size; row++)
            {
                for (int col = 0; col < m_Game.Board.Size; col++)
                {
                    PictureBox square = new PictureBox();
                    square.Dock = DockStyle.Fill;
                    square.SizeMode = PictureBoxSizeMode.Zoom;

                    square.Height = squereSize;
                    square.Width = squereSize;

                    if ((row + col) % 2 == 0)
                    {
                        // Even cells are light-colored
                        square.BackColor = Color.White;
                    }
                    else
                    {
                        // Odd cells are dark-colored
                        square.BackColor = Color.Black;
                    }
                    m_board.Controls.Add(square, col, row);
                }
            }
            this.ShowDialog();
        }

        public static void ShowInstractions()
        {

        }



        public static void ShowBorad(Game o_game)
        {
            string board = o_game.Board.ToString();

            int boardSize = o_game.Board.Size;


            
        }


        public static void NotAValidMove()
        {
            Form errorForm = new Form();
            errorForm.Text = "Please Enter a valid move!!!";
        }

        public static string AskForNextMove(Game i_game)
        {
            return "";
        }

        private void GameForm_Load_1(object sender, EventArgs e)
        {

        }

        private void GameForm_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void GameForm_Resize(object sender, EventArgs e)
        {

        }
    }
}
