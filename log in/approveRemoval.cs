using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log_in
{
    public partial class approveRemoval : UserControl
    {
        private static String CS = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        SqlConnection connection = new SqlConnection(CS);
        public approveRemoval()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Removal Approved");
            RemoveUser removeUser = new RemoveUser();
            addUserControl(removeUser);

        }
        private void addUserControl(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            guna2GradientPanel1.Controls.Clear();
            guna2GradientPanel1.Controls.Add(user);
            user.BringToFront();

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Removal Not Approved, please comment below");
        }
    }
}
