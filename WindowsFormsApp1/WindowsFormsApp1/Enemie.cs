using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Enemy
    {
        public int score;
        public Image enemyImage;
        public int x, y, width, height;
        public Rectangle enemyRec;
        public Enemy(int spacing)
        {
            x =10 ;
            y = spacing;
            width = 25;
            height = 25;
            enemyImage = Image.FromFile("enemie.png");
            enemyRec= new Rectangle(x, y, width, height);
        }
        public void drawEnemie(Graphics g)
        {
            enemyRec = new Rectangle(x, y, width, height);
            g.DrawImage(enemyImage, enemyRec);
        }
        public void moveEnemy()
        {

            enemyRec.Location = new Point(x, y);
            if (enemyRec.Location.X>380)
            {
                score += 1;
                x =0;
                enemyRec.Location = new Point(x, y);
            }

        }
    }
    

}
