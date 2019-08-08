﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        Graphics g; //declare a graphics object called g
        Ogre player = new Ogre(); //create the object, planet1
        bool left, right,up,down;
        string move;
        Enemy[] enemy = new Enemy[8];
        Random xspeed = new Random();
        int score,lives;
        
        
        public Form1()
        {
            InitializeComponent();

            score = 10;
            LbScore.Text=score.ToString();
            for (int i = 0; i < 8; i++)
            {
                int y = 5 + (i * 55);
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
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TmrEnemy_Tick(object sender, EventArgs e)
        {
            int score = 0;
            for (int i = 0; i < 8; i++)
            {
                int rndmspeed = xspeed.Next(2, 40);
                enemy[i].x += rndmspeed;
                enemy[i].moveEnemy();
                score += enemy[i].score;
                LbScore.Text = score.ToString();
                if (player.ogrerec.IntersectsWith(enemy[i].enemyRec))
                {
                    //reset planet[i] back to top of panel
                    enemy[i].x = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                    TxtLives.Text = lives.ToString();// display number of lives
                    
                }
                if (lives < 1)
                {
                    Tmrogre.Enabled = false;
                    TmrEnemy.Enabled = false;
                    MessageBox.Show("Game Over");
                }

            }
            
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TmrEnemy.Enabled = true;
            Tmrogre.Enabled = true;
            lives = int.Parse(TxtLives.Text);
        }

        private void TmrSpeedup_Tick(object sender, EventArgs e)
        {
            if (TmrEnemy.Interval > 40)
            {
                TmrEnemy.Interval = 45;
            }
            else TmrEnemy.Interval -= 10;

           



        }

        private void TxtLives_TextChanged(object sender, EventArgs e)
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
            
            for (int i = 0; i < 8; i++)
            {
                enemy[i].drawEnemie(g);


            }

        }
    }
}
