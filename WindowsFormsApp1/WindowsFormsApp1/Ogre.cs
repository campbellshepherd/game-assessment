using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Ogre
    {
        Graphics g;
        public int x, y, height, width;
        public Image ogre;
        public Rectangle ogrerec;
        public Ogre()
        {
            x = 100;
            y = 36;
            width = 50;
            height = 50;
            ogre = Image.FromFile("ogre.png");
            ogrerec = new Rectangle(x, y, width, height);

        }
        public void drawOgre(Graphics g)
        {
            g.DrawImage(ogre, ogrerec);
        }
        public void moveogre(string move)
        {
            ogrerec.Location = new Point(x, y);
            if (move == "right")
            {
                x += 5;
            }
            if (move == "left")
            {
                x -= 5;
            }

        }

    }
}
