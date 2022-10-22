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
    public partial class Principal_ViewReports : UserControl
    {

        String CS = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public Principal_ViewReports()
        {
            InitializeComponent();

            button18.Hide();
            button19.Hide();
            button20.Hide();
            comment.Hide();
            saveButton.Hide();

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Learner.learnerFName, Learner.learnerLName, Learner.absentDays, LearnerReport.Term, ClassGrade.gradeLevel, Staff.StaffLName " +
                    "FROM LearnerReport " +
                    "inner join Learner on LearnerReport.Learner_IDNo = Learner.Learner_IDNo inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID " +
                    "inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID inner join Staff on LearnerReport.Staff_WorkNO = Staff.Staff_WorkNO " +
                    "WHERE LearnerReport.Learner_IDNo = 0003059827083 OR LearnerReport.Class_ID = 120"))
                {
                    DateTime dt = DateTime.Now;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();


                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {

                        sdr.Read();
                        name.Text = sdr["learnerFName"].ToString(); name.ReadOnly = true;
                        surname.Text = sdr["learnerLName"].ToString(); surname.ReadOnly = true;
                        daysAbsent.Text = sdr["absentDays"].ToString(); daysAbsent.ReadOnly = true;
                        term.Text = "Term: " + sdr["Term"].ToString(); term.ReadOnly = true;
                        date.Text = dt.ToString(); date.ReadOnly = true;
                        grade.Text = sdr["gradeLevel"].ToString(); grade.ReadOnly = true;
                        teacherName.Text = sdr["StaffLName"].ToString(); teacherName.ReadOnly = true;
                    }
                    con.Close();
                }
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 7 SubjectName, finalMark FROM LearnerReport inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID  WHERE Learner_IDNo = 0003059827083", con);
                    DataTable data = new DataTable();
                    adapter.Fill(data);


                    dataGridView1.DataSource = data;
                    dataGridView1.ReadOnly = true;

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button18_Click(object sender, EventArgs e) //Next
        {
            if (e.Equals(1))
            {
                button15_Click_1(sender, e);
            }
            else
                if (e.Equals(2))
            {
                button16_Click(sender, e);
            }


        }

        private void displayComment()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 2 LearnerFName, Comment FROM LearnerReport inner join Learner on LearnerReport.LearnerIDNo = Learner.LearnerIDNo", con);
                    DataTable data = new DataTable();
                    adapter.Fill(data);


                    //dataGridView2.DataSource = data;
                    //dataGridView2.ReadOnly = true;

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void searchNormal_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null || comboBox3.SelectedItem != null)
            {
                String grade = comboBox1.GetItemText(comboBox1.SelectedItem);
                String term = comboBox2.GetItemText(comboBox2.SelectedItem);
                String year = comboBox3.GetItemText(comboBox3.SelectedItem);

                if (grade == "Grade 8" || term == "Term 1" || year == "2022") //120
                {
                    button10_Click_1(sender, e);
                }
                else
                    if (grade == "Grade 9" || term == "Term 3" || year == "2021") //121
                {
                    button15_Click_1(sender, e);
                }
                else
                    if (grade == "Grade 10" || term == "Term 4" || year == "2020") //122
                {
                    button16_Click(sender, e);
                }

            }
        }

        private void searchStudent_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Bungaza" || textBox1.Text == "Ngcobo")
            {
                button10_Click_1(sender, e);
            }
            if (textBox1.Text == "Lisa" || textBox1.Text == "Mpofu")
            {
                button15_Click_1(sender, e);
            }
            if (textBox1.Text == "Tino" || textBox1.Text == "Kudzayi")
            {
                button16_Click(sender, e);
            }
        }

        private void commentButton_Click_1(object sender, EventArgs e)
        {
            comment.Show();
            saveButton.Show();
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            var viewR = new Form2();
            viewR.Close();
            var hideF1 = new Form1();
            hideF1.Show();
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (comment != null && comment.Text.Length > 0 && !(comment.Text.Length > 50))
            {

                MessageBox.Show("Comment Saved");
                comment.ReadOnly = true;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO LearnerReport ([Comment]) Values ('" + comment.Text + "')", con))
                    {
                        //displayComment();
                    }

                }
            }
            else
                MessageBox.Show("Wrong Comment Format");
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            button18.Show();
            button19.Show();
            button20.Show();

            button10.Hide();
            button15.Hide();
            button16.Hide();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Learner.learnerFName, Learner.learnerLName, Learner.absentDays, LearnerReport.Term, ClassGrade.gradeLevel, Staff.StaffLName " +
                    "FROM LearnerReport " +
                    "inner join Learner on LearnerReport.Learner_IDNo = Learner.Learner_IDNo inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID " +
                    "inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID inner join Staff on LearnerReport.Staff_WorkNO = Staff.Staff_WorkNO " +
                    "WHERE LearnerReport.Learner_IDNo = 0003059827083 OR LearnerReport.Class_ID = 120"))
                {
                    DateTime dt = DateTime.Now;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();


                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {

                        sdr.Read();
                        name.Text = sdr["learnerFName"].ToString();
                        surname.Text = sdr["learnerLName"].ToString();
                        daysAbsent.Text = sdr["absentDays"].ToString();
                        term.Text = "Term: " + sdr["Term"].ToString();
                        date.Text = dt.ToString();
                        grade.Text = sdr["gradeLevel"].ToString();
                        teacherName.Text = sdr["StaffLName"].ToString();
                    }
                    con.Close();
                }
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 7 SubjectName, finalMark FROM LearnerReport inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID  WHERE Learner_IDNo = 0003059827083", con);
                    DataTable data = new DataTable();
                    adapter.Fill(data);



                    dataGridView1.DataSource = data;





                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button15_Click_1(object sender, EventArgs e) //R3
        {
           
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Learner.learnerFName, Learner.learnerLName, Learner.absentDays, LearnerReport.Term, ClassGrade.gradeLevel, Staff.StaffLName " +
                        "FROM LearnerReport " +
                        "inner join Learner on LearnerReport.Learner_IDNo = Learner.Learner_IDNo inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID " +
                        "inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID inner join Staff on LearnerReport.Staff_WorkNO = Staff.Staff_WorkNO " +
                        "WHERE LearnerReport.Learner_IDNo = 0712238934031 OR LearnerReport.Class_ID = 121"))
                    {
                        DateTime dt = DateTime.Now;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            sdr.Read();
                            name.Text = sdr["learnerFName"].ToString();
                            surname.Text = sdr["learnerLName"].ToString();
                            daysAbsent.Text = sdr["absentDays"].ToString();
                            term.Text = "Term: " + sdr["Term"].ToString();
                            date.Text = dt.ToString();
                            grade.Text = sdr["gradeLevel"].ToString();
                            teacherName.Text = sdr["StaffLName"].ToString();
                        }
                        con.Close();
                    }
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 7 SubjectName, finalMark FROM LearnerReport inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID  WHERE Learner_IDNo = 0712238934031", con);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        dataGridView1.DataSource = data;
                        dataGridView1.AutoGenerateColumns = false;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        private void button16_Click(object sender, EventArgs e)
        {
           
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Learner.learnerFName, Learner.learnerLName, Learner.absentDays, LearnerReport.Term, ClassGrade.gradeLevel, Staff.StaffLName " +
                        "FROM LearnerReport " +
                        "inner join Learner on LearnerReport.Learner_IDNo = Learner.Learner_IDNo inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID " +
                        "inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID inner join Staff on LearnerReport.Staff_WorkNO = Staff.Staff_WorkNO " +
                        "WHERE LearnerReport.Learner_IDNo = 0305061406083 OR LearnerReport.Class_ID = 122"))
                    {
                        DateTime dt = DateTime.Now;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            sdr.Read();
                            name.Text = sdr["learnerFName"].ToString();
                            surname.Text = sdr["learnerLName"].ToString();
                            daysAbsent.Text = sdr["absentDays"].ToString();
                            term.Text = "Term: " + sdr["Term"].ToString();
                            date.Text = dt.ToString();
                            grade.Text = sdr["gradeLevel"].ToString();
                            teacherName.Text = sdr["StaffLName"].ToString();
                        }
                        con.Close();
                    }
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 7 SubjectName, FinalMark FROM LearnerReport inner join SubjectTable on LearnerReport.Subject_ID = SubjectTable.Subject_ID  WHERE Learner_IDNo = 0305061406083", con);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        dataGridView1.DataSource = data;
                        dataGridView1.AutoGenerateColumns = false;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
