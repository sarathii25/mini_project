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
    public partial class Homeappliances : Form
    {
        public Homeappliances()
        {
            InitializeComponent();
        }
        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos +=1;
            mainprogress.Value = startpos;
            if(startpos<=33)
            {
                loadlbl.Text = "Welcome.........";
                loadlbl.ForeColor = Color.Crimson;
            }
            else if (startpos>33 && startpos<=65)
            {
                loadlbl.Text = "Home Appliances Store";
                loadlbl.ForeColor = Color.DarkGreen;
            }
            else if (startpos>65)
            {
                loadlbl.Text = "Starting the Application";
                loadlbl.ForeColor = Color.DarkRed;
            }
           if(mainprogress.Value==100)
            {
                mainprogress.Value = 0;
                timer1.Stop();
                login logp = new login();
                this.Hide();
                logp.Show();
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
