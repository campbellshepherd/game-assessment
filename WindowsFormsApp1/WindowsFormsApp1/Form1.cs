using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Rectangle enemyRec;
        Graphics g; //declare a graphics object called g
        Ogre player = new Ogre(); //create the object, planet1
        bool left, right,up,down;
        string move;
        Enemy[] enemy = new Enemy[7];
        Random xspeed = new Random();
        int score=1;
        
        
        public Form1()
        {
            InitializeComponent();
           
            for (int i = 0; i < 7; i++)
            {
                int y = 5 + (i * 45);
                enemy[i] = new Enemy(y);
            }
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                lblScore.Text = score.ToString();
                score += enemy[i].score;
                enemy[i].moveEnemy();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }
        }

        private void Tmrogre_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                player.moveogre(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                player.moveogre(move);

            }
            if (up) // if left arrow key pressed
            {
                move = "up";
                player.moveogre(move);

            }
            if (down) // if left arrow key pressed
            {
                move = "down";
                player.moveogre(move);

            }
            PnlGame.Invalidate();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            player.drawOgre(g);

            for (int i = 0; i < 7; i++)
            {
                enemy[i].moveEnemy();
                int rndmspeed = xspeed.Next(1, 8);
                enemy[i].x += rndmspeed;
                enemy[i].drawEnemie(g);
            }

        }
    }
}
