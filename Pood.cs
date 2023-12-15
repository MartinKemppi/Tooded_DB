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
    public partial class Pood : Form
    {
        public Pood()
        {
            InitializeComponent();
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
    }
}
