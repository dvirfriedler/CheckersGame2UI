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

namespace DmakaWinFormUITest
{
    public partial class GameForm : Form
    {
        private Panel m_BoardPanel = null;

        private Game m_Game = null;

        private int m_BoardSize = 0;

        private Board m_Board = null;

        private readonly Dictionary<Button,Tuple<int,int>> m_ButtonsLocations = new Dictionary<Button, Tuple<int, int>>();

        private Button[,] _Buttons = null;

        private string m_CurrentMove = "";

        private List<Tuple<int,int>> m_MoveTuple = new List<Tuple<int,int>>();


        public GameForm(Game i_Game)
        {
            InitializeComponent();

            this.m_BoardPanel = this.BoardPanel;

            this.m_Game = i_Game;

            this.m_BoardSize = i_Game.BoardSize;

            this.m_Board = i_Game.Board;

            this._Buttons = new Button[m_BoardSize, m_BoardSize];

            this.initCheckersBoard();

            this.ShowBorad(i_Game);

            this.Show();

        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        public void ShowBorad(Game o_game)
        {
            for (int row = 0; row <o_game.BoardSize; row++)
            {
                for (int col = 0; col < o_game.BoardSize; col++)
                {
                    _Buttons[col, row].Text = o_game.Board.Borad[row, col] == null ? row.ToString()  + "," + col.ToString()  : o_game.Board.Borad[row, col].ToString();
                }
            }

            this.Show();
        }

        private void initCheckersBoard()
        {
            int squareSize = this.m_BoardPanel.Width / m_BoardSize;

            for (int row = 0; row < m_BoardSize; row++)
            {
                for (int col = 0; col < this.m_BoardSize; col ++)
                {
                    Button squareButton = new Button();

                    squareButton.Height = squareButton.Width = squareSize;

                    squareButton.BackColor = (row + col) % 2 == 0 ? Color.Black : Color.White;

                    squareButton.Click += Button_Click;

                    m_ButtonsLocations.Add(squareButton, new Tuple<int, int>(row, col));

                    this._Buttons[row, col] = squareButton; 

                    this.m_BoardPanel.Controls.Add(squareButton);

                    squareButton.Location = new Point(row * squareSize + this.m_BoardPanel.Location.X, col * squareSize + this.m_BoardPanel.Location.X);

                }
            }


            Button downLeftButton = this._Buttons[this.m_BoardSize - 1, this.m_BoardSize - 1];

            this.m_BoardPanel.BackColor = Color.Black;

            this.m_BoardPanel.Width = this.m_BoardPanel.Location.X + downLeftButton.Location.X + downLeftButton.Width;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button) sender;

            button.FlatAppearance.BorderColor = Color.DarkGray;

        }

        private void ClickToMove(Button i_button)
        {
            Tuple<int, int> m_Location = m_ButtonsLocations[i_button];

            if(m_MoveTuple.Count > 1)
            {
                m_MoveTuple.Clear();
            }
            else
            {
                m_MoveTuple.Add(m_ButtonsLocations[i_button]);
            }
        }
    }
}
