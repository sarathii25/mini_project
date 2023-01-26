using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homeapp
{
    class Methods
    {
       protected SqlConnection getCon()
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=DESKTOP-MKRIHI1\SQLEXPRESS01;Initial Catalog=HomeAppliances;Integrated Security=True";
            return cnn;
        }

        public void insertvalues(string query)
        {
            SqlConnection cnn = getCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cnn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product were successfully added....");
            cnn.Close();
        }
        public void updatevalues(string query)
        {
            SqlConnection cnn = getCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cnn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product were successfully Updated....");
            cnn.Close();
        }

        //Method to display in gridbox
        public DataSet display(string query)
        {
            SqlConnection cnn = getCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //Method to delete the records in gridbox
        public void deleteprod(string query)
        {
            SqlConnection cnn = getCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cnn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product were successfully Deleted....");
            cnn.Close();
        }

        //Method to set product Id automatically
        public int count()
        {
            SqlConnection cnn = getCon();
            string query = "select * from product_table order by ID";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cnn.Open();
            cmd.CommandText = query;

            SqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while(dr.Read())
            {
                id = dr.GetInt32(0);
            }
            id = id + 1;
            cnn.Close();
            return id;
        }

        // Billcount for bill table
        public int billcount()
        {
            SqlConnection cnn = getCon();
            string query = "select * from Bill_table order by ID";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cnn.Open();
            cmd.CommandText = query;

            SqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            id = id + 1;
            cnn.Close();
            return id;
        }

    }
}
