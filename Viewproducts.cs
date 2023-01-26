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
    public partial class Viewproducts : Form
    {
        public Viewproducts()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            login logp = new login();
            logp.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myquery = "delete from product_table where ID="+prodidtb.Text+";";
                mt.deleteprod(myquery);
                getproduct();

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }
        Methods mt = new Methods();
        string myquery;
        private void getproduct()
        {
            myquery = "select * from Product_table";
            var ds = mt.display(myquery);
            View_product_grid.DataSource = ds.Tables[0];
        }
        private void Viewproducts_Load(object sender, EventArgs e)
        {
            getproduct();
        }



        //Purely Option Event for grid view to the textbox
        private void View_product_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.View_product_grid.Rows[e.RowIndex];
                prodidtb.Text = row.Cells["ID"].Value.ToString();
                prodnametb.Text = row.Cells["ProdName"].Value.ToString();
                prodbrand.SelectedItem = row.Cells["ProdBrand"].Value.ToString();
                prodcat.SelectedItem = row.Cells["ProdCategory"].Value.ToString();
                prodqty.Text = row.Cells["ProdQty"].Value.ToString();
                prodprice.Text = row.Cells["ProdPrice"].Value.ToString();

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            prodidtb.Text = "";
            prodnametb.Text = "";
            prodbrand.SelectedIndex = -1;
            prodcat.SelectedIndex = -1;
            prodqty.Text = "";
            prodprice.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void View_product_grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                if (View_product_grid.SelectedRows.Count >= 0)
                {
                    prodidtb.Text = View_product_grid.SelectedRows[0].Cells[0].Value.ToString();
                    prodnametb.Text = View_product_grid.SelectedRows[0].Cells[1].Value.ToString();
                    prodbrand.SelectedItem = View_product_grid.SelectedRows[0].Cells[2].Value.ToString();
                    prodcat.SelectedItem = View_product_grid.SelectedRows[0].Cells[3].Value.ToString();
                    prodqty.Text = View_product_grid.SelectedRows[0].Cells[4].Value.ToString();
                    prodprice.Text = View_product_grid.SelectedRows[0].Cells[5].Value.ToString();

                }
            }
            catch
            {
                MessageBox.Show("Invalid Selection, Please Select a Row By Double Click...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                myquery = "update product_table set ProdName='" + prodnametb.Text + "', ProdBrand='" + prodbrand.SelectedItem.ToString() + "', ProdCategory='" + prodcat.SelectedItem.ToString() + "'" +
                    ",ProdQty='" + prodqty.Text + "', ProdPrice='" + prodprice.Text + "' where ID='" + prodidtb.Text + "'; "; 
                mt.updatevalues(myquery);
                getproduct();

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mainpage main = new Mainpage();
            main.Show();
            this.Hide();
        }
    }
}
