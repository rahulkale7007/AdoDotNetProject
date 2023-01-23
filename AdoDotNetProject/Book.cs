using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace AdoDotNetProject
{
    public partial class Book : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Book()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        }

        private void Book_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2 -  > write the sql query
                string qry = "insert into Book values(@name,@price,@author,@edition,publication)";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // ste-4  assign values to the parameter
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtprice.Text));
                cmd.Parameters.AddWithValue("@author", txtauthor.Text);
                cmd.Parameters.AddWithValue("@edition", txtedition.Text);
                cmd.Parameters.AddWithValue("@publication", txtpublication.Text);
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
            txtname.Clear();
            txtprice.Clear();
            txtauthor.Clear();
            txtedition.Clear();
            txtpublication.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }
    }
}
