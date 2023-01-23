using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace AdoDotNetProject
{
    public partial class Product : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Product()
        {
            InitializeComponent();
            // step 1 --> set the configuraion with DB server
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Product_Load(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2 -  > write the sql query
                string qry = "insert into tblProduct values(@name,@price,@comp)";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // ste-4  assign values to the parameter
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@comp", txtCompanyName.Text);
                // step 5 - open conn
                con.Open();
                // step 6 - fire the query
                int result = cmd.ExecuteNonQuery(); // fire the insert /update / delete
                if (result == 1)
                {
                    MessageBox.Show("Record inserted");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // step 7
                con.Close();
            }

        }

        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtCompanyName.Clear();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2 -  > write the sql query
                string qry = "update tblProduct set name=@name,price=@price, companyName=@comp where id=@id";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // step-4  assing values to the parameter
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@comp", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                // step 5 - open conn
                con.Open();
                // step 6 - fire the query
                int result = cmd.ExecuteNonQuery(); // fire the insert /update / delete
                if (result == 1)
                {
                    MessageBox.Show("Record updated");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // step 7
                con.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2 -  > write the sql query
                string qry = "delete from tblProduct where id=@id";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // step-4  assing values to the parameter
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                // step 5 - open conn
                con.Open();
                // step 6 - fire the query
                int result = cmd.ExecuteNonQuery(); // fire the insert /update / delete
                if (result == 1)
                {
                    MessageBox.Show("Record deleted");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // step 7
                con.Close();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from tblProduct where id =@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                con.Open();
                dr = cmd.ExecuteReader(); // fire the select query
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["name"].ToString();
                        txtPrice.Text = dr["price"].ToString();
                        txtCompanyName.Text = dr["companyname"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // step 7
                con.Close();
            }

        }



        private void btnShowAllProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from tblProduct";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader(); // fire the select query
                if (dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // step 7
                con.Close();
            }
        }


        private void Product_Load_1(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
