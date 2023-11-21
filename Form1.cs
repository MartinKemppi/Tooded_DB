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
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooded_AB.mdf;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public Form1()
        {
            InitializeComponent();
            NaitaKategooriad();
            NaitaAndmed();
        }      
          
        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_Toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM Tootetable", connect);
            adapter_toode.Fill(dt_Toode);
            dataGridView1.DataSource = dt_Toode;
            connect.Close();
        }

        private void Lisa_Kategooria(object sender, EventArgs e)
        {
            connect.Open();
            command = new SqlCommand("INSERT INTO ToodeTable(Kategooria_nimetus) VALUES (@kat)",connect);
            command.Parameters.AddWithValue("@kat", Kat_Box.Text);
            command.ExecuteNonQuery();
            connect.Close();
            Kat_Box.Items.Clear();
            NaitaKategooriad();
        }

        public void NaitaKategooriad()
        {
            connect.Open();
            DataTable dt_Kategooria = new DataTable();
            adapter_kategooria = new SqlDataAdapter("SELECT Kategooria_nimetus FROM ToodeTable", connect);
            adapter_kategooria.Fill(dt_Kategooria);
            foreach (DataRow item in dt_Kategooria.Rows)
            {
                Kat_Box.Items.Add(item["Kategooria_nimetus"]);
            }
            connect.Close();
        }
    }
}
