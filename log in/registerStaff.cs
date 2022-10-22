using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace log_in
{
    public partial class registerStaff : UserControl
    {
        private static String CS = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        SqlConnection connection = new SqlConnection(CS);


        public registerStaff()
        {
            InitializeComponent();
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e) //
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Staff (Staff_WorkNO,staffFName, StaffLName, staffType, staffEmail, Active) values('" + int.Parse(staffID.Text) + "', '" + name.Text + "','" + surname.Text + "','" + type.SelectedItem.ToString()  + "','" + email.Text + "','" + "Yes" + "')", connection);

            connection.Open();
            cmd.ExecuteNonQuery();

            connection.Close();
            displayData();
            MessageBox.Show("Staff inserted successfully");
        }
        public void displayData()
        {
            SqlCommand cmd = new SqlCommand("select* from Staff", connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;

            connection.Close();
        }

        private void registerStaff_Load(object sender, EventArgs e)
        {
            displayData();
        }

        
    }
}
