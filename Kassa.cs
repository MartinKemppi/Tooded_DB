using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace Tooded_DB
{
    public partial class Kassa : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Matti\source\repos\Tooded_DB-master\AppData\Tooded_AB.mdf;Integrated Security=True");
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\MartinKemppi\Tooded_DB-master\AppData\Tooded_AB.mdf;Integrated Security=True");
        //SqlConnection connect = new SqlConnection(@"Data Source=HP-CZC2349HTR;Initial Catalog=Pood;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        int Id;
        OpenFileDialog open;
        SaveFileDialog save;
        Document document;
        List<string> Tooded_list = new List<string>();//tooded listisse
        private float totalPriceSum;
        private bool allhind = false;
        public Kassa(List<string> voetudItemsFromPood)
        {
            InitializeComponent();
            UpdateKorv(voetudItemsFromPood);
            korv.SelectedIndexChanged += korv_SelectedIndexChanged;
            korv.SelectedIndexChanged += PiltAB;
            Tooded_list = voetudItemsFromPood;
            Allhindkontroll();
        }
        private void UpdateKorv(List<string> items)
        {
            foreach (var item in items)
            {
                korv.Items.Add(item);
            }
        }
        private void korv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (korv.SelectedItem != null)
            {
                string selectedItem = korv.SelectedItem.ToString();

                float itemPrice = HindAB(selectedItem);
                hind_txt.Text = itemPrice.ToString();
                hind_txt.ReadOnly = true;

                float totalPrice = ArvutaKorvi();

                if (allhind)
                {
                    itemPrice *= 0.95f;
                    totalPrice *= 0.95f;
                }

                hind_txt.Text = itemPrice.ToString();
                hindkokku_txt.Text = totalPrice.ToString();
                hindkokku_txt.ReadOnly = true;
            }
        }
        private float HindAB(string itemName)
        {
            float itemPrice = 0.0f;

            try
            {
                connect.Open();
                string query = "SELECT Hind FROM Tootetable WHERE Toodenimetus = @itemName";
                command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@itemName", itemName);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    itemPrice = Convert.ToSingle(reader["Hind"]);
                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Probleem: {ex.Message}");
            }

            return itemPrice;
        }
        private void PiltAB(object sender, EventArgs e)
        {
            if (korv.SelectedItem != null)
            {
                string selectedItem = korv.SelectedItem.ToString();
                string imageName = string.Empty;

                try
                {
                    connect.Open();
                    string query = "SELECT Pilt FROM Tootetable WHERE Toodenimetus = @itemName";
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
                            val_toode_pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            val_toode_pb.ClientSize = new Size(150, 150);
                            val_toode_pb.Image = (Image)(new Bitmap(img, val_toode_pb.ClientSize));
                        }
                        else
                        {
                            MessageBox.Show($"Pilt '{imageName}' ei ole leitud.");
                        }
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
        private void Maksa(object sender, EventArgs e)
        {
            try
            {
                Kviitung(sender, e);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = Path.Combine(Environment.CurrentDirectory, "..", "..", "Arved"),
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    document = new Document();
                    var page = document.Pages.Add();

                    var header = new Aspose.Pdf.Text.TextFragment("         Selver\n         Tallinn\n\n");
                    header.TextState.Font = FontRepository.FindFont("Arial");
                    header.TextState.FontSize = 20;
                    page.Paragraphs.Add(header);

                    var columnHeader = new Aspose.Pdf.Text.TextFragment("Toode              \tHind \tKogus \t Kokku \n");
                    columnHeader.TextState.Font = FontRepository.FindFont("Arial");
                    columnHeader.TextState.FontSize = 12;
                    page.Paragraphs.Add(columnHeader);

                    foreach (var item in Tooded_list)
                    {
                        var content = new Aspose.Pdf.Text.TextFragment(item.Replace("\t", "           ") + "\n");
                        content.TextState.Font = FontRepository.FindFont("Arial");
                        content.TextState.FontSize = 12;
                        page.Paragraphs.Add(content);
                    }

                    page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("==============================================="));
                    var totalPriceText = new Aspose.Pdf.Text.TextFragment($"                           Kokku maksta: {totalPriceSum}€");
                    totalPriceText.TextState.Font = FontRepository.FindFont("Arial");
                    totalPriceText.TextState.FontSize = 12;
                    page.Paragraphs.Add(totalPriceText);

                    document.Save(savePath);
                    document.Dispose();

                    MessageBox.Show("Arve salvestatud!", "Teavitus");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Probleem: {ex.Message}");
            }
        }
        private void Kviitung(object sender, EventArgs e)
        {
            Tooded_list.Clear();
            totalPriceSum = 0;

            var uniqueItems = korv.Items.Cast<string>().Distinct().ToList();

            foreach (var item in uniqueItems)
            {
                string itemName = item.ToString();
                float itemPrice = HindAB(itemName);
                int quantity = korv.Items.Cast<string>().Count(i => i == itemName);
                float totalPrice = itemPrice * quantity;

                Tooded_list.Add($"{itemName}\t{itemPrice + "€"}\t{quantity}\t{totalPrice + "€"}");

                totalPriceSum += totalPrice;
            }

            if (allhind)
            {
                float discountedTotalPrice = totalPriceSum * 0.95f;
                float discountedItemPrice = float.Parse(hind_txt.Text) * 0.95f;
                float discountedTotalKokku = float.Parse(hindkokku_txt.Text) * 0.95f;

                totalPriceSum = discountedTotalPrice;
                hind_txt.Text = discountedItemPrice.ToString();
                hindkokku_txt.Text = discountedTotalKokku.ToString();
            }
        }
        private void SaadaArve_btn_Click(object sender, EventArgs e)
        {
            string adress = Interaction.InputBox("Sisesta e-mail", "Kuhu saada", "marina.oleinik@tthk.ee");
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    //string password = Interaction.InputBox("Sisesta salasõna");
                    Credentials = new System.Net.NetworkCredential("mvc.programmeerimine@gmail.com", "3.Kuursus"), //kellelt email,password
                    EnableSsl = true
                };
                mail.From = new MailAddress("mvc.programmeerimine@gmail.com");
                mail.To.Add(adress);//kellele
                mail.Subject = "Arve";
                mail.Body = "Arve on ostetud ja ta on maanuses";
                mail.Attachments.Add(new Attachment(@"..\..\Arved\Arve_.pdf"));
                smtpClient.Send(mail);
                MessageBox.Show("Arve oli saadetud mailile: " + adress);
            }
            catch (Exception)
            {
                MessageBox.Show("Viga");
            }
        }
        private float ArvutaKorvi()
        {
            float totalPrice = 0.0f;

            foreach (var item in korv.Items)
            {
                float itemPrice = HindAB(item.ToString());
                totalPrice += itemPrice;
            }

            return totalPrice;
        }
        private void Allhindkontroll()
        {
            Pood pood = Application.OpenForms.OfType<Pood>().FirstOrDefault();
            if (pood != null && pood.LoggedInFromLogin)
            {
                allhind = true;
                MessageBox.Show("Olete sisseloginud, ehk saate 5% soodustust.");
            }
            else
            {
                MessageBox.Show("Te pole sisseloginud, ehk ei saa 5% soodustust.");
            }
        }

    }
}