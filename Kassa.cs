﻿using System;
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
    public partial class Kassa : Form
    {
        public Kassa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pood pood = new Pood();
            pood.Show();
            this.Close();
        }
    }
}
