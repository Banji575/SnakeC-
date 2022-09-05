using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public interface IGameEntity
    {
        PictureBox element { get; set; }
        Size size { get; set; }
        Point location { get; set; }
    }
}
