using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://www.mooict.com/c-tutorial-create-a-zombie-survival-shooting-game-in-visual-studio/

namespace ZombieShooter2
{
    public partial class Zombieshooter2 : Form
    {
        //Player movement
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        string facing = "up"; //save Player Position
        public int playerHealt = 100;

        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int score = 0;
        bool gameOver = false;
        Random rnd = new Random();

        int zombiecount = 1;
        int level = 0;

        public Zombieshooter2()
        {
            InitializeComponent();
        }

        private void MainTimer(object sender, EventArgs e)
        {
            if (playerHealt > 1)
            {
                healthBar.Value = playerHealt;
            }
            else
            {
                player.Image = Properties.Resources.dead;
                Gametimer.Stop();
                gameOver = true;
            }
            txtAmmo.Text = "Ammo: " + ammo;
            txtScore.Text = "Kills: " + score;
            txtLevel.Text = "Level: " + level;

            //healtbar collor
            if (playerHealt < 20)
            {
                healthBar.ForeColor = System.Drawing.Color.Red;
            }
            //player movment
            if (goleft && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goright && player.Left + player.Width < 930)
            {
                player.Left += speed;
            }
            if (goup && player.Top > 0)
            {
                player.Top -= speed;
            }
            if (godown && player.Top + player.Height < 700)
            {
                player.Top += speed;
            }
            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                        ammo = ammo + 5;
                    }
                }
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                if (x is PictureBox && (string)x.Tag == "live")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                           if (playerHealt < 75)
                        { 
                        playerHealt = playerHealt + 25;
                        }
                    }
                }
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                }

                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealt--;
                    }
                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }
                    if (((PictureBox)x).Left < player.Left)
                    {
                        ((PictureBox)x).Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (((PictureBox)x).Top > player.Top)
                    {
                        ((PictureBox)x).Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                    if (((PictureBox)x).Top < player.Top)
                    {
                        ((PictureBox)x).Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }
                }
                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && (string)j.Tag == "bullet") && (x is PictureBox && (string)x.Tag == "zombie"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            j.Dispose();
                            this.Controls.Remove(x);
                            x.Dispose();
                            //---------------------------------------
                            if (score > (level * 10))
                            {
                                makeZombie();
                                makeZombie();
                                level++;
                            }
                            else
                            {
                                makeZombie();
                            }
                            //---------------------------------------
                        }
                    }
                }
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (gameOver)
            {
                return;
            }
            //left key is pressed
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }
            //right key is pressed
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }
            //up key is pressed
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }
            //down key is pressed
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            //left key is NOT pressed
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            //right key is NOT pressed
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            //up key is NOT pressed
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            //down key is NOT pressed
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            //
            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                shoot(facing);
                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
            if (e.KeyCode == Keys.Space && playerHealt > 25)
            {
                if (ammo == 0 && playerHealt < 50)
                {
                    DropLive();
                }
            }
        }
        private void DropAmmo()
        { //this function will be used when the user needs ammo in the game
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(10, 890);
            ammo.Top = rnd.Next(50, 600);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxx OFFEN
        private void DropLive()
        { //this function will be used when the user needs live in the game
            PictureBox live = new PictureBox();
            live.Image = Properties.Resources.up; // ändern einbinden des Bildes Live 
            live.SizeMode = PictureBoxSizeMode.AutoSize;
            live.Left = rnd.Next(10, 890);
            live.Top = rnd.Next(50, 600);
            live.Tag = "live";
            this.Controls.Add(live);
            live.BringToFront();
            player.BringToFront();
        }
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxx OFFEN
        private void shoot(string direct)
        {//This function  will be used when the player is shooting in the game
            Bullet shoot = new Bullet();
            shoot.direction = direct;
            shoot.bulletLeft = player.Left + (player.Width / 2);
            shoot.bulletTop = player.Top + (player.Height / 2);
            shoot.mkBullet(this);
        }
        private void makeZombie()
        {// This function will be used when we need to make more zombies in the game
            PictureBox zombiebox = new PictureBox();
            zombiebox.Tag = "zombie";
            zombiebox.Image = Properties.Resources.zdown;
            zombiebox.SizeMode = PictureBoxSizeMode.AutoSize;
            zombiebox.Left = rnd.Next(0, 800);
            zombiebox.Top = rnd.Next(0, 600);
            this.Controls.Add(zombiebox);
            player.BringToFront();

        }
    }
}
