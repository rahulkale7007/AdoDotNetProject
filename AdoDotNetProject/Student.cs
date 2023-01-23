using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace AdoDotNetProject
{
    public partial class Student : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Student()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2 -  > write the sql query
                string qry = "insert into Student values(@name,@stream,@percentage,@age,@gender)";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // ste-4  assign values to the parameter
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@stream", txtstream.Text);
                cmd.Parameters.AddWithValue("@percentage", Convert.ToInt32(txtpercentage.Text));
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text));
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
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
            txtrollNo.Clear();
            txtname.Clear();
            txtstream.Clear();
            txtpercentage.Clear();
            txtage.Clear();
            txtgender.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2 -  > write the sql query
                string qry = "update Student set name=@name,stream=@stream, percentage=@percentage, age=@age, gender=@gender where rollNo=@rollNo";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // step-4  assing values to the parameter
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@stream", txtstream.Text);
                cmd.Parameters.AddWithValue("@percentage", Convert.ToInt32(txtpercentage.Text));
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text));
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@rollNo", Convert.ToInt32(txtrollNo.Text));

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
                string qry = "delete from Student where rollNo=@rollNo";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // step-4  assing values to the parameter
                cmd.Parameters.AddWithValue("@rollNo", Convert.ToInt32(txtrollNo.Text));
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
                string qry = "select * from Student where rollNo =@rollNo";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@rollNo", Convert.ToInt32(txtrollNo.Text));
                con.Open();
                dr = cmd.ExecuteReader(); // fire the select query
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtname.Text = dr["name"].ToString();
                        txtstream.Text = dr["stream"].ToString();
                        txtpercentage.Text = dr["percentage"].ToString();
                        txtage.Text = dr["age"].ToString();
                        txtgender.Text = dr["gender"].ToString();

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

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from Student";
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
    }
}
