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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void addUserControl(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            guna2GradientPanel2.Controls.Clear();

            guna2GradientPanel2.Controls.Add(user);
            //user.BringToFront();

        }
        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            registerStudent registerStudent = new registerStudent();
            addUserControl(registerStudent);
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            registerStaff registerStudent = new registerStaff();
            addUserControl(registerStudent);
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
           RemoveUser removeUser = new RemoveUser();
           addUserControl(removeUser);
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            checkPerformance checkPerformance = new checkPerformance();
            addUserControl(checkPerformance);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            personalDetail personalDetail = new personalDetail();
            addUserControl(personalDetail);
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            approveRemoval approveRemoval = new approveRemoval();
            addUserControl(approveRemoval);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {

        }

        private void ViewReports_Click(object sender, EventArgs e)
        {
            Admin_ViewReports v = new Admin_ViewReports();
            addUserControl(v);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
