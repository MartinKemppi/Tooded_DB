using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tooded_DB
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void unustasin_btn_Click(object sender, EventArgs e)
        {
            Meeldtetuletamine meeldetuletamineForm = new Meeldtetuletamine();
            meeldetuletamineForm.Show();
        }

        private void loouuuskasutaja_btn_Click(object sender, EventArgs e)
        {
            Registreerimine registreerimineForm = new Registreerimine();
            registreerimineForm.Show();
        }

        private void logikylalisena_Click(object sender, EventArgs e)
        {
            Pood poodForm = new Pood();
            poodForm.Show();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if(login_txt.Text.Trim() != string.Empty && salasona_txt.Text.Trim() != string.Empty)
                try
                {
                    if(login_txt.Text=="Admin" && salasona_txt.Text == "Admin")
                    {
                        Admin_Klient admin_klientForm = new Admin_Klient();
                        admin_klientForm.Show();

                        Admin_Tooded admin_toodedForm = new Admin_Tooded();
                        admin_toodedForm.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Probleem tekkis: {ex.Message}");
                }
            else
            {
                MessageBox.Show("Sisesta andmed!");
            }
        }
    }
}
