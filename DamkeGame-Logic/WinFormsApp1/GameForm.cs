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

        private readonly Dictionary<Button, Tuple<int, int>> m_ButtonsLocations = new Dictionary<Button, Tuple<int, int>>();

        private Button[,] _Buttons = null;

        private Button m_srcButton;

        private Button m_destButton;

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
                    setButtonPhoto(_Buttons[col, row]);
                }
            }

            this.Show();
        }

        private void setButtonPhoto(Button i_button)
        {
            switch (i_button.Text)
            {
                case "X":
                    i_button.Image = Image.FromFile(@"C:\\Users\\dvirf\\source\\repos\\DamkaCounle\\DamkeGame-Logic\\Photos\\black-sol.png");
                    break;

                case "O":
                    i_button.Image = Image.FromFile(@"C:\Users\dvirf\source\repos\DamkaCounle\DamkeGame-Logic\Photos\white-sol.png");
                    break;

                case "K":
                    i_button.Image = System.Drawing.Image.FromFile(@"C:\Users\dvirf\source\repos\DamkaCounle\DamkeGame-Logic\Photos\black-King.png");
                    break;

                case "Q":
                    i_button.Image = System.Drawing.Image.FromFile(@"C:\Users\dvirf\source\repos\DamkaCounle\DamkeGame-Logic\Photos\white-king.png");
                    break;

                default:
                    i_button.Image = null;
                    break;

            }
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

                    squareButton.BackColor = (row + col) % 2 == 0 ? Color.White : Color.Black;

                    if(squareButton.BackColor == Color.White)
                    {
                        squareButton.Enabled = false;
                    }

                    squareButton.Click += Button_Click;

                    m_ButtonsLocations.Add(squareButton, new Tuple<int, int>(col, row));

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

            setCorrectColor(button);

            ClickToMove(button);
        }

        private void setCorrectColor(Button i_button)
        {
            if (i_button.BackColor == Color.Black)
            {
                i_button.BackColor = Color.DarkGray;
            }
            else if (i_button.BackColor == Color.DarkGray)
            {
                i_button.BackColor = Color.Black;
            }
            else if (i_button.BackColor == Color.White)
            {
                i_button.BackColor = Color.Gray;
            }
            else
            {
                i_button.BackColor = Color.White;
            }
        }

        private void ClickToMove(Button i_button)
        {

            if (m_srcButton == null)
            {
                this.m_srcButton = i_button;
            }
            else if (this.m_destButton == null)
            {
                this.m_destButton = i_button;
            }
            else
            {
                this.m_srcButton = i_button;
                this.m_destButton = null;
            }

            if (m_destButton != null)
            {
                playMove();

                this.m_srcButton.BackColor = Color.Black;
                this.m_destButton.BackColor = Color.Black;

            }
        }


        private void playMove()
        {
            Tuple<int, int> srcTuple = this.m_ButtonsLocations[this.m_srcButton];
            Tuple<int, int> destTuple = this.m_ButtonsLocations[this.m_destButton];

            List<Tuple<int, int>> moveTuple = new List<Tuple<int, int>>() { srcTuple,destTuple};

            string move = m_Game.moveTupleToStringMove(moveTuple);

            bool didmove = m_Game.PlayMove(move);

            ShowBorad(m_Game);
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
