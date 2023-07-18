
namespace Muschel
{
    partial class Magische_Mismuschel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.antwort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.Tag = "";
            this.printDialog1.UseEXDialog = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = global::Muschel.Properties.Resources.Br_Muschel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.button1.Location = new System.Drawing.Point(605, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(417, 148);
            this.button1.TabIndex = 0;
            this.button1.Text = "Schnur Ziehen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // antwort
            // 
            this.antwort.AutoSize = true;
            this.antwort.BackColor = System.Drawing.Color.Fuchsia;
            this.antwort.Font = new System.Drawing.Font("Jokerman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.antwort.ForeColor = System.Drawing.Color.Yellow;
            this.antwort.Image = global::Muschel.Properties.Resources.Br_Muschel;
            this.antwort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.antwort.Location = new System.Drawing.Point(-2, 491);
            this.antwort.Name = "antwort";
            this.antwort.Size = new System.Drawing.Size(449, 43);
            this.antwort.TabIndex = 1;
            this.antwort.Text = "Frag doch einfach nochmal.";
            // 
            // Magische_Mismuschel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Muschel.Properties.Resources.Br_Muschel;
            this.ClientSize = new System.Drawing.Size(1023, 935);
            this.Controls.Add(this.antwort);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Magische_Mismuschel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magische_Mismuschel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label antwort;
    }
}

