﻿using System;
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
        private void Kustuta_Kategooria(object sender, EventArgs e)
        {
            if (Kat_Box.SelectedItem != null)
            {
                string val_kat = Kat_Box.SelectedItem.ToString();
                
                connect.Open();
                SqlCommand command = new SqlCommand("DELETE FROM ToodeTable WHERE Kategooria_nimetus = @kat", connect);
                command.Parameters.AddWithValue("@kat", val_kat);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_Box.Items.Clear();
                NaitaKategooriad();                
            }
        }

        private void Lisa(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()!=string.Empty && textBox2.Text.Trim()!=string.Empty && textBox3.Text.Trim()!=string.Empty && Kat_Box.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Tootetable (Toodenimetus,Kogus,Hind, Pilt, Kategooriad) VALUES(@toode, @kog, @pc,@pilt, @katID)", connect);
                    command.Parameters.AddWithValue("@toode", textBox1.Text);
                    command.Parameters.AddWithValue("@kog", textBox2.Text);
                    command.Parameters.AddWithValue("@pc", textBox3.Text);
                    command.Parameters.AddWithValue("@pilt", textBox1.Text+".jpg");
                    command.Parameters.AddWithValue("@katID", Kat_Box.SelectedIndex);

                    command.ExecuteNonQuery();
                    connect.Close();
                    NaitaAndmed();
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaaisga viga!");
                }
            }
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
