using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tooded_DB
{
    public partial class Esileht : Form
    {
        PictureBox pb_logo_pood, pb1, pb2, pb3;
        public Esileht()
        {
            InitializeComponent();
            Pildid();
        }
        private void button1_Click(object sender, EventArgs e)
        {           
            Login loginForm = new Login();
            loginForm.Show();
           
            //this.Hide();
            //this.FormClosing += MainForm_FormClosing;
        }
        //private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        e.Cancel = true; 
        //        this.Show();
        //    }
        //}
        private void Pildid()
        {
            pb_logo_pood = new PictureBox();
            pb_logo_pood.Image = new Bitmap("../../Selver.png");
            pb_logo_pood.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_logo_pood.Location = new Point(12,12);
            pb_logo_pood.ClientSize = new Size(150, 150);

            pb1 = new PictureBox();
            pb1.Image = new Bitmap("../../Images/Ketsup.jpg");
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1.Location = new Point(12, 240);
            pb1.ClientSize = new Size(150, 150);

            pb2 = new PictureBox();
            pb2.Image = new Bitmap("../../Images/piim.jpg");
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2.Location = new Point(120, 240);
            pb2.ClientSize = new Size(150, 150);

            pb3 = new PictureBox();
            pb3.Image = new Bitmap("../../Images/Sinep.jpg");
            pb3.SizeMode = PictureBoxSizeMode.StretchImage;
            pb3.Location = new Point(280, 240);
            pb3.ClientSize = new Size(150, 150);

            Controls.Add(pb_logo_pood);
            Controls.Add(pb1);
            Controls.Add(pb2);
            Controls.Add(pb3);
        }
    }
}
