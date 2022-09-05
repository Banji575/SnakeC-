using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public class Fruit : IGameEntity
    {
        public PictureBox element { get; set; }
        public Size size { get; set; }
        public Point location { get; set; }
        Color color { get; set; }
        
        public Fruit(Size size, Point location, Color color)
        {
            this.size = size;
            this.location = location;
            this.color = color;
            element = createFruit();
        }

        public void setPosition(Point point)
        {
            element.Location = point;
        }

        private PictureBox createFruit()
        {
            PictureBox fruit = new PictureBox();
            fruit.BackColor = color;
            fruit.Location = location;
            fruit.Size = size;
            return fruit;
        }


    }
}
