using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckersLogic;

namespace CheckersWinFormUI
{
    public partial class GameForm : Form
    {
        private Panel m_BoardPanel = null;

        private Game m_Game;

        private int m_BoardSize = 0;

        private Board m_Board;

        private readonly Dictionary<Button, Tuple<int, int>> m_ButtonsLocations = new Dictionary<Button, Tuple<int, int>>(); //Item1 = col, Item2 = row

        private Button[,] _Buttons;

        private Button m_srcButton;

        private Button m_destButton;

        private Button m_LastSrcButton;

        private Button m_LastDestButton;


        public GameForm(Game i_Game)
        {
            InitializeComponent();

            this.m_BoardPanel = this.BoardPanel;

            this.m_Game = i_Game;

            this.m_BoardSize = i_Game.BoardSize;

            this.m_Board = i_Game.Board;

            this._Buttons = new Button[m_BoardSize, m_BoardSize];

            this.initCheckersBoard();

            this.ShowBorad();

            this.Show();
        }

        private Button LastSrcButton
        {
            get => this.m_LastSrcButton;
            set
            {
                if(m_LastSrcButton!= null)
                {
                    this.m_LastSrcButton.BackColor = Color.Black;

                }
                this.m_LastSrcButton = value;
                this.m_LastSrcButton.BackColor = Color.Blue;

            }
        }

        private Button LastDestButton
        {
            get => this.m_LastDestButton;
            set
            {
                if(m_LastDestButton != null)
                {
                    this.m_LastDestButton.BackColor = Color.Black;
                }
                this.m_LastDestButton = value;
                this.m_LastDestButton.BackColor = Color.Blue;
            }
        }



        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        public void ShowBorad()
        {
            for (int row = 0; row <this.m_Game.BoardSize; row++)
            {
                for (int col = 0; col < this.m_Game.BoardSize; col++)
                {
                    setButtonPhoto(_Buttons[col, row]);
                }
            }

            ScorePlayer1Label.Text = this.m_Game.Player1.Name + " Score: " + this.m_Game.GetScore(this.m_Game.Player1).ToString();
            ScorePlayer2Label.Text = this.m_Game.Player2.Name + " Score: " + this.m_Game.GetScore(this.m_Game.Player2).ToString();

            this.Show();
        }

        private void setButtonPhoto(Button i_button)
        {
            int col = this.m_ButtonsLocations[i_button].Item2;

            int row = this.m_ButtonsLocations[i_button].Item1;

            string piceSymbole = this.m_Game.Board.Borad[row, col] == null ? row.ToString() + "," + col.ToString() : this.m_Game.Board.Borad[row, col].ToString();

            switch (piceSymbole)
            {
                case "X":
                    i_button.BackgroundImage = Image.FromFile("Photos/black-sol.png");
                    break;

                case "O":
                    i_button.BackgroundImage = Image.FromFile("Photos/white-sol.png");
                    break;

                case "K":
                    i_button.BackgroundImage = Image.FromFile("Photos/black-King.png");
                    break;

                case "Q":
                    i_button.BackgroundImage = Image.FromFile("Photos/white-king.png");
                    break;

                default:
                    i_button.BackgroundImage = null;
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

                    Color buttonColor = (row + col) % 2 == 0 ? Color.White : Color.Black;

                    Point buttonLocation = new Point(row * squareSize + this.m_BoardPanel.Location.X, col * squareSize + this.m_BoardPanel.Location.X);

                    setSquareButtonProperties(squareButton, squareSize, buttonColor, buttonLocation);
                    
                    m_ButtonsLocations.Add(squareButton, new Tuple<int, int>(col, row));

                    this._Buttons[row, col] = squareButton; 

                    this.m_BoardPanel.Controls.Add(squareButton);
                }
            }

            Button downLeftButton = this._Buttons[this.m_BoardSize - 1, this.m_BoardSize - 1];

            this.m_BoardPanel.BackColor = Color.Black;

            this.m_BoardPanel.Width = this.m_BoardPanel.Location.X + downLeftButton.Location.X + downLeftButton.Width;
        }

        private void setSquareButtonProperties(Button i_button,int i_size ,Color i_color,Point i_location)
        {
            i_button.Height = i_button.Width = i_size;

            i_button.BackColor = i_color;

            i_button.Enabled = i_button.BackColor == Color.Black;

            i_button.BackgroundImageLayout = ImageLayout.Stretch;

            i_button.Click += Button_Click;

            i_button.Location = i_location;
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
            else
            {
                i_button.BackColor = Color.Black;
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


        private void playMove(bool random = false)
        {
            if (random)
            {
                this.m_Game.PlayRandomMove();

            }
            else
            {
                Tuple<int, int> srcTuple = this.m_ButtonsLocations[this.m_srcButton];
                Tuple<int, int> destTuple = this.m_ButtonsLocations[this.m_destButton];

                List<Tuple<int, int>> moveTuple = new List<Tuple<int, int>>() { srcTuple, destTuple };

                string move = m_Game.moveTupleToStringMove(moveTuple);

                bool didmove = m_Game.PlayMove(move);
            }

            string lastMove = this.m_Game.LastMove;

            LastSrcButton = stringLocationToButton(lastMove.Substring(0, 2));

            LastDestButton = stringLocationToButton(lastMove.Substring(3, 2));

            ShowBorad();
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonRandomeMove_Click(object sender, EventArgs e)
        {
            this.playMove(true); //random = true
        }

        private Button stringLocationToButton(string i_location)
        {
            char[] locationCahrArray = i_location.ToCharArray();

            int col = locationCahrArray[0] - (int)'A';
            int row = locationCahrArray[1] - (int)'a';

            return _Buttons[col, row];
        }

        private void buttonFinishGame_Click(object sender, EventArgs e)
        {
            Form formGameOver = new FinishGameForm();
            formGameOver.Show();
        }
    }
}
