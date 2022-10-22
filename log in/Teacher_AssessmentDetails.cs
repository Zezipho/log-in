using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log_in
{
    public partial class Teacher_AssessmentDetails : UserControl
    {

        static string conString = "Data Source=LAPTOP-7PTBCL58;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        public Teacher_AssessmentDetails()
        {
            InitializeComponent();
        }

        private void AddAssessment_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT into AssessmentDetails values('" + SubjectSelect.SelectedItem.ToString() + "','" + AssessmentId.Text + "','" + ClassId.Text + "','" + LearnerID.Text + "','" + Mark.Text + "')", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Assement Details added successfully");
        }

        DataGridView dataGrid = new DataGridView();
        public void Displaydata()
        {

            SqlCommand cmd = new SqlCommand("select* from AssessmentDetails", con);

            con.Open();
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);

            dataGrid.DataSource = dt;
            con.Close();



        }
    }
}
