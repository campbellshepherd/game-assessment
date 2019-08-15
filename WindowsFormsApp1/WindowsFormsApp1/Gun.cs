using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Gun
    {
        Graphics g;
        public int x, y, height, width;
        public Image gunImage;
        public Rectangle gunrec;
        public Gun()
        {
            width = 20;
            height = 40;
            y = -100;
            x = -100;
            gunImage = Image.FromFile("bullet.png");
            gunrec = new Rectangle(x, y, width, height);
        }
        public void gunshoot(string shoot)
        {
            
        }
        public void drawgun(Graphics g)
        {
            g.DrawImage(gunImage, gunrec);
        }
    }
}
