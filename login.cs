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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(lpasstb.PasswordChar=='*')
            {
                button2.BringToFront();
                lpasstb.PasswordChar = '\0';
            }
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lpasstb.PasswordChar == '\0')
            {
                button3.BringToFront();
                lpasstb.PasswordChar = '*';
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lunametb.Text=="" || lpasstb.Text=="")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else if (lunametb.Text=="Admin" && lpasstb.Text=="admin")
            {
                Mainpage main = new Mainpage();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username and Password...Try Again");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            sales sl = new sales();
            sl.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
