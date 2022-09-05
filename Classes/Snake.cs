using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public class Snake
    {
        public SnakeTail head;
        private List<SnakeTail> body;
        private Size size;
        private Point startLocation;
        private Color color = Color.Red;

    
        public Snake(Size size, Point startLocation )
        {
            this.size = size;
            this.startLocation = startLocation;
            body = new List<SnakeTail>();
            head = CreateElement(this.size, this.startLocation);
        }

        public SnakeTail LastElement => body[body.Count - 1];
        public void Move(sbyte dirX, sbyte dirY)
        {
            for (int i = body.Count - 1; i >= 1; i--)
            {
                Point coord = body[i].location;
                Point prevCoord = body[i - 1].location;
                body[i].setPosition(new Point(prevCoord.X, prevCoord.Y)) ;
            }
            Point headCoord = head.location;
            Point newHeadCoord = new Point(headCoord.X + size.Width * dirX, headCoord.Y + size.Height * dirY);


            head.setPosition(newHeadCoord);
        }
        public SnakeTail CreateElement(Size size, Point location)
        {
            SnakeTail element = new SnakeTail(size, location, color);
            body.Add(element);
            return element;
        }


    }
}
