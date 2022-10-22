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
    public partial class RemoveUser : UserControl
    {
        private static String CS = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        SqlConnection connection = new SqlConnection(CS);
        public RemoveUser()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl user)
        {

        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            connection.Open();

            MessageBox.Show("The request await approval form the principal");
            approveRemoval approveRemoval = new approveRemoval();
            
            string typeOfUser = comboBoxTypeUser.SelectedItem.ToString();
            string surname = txtSerach.Text;
            int rowIndex = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(rowIndex);

            var item = dataGridView3.Rows[rowIndex].Cells[0].Value;
            int id = Convert.ToInt32(item);
       
            SqlCommand cmd = null;
            if (typeOfUser == "Student")
                cmd = new SqlCommand("delete from Student where ID_Number = '" + id + "'", connection);
            else if (typeOfUser == "Staff")
                cmd = new SqlCommand("delete from Staff where ID_Number = '" + id + "'", connection);

            cmd.ExecuteNonQuery();
            connection.Close();
            displayData(cmd);
            MessageBox.Show("User successfully removed");
        }
        public void displayData(SqlCommand cmd)
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;

            connection.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string typeOfUser = comboBoxTypeUser.SelectedItem.ToString();
            string surname = txtSerach.Text;

            SqlCommand cmd = null;
            if (typeOfUser == "Student")
                cmd = new SqlCommand("select * from Student where Last_Name = '" + surname + "'", connection);
            else if (typeOfUser == "Staff")
                cmd = new SqlCommand("select * from Staff where Last_Name = '" + surname + "'", connection);

            cmd.ExecuteNonQuery();
            connection.Close();
            displayData(cmd);
        }

        private void comboBoxTypeUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
