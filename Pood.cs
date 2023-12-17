using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tooded_DB
{
    public partial class Pood : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Matti\source\repos\Tooded_DB-master\AppData\Tooded_AB.mdf;Integrated Security=True");
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\MartinKemppi\Tooded_DB-master\AppData\Tooded_AB.mdf;Integrated Security=True");
        //SqlConnection connect = new SqlConnection(@"Data Source=HP-CZC2349HTR;Initial Catalog=Pood;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        int Id;
        OpenFileDialog open;
        SaveFileDialog save;
        public Pood()
        {
            InitializeComponent();
            NaitaKategooriad();
            NaitaAndmed();
            Kat_Box.SelectedIndexChanged += Kat_Box_SelectedIndexChanged;
            Olemas.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            Voetud.SelectedIndexChanged += ListBox2_SelectedIndexChanged;
        }
        private void Kassa(object sender, EventArgs e)
        {
            Kassa kassa = new Kassa();
            kassa.Show();
            this.Close();
        }
        private void Valju(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NaitaAndmed()
        {
            string selectedCategory = Kat_Box.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                try
                {
                    connect.Open();
                    string query = "SELECT Toodenimetus FROM Tootetable WHERE Kategooriad IN (SELECT Id FROM ToodeTable WHERE Kategooria_nimetus = @category)";
                    command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@category", selectedCategory);
                    SqlDataReader reader = command.ExecuteReader();
                    Olemas.Items.Clear();

                    while (reader.Read())
                    {
                        string itemName = reader["Toodenimetus"].ToString();
                        Olemas.Items.Add(itemName);
                    }

                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Probleem: {ex.Message}");
                }
            }
            else
            {
                Olemas.Items.Clear();
            }
        }
        private void NaitaKategooriad()
        {
            Kat_Box.Items.Clear();
            Kat_Box.Text = "";
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM ToodeTable", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);

            foreach (DataRow item in dt_kat.Rows)
            {
                if (!Kat_Box.Items.Contains(item["Kategooria_nimetus"]))
                {
                    Kat_Box.Items.Add(item["Kategooria_nimetus"]);
                }
            }
            connect.Close();
        }
        private void Kat_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            NaitaAndmed();
        }
        private void Lisatoode_korvi(object sender, EventArgs e)
        {
            try
            {
                if (Olemas.SelectedItem != null)
                {
                    string selectedItem = Olemas.SelectedItem.ToString();

                    // Kontroll kogusele
                    string checkQuery = "SELECT Kogus FROM Tootetable WHERE Toodenimetus = @itemName";
                    command = new SqlCommand(checkQuery, connect);
                    command.Parameters.AddWithValue("@itemName", selectedItem);
                    connect.Open();
                    int kogusValue = Convert.ToInt32(command.ExecuteScalar());
                    connect.Close();

                    if (kogusValue > 0)
                    {
                        // Kui toode on olemas, siis laseme votta yks kuni toode jatkub
                        string updateQuery = "UPDATE Tootetable SET Kogus = Kogus - 1 WHERE Toodenimetus = @itemName";
                        command = new SqlCommand(updateQuery, connect);
                        command.Parameters.AddWithValue("@itemName", selectedItem);
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();

                        Voetud.Items.Add(selectedItem);
                        Naitakogus(selectedItem);
                    }
                    else
                    {
                        MessageBox.Show("Kogus on juba 0!","Hoiatus");
                    }
                }
                else
                {
                    MessageBox.Show("Valige toode");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Probleem: {ex.Message}");
            }
        }
        private void Kustutatoode_korvist(object sender, EventArgs e)
        {
            try
            {
                if (Voetud.SelectedItem != null)
                {
                    string selectedItem = Voetud.SelectedItem.ToString();

                    // Tagasi paneme riulile toode e. +1
                    string updateQuery = "UPDATE Tootetable SET Kogus = Kogus + 1 WHERE Toodenimetus = @itemName";
                    command = new SqlCommand(updateQuery, connect);
                    command.Parameters.AddWithValue("@itemName", selectedItem);
                    connect.Open();
                    command.ExecuteNonQuery();
                    connect.Close();

                    Voetud.Items.Remove(selectedItem);
                    Naitakogus(selectedItem);
                }
                else
                {
                    MessageBox.Show("Valige toode");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Probleem: {ex.Message}");
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Olemas.SelectedItem != null)
            {
                string selectedItem = Olemas.SelectedItem.ToString();
                string imageName = string.Empty;

                try
                {
                    connect.Open();
                    string query = "SELECT Pilt, Kogus, Hind FROM Tootetable WHERE Toodenimetus = @itemName";
                    command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@itemName", selectedItem);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        imageName = reader["Pilt"].ToString();
                        string imagePath = Path.Combine(Path.GetFullPath(@"..\..\Images"), imageName);
                        if (File.Exists(imagePath))
                        {
                            Image img = Image.FromFile(imagePath);
                            olemastoode.SizeMode = PictureBoxSizeMode.StretchImage;
                            olemastoode.ClientSize = new Size(150, 150);
                            olemastoode.Image = (Image)(new Bitmap(img, olemastoode.ClientSize));
                        }
                        else
                        {
                            MessageBox.Show($"Pilt '{imageName}' ei ole leitud.");
                        }

                        int kogus = Convert.ToInt32(reader["Kogus"]);
                        float hind = Convert.ToSingle(reader["Hind"]);

                        kogus_txt.Text = kogus.ToString();
                        hind_txt.Text = hind.ToString();

                        kogus_txt.ReadOnly = true;
                        hind_txt.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show($"Pilt '{selectedItem}' ei ole leitud.");
                    }
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Probleem: {ex.Message}");
                }
            }
        }        
        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Voetud.SelectedItem != null)
            {
                string selectedItem = Voetud.SelectedItem.ToString();
                string imageName = string.Empty;

                try
                {
                    connect.Open();
                    string query = "SELECT Pilt, Kogus, Hind FROM Tootetable WHERE Toodenimetus = @itemName";
                    command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@itemName", selectedItem);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        imageName = reader["Pilt"].ToString();
                        string imagePath = Path.Combine(Path.GetFullPath(@"..\..\Images"), imageName);
                        if (File.Exists(imagePath))
                        {
                            Image img = Image.FromFile(imagePath);
                            voetudtoode.SizeMode = PictureBoxSizeMode.StretchImage;
                            voetudtoode.ClientSize = new Size(150, 150);
                            voetudtoode.Image = (Image)(new Bitmap(img, voetudtoode.ClientSize));
                        }
                        else
                        {
                            MessageBox.Show($"Pilt '{imageName}' ei ole leitud.");
                        }                       
                    }
                    else
                    {
                        MessageBox.Show($"Toode '{selectedItem}' ei ole leitud.");
                    }
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Probleem: {ex.Message}");
                }
            }
        }
        private void Naitakogus(string selectedItem)
        {
            try
            {
                connect.Open();
                string query = "SELECT Kogus FROM Tootetable WHERE Toodenimetus = @itemName";
                command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@itemName", selectedItem);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int kogus = Convert.ToInt32(reader["Kogus"]);
                    kogus_txt.Text = kogus.ToString();
                }
                else
                {
                    MessageBox.Show($"Toode '{selectedItem}' ei ole leitud.");
                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Probleem: {ex.Message}");
            }
        }
    }
}