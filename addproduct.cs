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
    public partial class addproduct : Form
    {
        public addproduct()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            login logp = new login();
            logp.Show();
            this.Hide();
        }
        Methods mt = new Methods();
        string query;
        int prodId;
        private void button1_Click(object sender, EventArgs e)
        { 
             
            try
            {
                prodId = mt.count();
                query = "insert into product_table values('" + prodId + "','" + prodnametb.Text + "','" + prodbrand.SelectedItem.ToString() + "','" + prodcat.SelectedItem.ToString() + "','" + prodqtytb.Text + "','" + prodpricetb.Text + "')";
                mt.insertvalues(query);

            }
            catch(Exception ex)

            {
                MessageBox.Show(ex.Message);
            }


        }

        private void prodbrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addproduct_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mainpage main = new Mainpage();
            main.Show();
            this.Hide();
        }
        private void clear()
        {
            
            prodnametb.Text = "";
            prodbrand.SelectedIndex = -1;
            prodcat.SelectedIndex = -1;
            prodqtytb.Text = "";
            prodpricetb.Text = "";
        }
    }
}
