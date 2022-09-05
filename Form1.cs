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
        private sbyte dirX = 1;
        private sbyte dirY = 0;
        private int _width = 900;
        private int _height = 800;
        private int _sizeOfSide = 40;
        private Field field;
        private Snake snake;
        private Fruit fruit;
        private Color fruitColor = Color.Yellow;


        private Label scoreLabel;

        private int score = 0;

        //private PictureBox[] snake = new PictureBox[400];

 
        public Form1()
        {
            InitializeComponent();
            
            this.Width = _width;
            this.Height = _height;
            this.KeyDown += new KeyEventHandler(OKP);

            scoreLabel = new Label();
            scoreLabel.Text = "Score: 0";
            scoreLabel.Location = new Point(810, 10);
            this.Controls.Add(scoreLabel);


            snake = new Snake(new Size(_sizeOfSide, _sizeOfSide), new Point(200, 200));
            Add(snake.head);

            timer.Tick += new EventHandler(update);
            timer.Interval = 200;
            timer.Start();

       

            GenerateFruit();
            Field gameField = new Field(_width, _height, _sizeOfSide);
            GenerateMap(gameField.GenerateMap());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void Add(IGameEntity tail)
        {
            this.Controls.Add(tail.element);
        }

        private void EatFruit()
        {
            if (snake.head.location.X == fruit.location.X && snake.head.location.Y == fruit.location.Y)
            {
                scoreLabel.Text = "Score" + ++score;
                GenerateFruit();
                SnakeTail lastElem = snake.LastElement;
                SnakeTail newElem = snake.CreateElement(
                    new Size(_sizeOfSide, _sizeOfSide),
                    new Point(lastElem.location.X + _sizeOfSide * dirX, lastElem.location.Y + _sizeOfSide * dirY)
                    );
                Add(newElem);
/*                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + 40 * dirX, snake[score - 1].Location.Y - 40 * dirY);
                snake[score].BackColor = Color.Red;
                snake[score].Size = new Size(_sizeOfSide, _sizeOfSide);
                this.Controls.Add(snake[score]);*/
            }
        }

        private void GenerateFruit()
        {
            if (fruit == null)
            {
                fruit = new Fruit(new Size(_sizeOfSide, _sizeOfSide), new Point(), fruitColor);
            }

            Random r = new Random();
            rI = r.Next(0, _width - 100 - _sizeOfSide);
            int tempI = rI % _sizeOfSide;
            rI -= tempI;

            rJ = r.Next(0, _height - _sizeOfSide);
            int tempJ = rJ % _sizeOfSide;
            rJ -= tempJ;

            fruit.setPosition(new Point(rI, rJ));
           
            Add(fruit);
        }

        private void CheckBorders()
        {

        }

        private void eatItSelf()
        {
     /*       for (int i = 1; i <=score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    for (int j = i; j <= score; j++)
                    {
                        this.Controls.Remove(snake[j]);
                        score = score - (score - i + 1);
                    }
                }
            }*/
        }

        private void GenerateMap(PictureBox[] pics)
        {
            for (int i = 0; i < pics.Length-1; i++)
            {
                this.Controls.Add(pics[i]);
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
            snake.Move(dirX, dirY);
            eatItSelf();
            EatFruit();
           // cube.Location = new Point(cube.Location.X + _sizeOfSide * dirX, cube.Location.Y + _sizeOfSide * dirY);
        }
    }
}
