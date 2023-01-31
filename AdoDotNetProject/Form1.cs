using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdoDotNetProject
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommandBuilder sqlCommandBuilder;
        DataSet ds;


        public Form1()
        {
          
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        }
        private DataSet GetAll()
        {
            adapter = new SqlDataAdapter("select * from tblProduct", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlCommandBuilder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "product");// product is table name given to the DataSet
            return ds;
        }
        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtCompanyName.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["product"].NewRow();
                row["name"] = txtName.Text;
                row["price"] = txtPrice.Text;
                row["CompanyName"] = txtCompanyName.Text;
                ds.Tables["product"].Rows.Add(row);
                int result = adapter.Update(ds.Tables["product"]);
                if (result == 1)
                {
                    MessageBox.Show("Record inserted..");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["product"].Rows.Find(txtId.Text);

                if (row != null)
                {
                    txtName.Text = row["name"].ToString();
                    txtPrice.Text = row["price"].ToString();
                    txtCompanyName.Text = row["CompanyName"].ToString();

                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["product"].Rows.Find(txtId.Text);

                if (row != null)
                {
                    row["name"] = txtName.Text;
                    row["price"] = txtPrice.Text;
                    row["CompanyName"] = txtCompanyName.Text;
                    int result = adapter.Update(ds.Tables["product"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record updated..");
                        ClearForm();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["product"].Rows.Find(txtId.Text);

                if (row != null)
                {
                    row.Delete();
                    int result = adapter.Update(ds.Tables["product"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record deleted..");
                        ClearForm();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnShowAllProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                dataGridView1.DataSource = ds.Tables["product"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
