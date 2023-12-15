using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tooded_DB
{
    partial class Esileht
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.reklaam = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pb_logo_pood = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.allhind = new System.Windows.Forms.Label();
            this.hindoli1 = new System.Windows.Forms.Label();
            this.hindsai1 = new System.Windows.Forms.Label();
            this.hindsai2 = new System.Windows.Forms.Label();
            this.hindoli2 = new System.Windows.Forms.Label();
            this.hindsai3 = new System.Windows.Forms.Label();
            this.hindoli3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo_pood)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Logi sisse e-poodi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reklaam
            // 
            this.reklaam.Location = new System.Drawing.Point(217, 90);
            this.reklaam.Name = "reklaam";
            this.reklaam.Size = new System.Drawing.Size(100, 20);
            this.reklaam.TabIndex = 1;
            this.reklaam.Text = "Logides sisse saate";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(11, 240);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.Image = new Bitmap("../../Images/Ketsup.jpg");
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(167, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 150);
            this.pictureBox2.Image = new Bitmap("../../Images/piim.jpg");

            this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(323, 240);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 150);
            this.pictureBox3.Image = new Bitmap("../../Images/Pirn.jpg");
            this.pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pb_logo_pood
            // 
            this.pb_logo_pood.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_logo_pood.Location = new System.Drawing.Point(12, 12);
            this.pb_logo_pood.Name = "pb_logo_pood";
            this.pb_logo_pood.Size = new System.Drawing.Size(150, 150);
            this.pb_logo_pood.Image = new Bitmap("../../Selver.png");
            this.pb_logo_pood.SizeMode = PictureBoxSizeMode.Zoom;
            this.pb_logo_pood.BorderStyle = BorderStyle.Fixed3D;
            this.pb_logo_pood.TabIndex = 7;
            this.pb_logo_pood.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(351, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "allhinna";
            // 
            // allhind
            // 
            this.allhind.Location = new System.Drawing.Point(323, 90);
            this.allhind.Name = "allhind";
            this.allhind.Size = new System.Drawing.Size(22, 20);
            this.allhind.TabIndex = 9;
            this.allhind.Text = "5%";
            // 
            // hindoli1
            // 
            this.hindoli1.Location = new System.Drawing.Point(33, 393);
            this.hindoli1.Name = "hindoli1";
            this.hindoli1.Size = new System.Drawing.Size(100, 20);
            this.hindoli1.TabIndex = 10;
            // 
            // hindsai1
            // 
            this.hindsai1.Location = new System.Drawing.Point(33, 413);
            this.hindsai1.Name = "hindsai1";
            this.hindsai1.Size = new System.Drawing.Size(100, 20);
            this.hindsai1.TabIndex = 11;
            // 
            // hindsai2
            // 
            this.hindsai2.Location = new System.Drawing.Point(191, 413);
            this.hindsai2.Name = "hindsai2";
            this.hindsai2.Size = new System.Drawing.Size(100, 20);
            this.hindsai2.TabIndex = 13;
            // 
            // hindoli2
            // 
            this.hindoli2.Location = new System.Drawing.Point(191, 393);
            this.hindoli2.Name = "hindoli2";
            this.hindoli2.Size = new System.Drawing.Size(100, 20);
            this.hindoli2.TabIndex = 12;
            // 
            // hindsai3
            // 
            this.hindsai3.Location = new System.Drawing.Point(337, 413);
            this.hindsai3.Name = "hindsai3";
            this.hindsai3.Size = new System.Drawing.Size(100, 20);
            this.hindsai3.TabIndex = 15;
            // 
            // hindoli3
            // 
            this.hindoli3.Location = new System.Drawing.Point(337, 393);
            this.hindoli3.Name = "hindoli3";
            this.hindoli3.Size = new System.Drawing.Size(100, 20);
            this.hindoli3.TabIndex = 14;
            // 
            // Esileht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.hindsai3);
            this.Controls.Add(this.hindoli3);
            this.Controls.Add(this.hindsai2);
            this.Controls.Add(this.hindoli2);
            this.Controls.Add(this.hindsai1);
            this.Controls.Add(this.hindoli1);
            this.Controls.Add(this.allhind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_logo_pood);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.reklaam);
            this.Controls.Add(this.button1);
            this.Name = "Esileht";
            this.Text = "Selver";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo_pood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label reklaam;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pb_logo_pood;
        private Label label1;
        private Label allhind;
        private Label hindoli1;
        private Label hindsai1;
        private Label hindsai2;
        private Label hindoli2;
        private Label hindsai3;
        private Label hindoli3;
    }
}