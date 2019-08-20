using System;
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
        bool left, right, up, down;
        bool nameStart, liveStart,bulletStart;
        string move;
        Enemy[] enemy = new Enemy[7];
        Random xspeed = new Random();
        Gun gun = new Gun();
        int score, lives,bullet;
        

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Use the arrow keys to move the ogre. \nDon't get hit by the red guys. \nUse space bar to shoot if you get stuck in a sticky situation. \nPlease type your name, lives and how many bullets you want.","Game Instructions");
            
            score =0;
            LbScore.Text = score.ToString();
            for (int i = 0; i < 7; i++)
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
            if (e.KeyData == Keys.Space) { if (bullet>0) { gun.gunrec.X = player.ogrerec.X;
                    gun.gunrec.Y = player.ogrerec.Y; bullet -= 1;
                }
            }
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
            string context = textBox1.Text;
            bool isletter = true;
            //for loop checks for letters as characters are entered
            for (int i = 0; i < context.Length; i++)
            {
                if (!char.IsLetter(context[i]))// if current character not a letter
                {
                    isletter = false;//make isletter false
                    break; // exit the for loop
                }

            }

            // if not a letter clear the textbox and focus on it
            // to enter name again
            if (isletter == false)
            {
                textBox1.Clear();
                textBox1.Focus();
            }
            else
            {
                nameStart = true;
            }
        }

        private void TxtLives_TextChanged(object sender, EventArgs e)
        {
            string context = TxtLives.Text;
            bool isnumber = true;
            //This loop checks for numbers as characters are entered
            for (int i = 0; i < context.Length; i++)
            {
                if (!char.IsNumber(context[i]))//If current character is not a number
                {
                    isnumber = false;
                    break;
                }
            }
            //If not a number clear the textbox and focus on it
            //to enter lives again
            if (isnumber == false)
            {
                TxtLives.Clear();
                TxtLives.Focus();
            }
            
            else
            {
                liveStart = true;
            }
        }
    

        private void TmrEnemy_Tick(object sender, EventArgs e)
        {
            int score = 0;
            for (int i = 0; i < 7; i++)
            {
                int rndmspeed = xspeed.Next(1, 20);
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
                    MessageBox.Show(score.ToString(),"your score was");
                }

            }
            
        }

        private void TxtBullets_TextChanged(object sender, EventArgs e)
        {
            string context = TxtBullets.Text;
            bool isnumber = true;
          
            //This loop checks for numbers as characters are entered
            for (int i = 0; i < context.Length; i++)
            {
                if (!char.IsNumber(context[i]))//If current character is not a number
                {
                    isnumber = false;
                    break;
                }
            }
            //If not a number clear the textbox and focus on it
            //to enter lives again
            
            if (isnumber == false)
            {
                TxtBullets.Clear();
                TxtBullets.Focus();
            }
            else
            {
                bulletStart = true;
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TmrEnemy.Enabled = true;
            Tmrogre.Enabled = true;
            TmrSpeedup.Enabled = true;
            TmrGun.Enabled = true;
            lives = int.Parse(TxtLives.Text);
            bullet = int.Parse(TxtBullets.Text);
        }

        private void MnuMusicStart_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer();
            simpleSound.Play();
            
        }

        private void MnuMusicStop_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer();
            simpleSound.Stop();
        }

        private void TmeStartcheck_Tick(object sender, EventArgs e)
        {
            if (liveStart == true && nameStart == true && bulletStart == true)
            {
                MnuStart.Enabled = true;
            }
           
                    

            
        }

        private void TmrGun_Tick(object sender, EventArgs e)
        {
            TxtBullets.Text = bullet.ToString();
            gun.gunrec.X -= 6;
            for (int i = 0; i < 7; i++)
            {
                if (gun.gunrec.IntersectsWith(enemy[i].enemyRec))
                {
                    enemy[i].x = 30;
                    gun.gunrec.X = -100;
                }
            }
        }

        private void TmrSpeedup_Tick(object sender, EventArgs e)
        {
            if (TmrEnemy.Interval < 20)
            {
                TmrEnemy.Interval = 20;
            }
            else TmrEnemy.Interval -= 4;
        }

        private void MnuStop_Click(object sender, EventArgs e)
        {
            TmrEnemy.Enabled = false;
            Tmrogre.Enabled = false;
            TmrSpeedup.Enabled = false;
            TmrGun.Enabled = false;
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
            gun.drawgun(g);
            
            for (int i = 0; i < 7; i++)
            {
                enemy[i].drawEnemy(g);


            }

        }
    }
}
