using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace AdoDotNetProject
{
    public partial class Employee : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
         
        public Employee()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        private void txtempId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2--> write the sql query
                string qry = "insert into Employee values(@empName,@deptList,@empSalary,@empAge)";
                // step 3--> assign the query to command class
                cmd = new SqlCommand(qry, con);
                //step4 --> assign values to parameter
                cmd.Parameters.AddWithValue("empName",txtempName.Text);
                cmd.Parameters.AddWithValue("deptList",txtdeptList.Text);
                cmd.Parameters.AddWithValue("empSalary",Convert.ToInt32(txtempSalary.Text));
                cmd.Parameters.AddWithValue("empAge",Convert.ToInt32(txtempAge.Text));
                //step 5--> open connection
                con.Open();
                //step 6--> fire the query
                int result=cmd.ExecuteNonQuery();// fire the insert/update/delete
                if (result == 1)
                {
                    MessageBox.Show("Record Inserted");
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // step 7--> close the connection
                con.Close();
            }
        }
        private void ClearForm()
        {
            txtempId.Clear();
            txtempName.Clear();
            txtdeptList.Clear();
            txtempSalary.Clear();
            txtempAge.Clear();
        }

        private void txtempName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdeptList_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtempSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtempAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // step 2 -  > write the sql query
                string qry = "update Employee set empName=@empName, deptList=@deptList, empSalary=@empSalary, empAge=@empAge where empId=@empId";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // step-4  assing values to the parameter
                cmd.Parameters.AddWithValue("@empName", txtempName.Text);
                cmd.Parameters.AddWithValue("@deptList", txtdeptList.Text);
                cmd.Parameters.AddWithValue("@empSalary", Convert.ToInt32(txtempSalary.Text));
                cmd.Parameters.AddWithValue("@empAge", Convert.ToInt32(txtempAge.Text));
                cmd.Parameters.AddWithValue("@empId", Convert.ToInt32(txtempId.Text));


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
                string qry = "delete from Employee where empId=@empId";
                //step 3 - assign the query to command class
                cmd = new SqlCommand(qry, con);
                // step-4  assing values to the parameter
                cmd.Parameters.AddWithValue("@empId", Convert.ToInt32(txtempId.Text));
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
                string qry = "select * from Employee where empId =@empId";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@empId", Convert.ToInt32(txtempId.Text));
                con.Open();
                dr = cmd.ExecuteReader(); // fire the select query
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtempId.Text = dr["empId"].ToString();
                        txtempName.Text = dr["empName"].ToString();
                        txtdeptList.Text = dr["deptList"].ToString();
                        txtempSalary.Text = dr["empSalary"].ToString();
                        txtempAge.Text = dr["empAge"].ToString();

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

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from Employee";
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
