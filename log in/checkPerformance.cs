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

namespace log_in
{
    public partial class checkPerformance : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename = C:\Users\thany\Music\log in\log in\Database1.mdf;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= C:\Users\thany\Music\log in\log in\SchoolManSyst.mdf;Integrated Security=True");
        public checkPerformance()
        {
            InitializeComponent();
            checkSearch.Hide();
            checkTxt.Hide();
            checkBtn.Hide();

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string performance = cbPerformance.GetItemText(cbPerformance.SelectedItem);
            if (performance == "Individual")
            {
                checkSearch.Show();
                checkTxt.Show();
                checkBtn.Show();
            }
            else
            {
                checkSearch.Hide();
                checkTxt.Hide();
                checkBtn.Hide();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkShow_Click(object sender, EventArgs e)
        {
            con.Open();
            string grade = cbGrade.GetItemText(cbGrade.SelectedItem);
            if (grade == "10")
            {
                string performance = cbPerformance.GetItemText(cbPerformance.SelectedItem);
                if (performance == "Individual")
                {
                    string surname = checkTxt.Text;
                    SqlCommand getStudentID = new SqlCommand("select Learner_IDNo from Learner where learnerLName = '" + surname + "'", con);
                    string studentID = getStudentID.ExecuteScalar().ToString();
                    int id = int.Parse(studentID);
                    SqlCommand getMAT = new SqlCommand("select Mark from AssessmentDetails where Learner_IDNo = '" + id + "' and Subject_ID = 'MAT'", con);
                    SqlCommand getENG = new SqlCommand("select Mark from AssessmentDetails where Learner_IDNo = '" + id + "' and Subject_ID = 'ENG'", con);
                    SqlCommand getLO = new SqlCommand("select Mark from AssessmentDetails where Learner_IDNo = '" + id + "' and Subject_ID = 'LO'", con);
                    SqlCommand getLF = new SqlCommand("select Mark from AssessmentDetails where Learner_IDNo = '" + id + "' and Subject_ID = 'LF'", con);
                    SqlCommand getPHY = new SqlCommand("select Mark from AssessmentDetails where Learner_IDNo = '" + id + "' and Subject_ID = 'PHY'", con);
                    string markMAT = getMAT.ExecuteScalar().ToString();
                    string markENG = getENG.ExecuteScalar().ToString();
                    string markLO = getLO.ExecuteScalar().ToString();
                    string markLF = getLF.ExecuteScalar().ToString();
                    string markPHY = getPHY.ExecuteScalar().ToString();
                    this.chart1.Series["Series1"].Points.AddXY("Mathematics", int.Parse(markMAT));
                    this.chart1.Series["Series1"].Points.AddXY("English", int.Parse(markENG));
                    this.chart1.Series["Series1"].Points.AddXY("Life Orientation", int.Parse(markLO));
                    this.chart1.Series["Series1"].Points.AddXY("Life Science", int.Parse(markLF));
                    this.chart1.Series["Series1"].Points.AddXY("Physical Science", int.Parse(markPHY));

                }
                else
                {

                    string getMark = "select* from AssessmentDetails";
                    SqlDataAdapter adapter = new SqlDataAdapter(getMark, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    List<string> subject = new List<string>();
                    List<int> mark = new List<int>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        subject.Add(Convert.ToString(row.Field<string>("Subject_ID")));
                        mark.Add(row.Field<int>("Mark"));
                    }
                    int[] marks = mark.ToArray();
                    int count = marks.Length / 2;
                    int[] learner1 = new int[count];
                    for (int i = 0; i < count; i++)
                    {
                        learner1[i] = marks[i];
                    }
                    int[] learner2 = new int[count];
                    int j = 0;
                    for (int i = count; i < marks.Length; i++)
                    {
                        learner2[j] = marks[i];
                        j++;
                    }
                    int MAT = (learner1[0] + learner2[0]) / 2;
                    int LO = (learner1[1] + learner2[1]) / 2;
                    int PHY = (learner1[2] + learner2[2]) / 2;
                    int LF = (learner1[3] + learner2[3]) / 2;
                    int ENG = (learner1[4] + learner2[4]) / 2;
                    this.chart1.Series["Series1"].Points.AddXY("Mathematics", MAT);
                    this.chart1.Series["Series1"].Points.AddXY("English", ENG);
                    this.chart1.Series["Series1"].Points.AddXY("Life Orientation", LO);
                    this.chart1.Series["Series1"].Points.AddXY("Life Science", LF);
                    this.chart1.Series["Series1"].Points.AddXY("Physical Science", PHY);

                }



            }
            else
                MessageBox.Show("Grade " + grade + " does not have data yet try grade 10");

            con.Close();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            string surname = checkTxt.Text;
            SqlCommand getStudentID = new SqlCommand("select Learner_IDNo from Learner where learnerLName = '" + surname + "'", con);
            string studentID = getStudentID.ExecuteScalar().ToString();
            if (studentID != null)
            {
                SqlCommand getName = new SqlCommand("select learnerFName from Learner where Learner_IDNo = '" + int.Parse(studentID) + "'", con);
                string name = getName.ExecuteScalar().ToString();
                MessageBox.Show(surname + " " + name + " " + "found");
            }
            else
                MessageBox.Show("Learner was not found");
    
            con.Close();
        }
    }
}
