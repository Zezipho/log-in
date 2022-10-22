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
    public partial class registerStudent : UserControl
    {
        private static String CS = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        SqlConnection connection = new SqlConnection(CS);
        public registerStudent()
        {
            InitializeComponent();
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Learner (Learner_IDNo, learnerFName, learnerLName, learnerEmail, absentDays, Class_ID, Active) values('" + (id.Text) + "', '" + name.Text + "','" + surname.Text + "','" + "','" + email.Text + "','" + 120 + "','" + "','" + Active.SelectedItem.ToString() + "')", connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            
            connection.Close();
            displayData();
            MessageBox.Show("Student inserted successfully");
        }
        public void displayData()
        {
            SqlCommand cmd = new SqlCommand("select* from Learner", connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            connection.Close();
        }

        private void registerStudent_Load(object sender, EventArgs e)
        {
            displayData();
        }
    }
}
