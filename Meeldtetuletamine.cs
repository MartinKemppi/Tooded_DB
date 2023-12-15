using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tooded_DB
{
    public partial class Meeldtetuletamine : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=HP-CZC2349HTR;Initial Catalog=Pood;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        int Id;
        OpenFileDialog open;
        SaveFileDialog save;
        public Meeldtetuletamine()
        {
            InitializeComponent();
        }

        private void Tuleta_meelde(object sender, EventArgs e)
        {
            if (login_txt.Text.Trim() != string.Empty && email_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    string sisLogin = login_txt.Text.Trim();
                    string sisEmail = email_txt.Text.Trim();

                    connect.Open();
                    DataTable dt_Toode = new DataTable();
                    adapter_toode = new SqlDataAdapter("SELECT login, email FROM klient", connect);

                    command = new SqlCommand("SELECT login, email FROM klient", connect);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string AB_Login = reader["login"].ToString();
                            string AB_Email = reader["email"].ToString();

                            if (sisLogin == AB_Login && sisEmail == AB_Email)
                            {
                                MessageBox.Show("Login ja Email leitud AB.");
                                string salasona = reader["salasona"].ToString();
                                MessageBox.Show($"Teie salasona on: {salasona}");
                                break;
                            }
                        }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Probleem tekkis: {ex.Message}");
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmed!");
            }
        }
    }
}
