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
            this.label1 = new System.Windows.Forms.Label();
            this.allhind = new System.Windows.Forms.Label();
            this.hindsai1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.button1.Click += new System.EventHandler(this.Logi_sisse);
            // 
            // reklaam
            // 
            this.reklaam.Location = new System.Drawing.Point(217, 90);
            this.reklaam.Name = "reklaam";
            this.reklaam.Size = new System.Drawing.Size(100, 20);
            this.reklaam.TabIndex = 1;
            this.reklaam.Text = "Logides sisse saate";
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
            // hindsai1
            // 
            this.hindsai1.Location = new System.Drawing.Point(37, 413);
            this.hindsai1.Name = "hindsai1";
            this.hindsai1.Size = new System.Drawing.Size(35, 20);
            this.hindsai1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(164, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Oli 1,39€";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(164, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nüüd 1€";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(177, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Allhinna näided";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(37, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nüüd 4€";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(37, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Oli 4,9€";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(323, 413);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Nüüd 1,59€";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(323, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Oli 2€";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(217, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Vaata rohkem poodis!";
            // 
            // Esileht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hindsai1);
            this.Controls.Add(this.allhind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reklaam);
            this.Controls.Add(this.button1);
            this.Name = "Esileht";
            this.Text = "Esileht";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label reklaam;
        private Label label1;
        private Label allhind;
        private Label hindsai1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}