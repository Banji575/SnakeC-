using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public class SnakeTail : IGameEntity
    {
      public PictureBox element { get; set; }
      public Size size { get; set; }
      public  Point location { get; set; }
      Color color { get; set; }

        public SnakeTail(Size size, Point location, Color color)
        {
            this.size = size;
            this.location = location;
            this.color = color;
            createElement(this.size, this.location,this.color );
        }

        public void setPosition(Point newPos)
        {
            element.Location = newPos;
            location = newPos;
            
        }

        private void createElement(Size size, Point location,Color color)
        {
            element = new PictureBox();
            element.BackColor = color;
            element.Size = size;
            element.Location = location;
        }

    }
}
