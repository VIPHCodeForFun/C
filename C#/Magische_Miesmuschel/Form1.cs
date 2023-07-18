using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muschel
{
    public partial class Magische_Mismuschel : Form
    {
        /*
         nein...
         ja.
         frag doch einfach nochmal..
        sicher nicht.

         */
        int i = 0;
        public Magische_Mismuschel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //antwort.Text = "Hallo";
            i++;
            if (i == 1) 
            { antwort.Text = "   nein..."; }
            if (i == 2)
            { antwort.Text = "   ja."; }
            if (i == 3)
            { antwort.Text = "   frag doch einfach nochmal.."; }
            if (i == 4)
            { antwort.Text = "   sicher nicht.";
                i = 0;
            }

        }
    }
}
