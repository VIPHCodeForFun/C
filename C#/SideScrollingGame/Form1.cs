using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SideScrollingGame
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, jumping, hasKey;
        int jumpspeed = 10;
        int force = 8;
        int score = 0;

        int playerSpeed = 10;
        int backroundSpeed = 8;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: "+ score;
            player.Top += jumpspeed;


            if (goLeft == true && player.Left>60)
            {
                player.Left -= playerSpeed;
                
            }
            if(goRight == true && player.Left + (player.Width + 60) < this.ClientSize.Width)
            {
                player.Left += playerSpeed;
                
            }



            if(goLeft == true && Backround.Left < 0)
            {
                Backround.Left += backroundSpeed;
                MoveGameElements("forward");
            }
            if(goRight == true && Backround.Left > -1372)
            {
                Backround.Left -= backroundSpeed;
                MoveGameElements("back");
            }
            
            if (jumping == true)
            {
                jumpspeed = -12;
                force -= 1;
            }
            else 
            {
                jumpspeed = 12;
            } 
            if(jumping == true && force < 0)
            {
                jumping = false;
            }
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds)&& jumping ==false)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                        jumpspeed = 0;
                    }

                    x.BringToFront();
                }
                if(x is PictureBox && (string)x.Tag == "coin")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score++;
                    }
                }
            }
            if(player.Bounds.IntersectsWith(Key.Bounds))
            {
                Key.Visible = false;
                hasKey = true;
            }
            if (player.Bounds.IntersectsWith(door.Bounds) && hasKey == true)
            {
                door.Image = Properties.Resources.door_open;
                Gametimer.Stop();
                MessageBox.Show("Well done, your Jurney is complete! " + Environment.NewLine + "Click OK to Play Again");
                Restartgame();
            }
            if(player.Top + player.Height > this.ClientSize.Height)
            {
                Gametimer.Stop();
                MessageBox.Show("GAME OVER" + Environment.NewLine + "Click OK to play again");
                Restartgame();
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(jumping == true )
            {
                jumping = false;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if(e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Closegame(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Restartgame()
        {
            Form1 newWindow = new Form1();
            newWindow.Show();
            this.Hide();
        }
        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "coin" || x is PictureBox && (string)x.Tag == "key" || x is PictureBox && (string)x.Tag == "door")
                {
                    if (direction == "back")
                    {
                        x.Left -= backroundSpeed;
                    }
                    if (direction == "forward")
                    {
                        x.Left += backroundSpeed;
                    }

                }

            }

        }

    }
}
