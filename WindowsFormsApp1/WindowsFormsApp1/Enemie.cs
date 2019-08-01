using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Enemie
    {
        public Image enemieImage;
        public int x, y, width, height;
        public Rectangle enemieRec;
        public Enemie(int spacing)
        {
            x =0 ;
            y = spacing;
            width = 25;
            height = 25;
            enemieImage = Image.FromFile("enemie.png");
            enemieRec= new Rectangle(x, y, width, height);
        }
        public void drawEnemie(Graphics g)
        {
            enemieRec = new Rectangle(x, y, width, height);
            g.DrawImage(enemieImage, enemieRec);
        }
    }
    

}
