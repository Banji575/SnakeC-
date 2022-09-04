using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        private int rI, rJ;
        private int dirX = 1;
        private int dirY = 0;
        private int _width = 900;
        private int _height = 800;
        private int _sizeOfSide = 40;

        private Label scoreLabel;

        private int score = 0;

        private PictureBox[] snake = new PictureBox[400];

        private PictureBox fruit;
        public Form1()
        {
            InitializeComponent();
            GenerateMap();
            this.Width = _width;
            this.Height = _height;
            this.KeyDown += new KeyEventHandler(OKP);

            scoreLabel = new Label();
            scoreLabel.Text = "Score: 0";
            scoreLabel.Location = new Point(810, 10);
            this.Controls.Add(scoreLabel);


            snake[0] = new PictureBox();
            snake[0].Location = new Point(200, 200);
            snake[0].Size = new Size(_sizeOfSide, _sizeOfSide);
            snake[0].BackColor = Color.Red;
            this.Controls.Add(snake[0]);

            timer.Tick += new EventHandler(update);
            timer.Interval = 200;
            timer.Start();

            fruit = new PictureBox();
            fruit.Size = new Size(_sizeOfSide, _sizeOfSide);
            fruit.BackColor = Color.Yellow;

            GenerateFruit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void EatFruit()
        {
            if (snake[0].Location.X == rI && snake[0].Location.Y == rJ)
            {
                scoreLabel.Text = "Score" + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + 40 * dirX, snake[score - 1].Location.Y - 40 * dirY);
                snake[score].BackColor = Color.Red;
                snake[score].Size = new Size(_sizeOfSide, _sizeOfSide);
                this.Controls.Add(snake[score]);
            }
        }

        private void GenerateFruit()
        {
            Random r = new Random();
            rI = r.Next(0, _width - _sizeOfSide);
            int tempI = rI % _sizeOfSide;
            rI -= tempI;

            rJ = r.Next(0, _height - _sizeOfSide);
            int tempJ = rJ % _sizeOfSide;
            rJ -= tempJ;

            fruit.Location = new Point(rI, rJ);
            this.Controls.Add(fruit);
        }

        private void MoveSnake()
        {
            for (int i = score; i>= 1 ; i--)
            {
                Point coord = snake[i].Location;
                Point prevCoord = snake[i - 1].Location;
                snake[i].Location = new Point(prevCoord.X, prevCoord.Y);
            }
            Point headCoord = snake[0].Location;
            snake[0].Location = new Point(headCoord.X + _sizeOfSide * dirX, headCoord.Y + _sizeOfSide * dirY);
        }

        private void CheckBorders()
        {

        }

        private void eatItSelf()
        {
            for (int i = 1; i <=score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    for (int j = i; j <= score; j++)
                    {
                        this.Controls.Remove(snake[j]);
                        score = score - (score - i + 1);
                    }
                }
            }
        }

        private void GenerateMap()
        {
            for (int i = 0; i < _width / _sizeOfSide; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, _sizeOfSide * i);
                pic.Size = new Size(_width - 140, 1);
                this.Controls.Add(pic);
            }
            for (int i = 0; i < _height / _sizeOfSide; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(_sizeOfSide * i, 0);
                pic.Size = new Size(1, _height);
                this.Controls.Add(pic);
            }
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;
                    break;
            }
        }

        private void update(Object obj, EventArgs e)
        {
            MoveSnake();
            eatItSelf();
            EatFruit();
           // cube.Location = new Point(cube.Location.X + _sizeOfSide * dirX, cube.Location.Y + _sizeOfSide * dirY);
        }
    }
}
