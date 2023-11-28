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
        int Id;
        public Form1()
        {
            InitializeComponent();
            NaitaKategooriad();
            NaitaAndmed();
        }                
        private void Lisa_Kategooria(object sender, EventArgs e)
        {
            bool on = false;
            foreach(var item in Kat_Box.Items)
            {
                if (item.ToString()==Kat_Box.Text)
                {
                    on = true;
                    MessageBox.Show("Kategooria on juba olemas");
                }
            }
            if(on==false)
            {
                connect.Open();
                command = new SqlCommand("INSERT INTO ToodeTable(Kategooria_nimetus) VALUES (@kat)", connect);
                command.Parameters.AddWithValue("@kat", Kat_Box.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_Box.Items.Clear();
                NaitaKategooriad();
            }            
        }
        private void Kustuta_Kategooria(object sender, EventArgs e)
        {
            if (Kat_Box.SelectedItem != null)
            {
                string val_kat = Kat_Box.SelectedItem.ToString();
                
                connect.Open();
                command = new SqlCommand("DELETE FROM ToodeTable WHERE Kategooria_nimetus = @kat", connect);
                command.Parameters.AddWithValue("@kat", val_kat);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_Box.Items.Clear();
                NaitaKategooriad();                
            }
        }
        private void Lisa(object sender, EventArgs e)
        {
            if (Toodenimetus.Text.Trim()!=string.Empty && Kogus.Text.Trim()!=string.Empty && Hind.Text.Trim()!=string.Empty && Kat_Box.SelectedItem != null)
            {
                try
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    command = new SqlCommand("SELECT Id FROM ToodeTable WHERE Kategooria_nimetus=@kat", connect);
                    command.Parameters.AddWithValue("@kat", Kat_Box.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("INSERT INTO Tootetable (Toodenimetus,Kogus,Hind, Pilt, Kategooriad) VALUES(@toode, @kog, @pc, @pilt, @katID)", connect);
                    command.Parameters.AddWithValue("@toode", Toodenimetus.Text);
                    command.Parameters.Add("@kog", SqlDbType.Int).Value = int.Parse(Kogus.Text);
                    command.Parameters.Add("@pc", SqlDbType.Float).Value = float.Parse(Hind.Text);
                    command.Parameters.AddWithValue("@pilt", Toodenimetus.Text + ".jpg");
                    command.Parameters.AddWithValue("@katID", Id);
                    command.ExecuteNonQuery();

                    connect.Close();
                    NaitaAndmed();
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaaisiga viga!");
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }           
            else
            {
                MessageBox.Show("Sisesta andmed!");
            }
        }
        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_Toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT TT.Id, TT.Toodenimetus, TT.Kogus, TT.Hind, TT.Pilt, TD.Kategooria_nimetus as Kategooriad FROM TooteTable TT INNER JOIN Toodetable TD ON TT.Kategooriad = TD.Id", connect);
            adapter_toode.Fill(dt_Toode);

            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Toodenimetus");
            table.Columns.Add("Kogus");
            table.Columns.Add("Hind");
            table.Columns.Add("Pilt");
            table.Columns.Add("Kategooriad");

            foreach (DataRow item in dt_Toode.Rows)
            {
                table.Rows.Add(
                    item["Id"],
                    item["Toodenimetus"],
                    item["Kogus"],
                    item["Hind"],
                    item["Pilt"],
                    item["Kategooriad"]
                );
            }

            DGW.DataSource = table;
            DataGridViewComboBoxColumn dgvcb = new DataGridViewComboBoxColumn();
            dgvcb.HeaderText = "Kategooriad";
            dgvcb.DataPropertyName = "Kategooriad";
            dgvcb.Name = "KategooriaColumn";

            foreach (DataRow item in dt_Toode.Rows)
            {
                if (!dgvcb.Items.Contains(item["Kategooriad"]))
                {
                    dgvcb.Items.Add(item["Kategooriad"]);
                }
            }

            DGW.Columns.Add(dgvcb);
            connect.Close();
        }
        private void Uuenda(object sender, EventArgs e)
        {
            if (DGW.SelectedRows.Count > 0)
            {
                DataGridViewRow val_rida = DGW.SelectedRows[0];

                string UUS_ToodeNimetus = Toodenimetus.Text;
                int UUS_Kogus = int.Parse(Kogus.Text);
                float UUS_Hind = float.Parse(Hind.Text);
                string UUS_Pilt = Toodenimetus.Text + ".jpg";
                string UUS_Kategooria = Kat_Box.SelectedItem.ToString();

                int val_rida_ID = Convert.ToInt32(val_rida.Cells["Id"].Value);

                try
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    command = new SqlCommand("SELECT Id FROM ToodeTable WHERE Kategooria_nimetus = @kat", connect);
                    command.Parameters.AddWithValue("@kat", UUS_Kategooria);
                    int kategooriaId = Convert.ToInt32(command.ExecuteScalar());
                    
                    command = new SqlCommand("UPDATE Tootetable SET Toodenimetus = @toode, Kogus = @kog, Hind = @pc, Pilt = @pilt, Kategooriad = @katID WHERE Id = @id", connect);
                    command.Parameters.AddWithValue("@toode", UUS_ToodeNimetus);
                    command.Parameters.AddWithValue("@kog", UUS_Kogus);
                    command.Parameters.AddWithValue("@pc", UUS_Hind);
                    command.Parameters.AddWithValue("@pilt", UUS_Pilt);
                    command.Parameters.AddWithValue("@katID", kategooriaId);
                    command.Parameters.AddWithValue("@id", val_rida_ID);

                    command.ExecuteNonQuery();
                    connect.Close();
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Probleem tekkis uuendamisel: " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vali rida DataGridView-l uuendamiseks.");
            }
        }
        private void Kustuta(object sender, EventArgs e)
        {
            if (DGW.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGW.SelectedRows[0];
                int selectedRowID = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                try
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    string deleteQuery = "DELETE FROM Tootetable WHERE Id = @id";
                    command = new SqlCommand(deleteQuery, connect);
                    command.Parameters.AddWithValue("@id", selectedRowID);
                    command.ExecuteNonQuery();
                    connect.Close();

                    DGW.Rows.Remove(selectedRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Probleem tekkis kustutamisel: " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vali rida DataGridView-l kustutamiseks");
            }
        }
        public void NaitaKategooriad()
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
    }
}