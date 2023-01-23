using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoDotNetProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.MdiParent=this;
            p.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.MdiParent=this;
            emp.Show();

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.MdiParent = this;
            std.Show();
        }
    }
}
