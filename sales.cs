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
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Methods mt = new Methods();
        private void getproduct()
        {
            string myquery = "select * from Product_table";
            var ds = mt.display(myquery);
            prodGrid.DataSource = ds.Tables[0];
        }
        private void sales_Load(object sender, EventArgs e)
        {
            getproduct();
        }
        int oldQty = 0,pid,newqty;
        int grandtot = 0;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if(printPreviewDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }
            int billId = mt.billcount();
            DateTime today = DateTime.Today;
            string query = "insert into Bill_table values('" + billId + "','" + today + "','" + amtlbl.Text + "')";
            mt.insertvalues(query);

        }
        int prodid, prodqty, prodprice, tottal, pos = 60;

        private void label7_Click(object sender, EventArgs e)
        {
            login logp = new login();
            logp.Show();
            this.Hide();
        }

        private void amtlbl_Click(object sender, EventArgs e)
        {

        }

        private void prodGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
   
        private void button3_Click(object sender, EventArgs e)
        {
            billgrid.Rows.Clear();
            amtlbl.Text = "";
        }

        string prodname;
        int n = 0;
        //int grdtotal = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Home Appliances Shop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(57));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in billgrid.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname=""+row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal , new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
             }
            e.Graphics.DrawString("Grand Total: Rs" + grandtot, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("*****Thanks for Purchasing******", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 85));
            billgrid.Rows.Clear();
            billgrid.Refresh();
            pos = 100;
            //grdtotal = 0;
            n = 0;

        }

        private void prodGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (prodGrid.SelectedRows.Count >= 0)
            {
                billprodname.Text = prodGrid.SelectedRows[0].Cells[1].Value.ToString();
                //billprodqty.Text = prodGrid.SelectedRows[0].Cells[4].Value.ToString();
                billprodprice.Text = prodGrid.SelectedRows[0].Cells[5].Value.ToString();
                oldQty = Convert.ToInt32(prodGrid.SelectedRows[0].Cells[4].Value.ToString());
                pid= Convert.ToInt32(prodGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if(billprodqty.Text== "" || Convert.ToInt32(billprodqty.Text) > oldQty)
            {
                MessageBox.Show("Not Enough Stock");

            }
            else
            {
                int total = Convert.ToInt32(billprodqty.Text) * Convert.ToInt32(billprodprice.Text);
                DataGridViewRow nr = new DataGridViewRow();
                nr.CreateCells(billgrid);

                nr.Cells[0].Value = pid;
                nr.Cells[1].Value = billprodname.Text;
                nr.Cells[2].Value = billprodprice.Text;
                nr.Cells[3].Value = billprodqty.Text;
                nr.Cells[4].Value = total;

                billgrid.Rows.Add(nr);

                grandtot = grandtot + total;
                amtlbl.Text = "" + grandtot;

                newqty = oldQty - Convert.ToInt32(billprodqty.Text);
                string myquery = "update product_table set ProdQty=" + newqty + " where ID=" + pid+ "; ";
                mt.updatevalues(myquery);
                getproduct();

               
            }

        }
    }
}
