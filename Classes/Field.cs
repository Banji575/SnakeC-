using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public class Field
    {
        int width;
        int height;
        int sizeOfSide;
        public Field(int width, int height, int sizeOfSide)
        {
            this.width = width;
            this.height = height;
            this.sizeOfSide = sizeOfSide;
        }

        public PictureBox[] GenerateMap()
        {
            int coutMapArr = this.width / this.sizeOfSide + this.height / this.sizeOfSide;

            PictureBox[] map = new PictureBox[coutMapArr];
            
            for (int i = 0; i < this.width / this.sizeOfSide; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, this.sizeOfSide * i);
                pic.Size = new Size(this.width - 140, 1);
                map[i] = pic;
            }
            for (int i = 0; i < this.height / this.sizeOfSide; i++)
            {
                int startArrIndex = this.width / this.sizeOfSide;
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(this.sizeOfSide * i, 0);
                pic.Size = new Size(1, this.height);
                map[startArrIndex + i] = pic;
            }
            return map;
        }
    }
}
