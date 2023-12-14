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
    }
}
