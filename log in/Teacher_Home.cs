using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log_in
{
    public partial class Teacher_Home : Form
    {
        public Teacher_Home()
        {
            InitializeComponent();
        }

        private void addUserControl(UserControl user)
        {
            user.Dock = DockStyle.Right;
            guna2GradientPanel2.Controls.Clear();
            guna2GradientPanel2.Controls.Add(user);
            user.BringToFront();

        }

        private void assessmentDetails_Click(object sender, EventArgs e)
        {
            Teacher_AssessmentDetails f = new Teacher_AssessmentDetails();
            f.Show();
        }

        private void viewReport_Click(object sender, EventArgs e)
        {
            Teacher_ViewReport v = new Teacher_ViewReport();
            addUserControl(v);
        }
    }
}
