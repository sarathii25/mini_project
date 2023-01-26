using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homeapp
{
    public partial class Mainpage : Form
    {
        public Mainpage()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            login logp = new login();
            logp.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Viewproducts viewp = new Viewproducts();
            viewp.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            addproduct addp = new addproduct();
            addp.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
