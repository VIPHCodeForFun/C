using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace ZombieShooter2
{
    class Bullet
    {
        public string direction;
        public int speed = 20;
        PictureBox Bulletbox = new PictureBox();
        Timer tm = new Timer();

        public int bulletLeft;
        public int bulletTop;

        public void mkBullet(Form form)
        {
            Bulletbox.BackColor = System.Drawing.Color.White;
            Bulletbox.Size = new Size(5, 5);
            Bulletbox.Tag = "bullet";
            Bulletbox.Left = bulletLeft;
            Bulletbox.Top = bulletTop;
            Bulletbox.BringToFront();
            form.Controls.Add(Bulletbox);

            tm.Interval = speed;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();
        }
        public void tm_Tick(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                Bulletbox.Left -= speed;
            }
            if (direction == "right")
            {
                Bulletbox.Left += speed;
            }
            if (direction == "up")
            {
                Bulletbox.Top -= speed;
            }
            if (direction == "down")
            {
                Bulletbox.Top += speed;
            }
            if (Bulletbox.Left < 0 || Bulletbox.Left > 930 || Bulletbox.Top < 0 || Bulletbox.Top > 700)
            {
                tm.Stop();
                tm.Dispose();
                Bulletbox.Dispose();
                tm = null;
                Bulletbox = null;
            }
        }
    }
}
