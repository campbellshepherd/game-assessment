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
            x = 200;
            y = 100;
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
                if (ogrerec.Location.X > 380)
                {
                    x = 380;
                }
                else
                    x += 5;
            }
            if (move == "left")
            {
                if (ogrerec.Location.X < 0)
                {
                    x = 0;
                }
                else
                    x -= 5;
            }
            if (move == "up")
            {
                if (ogrerec.Location.Y < 0)
                {
                    y = 0;
                }
                else
                    y -= 5;
            }
            if (move == "down")
            {
                if(ogrerec.Location.Y>250 )
                {
                    y = 250;
                }else
                y += 5;
            }
        }

    }
}
