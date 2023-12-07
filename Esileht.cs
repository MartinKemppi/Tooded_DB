using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tooded_DB
{
    public partial class Esileht : Form
    {       
        public Esileht()
        {
            InitializeComponent();

            pb_logo_pood.Image = new Bitmap("../../../Selver_logo.png");
            pb_logo_pood.Size = new Size(150,150);
            pb_logo_pood.SizeMode = PictureBoxSizeMode.Zoom;
            pb_logo_pood.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
