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
    public partial class personalDetail : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= C:\Users\thany\Music\log in\log in\SchoolManSyst.mdf;Integrated Security=True");
        public personalDetail()
        {
            InitializeComponent();
            getDetails();
        }
        public void getDetails()
        {
            connection.Open();

            int ID = 1234;
            SqlCommand cworkID = new SqlCommand("select Staff_WorkNO from Staff where Staff_WorkNO = '" + ID + "'", connection);
            SqlCommand cName = new SqlCommand("select staffFName from Staff where Staff_WorkNO = '" + ID + "'", connection);
            SqlCommand cSurname = new SqlCommand("select staffLName from Staff where Staff_WorkNO = '" + ID + "'", connection);
            SqlCommand cEmail = new SqlCommand("select staffEmail from Staff where Staff_WorkNO = '" + ID + "'", connection);
            SqlCommand cContact = new SqlCommand("select contact from Staff where Staff_WorkNO = '" + ID + "'", connection);
            SqlCommand cAddress = new SqlCommand("select address from Staff where Staff_WorkNO = '" + ID + "'", connection);
            string workID = cworkID.ExecuteScalar().ToString();
            string name = cName.ExecuteScalar().ToString();
            string surname = cSurname.ExecuteScalar().ToString();
            string email = cEmail.ExecuteScalar().ToString() + "@schoolmanagement";
            string contact = cContact.ExecuteScalar().ToString();
            string address = cAddress.ExecuteScalar().ToString();
            StaffNum.Text = workID;
            stafName.Text = name;   
            staffSurname.Text = surname;
            staffEmail.Text = email;
            staffContact.Text = contact;
            staffAdress.Text = address;

            connection.Close();

        }
    }
}
